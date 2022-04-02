/*2D*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform playerTrans;

    void Update()
    {
        transform.position = new Vector3(playerTrans.position.x, 0, -10f);
    }
}
