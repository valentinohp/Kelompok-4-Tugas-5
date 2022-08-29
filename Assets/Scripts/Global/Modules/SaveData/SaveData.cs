using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Paintastic.UI.ColorSelect;
using Paintastic.Global.Modules.Audio;

namespace Paintastic.Global.Modules.SaveData
{
    public class SaveData : MonoBehaviour
    {
        public static Action<int> OnLoadSelectedPlayerColor;
        public static Action<bool> OnLoadAudioSetting;

        [SerializeField] private ColorSelectData _colorSelectData;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
        void Start()
        {
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

        protected void SavePlayerColor(int indexPlayer, int indexColor)
        {
            for(int i = 0; i < ColorSelectManager.ColorSelects; i++)
            {
                string temp = $"player{indexPlayer}";
                PlayerPrefs.SetInt(temp, indexColor);
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
