using Enums;
using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class UISignals : MonoSingleton<UISignals>
    {
        public UnityAction<UIPanels> onOpenPanel = delegate { };
        public UnityAction<UIPanels> onClosePanel = delegate { };
        public UnityAction onFail = delegate { };
        public UnityAction onWin = delegate {  };
        public UnityAction<float> onSetTimeValue = delegate {  };
        public UnityAction<int> onSetPlayerScoreText = delegate {  };
        public UnityAction<int> onSetEnemyScoreText = delegate {  };
    }
}