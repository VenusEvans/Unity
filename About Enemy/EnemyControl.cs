using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl: Enemy //继承父级改为Enemy 为了调用消灭动画
{
    Rigidbody2D rb;

    public float speed; //敌人速度
    public Transform left;
    public Transform right;
    bool faceLeft = true;
    float leftx;
    float rightx;

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        transform.DetachChildren();
        leftx = left.position.x;
        rightx = right.position.x;
        Destroy(left.gameObject);
        Destroy(right.gameObject);
    }

    void Update()
    {
        Movement();
    }

    void Movement() //敌人移动
    {
        if (faceLeft)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            if (transform.position.x < leftx)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                faceLeft = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if (transform.position.x > rightx)
            {
                transform.localScale = new Vector3(1, 1, 1);
                faceLeft = true;
            }
        }
    }
}
 
