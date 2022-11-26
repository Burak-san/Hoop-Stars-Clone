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
            UISignals.Instance.onSetPlayerScoreText += OnSetPlayerScoreText;
            UISignals.Instance.onSetEnemyScoreText += OnSetEnemyScoreText;
            UISignals.Instance.onSetTimeValue += OnSetTimeValue;
            UISignals.Instance.onFail += OnFail;
            UISignals.Instance.onWin += OnWin;
            
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onReset += OnReset;
        }

        private void UnSubscribeEvents()
        {
            UISignals.Instance.onOpenPanel -= OnOpenPanel;
            UISignals.Instance.onClosePanel -= OnClosePanel;
            UISignals.Instance.onSetPlayerScoreText -= OnSetPlayerScoreText;
            UISignals.Instance.onSetEnemyScoreText -= OnSetEnemyScoreText;
            UISignals.Instance.onSetTimeValue -= OnSetTimeValue;
            UISignals.Instance.onFail -= OnFail;
            UISignals.Instance.onWin -= OnWin;
            
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onReset -= OnReset;
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

        private void OnSetPlayerScoreText(int value)
        {
            playerScoreText.text = value.ToString();
        }
        
        private void OnSetEnemyScoreText(int value)
        {
            enemyScoreText.text = value.ToString();
        }

        private void OnSetTimeValue(float value)
        {
            int tempValue = (int)value;
            timeText.text = tempValue.ToString();
        }

        private void OnFail()
        {
            UISignals.Instance.onClosePanel?.Invoke(UIPanels.GamePanel);
            UISignals.Instance.onOpenPanel?.Invoke(UIPanels.FailPanel);
        }

        private void OnWin()
        {
            UISignals.Instance.onClosePanel?.Invoke(UIPanels.GamePanel);
            UISignals.Instance.onOpenPanel?.Invoke(UIPanels.WinPanel);
        }

        private void OnPlay()
        {
            UISignals.Instance.onClosePanel?.Invoke(UIPanels.StartPanel);
            UISignals.Instance.onOpenPanel?.Invoke(UIPanels.GamePanel);
        }

        private void ResetText()
        {
            playerScoreText.text = "0";
            enemyScoreText.text = "0";
            timeText.text = "60";
        }

        private void OnReset()
        {
            UISignals.Instance.onOpenPanel?.Invoke(UIPanels.StartPanel);
            UISignals.Instance.onClosePanel?.Invoke(UIPanels.GamePanel);
            UISignals.Instance.onClosePanel?.Invoke(UIPanels.FailPanel);
            UISignals.Instance.onClosePanel?.Invoke(UIPanels.WinPanel);
            ResetText();
        }
    }
}