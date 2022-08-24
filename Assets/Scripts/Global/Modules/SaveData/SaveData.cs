using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

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
        
    }

    private void OnDisable()
    {
        AudioToggleSetting.OnToggleBgmClick += SaveAudioSetting;
    }

    protected void GetPlayerColor()
    {
       /* int indexColor = PlayerPrefs.GetInt("indexColorPlayer1");
        OnLoadSelectedPlayerColor(indexColor);*/
    }

    protected void GetAudioSetting()
    {
        int isAudioOn = PlayerPrefs.GetInt("isAudioOn");
        if(isAudioOn == 1)
        {
            OnLoadAudioSetting(true);
        }
        else if (isAudioOn == 0)
        {
            OnLoadAudioSetting(false);
        }
    }

    protected void SavePlayerColor(string playerName, int _indexColor)
    {
        PlayerPrefs.SetInt("indexPlayerColor" + playerName, _indexColor);
    }

    protected void SaveAudioSetting(bool isAudioOn)
    {
        if(isAudioOn == true)
        {
            PlayerPrefs.SetInt("isAudioOn", 1);
        }
        else if(isAudioOn == false)
        {
            PlayerPrefs.SetInt("isAudioOn", 0);
        }
    }


}
