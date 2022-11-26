using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Controllers.Enemy
{
    public class EnemyMovementController : MonoBehaviour
    {
        private Rigidbody _enemyRigidbody;

        private void Awake()
        {
            Init();
        }
        #region EventSubscriptions

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onChangeGameState += OnChangeGameState;
        }

        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.onChangeGameState -= OnChangeGameState;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        #endregion
        
        private void Init()
        {
            _enemyRigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            EnemyMove();
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
    }
}