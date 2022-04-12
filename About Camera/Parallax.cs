using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*视觉差*/
public class Parallax : MonoBehaviour
{
    public Transform cam;
    public float xmoveRate;//移动范围
    public float ymoveRate;
    float xstartPoint;
    float ystartPoint;

    void Start()
    {
        xstartPoint = transform.position.x;
        ystartPoint = transform.position.y;

    }

    void Update()
    {
        transform.position = new Vector2(xstartPoint + cam.position.x * xmoveRate, ystartPoint + cam.position.y * ymoveRate);
    }
}
