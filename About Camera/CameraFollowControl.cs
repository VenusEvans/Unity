/*相机跟随*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform playerTrans; //获取Player自身位置

    void Update()
    {
        transform.position = new Vector3(playerTrans.position.x, 0, -10f);
    }
}
