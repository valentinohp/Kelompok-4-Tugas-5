using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paintastic.Global.Modules.Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioData _audioData;
        private bool _isAudioOn = true ;

        void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }


        void Update()
        {
            CheckSoundOn();
        }

        private void CheckSoundOn()
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

        private void OnPlayerMove()
        {
            for (int i = 0; i < _audioData._sounds.Count; i++)
            {
                if (_audioData._sounds[i]._soundName == "OnPlayerMove")
                {
                    _audioSource.clip = _audioData._sounds[i]._clip;
                    if(_isAudioOn)
                    _audioSource.Play();
                }
                break;
            }
  
        }

        private void OnCollectPoint()
        {
            for (int i = 0; i < _audioData._sounds.Count; i++)
            {
                if(_audioData._sounds[i]._soundName == "OnCollectPoint")
                {
                    _audioSource.clip = _audioData._sounds[i]._clip;
                    if (_isAudioOn)
                        _audioSource.Play();
                }
                break;
            }
        }

        private void OnCollideBomb()
        {
            //play sound bomb
        }

        private void OnGameOver()
        {
            //play sound Game Over
        }
    }

}
