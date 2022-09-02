using Paintastic.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paintastic.Player
{
    public class PlayerScript : MonoBehaviour
    {
        [SerializeField] private KeyCode upward;
        private KeyCode leftward;
        private KeyCode downward;
        private KeyCode rightward;

        [SerializeField] private GameObject gridManager;

        private PlayerControlScript playerControl;

        [SerializeField] private float counter;
        private float orCounter;

        [SerializeField] private GameObject target;
        [SerializeField] private int tilePos;

        private GridContainer gridcont;
        private float speed;
        private int playerIndex;
        private int otherA, otherB, otherC;
        [SerializeField] private bool playerCanMove;
        private int gridsize;
        private int materialIndex;
        private Material playerMat;
        [SerializeField]
        private GameObject childObj;
        [SerializeField]
        private GameObject charaObj;
        [SerializeField]
        private GameObject charaParObj;
        private void Start()
        {
            gridManager = GameObject.Find("GridManager");
            playerControl = gridManager.GetComponent<PlayerControlScript>();
            gridcont = gridManager.GetComponent<GridContainer>();

            playerCanMove = true;

            childObj = gameObject.transform.GetChild(0).gameObject;

        }

        private void Update()
        {
            MoveToTarget();

            if (transform.position == target.transform.position)
            {
                SetIdleAnim();
                ChangeTile();
                counter -= Time.deltaTime;
                if (counter > 0)
                {
                    return;
                }
                playerCanMove = true;
                counter = orCounter;
            }

            MoveInput();
        }


        public void SpawnSet(float spd, float cntr, KeyCode up, KeyCode left, KeyCode down, KeyCode right, int pIndex, int size, GameObject pTarget, int pos, Material colormat)
        {
            SetSpeed(spd);
            SetCounter(cntr);
            SetKeycode(up, left, down, right);
            SetPlayerIndex(pIndex);
            SetGridSize(size);
            SetTilePos(pos);
            target = pTarget;
            SetColor(colormat);
            SetOtherIdx();
        }

        private void SetGridSize(int size)
        {
            gridsize = size;
        }

        private void SetTilePos(int pos)
        {
            tilePos = pos;
        }

        private void SetSpeed(float spd)
        {
            speed = spd;
        }

        private void SetPlayerIndex(int pIndex)
        {
            playerIndex = pIndex;
        }

        private void SetCounter(float cntr)
        {
            counter = cntr;
            orCounter = counter;
        }

        private void SetKeycode(KeyCode up, KeyCode left, KeyCode down, KeyCode right)
        {
            upward = up;
            leftward = left;
            downward = down;
            rightward = right;
        }

        private void MoveToTarget()
        {
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        }

        private void MoveInput()
        {
            if (Input.GetKey(leftward) && playerCanMove && tilePos % gridsize != 0)
            {
                RotatePlayer(-90);
                playerCanMove = false;
                Move(-1);
            }

            if (Input.GetKey(rightward) && playerCanMove && ((tilePos + 1) % gridsize != 0))
            {
                RotatePlayer(90);
                playerCanMove = false;
                Move(1);
            }

            if (Input.GetKey(upward) && playerCanMove && tilePos < (gridsize * (gridsize - 1)))
            {
                RotatePlayer(0);
                playerCanMove = false;
                Move(+gridsize);
            }

            if (Input.GetKey(downward) && playerCanMove && tilePos > (gridsize - 1))
            {
                RotatePlayer(180);
                playerCanMove = false;
                Move(-gridsize);
            }
        }

        private void Move(int plus)
        {
            GameObject targetNom = gridcont.Poles[tilePos + plus];
            if (playerControl.PlayerTarget[otherA] != targetNom && playerControl.PlayerTarget[otherB] != targetNom && playerControl.PlayerTarget[otherC] != targetNom)
            {
                SetJumpAnim();
                playerControl.PlayerTarget[playerIndex] = gridcont.Poles[tilePos + plus];
                SetTarget();

                tilePos += plus;
            }

        }

        private void SetTarget()
        {
            target = playerControl.PlayerTarget[playerIndex];
        }

        private void SetColor(Material colormat)
        {
           
            MeshRenderer childrenderer = childObj.GetComponent<MeshRenderer>();
            MeshRenderer skinchara = charaObj.GetComponent<MeshRenderer>();
            skinchara.material = colormat;
            childrenderer.material = colormat;
            playerMat = colormat;
        }

        private void ChangeTile()
        {
            MeshRenderer tilerender = target.GetComponent<MeshRenderer>();
            tilerender.material = playerMat;

            AddToPlayerTile();
        }

        private void AddToPlayerTile()
        {
            if (gameObject.name == "PLAYER1")
            {
                if (gridcont.P2Tile.Contains(target))
                {
                    int idx = gridcont.P2Tile.IndexOf(target);
                    gridcont.P2Tile.RemoveAt(idx);
                }

                if (gridcont.P3Tile.Contains(target))
                {
                    int idx = gridcont.P3Tile.IndexOf(target);
                    gridcont.P3Tile.RemoveAt(idx);
                }

                if (gridcont.P4Tile.Contains(target))
                {
                    int idx = gridcont.P4Tile.IndexOf(target);
                    gridcont.P4Tile.RemoveAt(idx);
                }

                if (gridcont.P1Tile.Contains(target))
                {

                }

                else
                {
                    gridcont.P1Tile.Add(target);
                    return;
                }
            }

            if (gameObject.name == "PLAYER2")
            {
                if (gridcont.P1Tile.Contains(target))
                {
                    int idx = gridcont.P1Tile.IndexOf(target);
                    gridcont.P1Tile.RemoveAt(idx);
                }

                if (gridcont.P3Tile.Contains(target))
                {
                    int idx = gridcont.P3Tile.IndexOf(target);
                    gridcont.P3Tile.RemoveAt(idx);
                }

                if (gridcont.P4Tile.Contains(target))
                {
                    int idx = gridcont.P4Tile.IndexOf(target);
                    gridcont.P4Tile.RemoveAt(idx);
                }

                if (gridcont.P2Tile.Contains(target))
                {

                }

                else
                {
                    gridcont.P2Tile.Add(target);
                    return;
                }
            }

            if (gameObject.name == "PLAYER3")
            {
                if (gridcont.P2Tile.Contains(target))
                {
                    int idx = gridcont.P2Tile.IndexOf(target);
                    gridcont.P2Tile.RemoveAt(idx);
                }

                if (gridcont.P1Tile.Contains(target))
                {
                    int idx = gridcont.P1Tile.IndexOf(target);
                    gridcont.P1Tile.RemoveAt(idx);
                }

                if (gridcont.P4Tile.Contains(target))
                {
                    int idx = gridcont.P4Tile.IndexOf(target);
                    gridcont.P4Tile.RemoveAt(idx);
                }

                if (gridcont.P3Tile.Contains(target))
                {

                }

                else
                {
                    gridcont.P3Tile.Add(target);
                    return;
                }
            }

            if (gameObject.name == "PLAYER4")
            {
                if (gridcont.P2Tile.Contains(target))
                {
                    int idx = gridcont.P2Tile.IndexOf(target);
                    gridcont.P2Tile.RemoveAt(idx);
                }

                if (gridcont.P3Tile.Contains(target))
                {
                    int idx = gridcont.P3Tile.IndexOf(target);
                    gridcont.P3Tile.RemoveAt(idx);
                }

                if (gridcont.P1Tile.Contains(target))
                {
                    int idx = gridcont.P1Tile.IndexOf(target);
                    gridcont.P1Tile.RemoveAt(idx);
                }

                if (gridcont.P4Tile.Contains(target))
                {

                }

                else
                {
                    gridcont.P4Tile.Add(target);
                    return;
                }
            }
        }

        private void SetOtherIdx()
        {
            if (playerIndex == 0)
            {
                otherA = 1;
                otherB = 2;
                otherC = 3;
            }

            if (playerIndex == 1)
            {
                otherA = 0;
                otherB = 2;
                otherC = 3;
            }

            if (playerIndex == 2)
            {
                otherA = 0;
                otherB = 1;
                otherC = 3;
            }

            if (playerIndex == 3)
            {
                otherA = 0;
                otherB = 1;
                otherC = 2;
            }
        }

        private void SetJumpAnim()
        {
            PlayerChildAnim playeranim = childObj.GetComponent<PlayerChildAnim>();
            playeranim.SetJump();
        }

        private void SetIdleAnim()
        {
            PlayerChildAnim playeranim = childObj.GetComponent<PlayerChildAnim>();
            playeranim.SetIdle();
        }

        public Material GetPlayerMaterial()
        {
            return playerMat;
        }

        private void RotatePlayer(float degree)
        {
            charaParObj.transform.rotation = Quaternion.Euler(0, degree, 0);
        }
    }
}

