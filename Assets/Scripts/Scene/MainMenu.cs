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
        [SerializeField] private GameObject _colorSelect;

        private void Start()
        {
            OnMainMenu?.Invoke();
            _playButton.onClick.AddListener(OnPlayButtonClick);
            _settingsButton.onClick.AddListener(OnSettingsButtonClick);
        }

        private void OnPlayButtonClick()
        {
            _colorSelect.SetActive(true);
        }

        public void OnSettingsButtonClick()
        {
            Debug.Log("settings clicked");
        }
    }
}