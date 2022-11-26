using UnityEngine;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        private int _playerScore;
        private int _enemyScore;

        private float _time;

        private void Update()
        {
            Count();
            
        }

        private void Count()
        {
            if (_time > 0)
            {
                _time -= Time.deltaTime;
            }
            else if (_time <= 0)
            {
                //game over
            }
            
            
        }
    }
}