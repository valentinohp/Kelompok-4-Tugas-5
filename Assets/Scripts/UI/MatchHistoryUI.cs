using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Paintastic.UI
{
    public class MatchHistoryUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text[] _players;
        [SerializeField] private Button _close;
        [SerializeField] private GameObject _popup;

        private int[] _winHistory = new int[4];

        private void Start()
        {
            _close.onClick.AddListener(Close);
            for (int i = 0; i < _players.Length; i++)
            {
                _players[i].text = _winHistory[i].ToString();
            }
        }

        public void GetData(int[] winHistory)
        {
            _winHistory = winHistory;
        }

        private void Close()
        {
            _popup.SetActive(false);
        }
    }
}