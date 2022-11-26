using System;
using Controllers.UI;
using Enums;
using Signals;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI playerScoreText;
        [SerializeField] private TextMeshProUGUI enemyScoreText;
        [SerializeField] private TextMeshProUGUI timeText;
        [SerializeField] private UIPanelController uıPanelController;

        #region EventSubscriptions

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            UISignals.Instance.onOpenPanel += OnOpenPanel;
            UISignals.Instance.onClosePanel += OnClosePanel;
            UISignals.Instance.onSetScoreText += OnSetScoreText;
            UISignals.Instance.onSetTimeValue += OnSetTimeValue;
            
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onReset += OnReset;
            CoreGameSignals.Instance.onChangeGameState += OnChangeGameState;
        }

        private void UnSubscribeEvents()
        {
            UISignals.Instance.onOpenPanel -= OnOpenPanel;
            UISignals.Instance.onClosePanel -= OnClosePanel;
            UISignals.Instance.onSetScoreText -= OnSetScoreText;
            UISignals.Instance.onSetTimeValue -= OnSetTimeValue;
            
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onReset -= OnReset;
            CoreGameSignals.Instance.onChangeGameState -= OnChangeGameState;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        #endregion
        
        public void PlayButton()
        {
            CoreGameSignals.Instance.onPlay?.Invoke();
        }

        public void RestartButton()
        {
            CoreGameSignals.Instance.onReset?.Invoke();
        }
        
        
        
        private void OnOpenPanel(UIPanels panel)
        {
            uıPanelController.OpenPanel(panel);
        }

        private void OnClosePanel(UIPanels panel)
        {
            uıPanelController.ClosePanel(panel);
        }

        private void OnSetScoreText(int value)
        {
            throw new NotImplementedException();
        }

        private void OnSetTimeValue(int value)
        {
            throw new NotImplementedException();
        }

        private void OnPlay()
        {
            UISignals.Instance.onClosePanel?.Invoke(UIPanels.StartPanel);
            UISignals.Instance.onOpenPanel?.Invoke(UIPanels.GamePanel);
        }

        private void OnReset()
        {
            UISignals.Instance.onOpenPanel?.Invoke(UIPanels.StartPanel);
            UISignals.Instance.onClosePanel?.Invoke(UIPanels.GamePanel);
            UISignals.Instance.onClosePanel?.Invoke(UIPanels.FailPanel);
            UISignals.Instance.onClosePanel?.Invoke(UIPanels.WinPanel);
        }
        
        
    }
}