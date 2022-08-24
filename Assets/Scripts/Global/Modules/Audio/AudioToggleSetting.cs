using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioToggleSetting : MonoBehaviour
{
    public static Action<bool> OnToggleBgmClick;
    public static Action OnToggleSoundFXClick;

    [SerializeField] private enum ButtonType { ButtonBGM, ButtonSoundFX }
    [SerializeField] private Vector3 _onBtnPos;
    [SerializeField] private Vector3 _offBtnPos;
    [SerializeField] private GameObject _controlBgmButton;

    private Vector3 _currentBgmButtonPos;
    private Vector3 _currentSoundFXButtonPos;
    private bool isBgmOn = true;

    private void OnEnable()
    {
        SaveData.OnLoadAudioSetting += SetCurrentBtnBgmPos;
    }

    private void OnDisable()
    {
        SaveData.OnLoadAudioSetting -= SetCurrentBtnBgmPos;
    }

    void Start()
    {
        _controlBgmButton.GetComponent<RectTransform>().anchoredPosition = _currentBgmButtonPos;
        CheckBgmOn();
    }

    void Update()
    {
        
    }

    private void SetCurrentBtnBgmPos(bool _isBgmOn)
    {
       if(_isBgmOn == true)
        {
            _currentBgmButtonPos = _onBtnPos;
        }
       else
        {
            _currentBgmButtonPos = _offBtnPos;
        }
    }
    
    public void ToggleBgm()
    {
        isBgmOn = !isBgmOn;
        OnToggleBgmClick(isBgmOn);
        if(isBgmOn)
        {
            _controlBgmButton.GetComponent<RectTransform>().anchoredPosition = _onBtnPos;
        }
        else if(!isBgmOn)
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
        else if(PlayerPrefs.GetInt("isAudioOn") == 0)
        {
            isBgmOn = false;
        }
    }

}
