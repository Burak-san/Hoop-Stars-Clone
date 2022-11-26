﻿using System;
using Controllers.Player;
using Signals;
using UnityEngine;

namespace Managers
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField]private PlayerMovementController _playerMovementController;


        #region Event Subscriptions

        private void OnEnable()
        {
            SubcribedEvents();
        }

        private void SubcribedEvents()
        {
            InputSignals.Instance.onInputTaken += _playerMovementController.Move;
        }
        
        private void UnSubcribedEvents()
        {
            InputSignals.Instance.onInputTaken -= _playerMovementController.Move;
        }

        private void OnDisable()
        {
            UnSubcribedEvents();
        }

        #endregion
    }
}