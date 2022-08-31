using UnityEngine;
using UnityEngine.Events;
using System.Text.RegularExpressions;

namespace Paintastic.Utility
{
    public class Timer : MonoBehaviour
    {
        public UnityAction<int> OnTimerEnd;
        [SerializeField] private float _duration;
        private bool _isRunning;
        private float _time;
        [SerializeField] private bool _loop = false;

        private void Update()
        {
            if (_isRunning)
            {
                _time += Time.deltaTime;
                if (_time >= _duration)
                {   
                    EndTimer();
                    if (_loop) StartTimer();
                }
            }
        }

        public void StartTimer()
        {
            _time = 0f;
            _isRunning = true;
        }

        public void EndTimer()
        {
            _isRunning = false;

            

            if(gameObject.tag == "Player Timer")
            {

                string gameObjectName = gameObject.name;
                string playerName = Regex.Replace(gameObjectName, "[^0-9]", "");
                int playerNumber = int.Parse(playerName);
                OnTimerEnd?.Invoke(playerNumber-1);
            }

            else
            {
                OnTimerEnd?.Invoke(0);
            }

        }

        public float GetDuration()
        {
            return _duration;
        }

        public float GetRemainingTime()
        {
            if (!_isRunning)
            {
                return 0f;
            }
            return _duration - _time;
        }

        public bool GetIsRunning()
        {
            return _isRunning;
        }
    }
}