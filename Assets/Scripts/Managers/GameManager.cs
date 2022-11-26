using Enums;
using Signals;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private void Awake()
        {
            Application.targetFrameRate = 60;
            CoreGameSignals.Instance.onChangeGameState?.Invoke(GameStates.Stop);
        }
        
        #region EventSubscriptions

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onReset += OnReset;

            UISignals.Instance.onFail += OnReset;
            UISignals.Instance.onWin += OnReset;
        }

        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onReset -= OnReset;
            
            UISignals.Instance.onFail -= OnReset;
            UISignals.Instance.onWin -= OnReset;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        #endregion
        
        private void OnPlay()
        {
            CoreGameSignals.Instance.onChangeGameState?.Invoke(GameStates.Playing);
        }

        private void OnReset()
        {
            CoreGameSignals.Instance.onChangeGameState?.Invoke(GameStates.Stop);
        }
    }
}