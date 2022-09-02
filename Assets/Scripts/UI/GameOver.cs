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
        [SerializeField] private GameObject _topiParent;
        [SerializeField] private GameObject _topiChild;
        [SerializeField] private GameObject _gameOverDance;

        private void OnEnable()
        {
            Gameplay.OnGameOver += SetWinner;
            _backToMenu.onClick.AddListener(BackToMenu);
        }

        private void OnDisable()
        {
            Gameplay.OnGameOver -= SetWinner;
            _backToMenu.onClick.RemoveListener(BackToMenu);
        }

        private void BackToMenu()
        {
            SceneManager.LoadScene("Main Menu");
        }

        private void SetWinner(int playerIndex, Color playerColor, int numberOfPlayer, Material winMat)
        {
            _gameOverDance.SetActive(true);
            _winnerColor.color = playerColor;
            if (playerIndex == -1)
                _winnerText.text = "Draw!";
            else
                _winnerText.text = $"Player {playerIndex + 1} Win!";
            _gameOver.SetActive(true);
            SetTopiColor(winMat);
        }

        private void SetTopiColor(Material winMat)
        {
            MeshRenderer childtopi = _topiChild.GetComponent<MeshRenderer>();
            MeshRenderer parrenttopi = _topiParent.GetComponent<MeshRenderer>();

            childtopi.material = winMat;
            parrenttopi.material = winMat;
        }
    }
}