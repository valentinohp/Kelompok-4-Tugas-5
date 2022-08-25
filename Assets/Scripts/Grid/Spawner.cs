using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //[SerializeField] private PlayerMovement player1;
    //[SerializeField] private PlayerMovement player2;

    [SerializeField] private GameObject gridMap;
    private Transform[,] grid;

    private void Start()
    {
        grid = new Transform[8, 8];
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                grid[i, j] = Instantiate(gridMap, new Vector3(i + (0.1f * i), 0, j + (0.1f * j)), Quaternion.identity).transform;
            }
        }

        //player1.SetInit(player2, grid, new Vector2Int(0, 0));
        //player2.SetInit(player1, grid, new Vector2Int(path.GetLength(0) - 1, path.GetLength(1) - 1));
    }
}
