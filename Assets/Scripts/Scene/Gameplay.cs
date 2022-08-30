using Paintastic.Utility;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Paintastic.Scene.Gameplay
{
    public class Gameplay : MonoBehaviour
    {
        public static UnityAction OnGameplay;
        public static UnityAction<int, Color> OnGameOver;

        [SerializeField] private Timer _gameTimer;
        [SerializeField] private Timer _playerOneTimer;
        [SerializeField] private Timer _playerTwoTimer;
        [SerializeField] private TMP_Text _remainingTime;

        private void Start()
        {
            _gameTimer.OnTimerEnd += GameOver;
            StartGame(); // placeholder, use Tutorial.OnGameplayStart when available
        }

        private void Update()
        {
            TimeSpan timeSpan;
            if (_gameTimer.GetIsRunning())
            {
                timeSpan = TimeSpan.FromSeconds(_gameTimer.GetRemainingTime() + 1);
            }
            else
            {
                timeSpan = TimeSpan.FromSeconds(0);
            }
            _remainingTime.text = "Remaining Time: " + timeSpan.ToString(@"m\:ss");
        }

        private void StartGame()
        {
            _gameTimer.StartTimer();
            OnGameplay?.Invoke();
        }

        private void GameOver()
        {
            // TODO: change winner index from score and color
            OnGameOver?.Invoke(1, Color.red);
        }

        private void PickupItem(string itemName, int player)
        {
            if (itemName == "CollectPoint")
            {
                CollectPoint(player);
            }
        }

        private void SpawnCollectPoint()
        {
            // TODO
        }

        private void SpawnBomb()
        {
            // TODO
        }

        private void CollectPoint(int player)
        {
            // TODO
        }
    }
}
