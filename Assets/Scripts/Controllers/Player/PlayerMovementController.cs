using System;
using DG.Tweening;
using Enums;
using UnityEngine;

namespace Controllers.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Move(PlayerState playerState)
        {
            _rigidbody.isKinematic = false;
            
            if (playerState == PlayerState.Left)
            {
                LeftButtonMove();
            }
            else if (playerState == PlayerState.Right)
            {
                RightButtonMove();
            }
        }

        private void LeftButtonMove()
        {
            _rigidbody.velocity = new Vector3(-2.5f, 10, 0);
        }
        
        private void RightButtonMove()
        {
            _rigidbody.velocity = new Vector3(2.5f, 10, 0);
        }

        public void TransformReset()
        {
            _rigidbody.isKinematic = true;
            transform.position = new Vector3(-3, 6, 0);
            transform.DORotate(new Vector3(0,0,0), 0.1f);
        }
    }
}