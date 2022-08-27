using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Paintastic.UI.ColorSelect
{
    public class ColorSelectManager : MonoBehaviour
    {

        public static UnityAction OnStartGameEvent;
        public static UnityAction OnHideColorSelectEvent;
        public static UnityAction<int> OnApplyFirstColor;

        [SerializeField] private Button _backToMenu;
        [SerializeField] private Button _startGame;
        [SerializeField] private List<ColorSelect> _colorSelects;

        public static int[] PlayerColors = new int[4];

        void Start()
        {
            _backToMenu.onClick.AddListener(OnHideColorSelect);
            _startGame.onClick.AddListener(OnStartGame);
            AddPlayerColorList();
            ApplyFirstColor();
        }

        void Update()
        {
        
        }

        private void AddPlayerColorList()
        {
            //for(int i = 0; i < _colorSelects.Count; i++)
            //{
            //    int indexPlayer = i + 1;
            //    string playerName = "player" + indexPlayer;
            //    int colorIndex = PlayerPrefs.GetInt(playerName);

            //    _playerColors.Add(colorIndex);
            //}

            for (int i = 0; i < PlayerColors.Length; i++)
            {
                if (i >= _colorSelects.Count)
                {
                    PlayerColors[i] = -1;
                    continue;
                }
                PlayerColors[i] = PlayerPrefs.GetInt($"player{i + 1}");
            }
        }

        private void ApplyFirstColor()
        {
            for (int i = 0; i < _colorSelects.Count; i ++)
            {
                int indexPlayer = i + 1;
                string playerName = "player" + indexPlayer;
                int colorIndex = PlayerPrefs.GetInt(playerName);

                Debug.Log(playerName);
                _colorSelects[i].SetFirstColor(colorIndex);
            }
        }

        private void OnHideColorSelect()
        {
            OnHideColorSelectEvent?.Invoke();
        }

        private void OnStartGame()
        {
            SceneManager.LoadScene("Gameplay");
            OnStartGameEvent?.Invoke();
        }
    }
}

