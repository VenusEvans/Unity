using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyControl: Enemy
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
