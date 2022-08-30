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
        public static UnityAction<int, int> OnCycle;

        [SerializeField] private Button _playerNext;
        [SerializeField] private Button _playerPrev;
        [SerializeField] private Image _playerImage;
        [SerializeField] private int _indexPlayer;

        public int _playerColor;

        private void OnEnable()
        {
            ColorSelectManager.OnHideColorSelectEvent += OnHideColorSelect;
            ColorSelectManager.OnApplyFirstColor += SetFirstColor;
        }

        private void OnDisable()
        {
            ColorSelectManager.OnHideColorSelectEvent -= OnHideColorSelect;
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
            _playerImage.color = ColorSelectManager.Colors[_playerColor];
        }

        private void OnPlayerCycle(int num)
        {
            _playerColor += num;

            if (_playerColor == ColorSelectManager.Colors.Length)
            {
                _playerColor = 0;
            }

            if (_playerColor == -1)
            {
                _playerColor = ColorSelectManager.Colors.Length - 1;
            }

            for (int i = 0; i < ColorSelectManager.PlayerColors.Length; i++)
            {
                if (_indexPlayer == i)
                {
                    continue;
                }

                if (_playerColor == ColorSelectManager.PlayerColors[i])
                {
                    OnPlayerCycle(num);
                }
            }

            OnCycle?.Invoke(_indexPlayer, _playerColor);
            _playerImage.color = ColorSelectManager.Colors[_playerColor];
        }

        private void OnHideColorSelect()
        {
            gameObject.SetActive(false);
        }
    }
}
