using System;
using Signals;
using UnityEngine;

namespace Controllers.Player
{
    public class PlayerPhysicsController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Target"))
            {
                CoreGameSignals.Instance.onGainPlayerScore?.Invoke();
            }
        }
    }
}