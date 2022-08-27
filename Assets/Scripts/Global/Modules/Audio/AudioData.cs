using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Paintastic.Global.Modules.Audio
{
    [System.Serializable]
    [CreateAssetMenu]
    public class AudioData : ScriptableObject
    {
    
      [System.Serializable]
      public struct Bgm
        {
            public string _soundName;
            public AudioClip _clip;
        }

      [System.Serializable]
      public struct SoundsFX
        {
            public string _soundName;
            public AudioClip _clip;
            [Range(0f, 1f)] public float _volume;
            public bool isLoop;
        }

        public List<Bgm> _backgroundMusic;
        public List<SoundsFX> _soundsFx;

    }

}

