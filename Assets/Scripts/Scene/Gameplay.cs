using Paintastic.Utility.Timer;
using UnityEngine;
using UnityEngine.Events;

namespace Paintastic.Scene.Gameplay
{
    public class Gameplay : MonoBehaviour
    {
        [SerializeField] private Timer _gameTimer;
        [SerializeField] private Timer _playerOneTimer;
        [SerializeField] private Timer _playerTwoTimer;

        private void Start()
        {
            _gameTimer.OnTimerEnd += GameOver;
            StartGame(); // placeholder, use Tutorial.OnGameplayStart when available
        }

        private void StartGame()
        {
            _gameTimer.StartTimer();
        }

        private void GameOver()
        {
            Debug.Log("game over");
        }
    }
}
