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
		//private int i = 0;

		//public event System.Action<string, int> OnPlayerTilesCount;

		void Start()
		{
			GenerateGrid(_size, _size);

		}
		private void OnEnable()
		{

		}
		private void OnDisable()
		{
			//foreach (GameObject go in gridGame)
			//{
			//	go.gameObject.GetComponent<DetectPlayer>().OnCollectPointPicked -= OnCollcectPointPicked;
			//}
		}

		//private void OnCollcectPointPicked(GameObject _gameObject)
		//{
		//	foreach (GameObject go in grid)
		//	{
		//		//kirim score
		//		//reset warna
		//		if (go.CompareTag(_gameObject.tag))
		//		{
		//			playerScore += 1;
		//			ResetColor(go);
		//		}
		//	}
		//	OnPlayerTilesCount?.Invoke(_gameObject.tag, playerScore);
		//	playerScore = 0;
		//}

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
			//player1.SetInit(player2, gridGame, new Vector2Int(0, 0));
			//player2.SetInit(player1, gridGame, new Vector2Int(gridGame.GetLength(0) - 1, gridGame.GetLength(1) - 1));
		}
		//private void ResetColor(GameObject go)
		//{
		//	//Debug.Log(go.tag);
		//	go.GetComponent<MeshRenderer>().material.color = Color.white;
		//	go.tag = "Tile";
		//}

	}
}


