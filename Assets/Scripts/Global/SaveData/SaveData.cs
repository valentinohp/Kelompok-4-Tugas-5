using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Paintastic.UI.ColorSelect;
using Paintastic.Global.Audio;

namespace Paintastic.Global.SaveData
{
    public class SaveData : MonoBehaviour
    {
        public static Action<int> OnLoadSelectedPlayerColor;
        public static Action<bool> OnLoadAudioSetting;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void OnEnable()
        {
            AudioToggleSetting.OnToggleBgmClick += SaveAudioSetting;
            ColorSelectManager.OnStartGameEvent += SavePlayerColor;
        }

        private void OnDisable()
        {
            AudioToggleSetting.OnToggleBgmClick -= SaveAudioSetting;
            ColorSelectManager.OnStartGameEvent -= SavePlayerColor;
        }

        protected void SavePlayerColor()
        {
            for (int i = 0; i < ColorSelectManager.ColorSelects; i++)
            {
                string temp = $"player{i + 1}";
                PlayerPrefs.SetInt(temp, ColorSelectManager.PlayerColors[i]);
            }
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
