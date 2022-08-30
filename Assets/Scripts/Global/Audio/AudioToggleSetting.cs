using UnityEngine;
using Paintastic.Global.SaveData;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Paintastic.Global.Audio
{
    public class AudioToggleSetting : MonoBehaviour
    {
        public static UnityAction<bool> OnToggleBgmClick;
        public static UnityAction OnToggleSoundFXClick;

        [SerializeField] private enum ButtonType { ButtonBGM, ButtonSoundFX }
        [SerializeField] private Vector3 _onBtnPos;
        [SerializeField] private Vector3 _offBtnPos;
        [SerializeField] private GameObject _controlBgmButton;
        [SerializeField] private Button _toggleBgm;
        [SerializeField] private Slider _volumeSetting;

        public Vector3 _currentBgmButtonPos;
        private bool isBgmOn = true;

        private void Start()
        {
            CheckBgmOn();
            SetCurrentBtnBgmPos();
            _toggleBgm.onClick.AddListener(delegate { ToggleBgm(); });
            _volumeSetting.onValueChanged.AddListener(delegate { SetVolume(); });
            _volumeSetting.value = 1f;
        }

        private void SetVolume()
        {
            AudioManager.instance.SetBgmVolume(_volumeSetting.value);
        }

        private void SetCurrentBtnBgmPos()
        {
            if (isBgmOn == true)
            {
                _controlBgmButton.GetComponent<RectTransform>().anchoredPosition = _onBtnPos;
            }
            else if (isBgmOn == false)
            {
                _controlBgmButton.GetComponent<RectTransform>().anchoredPosition = _offBtnPos;
            }
        }

        public void ToggleBgm()
        {
            isBgmOn = !isBgmOn;
            OnToggleBgmClick?.Invoke(isBgmOn);
            if (isBgmOn)
            {
                _controlBgmButton.GetComponent<RectTransform>().anchoredPosition = _onBtnPos;
            }
            else if (!isBgmOn)
            {
                _controlBgmButton.GetComponent<RectTransform>().anchoredPosition = _offBtnPos;
            }
        }

        private void CheckBgmOn()
        {
            if (PlayerPrefs.GetInt("isAudioOn") == 1)
            {
                isBgmOn = true;
            }
            else if (PlayerPrefs.GetInt("isAudioOn") == 0)
            {
                isBgmOn = false;
            }
        }
    }
}
