using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using Paintastic.Global.MatchHistory;

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
        private bool[] _unlock = new bool[6];
        public int _playerColor;

        private void Start()
        {
            _playerNext.onClick.AddListener(delegate { OnPlayerCycle(1); });
            _playerPrev.onClick.AddListener(delegate { OnPlayerCycle(-1); });

            for (int i = 0; i < _unlock.Length - 2; i++)
            {
                _unlock[i] = true;
            }

            if (MatchHistoryManager.instance.matchHistory.WinHistory[_indexPlayer] >= 5)
                _unlock[4] = true;
            if (MatchHistoryManager.instance.matchHistory.WinHistory[_indexPlayer] >= 10)
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
    }
}
