using Paintastic.Grid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Paintastic.Player
{
    public class PlayerMove : MonoBehaviour
    {
        public GameObject gridManager;

        private int _pos;
        [SerializeField] private int _colortile;
        private bool _canMove;

        [SerializeField] private float _counter;
        private float _orCounter;

        [SerializeField] private GameObject _childColor;
        [SerializeField] private List<GameObject> _players;

        private KeyCode _upward, _downward, _leftward, _rightward;

        [SerializeField] Material r, g, b, y;
        [SerializeField] private float _speed;
        private Transform _target;

        private void Start()
        {
            gridManager = GameObject.Find("GridManager");
            _orCounter = _counter;
            SetSpawnPos();
        }

        private void Update()
        {
            var step = _speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _target.position, step);

            if (transform.position == _target.position)
            {
                ColoringGrid();
                _counter -= Time.deltaTime;
                if (_counter > 0)
                {
                    return;
                }
                _canMove = true;
                _counter = _orCounter;
            }

            if (Input.GetKey(_leftward) && _canMove && _pos % 8 != 0)
            {
                _canMove = false;
                Move(-1);
            }

            if (Input.GetKey(_rightward) && _canMove && ((_pos + 1) % 8 != 0))
            {
                _canMove = false;
                Move(1);
            }

            if (Input.GetKey(_upward) && _canMove && _pos < 56)
            {
                _canMove = false;
                Move(+8);
            }

            if (Input.GetKey(_downward) && _canMove && _pos > 7)
            {
                _canMove = false;
                Move(-8);
            }
        }

        public void Move(int plus)
        {
            GridContainer gridcont = gridManager.GetComponent<GridContainer>();
            if (gameObject.tag == "P1")
            {
                MoveP1(gridcont, plus);
            }
            if (gameObject.tag == "P2")
            {
                MoveP2(gridcont, plus);
            }
        }

        public void ChangeColor(int colorCode)
        {
            _colortile = colorCode;
            if (colorCode == 1)
            {
                _childColor.GetComponent<MeshRenderer>().material = r;
            }
            if (colorCode == 2)
            {
                _childColor.GetComponent<MeshRenderer>().material = g;
            }
            if (colorCode == 3)
            {
                _childColor.GetComponent<MeshRenderer>().material = b;
            }
            if (colorCode == 4)
            {
                _childColor.GetComponent<MeshRenderer>().material = y;
            }
        }

        public void SetSpawnPos()
        {
            if (gameObject.tag == "P1")
            {
                _pos = 0;
            }

            if (gameObject.tag == "P2")
            {
                _pos = 63;
            }

            GridContainer gridcont = gridManager.GetComponent<GridContainer>();
            _target = gridcont.Poles[_pos].transform;
        }

        public void SetMovement(KeyCode w, KeyCode a, KeyCode s, KeyCode d)
        {
            _upward = w;
            _downward = s;
            _leftward = a;
            _rightward = d;
        }

        public void ColoringGrid()
        {
            GridCell gridcell = _target.GetComponent<GridCell>();
            gridcell.PrintName();
            gridcell.SetColor(_colortile);
        }

        public void MoveP1(GridContainer gridcont, int plus)
        {
            GameObject targetNom;
            int listCount;
            targetNom = gridcont.Poles[_pos + plus];
            listCount = gridcont.P2Tile.Count;

            if (gridcont.P2Tile[listCount - 1] != targetNom)
            {
                _target = gridcont.Poles[_pos + plus].transform;
                _pos += plus;
            }
        }

        public void MoveP2(GridContainer gridcont, int plus)
        {
            GameObject targetNom;
            int listCount;
            targetNom = gridcont.Poles[_pos + plus];
            listCount = gridcont.P1Tile.Count;

            if (gridcont.P1Tile[listCount - 1] != targetNom)
            {
                _target = gridcont.Poles[_pos + plus].transform;
                _pos += plus;
            }
        }

        public void AddPlayer(GameObject playerfabs)
        {
            _players.Add(playerfabs);
        }
    }
}

