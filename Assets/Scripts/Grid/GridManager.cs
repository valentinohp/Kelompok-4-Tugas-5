using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
	[SerializeField] private GameObject gridCell;
	private GameObject[,] grid;

	[SerializeField]
	private int size;
	private float space = 3.5f;
	//private int i = 0;

	public event System.Action<string, int> OnPlayerTilesCount;

	void Start()
	{
		GenerateGrid(size, size);
		
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
		grid = new GameObject[height, width];
		int numbering = 1;
		for (int y = 0; y < height; y++)
		{
			for (int x = 0; x < width; x++)
			{
				grid[x, y] = Instantiate(gridCell, new Vector3(x * space, 0, y * space), Quaternion.identity);
				grid[x, y].gameObject.name = "Tile" + numbering.ToString();
				numbering += 1;
				grid[x, y].GetComponent<GridCell>().SetPosition(x, y);
				grid[x, y].transform.parent = transform;
				GridContainer container = gameObject.GetComponent<GridContainer>();
				container.AddToList(grid[x, y], size);
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

