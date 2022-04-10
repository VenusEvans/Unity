using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*这个敌人动画有点多 重新写了一个*/
public class EnemyControl_Gra: MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    BoxCollider2D boxColl;

    public float speed; //敌人速度
    public float jumpForce;
    public LayerMask ground;
    public Transform left;
    public Transform right;
    bool faceLeft = true;
    float leftx;
    float rightx;

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxColl = GetComponent<BoxCollider2D>();
        transform.DetachChildren();
        leftx = left.position.x;
        rightx = right.position.x;
        Destroy(left.gameObject);
        Destroy(right.gameObject);
    }

    void Update()
    {
        //Movement(); //在idle动画添加了动画事件，就不用在update里调用了
        ChangeAnim();
    }

    void Movement() //敌人移动
    {
        if (faceLeft)
        {
            if (boxColl.IsTouchingLayers(ground))
            {               
                rb.velocity = new Vector2(-speed, jumpForce);
                anim.SetBool("isJump", true);
            }
            if (transform.position.x < leftx)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                faceLeft = false;
            }
        }
        else
        {
            if (boxColl.IsTouchingLayers(ground))
            {
                rb.velocity = new Vector2(speed, jumpForce);
                anim.SetBool("isJump", true);
            }
            if (transform.position.x > rightx)
            {
                transform.localScale = new Vector3(1, 1, 1);
                faceLeft = true;
            }
        }
    }

    void ChangeAnim() //改变动画
    {
        if (anim.GetBool("isJump"))
        {
            if (rb.velocity.y < 0.1f)
            {               
                anim.SetBool("isJump",false);
                anim.SetBool("isFall",true);
            }
        }
        if (boxColl.IsTouchingLayers(ground) && anim.GetBool("isFall"))
        {
            anim.SetBool("isFall",false);
        }
    }
}
