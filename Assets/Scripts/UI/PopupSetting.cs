using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Paintastic.UI.PopupSetting
{
    public class PopupSetting : MonoBehaviour

    {
        [SerializeField] private Button _popupSettingBtn;
        [SerializeField] private Button _closePopupBtn;
        [SerializeField] private GameObject _popupSetting;


        void Start()
        {
            _popupSettingBtn.onClick.AddListener(delegate { ShowPopup(); });
            _closePopupBtn.onClick.AddListener(delegate { ClosePopup(); });
        }


        void Update()
        {

        }

        private void ShowPopup()
        {
            _popupSetting.gameObject.SetActive(true);
        }

        private void ClosePopup()
        {
            _popupSetting.gameObject.SetActive(false);
        }
    }

}
