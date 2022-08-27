using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paintastic.UI.ColorSelect
{
    public class ColorSelectData : MonoBehaviour
    {
        [System.Serializable]
        public struct PlayerColor
        {
            public ColorSelect colorSelect;
            public int _indexColor;
        }

        public List<PlayerColor> _playerColor;
    }
}
