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

        public static int[] PlayerColors = new int[4] {1,2,-1,-1};
        public static int ColorSelects;

        [SerializeField] private Button _backToMenu;
        [SerializeField] private Button _startGame;
        [SerializeField] private List<ColorSelect> _colorSelects;


        void Start()
        {
            ColorSelects = _colorSelects.Count;
            _backToMenu.onClick.AddListener(OnHideColorSelect);
            _startGame.onClick.AddListener(OnStartGame);
            AddPlayerColorList();
        }

        void Update()
        {
        
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
            Debug.Log("p1"+PlayerColors[0]);
            Debug.Log("p2" + PlayerColors[1]);
            PlayerColors[indexPlayer] = colorPlayer;
        }

        private void AddPlayerColorList()
        {
            for (int i = 0; i < PlayerColors.Length; i++)
            {
                if (i >= _colorSelects.Count)
                {
                    PlayerColors[i] = -1;
                    continue;
                }
                string temp = $"player{i + 1}";
                PlayerColors[i] = PlayerPrefs.GetInt(temp);
                _colorSelects[i].SetFirstColor(PlayerColors[i]);
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

