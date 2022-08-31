using Paintastic.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paintastic.Score;

namespace Paintastic.Player
{
    public class PlayerSpawn : MonoBehaviour
    {
        public GameObject playerFabs;
        [SerializeField] private int _colorcode1, _colorcode2;
        public int playerCount;

        private KeyCode _upkey;
        private KeyCode _leftkey;
        private KeyCode _downkey;
        private KeyCode _rightkey;

        [SerializeField] private float _playerSpeed;
        [SerializeField] private float _playerMoveTimer;

        public PlayerList playerMovement = new PlayerList();

        private ColorManager _colormanager;

        private ScoreManager _scoreManager;

        private void Start()
        {
            _scoreManager = GetComponent<ScoreManager>();
            _colormanager = GetComponent<ColorManager>();
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
                playercontrol.AddPlayerTarget(gridcontainer.Poles[playerPoles], i);

                ColorManager clrmngr = gameObject.GetComponent<ColorManager>();
                // Material colormat = clrmngr.colorMaterial[i];
                Material colormat = clrmngr.colorMaterial[PlayerPrefs.GetInt($"player{i + 1}")];
                CreatePlayerColorName(colormat.name);

                PlayerScript playerscript = player.GetComponent<PlayerScript>();
                playerscript.SpawnSet(_playerSpeed, _playerMoveTimer, _upkey, _leftkey, _downkey, _rightkey, i, gridsize, gridcontainer.Poles[playerPoles], playerPoles, colormat);

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
            _upkey = playerMovement.players[i].UpLeftDownRight[0];
            _leftkey = playerMovement.players[i].UpLeftDownRight[1];
            _downkey = playerMovement.players[i].UpLeftDownRight[2];
            _rightkey = playerMovement.players[i].UpLeftDownRight[3];
        }

        private void CreatePlayerColorName(string colorname)
        {
            _scoreManager.CreateColor(colorname.ToLower());
        }
    }
}

