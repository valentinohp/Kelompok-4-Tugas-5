using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{

    public GameObject playerFabs;
    [SerializeField] private int colorcode1, colorcode2;
    public int playerCount;

    private KeyCode upkey;
    private KeyCode leftkey;
    private KeyCode downkey;
    private KeyCode rightkey;

    [SerializeField]
    private float playerSpeed;

    [SerializeField]
    private float playerMoveTimer;

    public PlayerList playerMovement = new PlayerList();

    private ColorManager colormanager;

    void Start()
    {
        colormanager = GetComponent<ColorManager>();
    }
    public void SpawnPlayer(GameObject p1Pos, GameObject p2Pos, int gridsize)
    {
        SpawnPlayers(gridsize);
    }

    public void SpawnPlayers(int gridsize)
    {
        GridContainer gridcontainer = gameObject.GetComponent<GridContainer>();
        int playerPoles = 0;

        PlayerControlScript playercontrol = gameObject.GetComponent<PlayerControlScript>();

        for (int i = 0; i < playerCount; i++)
        {
            Vector3 spawnPositionX = gridcontainer.Poles[playerPoles].transform.position;
            GameObject player = Instantiate(playerFabs, spawnPositionX, Quaternion.identity);
            player.name = "PLAYER" + (i + 1).ToString();
            player.tag = "P" + (i + 1).ToString(); ;

            playercontrol.AddPlayer(player);

            SetKeyCode(i);
            playercontrol.AddPlayerTarget(gridcontainer.Poles[playerPoles]);

            ColorManager clrmngr = gameObject.GetComponent<ColorManager>();
            Material colormat = clrmngr.colorMaterial[i];

            PlayerScript playerscript = player.GetComponent<PlayerScript>();
            playerscript.SpawnSet(playerSpeed, playerMoveTimer, upkey, leftkey, downkey, rightkey, i, gridsize, gridcontainer.Poles[playerPoles], playerPoles, colormat);



            if (i == 2)
            {
                playerPoles = gridsize - 1;
            }
            if (i == 1)
            {
                playerPoles = gridsize * (gridsize - 1);
            }
            if (i == 0)
            {
                playerPoles = (gridsize * gridsize) - 1;
            }
        }
    }

    private void SetKeyCode(int i)
    {
        upkey = playerMovement.players[i].UpLeftDownRight[0];
        leftkey = playerMovement.players[i].UpLeftDownRight[1];
        downkey = playerMovement.players[i].UpLeftDownRight[2];
        rightkey = playerMovement.players[i].UpLeftDownRight[3];
    }
}
