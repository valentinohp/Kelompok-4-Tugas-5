using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Paintastic.UI.ColorSelect;

namespace Paintastic.Global.Modules.SaveData
{
    public class SaveData : MonoBehaviour
    {
        public static Action<int> OnLoadSelectedPlayerColor;
        public static Action<bool> OnLoadAudioSetting;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
        void Start()
        {
            GetPlayerColor();
            GetAudioSetting();
        }

        void Update()
        {

        }

        private void OnEnable()
        {
            AudioToggleSetting.OnToggleBgmClick += SaveAudioSetting;
            ColorSelect.OnPlayerColorChanged += SavePlayerColor;
        }

        private void OnDisable()
        {
            AudioToggleSetting.OnToggleBgmClick -= SaveAudioSetting;
            ColorSelect.OnPlayerColorChanged -= SavePlayerColor;
        }

        protected void GetPlayerColor()
        {
            /* int indexColor = PlayerPrefs.GetInt("indexColorPlayer1");
             OnLoadSelectedPlayerColor(indexColor);*/
        }

        protected void GetAudioSetting()
        {
            int isAudioOn = PlayerPrefs.GetInt("isAudioOn");
            if (isAudioOn == 1)
            {
                OnLoadAudioSetting?.Invoke(true);
            }
            else if (isAudioOn == 0)
            {
                OnLoadAudioSetting?.Invoke(false);
            }
        }

        protected void SavePlayerColor(Color playerOneColor, Color playerTwoColor)
        {
            string _p1color = ColorUtility.ToHtmlStringRGB(playerOneColor);
            string _p2color = ColorUtility.ToHtmlStringRGB(playerTwoColor);

            PlayerPrefs.SetString("playerOneColor" , _p1color);
            PlayerPrefs.SetString("playerTwoColor", _p2color);
        }

        protected void SaveAudioSetting(bool isAudioOn)
        {
            if (isAudioOn == true)
            {
                PlayerPrefs.SetInt("isAudioOn", 1);
            }
            else if (isAudioOn == false)
            {
                PlayerPrefs.SetInt("isAudioOn", 0);
            }
        }


    }

}
