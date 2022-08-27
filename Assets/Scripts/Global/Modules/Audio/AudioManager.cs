using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paintastic.Global.Modules.Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _bgmSource;
        [SerializeField] private AudioSource _soundFxSource;
        [SerializeField] private AudioData _audioData;
        private bool _isAudioOn = true ;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        void Start()
        {
            _bgmSource = GetComponent<AudioSource>();
            _soundFxSource = GetComponent<AudioSource>();
        }


        void Update()
        {
            IsSoundOn();
        }

        private void IsSoundOn()
        {
            if(PlayerPrefs.GetInt("isAudioOn") == 1)
            {
                _isAudioOn = true;
            }
            else if(PlayerPrefs.GetInt("isAudioOn") == 0)
            {
                _isAudioOn = false;
            }
        }

        private void SetCurrentBgmClip(string clip)
        {
            for (int i = 0; i < _audioData._backgroundMusic.Count; i++)
            {
                if (_audioData._backgroundMusic[i]._soundName == clip)
                {
                    _bgmSource.clip = _audioData._backgroundMusic[i]._clip;
                    if (_isAudioOn)
                        _bgmSource.Play();
                }
                break;
            }
        }

        private void SetCurrentSoundFXClip(string clip)
        {
            for (int i = 0; i < _audioData._soundsFx.Count; i++)
            {
                if (_audioData._soundsFx[i]._soundName == clip)
                {
                    _soundFxSource.clip = _audioData._soundsFx[i]._clip;
                    _soundFxSource.volume = _soundFxSource.volume * _audioData._soundsFx[i]._volume;
                    _soundFxSource.loop = _audioData._soundsFx[i].isLoop;
                    if (_isAudioOn)
                        _soundFxSource.Play();
                }
            }
        }

        protected void OnMainMenu()
        {
            SetCurrentBgmClip("OnMainMenu");
        }

        protected void OnGameplay()
        {
            SetCurrentBgmClip("OnGameplay");
        }

        protected void OnPlayerMove()
        {
            SetCurrentSoundFXClip("OnPlayerMove");
        }

        protected void OnCollectPoint()
        {
            SetCurrentSoundFXClip("OnCollectPoint");
        }

        protected void OnCollideBomb()
        {
            SetCurrentSoundFXClip("OnCollideBomb");
        }

        protected void OnGameOver()
        {
            SetCurrentSoundFXClip("OnGameOver");
        }
    }

}
