using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using Enums;
using Signals;
using Unity.VisualScripting;
using UnityEngine;

namespace Controllers.Enemy
{
    public class EnemyMovementController : MonoBehaviour
    {
        private Rigidbody _enemyRigidbody;
        private GameStates _gameStates;

        private void Awake()
        {
            Init();
        }
        
        private void Init()
        {
            _enemyRigidbody = GetComponent<Rigidbody>();
            _gameStates = GameStates.Stop;
        }
        
        #region EventSubscriptions

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onChangeGameState += OnChangeGameState;
            CoreGameSignals.Instance.onReset += TransformReset;
        }

        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.onChangeGameState -= OnChangeGameState;
            CoreGameSignals.Instance.onReset -= TransformReset;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        #endregion
        
        private void FixedUpdate()
        {
            if (_gameStates == GameStates.Playing)
            {
                EnemyMove();
            }
        }
        
        private void OnChangeGameState(GameStates state)
        {
            _gameStates = state;
            if (_gameStates == GameStates.Playing)
            {
                _enemyRigidbody.isKinematic = false;
            }
        }

        private void EnemyMove()
        {
            if (_enemyRigidbody.position.x > 0 && _enemyRigidbody.position.y < 10)
            {
                EnemyLeftMove();
            }
            else if (_enemyRigidbody.position.x < 0 && _enemyRigidbody.position.y < 10)
            {
                EnemyRightMove();
            }
        }

        private void EnemyLeftMove()
        {
            _enemyRigidbody.velocity = new Vector3(-2.5f,12,0);
        }

        private void EnemyRightMove()
        {
            _enemyRigidbody.velocity = new Vector3(2.5f,12,0);
        }
        
        private void TransformReset()
        {
            _enemyRigidbody.isKinematic = true;
            transform.position = new Vector3(3, 6, 0);
            transform.DORotate(new Vector3(0,0,0), 0.1f);
        }
    }
}