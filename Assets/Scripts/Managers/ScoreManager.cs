using System;
using System.Collections;
using System.Threading.Tasks;
using Enums;
using Signals;
using Unity.VisualScripting;
using UnityEngine;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        private int _playerScore = 0;
        private int _enemyScore = 0;
        private float _time = 60;
        private GameStates _gameStates;

        private void Awake()
        {
            _gameStates = GameStates.Stop;
        }

        #region EventSubscriptions

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onReset += OnReset;
            CoreGameSignals.Instance.onGainPlayerScore += OnGainPlayerScore;
            CoreGameSignals.Instance.onGainEnemyScore += OnGainEnemyScore;
            CoreGameSignals.Instance.onChangeGameState += OnChangeGameState;
        }

        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.onReset -= OnReset;
            CoreGameSignals.Instance.onGainPlayerScore -= OnGainPlayerScore;
            CoreGameSignals.Instance.onGainEnemyScore -= OnGainEnemyScore;
            CoreGameSignals.Instance.onChangeGameState -= OnChangeGameState;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        #endregion

        private void Update()
        {
            if (_gameStates == GameStates.Playing)
            {
                StartCoroutine(Count());
            }

            if (_playerScore >= 3)
            {
                UISignals.Instance.onWin?.Invoke();
            }
            if (_enemyScore >= 3)
            {
                UISignals.Instance.onFail?.Invoke();
            }
        }

        private IEnumerator Count()
        {
            if (_time > 0)
            {
                yield return new WaitForSecondsRealtime(1f);
                _time -= Time.deltaTime;
                UISignals.Instance.onSetTimeValue?.Invoke(_time);
                
            }
            else if (_time <= 0)
            {
                UISignals.Instance.onFail?.Invoke();
            }
        }
        
        private void OnGainPlayerScore()
        {
            _playerScore += 1;
            UISignals.Instance.onSetPlayerScoreText?.Invoke(_playerScore);
        }
        
        private void OnGainEnemyScore()
        {
            _enemyScore += 1;
            UISignals.Instance.onSetEnemyScoreText?.Invoke(_enemyScore);
        }
        
        private void OnChangeGameState(GameStates state)
        {
            _gameStates = state;
        }
        

        private void OnReset()
        {
            _time = 60;
            _playerScore = 0;
            _enemyScore = 0;
        }

        
    }
}