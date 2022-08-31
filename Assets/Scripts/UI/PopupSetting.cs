using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Paintastic.UI.PopupSetting
{
    public class PopupSetting : MonoBehaviour

    {
        [SerializeField] private Button _closePopupBtn;
        [SerializeField] private GameObject _popupSetting;


        private void Start()
        {
            _closePopupBtn.onClick.AddListener(delegate { ClosePopup(); });
        }

        private void ClosePopup()
        {
            _popupSetting.gameObject.SetActive(false);
        }
    }

}
