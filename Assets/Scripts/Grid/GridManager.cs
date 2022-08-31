using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paintastic.Grid
{
    public class GridManager : MonoBehaviour
    {
        [SerializeField] private GameObject _gridCell;
        private GameObject[,] _grid;

        [SerializeField] private int _size;
        private float _space = 3.5f;

        private void Start()
        {
            StartGame();
        }

        private void OnEnable()
        {

        }

        private void OnDisable()
        {
            
        }

        public void StartGame()
        {
            GenerateGrid(_size, _size);
        }

        private void GenerateGrid(int height, int width)
        {
            _grid = new GameObject[height, width];
            int numbering = 1;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    _grid[x, y] = Instantiate(_gridCell, new Vector3(x * _space, 0, y * _space), Quaternion.identity);
                    _grid[x, y].gameObject.name = "Tile" + numbering.ToString();
                    numbering += 1;
                    _grid[x, y].GetComponent<GridCell>().SetPosition(x, y);
                    _grid[x, y].transform.parent = transform;
                    GridContainer container = gameObject.GetComponent<GridContainer>();
                    container.AddToList(_grid[x, y], _size);
                }
            }
        }
    }
}


