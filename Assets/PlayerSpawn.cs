using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{

    public GameObject playerFabs;
    [SerializeField] private int colorcode1, colorcode2;
    public int playerCount;

    public void SpawnPlayer(GameObject p1Pos, GameObject p2Pos)
    {
        if(playerCount == 1)
        {
            SpawnP1(p1Pos);
        }

        if (playerCount == 2)
        {
            SpawnP1(p1Pos);
            SpawnP2(p2Pos);
        }
    }

    public void SpawnP1(GameObject p1Pos)
    {
        Vector3 pos1 = p1Pos.transform.position;
        pos1.y += 2;
        GameObject player1 = Instantiate(playerFabs, pos1, Quaternion.identity);
        player1.name = "PLAYER1";
        player1.tag = "P1";
        PlayerMove playerscript = player1.GetComponent<PlayerMove>();
        playerscript.ChangeColor(colorcode1);
        playerscript.SetMovement(KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D);
    }

    public void SpawnP2(GameObject p2Pos)
    {
        Vector3 pos2 = p2Pos.transform.position;
        pos2.y += 2;
        GameObject player2 = Instantiate(playerFabs, pos2, Quaternion.identity);
        player2.name = "PLAYER2";
        player2.tag = "P2";
        PlayerMove playerscript = player2.GetComponent<PlayerMove>();
        playerscript.ChangeColor(colorcode2);
        playerscript.SetMovement(KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.RightArrow);
    }
}
