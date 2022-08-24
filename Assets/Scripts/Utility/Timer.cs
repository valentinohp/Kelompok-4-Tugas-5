using UnityEngine;
using UnityEngine.Events;

namespace Paintastic.Utility.Timer
{
    public class Timer : MonoBehaviour
    {
        public UnityAction OnTimerEnd;
        [SerializeField] private float duration;
        private bool isRunning;
        private float time;

        private void Update()
        {
            if (isRunning)
            {
                time += Time.deltaTime;
                if (time >= duration)
                {   
                    EndTimer();
                }
            }
        }

        public void StartTimer()
        {
            time = 0f;
            isRunning = true;
            Debug.Log(gameObject.name + " started");
        }

        public void EndTimer()
        {
            isRunning = false;
            OnTimerEnd?.Invoke();
        }
    }
}