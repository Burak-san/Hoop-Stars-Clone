using System;
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
    }
}