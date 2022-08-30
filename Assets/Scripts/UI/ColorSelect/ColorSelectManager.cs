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

        public static int[] PlayerColors = new int[4] { 1, 2, -1, -1 };
        public static int ColorSelects;

        public static Color[] Colors = new Color[]
        {
            Color.black,
            Color.white,
            Color.red,
            Color.green,
            Color.blue,
            Color.yellow
        };

        [SerializeField] private Button _backToMenu;
        [SerializeField] private Button _startGame;
        [SerializeField] private List<ColorSelect> _colorSelects;

        private void Start()
        {
            ColorSelects = _colorSelects.Count;
            _backToMenu.onClick.AddListener(OnHideColorSelect);
            _startGame.onClick.AddListener(OnStartGame);
            AddPlayerColorList();
        }

        private void OnEnable()
        {
            ColorSelect.OnCycle += OnCycle;
        }

        private void OnDisable()
        {
            ColorSelect.OnCycle -= OnCycle;
        }

        private void OnCycle(int indexPlayer, int colorPlayer)
        {
            PlayerColors[indexPlayer] = colorPlayer;
        }

        private void AddPlayerColorList()
        {
            for (int i = 0; i < _colorSelects.Count; i++)
            {
                if (i >= _colorSelects.Count)
                {
                    PlayerColors[i] = -1;
                    continue;
                }
                string temp = $"player{i + 1}";

                PlayerColors[i] = PlayerPrefs.GetInt(temp);

                if (i > 0)
                {
                    if (PlayerColors[i] == PlayerColors[i - 1])
                    {
                        ResetAllColor();
                        break;
                    }
                }
                _colorSelects[i].SetFirstColor(PlayerColors[i]);
            }
        }

        private void ResetAllColor()
        {
            for (int i = 0; i < _colorSelects.Count; i++)
            {
                PlayerColors[i] = i;
                Debug.Log(_colorSelects[i]);
                _colorSelects[i].SetFirstColor(i);
                Debug.Log(i);
            }
        }

        private void OnHideColorSelect()
        {
            gameObject.SetActive(false);
        }

        private void OnStartGame()
        {
            SceneManager.LoadScene("Gameplay");
            OnStartGameEvent?.Invoke();
        }
    }
}

