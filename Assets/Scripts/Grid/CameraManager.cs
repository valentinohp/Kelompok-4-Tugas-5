using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private float centerPos;
    private float posX, posY, posZ;

    private void Start()
    {
        SetOrPos();
    }

    private void Update()
    {
        transform.position = new Vector3(centerPos, posY, posZ);
    }

    public void SetGridCenter(GameObject A, GameObject B)
    {
        float xA = A.transform.position.x;
        float xB = B.transform.position.x;

        centerPos = ((xA + xB) / 2);
    }

    private void SetOrPos()
    {
        posX = transform.position.x;
        posY = transform.position.y;
        posZ = transform.position.z;
    }
}
