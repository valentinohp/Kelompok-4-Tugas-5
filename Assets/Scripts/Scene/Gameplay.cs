using Paintastic.Utility;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Events;

namespace Paintastic.Scene.Gameplay
{
    public class Gameplay : MonoBehaviour
    {
        public static UnityAction OnGameplay;

        [SerializeField] private Timer _gameTimer;
        [SerializeField] private Timer _playerOneTimer;
        [SerializeField] private Timer _playerTwoTimer;
        [SerializeField] private TMP_Text _remainingTime;

        private void Start()
        {
            OnGameplay();
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
        }

        private void GameOver()
        {
            // TODO
            Debug.Log("game over");
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
