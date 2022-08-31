using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Paintastic.Scene.MainMenu
{

    public class MainMenu : MonoBehaviour
    {
        public static UnityAction OnMainMenu;

        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _matchHistory;
        [SerializeField] private GameObject _colorSelect;
        [SerializeField] private GameObject _popupSettings;
        [SerializeField] private GameObject _popupMatchHistory;

        private void Start()
        {
            OnMainMenu?.Invoke();
            _playButton.onClick.AddListener(OnPlayButtonClick);
            _settingsButton.onClick.AddListener(OnSettingsButtonClick);
            _matchHistory.onClick.AddListener(OnMatchHistoryClick);
        }

        private void OnPlayButtonClick()
        {
            _colorSelect.SetActive(true);
        }

        private void OnSettingsButtonClick()
        {
            _popupSettings.SetActive(true);
        }

        private void OnMatchHistoryClick()
        {
            _popupMatchHistory.SetActive(true);
        }
    }
}