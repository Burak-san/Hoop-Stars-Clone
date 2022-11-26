using Enums;
using Signals;
using UnityEngine;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        public void Left()
        {
            InputSignals.Instance.onInputTaken?.Invoke(PlayerState.Left);
        }
        
        public void Right()
        {
            InputSignals.Instance.onInputTaken?.Invoke(PlayerState.Right);
        }
    }
}