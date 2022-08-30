using UnityEngine;
using Paintastic.Scene.MainMenu;
using Paintastic.Scene.Gameplay;
using UnityEngine.UI;

namespace Paintastic.Global.Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _bgmSource;
        [SerializeField] private AudioSource _soundFxSource;
        [SerializeField] private AudioData _audioData;

        public bool _muteBgm = true;

        public static AudioManager instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }
        }

        private void OnEnable()
        {
            MainMenu.OnMainMenu += OnMainMenu;
            Gameplay.OnGameplay += OnGameplay;
            AudioToggleSetting.OnToggleBgmClick += ToggleBgm;
        }

        private void OnDisable()
        {
            MainMenu.OnMainMenu -= OnMainMenu;
            Gameplay.OnGameplay -= OnGameplay;
            AudioToggleSetting.OnToggleBgmClick -= ToggleBgm;
        }

        private void Start()
        {
            IsSoundOn();
        }

        public void SetBgmVolume(float vol)
        {
            _bgmSource.volume = vol;
        }

        private void ToggleBgm(bool muteBgm)
        {
            _muteBgm = !_muteBgm;
            if(_muteBgm)
            {
                _bgmSource.Stop();
            }
            else if(!_muteBgm)
            {
                _bgmSource.Play();
            }
        }

        private void IsSoundOn()
        {
            if (PlayerPrefs.GetInt("isAudioOn") == 1)
            {
                _muteBgm = false;
            }
            else if (PlayerPrefs.GetInt("isAudioOn") == 0)
            {
                _muteBgm = true;
            }
        }

        private void SetCurrentBgmClip(string clip)
        {
            for (int i = 0; i < _audioData._backgroundMusic.Count; i++)
            {
                if (_audioData._backgroundMusic[i]._soundName == clip)
                {
                    _bgmSource.clip = _audioData._backgroundMusic[i]._clip;
                    if (!_muteBgm)
                        _bgmSource.Play();
                    else if(_muteBgm)
                        _bgmSource.Stop();
                    break;
                }
            }
        }

        private void SetCurrentSoundFXClip(string clip)
        {
            for (int i = 0; i < _audioData._soundsFx.Count; i++)
            {
                if (_audioData._soundsFx[i]._soundName == clip)
                {
                    _soundFxSource.clip = _audioData._soundsFx[i]._clip;
                    _soundFxSource.volume *= _audioData._soundsFx[i]._volume;
                    _soundFxSource.loop = _audioData._soundsFx[i].isLoop;
                    if (!_muteBgm)
                        _soundFxSource.Play();
                    else if(_muteBgm)
                        _soundFxSource.Stop();
                    break;
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
