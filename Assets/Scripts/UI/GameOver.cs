using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Paintastic.Scene.Gameplay;

namespace Paintastic.UI
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOver;
        [SerializeField] private Button _backToMenu;
        [SerializeField] private Image _winnerColor;
        [SerializeField] private TMP_Text _winnerText;

        private void Start()
        {
            Gameplay.OnGameOver += SetWinner; 
            _backToMenu.onClick.AddListener(BackToMenu);
        }

        private void BackToMenu()
        {
            SceneManager.LoadScene("Main Menu");
        }

        private void SetWinner(int playerIndex, string colorindex)
        {
            _winnerColor.color = colorindex.ToColor();
            _winnerText.text = $"Player {playerIndex+1} Win!";
            _gameOver.SetActive(true);
        }
    }
}