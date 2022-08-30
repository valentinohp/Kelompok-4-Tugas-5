using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paintastic.Grid
{
    public class GridCell : MonoBehaviour
    {
        private int _posX;
        private int _posY;

        public bool isOccupied = false;
        [SerializeField] private Material _defaultMaterial;
        [SerializeField] Material r, g, b, y;

        public void SetPosition(int x, int y)
        {
            _posX = x;
            _posY = y;
        }

        public Vector2Int GetPosition()
        {
            return new Vector2Int(_posX, _posY);
        }

        public void PrintName()
        {
            Debug.Log(gameObject.name);
        }

        public void SetColor(int number)
        {
            if (number == 0)
            {
                gameObject.GetComponent<MeshRenderer>().material = _defaultMaterial;
            }
            if (number == 1)
            {
                gameObject.GetComponent<MeshRenderer>().material = r;
            }
            if (number == 2)
            {
                gameObject.GetComponent<MeshRenderer>().material = g;
            }
            if (number == 3)
            {
                gameObject.GetComponent<MeshRenderer>().material = b;
            }
            if (number == 4)
            {
                gameObject.GetComponent<MeshRenderer>().material = y;
            }
        }
    }
}

