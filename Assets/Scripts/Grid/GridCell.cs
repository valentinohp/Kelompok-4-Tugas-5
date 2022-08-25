using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
	// Start is called before the first frame update
	private int posX;
	private int posY;

	public bool isOccupied = false;

	[SerializeField] Material r, g, b, y;

	public void SetPosition(int x, int y)
	{
		posX = x;
		posY = y;
	}

	public Vector2Int GetPosition()
	{
		return new Vector2Int(posX, posY);
	}

	public void PrintName()
    {
		Debug.Log(gameObject.name);
    }

	public void SetColor(int number)
    {
        if(number == 1)
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
