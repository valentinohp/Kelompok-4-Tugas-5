using Paintastic.Utility;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Events;
using UnityEngine.UI;
using Paintastic.Score;
using System.Collections.Generic;
using Paintastic.Player;

namespace Paintastic.Scene.Gameplay
{
    public class Gameplay : MonoBehaviour
    {
        public static UnityAction OnGameplay;
        public static UnityAction<int, Color> OnGameOver;
        public static UnityAction OnItemTimerEnd;

        [SerializeField] private Timer _gameTimer;
        [SerializeField] private TMP_Text _remainingTime;
        [SerializeField] private Timer[] _playerTimers;
        [SerializeField] private TMP_Text[] _playerScoreText;
        [SerializeField] private Slider[] _playerTimeSliders;
        [SerializeField] private Button _pauseButton;
        [SerializeField] private Button _unPauseButton;
        [SerializeField] private GameObject _pausePanel;
        private ScoreManager _scoreManager;
        private PlayerControlScript _playerControlScript;


        private void Start()
        {
            _pauseButton.onClick.AddListener(OnPause);
            _unPauseButton.onClick.AddListener(OnUnPause);
            _scoreManager = GetComponent<ScoreManager>();
            _playerControlScript = GetComponent<PlayerControlScript>();
            _gameTimer.OnTimerEnd += GameOver;
            for (int i = 0; i < _playerTimers.Length; i++)
            {
                _playerTimers[i].OnTimerEnd += DeactiveDoubleScore;
            }
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

            for (int i = 0; i < _playerScoreText.Length; i++)
            {
                _playerScoreText[i].text = _scoreManager.playersScore[i].ToString();
            }

            for (int i = 0; i < _playerTimeSliders.Length; i++)
            {
                if (_playerTimers[i].GetIsRunning())
                {
                    _playerTimeSliders[i].value = _playerTimers[i].GetRemainingTime() / _playerTimers[i].GetDuration();
                }
                else
                {
                    _playerTimeSliders[i].gameObject.SetActive(false);
                }
            }
        }

        private void StartGame()
        {
            _gameTimer.StartTimer();
            OnGameplay?.Invoke();
        }

        private void GameOver(int unused)
        {
            int winnerIndex = -1;
            int winnerScore = -1;
            Color winnerColor = Color.grey;
            List<int> playerScore = _scoreManager.playersScore;

            for (int i = 0; i < _playerTimers.Length; i++)
            {
                if (playerScore[i] > winnerScore)
                {
                    winnerIndex = i;
                    winnerScore = playerScore[i];
                }
            }

            winnerColor = _playerControlScript.playersList[winnerIndex].GetComponent<PlayerScript>().GetPlayerMaterial().color;

            for (int i = 0; i < playerScore.Count; i++)
            {
                if (i == winnerIndex)
                {
                    continue;
                }

                if (playerScore[i] == winnerScore)
                {
                    winnerIndex = -1;
                    winnerColor = Color.grey;
                    break;
                }
            }

            OnGameOver?.Invoke(winnerIndex, winnerColor);
        }

        public void PlayerTimer(int playerIndex)
        {
            _playerTimers[playerIndex].StartTimer();
            _playerTimeSliders[playerIndex].gameObject.SetActive(true);
        }

        private void DeactiveDoubleScore(int playerIndex)
        {
            _scoreManager.DeactiveDoubleScore(playerIndex);
        }

        private void OnPause()
        {
            _pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
        
        private void OnUnPause()
        {
            _pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}