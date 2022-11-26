using System;
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
            //_rigidbody.AddForce(new Vector3(-2.5f,5,0),ForceMode.Impulse);
            _rigidbody.velocity = new Vector3(-2.5f, 5, 0);
            CheckRigidbodyKinematic();
        }
        
        private void RightButtonMove()
        {
            //_rigidbody.AddForce(new Vector3(2.5f,5,0),ForceMode.Impulse);
            _rigidbody.velocity = new Vector3(2.5f, 5, 0);
            CheckRigidbodyKinematic();
        }

        private void CheckRigidbodyKinematic()
        {
            if (_rigidbody.isKinematic == true)
            {
                _rigidbody.isKinematic = false;
            }
        }
    }
}