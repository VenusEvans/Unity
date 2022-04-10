using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*只是调整了一些参数，可以让敌人上下飞舞*/
public class FlyEnemyControl: MonoBehaviour
{
    Rigidbody2D rb;

    public float speed; //敌人速度
    public Transform up;
    public Transform down;
    bool FlyUp = true;
    float upy;
    float downy;

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        transform.DetachChildren();
        upy = up.position.y;
        downy = down.position.y;
        Destroy(up.gameObject);
        Destroy(down.gameObject);
    }

    void Update()
    {
        Movement();
    }

    void Movement() //敌人移动
    {
        if (FlyUp)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
            if (transform.position.y > upy)
            {
                //transform.localScale = new Vector3(-1, 1, 1);
                FlyUp = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, -speed);
            if (transform.position.y < downy)
            {
                //transform.localScale = new Vector3(1, 1, 1);
                FlyUp = true;
            }
        }
    }
}
