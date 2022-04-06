using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;
    BoxCollider2D boxcoll;

    [Header("Player移动属性")]
    public float speed; //玩家的移动速度
    private float xVelocity; //玩家x轴力的方向(根据按下键盘左右方向键，值会在-1到1之间浮动)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxcoll = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        MoveControl(); //物理方法最好在FixedUpdate里调用
    }

    void MoveControl() //控制移动的方法
    {
        xVelocity = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(xVelocity * speed, rb.velocity.y); //控制左右移动
    }
}
