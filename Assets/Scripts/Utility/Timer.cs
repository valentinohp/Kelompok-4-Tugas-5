using UnityEngine;
using UnityEngine.Events;

namespace Paintastic.Utility.Timer
{
    public class Timer : MonoBehaviour
    {
        public UnityAction OnTimerEnd;
        [SerializeField] private float _duration;
        private bool _isRunning;
        private float _time;

        private void Update()
        {
            if (_isRunning)
            {
                _time += Time.deltaTime;
                if (_time >= _duration)
                {   
                    EndTimer();
                }
            }
        }

        public void StartTimer()
        {
            _time = 0f;
            _isRunning = true;
            Debug.Log(gameObject.name + " started");
        }

        public void EndTimer()
        {
            _isRunning = false;
            OnTimerEnd?.Invoke();
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
    }
}