using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public GameObject gridManager;

    private int pos;
    [SerializeField]
    private int colortile;
    private bool canMove;

    [SerializeField]
    private float counter;
    private float orCounter;

    [SerializeField]
    private GameObject childColor;

    [SerializeField]
    private List<GameObject> players;


    private KeyCode upward, downward, leftward, rightward;

    [SerializeField] Material r, g, b, y;
    [SerializeField]
    private float speed;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        gridManager = GameObject.Find("GridManager");
        orCounter = counter;
        SetSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);


        if(transform.position == target.position)
        {
            ColoringGrid();
            counter -= Time.deltaTime;
            if(counter > 0)
            {
                return;
            }
            canMove = true;
            counter = orCounter;
        }


        if (Input.GetKey(leftward) && canMove && pos % 8 != 0)
        {
            canMove = false;
            Move(-1);
        }

        if (Input.GetKey(rightward) && canMove && ((pos + 1) % 8 != 0))
        {
            canMove = false;
            Move(1);
        }

        if (Input.GetKey(upward) && canMove && pos < 56)
        {
            canMove = false;
            Move(+8);
        }

        if (Input.GetKey(downward) && canMove && pos > 7)
        {
            canMove = false;
            Move(-8);
        }
    }

    void Move(int plus)
    {
        GridContainer gridcont = gridManager.GetComponent<GridContainer>();
        if(gameObject.tag == "P1")
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
        colortile = colorCode;
        if (colorCode == 1)
        {
            childColor.GetComponent<MeshRenderer>().material = r;
        }
        if (colorCode == 2)
        {
            childColor.GetComponent<MeshRenderer>().material = g;
        }
        if (colorCode == 3)
        {
            childColor.GetComponent<MeshRenderer>().material = b;
        }
        if (colorCode == 4)
        {
            childColor.GetComponent<MeshRenderer>().material = y;
        }
    }


    public void SetSpawnPos()
    {
        if(gameObject.tag == "P1")
        {
            pos = 0;
        }

        if (gameObject.tag == "P2")
        {
            pos = 63;
        }
        GridContainer gridcont = gridManager.GetComponent<GridContainer>();
        target = gridcont.Poles[pos].transform;
    }

    public void SetMovement(KeyCode w, KeyCode a, KeyCode s, KeyCode d)
    {
        upward = w;
        downward = s;
        leftward = a;
        rightward = d;
    }

    public void ColoringGrid()
    {
        GridCell gridcell = target.GetComponent<GridCell>();
        gridcell.PrintName();
        gridcell.SetColor(colortile);
    }

    public void MoveP1(GridContainer gridcont, int plus)
    {
        GameObject targetNom;
        int listCount;
        targetNom = gridcont.Poles[pos + plus];
        listCount = gridcont.P2Tile.Count;

        if (gridcont.P2Tile[listCount - 1] != targetNom)
        {
            target = gridcont.Poles[pos + plus].transform;
            pos += plus;
        }
    }

    public void MoveP2(GridContainer gridcont, int plus)
    {
        GameObject targetNom;
        int listCount;
        targetNom = gridcont.Poles[pos + plus];
        listCount = gridcont.P1Tile.Count;

        if (gridcont.P1Tile[listCount - 1] != targetNom)
        {
            target = gridcont.Poles[pos + plus].transform;
            pos += plus;
        }
    }

    public void AddPlayer(GameObject playerfabs)
    {
        players.Add(playerfabs);
    }
}
