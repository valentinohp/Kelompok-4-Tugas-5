using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Events;
using Paintastic.Global.MatchHistory;
using TMPro;

namespace Paintastic.UI.ColorSelect
{
    public class ColorSelect : MonoBehaviour
    {
        public static UnityAction<int, int> OnPlayerColorChanged;
        public static UnityAction<int, int> OnCycle;

        [SerializeField] private Button _playerNext;
        [SerializeField] private Button _playerPrev;
        [SerializeField] private Image _playerImage;
        [SerializeField] private TMP_Text _playerLevelText;
        [SerializeField] private Slider _xpSlider;
        [SerializeField] private int _indexPlayer;
        private bool[] _unlock = new bool[6];
        public int _playerColor;
        private int _playerLevel;

        private void Start()
        {
            _playerNext.onClick.AddListener(delegate { OnPlayerCycle(1); });
            _playerPrev.onClick.AddListener(delegate { OnPlayerCycle(-1); });

            for (int i = 0; i < _unlock.Length - 2; i++)
            {
                _unlock[i] = true;
            }

            ConvertXPToLevel();

            if (_playerLevel >= 2)
                _unlock[4] = true;
            if (_playerLevel >= 4)
                _unlock[5] = true;
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

            if (!_unlock[_playerColor])
            {
                OnPlayerCycle(num);
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

        private void ConvertXPToLevel()
        {
            _playerLevel = MatchHistoryManager.instance.matchHistory.PlayerXP[_indexPlayer] / 500 + 1;

            if (_playerLevel > 50)
            {
                _playerLevelText.text = "Level MAX";
                _xpSlider.value = 1f;
            }
            else
            {
                _playerLevelText.text = "Level " + _playerLevel;
                _xpSlider.value = (MatchHistoryManager.instance.matchHistory.PlayerXP[_indexPlayer] % 500) / 500f;
            }

        }
    }
}
