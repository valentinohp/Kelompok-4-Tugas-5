using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridContainer : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> Poles;

    [SerializeField]
    public List<GameObject> P1Tile;
    [SerializeField]
    public List<GameObject> P2Tile;

    public void AddToList(GameObject pole)
    {
        Poles.Add(pole);
        if(Poles.Count == 64)
        {
            PlayerSpawn spawnplayer = gameObject.GetComponent<PlayerSpawn>();
            spawnplayer.SpawnPlayer(Poles[0],Poles[63]);
        }
    }

    public void AddP1(GameObject pole)
    {
        if (P2Tile.Contains(pole))
        {
            int idx = P2Tile.IndexOf(pole);
            P2Tile.RemoveAt(idx);
        }

        if (P1Tile.Contains(pole))
        {
        }
            else
            {

                P1Tile.Add(pole);
            }
    }

    public void AddP2(GameObject pole)
    {
        if (P1Tile.Contains(pole))
        {
            int idx = P1Tile.IndexOf(pole);
            P1Tile.RemoveAt(idx);
        }

        if (P2Tile.Contains(pole))
        {
        }
        else
        {

            P2Tile.Add(pole);
        }
    }

}
