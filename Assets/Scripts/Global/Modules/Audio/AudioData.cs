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
      public struct Sounds
        {
            public string _soundName;
            public AudioClip _clip;
        }

        public List<Sounds> _sounds;

    }

}

