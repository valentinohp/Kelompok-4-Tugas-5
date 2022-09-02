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
        public static UnityAction<int, Color, int, Material> OnGameOver;
        public static UnityAction OnItemTimerEnd;

        [SerializeField] private Timer _gameTimer;
        [SerializeField] private TMP_Text _remainingTime;
        [SerializeField] private Timer[] _playerTimers;
        [SerializeField] private TMP_Text[] _playerScoreText;
        [SerializeField] private Slider[] _playerTimeSliders;
        private ScoreManager _scoreManager;
        private PlayerControlScript _playerControlScript;

        [SerializeField] private Button _pauseButton;
        [SerializeField] private Button _unpauseButton;
        [SerializeField] private Button _playButton;
        [SerializeField] private GameObject _tutorialPanel;
        [SerializeField] private GameObject _pausePanel;
        [SerializeField] private Material _defMaterial;


        private void Start()
        {
            _scoreManager = GetComponent<ScoreManager>();
            _playerControlScript = GetComponent<PlayerControlScript>();
            _gameTimer.OnTimerEnd += GameOver;

            _pauseButton.onClick.AddListener(OnPause);
            _unpauseButton.onClick.AddListener(OnUnPause);
            _playButton.onClick.AddListener(OnPlayGame);

            for (int i = 0; i < _playerTimers.Length; i++)
            {
                _playerTimers[i].OnTimerEnd += DeactiveDoubleScore;
            }
            Time.timeScale = 0;

            
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
            Material winnerMaterial = _defMaterial;
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
            winnerMaterial = _playerControlScript.playersList[winnerIndex].GetComponent<PlayerScript>().GetPlayerMaterial();

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
                    winnerMaterial = _defMaterial;
                    break;
                }
            }

            OnGameOver?.Invoke(winnerIndex, winnerColor, _playerTimers.Length, winnerMaterial); ;
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
        private void OnPlayGame()
        {
            _tutorialPanel.SetActive(false);
            Time.timeScale = 1;
            StartGame();
        }
    }
}