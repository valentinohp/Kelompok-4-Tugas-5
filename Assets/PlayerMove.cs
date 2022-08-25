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
    private GameObject childColor;


    private KeyCode upward, downward, leftward, rightward;

    [SerializeField] Material r, g, b, y;
    [SerializeField]
    private float speed;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        gridManager = GameObject.Find("GridManager");
        SetSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        if(transform.position == target.position)
        {
            canMove = true;
        }

        if (transform.position != target.position)
        {
            canMove = false;
        }


        if (Input.GetKeyDown(leftward) && canMove && pos % 8 != 0)
        {
            Move(-1);
        }

        if (Input.GetKeyDown(rightward) && canMove && ((pos + 1) % 8 != 0))
        {
            Move(1);
        }

        if (Input.GetKeyDown(upward) && canMove && pos < 56)
        {
            Move(+8);
        }

        if (Input.GetKeyDown(downward) && canMove && pos > 7)
        {
            Move(-8);
        }
    }

    void Move(int plus)
    {
            GridContainer gridcont = gridManager.GetComponent<GridContainer>();
            target = gridcont.Poles[pos + plus].transform;
            pos += plus;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tile")
        {
            AddPlayerTile(other.gameObject);
            GridCell gridcell = other.GetComponent<GridCell>();
            gridcell.PrintName();
            gridcell.SetColor(colortile);

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

    public void AddPlayerTile(GameObject go)
    {
        GridContainer gridcont = gridManager.GetComponent<GridContainer>();
        if (gameObject.tag == "P1")
        {

            gridcont.AddP1(go);
        }

        if (gameObject.tag == "P2")
        {
            gridcont.AddP2(go);
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
}
