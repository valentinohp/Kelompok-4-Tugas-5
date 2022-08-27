using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Paintastic.UI.ColorSelect
{
    public class ColorSelect : MonoBehaviour
    {
        public static UnityAction<int, int> OnPlayerColorChanged;

        [SerializeField] private Button _playerNext;
        [SerializeField] private Button _playerPrev;
        [SerializeField] private Image _playerImage;
        [SerializeField] private int _indexPlayer;
        [SerializeField] private ColorSelectData _colorSelectData;

        public int _playerColor = 4;
        private Color[] _colors = new Color[]
            {
                Color.black,
                Color.white,
                Color.green,
                Color.red,            
                Color.blue
            };

        private void OnEnable()
        {
            ColorSelectManager.OnHideColorSelectEvent += OnHideColorSelect;
            ColorSelectManager.OnStartGameEvent += OnStartGame;
            ColorSelectManager.OnApplyFirstColor += SetFirstColor;
        }

        private void OnDisable()
        {
            ColorSelectManager.OnHideColorSelectEvent -= OnHideColorSelect;
            ColorSelectManager.OnStartGameEvent -= OnStartGame;
            ColorSelectManager.OnApplyFirstColor -= SetFirstColor;
        }

        private void Start()
        {
            _playerNext.onClick.AddListener(delegate { OnPlayerCycle(1); });
            _playerPrev.onClick.AddListener(delegate { OnPlayerCycle(-1); });
        }

        public void SetFirstColor(int colorIndex)
        {
            _playerColor = colorIndex;
            _playerImage.color = _colors[_playerColor];
            Debug.Log("tes:"+_playerColor);
        }

        private void OnPlayerCycle(int num)
        {
            _playerColor += num;

            if (_playerColor == _colors.Length)
            {
                _playerColor = 0;
            }

            if (_playerColor == -1)
            {
                _playerColor = _colors.Length - 1;
            }

           /* for (int i = 0; i < ColorSelectManager._playerColors.Count; i++)
            {
                if (_playerColor == ColorSelectManager._playerColors[i])
                {
                    OnPlayerCycle(-1);
                }
            }*/

            _playerImage.color = _colors[_playerColor];

        }

      
        private void OnHideColorSelect()
        {
            gameObject.SetActive(false);
        }

        private void OnStartGame()
        {
            OnPlayerColorChanged?.Invoke(_indexPlayer, _playerColor);
        }
    }
}
