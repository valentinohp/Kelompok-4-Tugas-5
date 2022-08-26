using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Paintastic.UI.ColorSelect
{
    public class ColorSelect : MonoBehaviour
    {
        public static UnityAction<Color, Color> OnPlayerColorChanged;
        [SerializeField] private Button _playerOneNext;
        [SerializeField] private Button _playerOnePrev;
        [SerializeField] private Image _playerOneImage;
        [SerializeField] private Button _playerTwoNext;
        [SerializeField] private Button _playerTwoPrev;
        [SerializeField] private Image _playerTwoImage;
        [SerializeField] private Button _backToMenu;
        [SerializeField] private Button _startGame;
        private int _playerOneColor = 4;
        private int _playerTwoColor = 1;
        private Color[] _colors;
           
        private void Start()
        {
            _playerOneNext.onClick.AddListener(delegate { OnPlayerOneCycle(1); });
            _playerOnePrev.onClick.AddListener(delegate { OnPlayerOneCycle(-1); });
            _playerTwoNext.onClick.AddListener(delegate { OnPlayerTwoCycle(1); });
            _playerTwoPrev.onClick.AddListener(delegate { OnPlayerTwoCycle(-1); });
            _backToMenu.onClick.AddListener(OnHideColorSelect);
            _startGame.onClick.AddListener(OnStartGame);

            /*_colors = new Dictionary<string, Color>()
            {
                { "black", ((Material) Resources.Load("@Resources/Materials/Black")).color },
                { "White", ((Material) Resources.Load("@Resources/Materials/White")).color },
                { "Green", ((Material) Resources.Load("Resources/Materials/Green")).color },
                { "Red", ((Material) Resources.Load("@Resources/Materials/Red")).color },
                { "Yellow",((Material) Resources.Load("@Resources/Materials/Yellow")).color },
                { "Blue", ((Material) Resources.Load("@Resources/Materials/Blue")).color }
            };*/

            _colors = new Color[]
            {
                Color.black,
                Color.white,
                Color.green,
                Color.red,
                Color.blue
            };

            InitSetPlayerColor();
            
        }

        private void InitSetPlayerColor()
        {
            string p1color = PlayerPrefs.GetString("playerOneColor");
            string p2color = PlayerPrefs.GetString("playerTwoColor");

            _playerOneImage.color = _colors[_playerOneColor];
            _playerTwoImage.color = _colors[_playerTwoColor];
        }

        private void OnPlayerOneCycle(int num)
        {
            _playerOneColor += num;

            if (_playerOneColor == _colors.Length)
            {
                _playerOneColor = 0;
            }

            if (_playerOneColor == -1)
            {
                _playerOneColor = _colors.Length - 1;
            }

            if (_playerOneColor == _playerTwoColor)
            {
                OnPlayerOneCycle(num);
            }

            _playerOneImage.color = _colors[_playerOneColor];
        }

        private void OnPlayerTwoCycle(int num)
        {
            _playerTwoColor += num;

            if (_playerTwoColor == _colors.Length)
            {
                _playerTwoColor = 0;
            }

            if (_playerTwoColor == -1)
            {
                _playerTwoColor = _colors.Length - 1;
            }

            if (_playerOneColor == _playerTwoColor)
            {
                OnPlayerTwoCycle(num);
            }

            _playerTwoImage.color = _colors[_playerTwoColor];
        }

        private void OnHideColorSelect()
        {
            gameObject.SetActive(false);
        }

        private void OnStartGame()
        {
            OnPlayerColorChanged?.Invoke(_playerOneImage.color, _playerTwoImage.color);
            SceneManager.LoadScene("Gameplay");
        }
    }
}
