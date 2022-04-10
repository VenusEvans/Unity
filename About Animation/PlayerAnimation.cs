using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    PlayerMovement movement;

    int speedID;
    int isJumpID;
    int isCrouchID;
    int isHurtID;
    public float jumpForce;
    public float force;

    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>(); //为了让两个代码可以互相访问 要获取另一个代码（代码也是一个组件）

        /*根据手册介绍，将Parameters中的属性转换为Int型兼容性更好*/
        speedID = Animator.StringToHash("Speed");
        isJumpID = Animator.StringToHash("isJump");
        isCrouchID = Animator.StringToHash("isCrouch");
        isHurtID = Animator.StringToHash("isHurt");
    }

    void Update()
    {
        AnimControl();
    }

    void AnimControl() //动画播放方法
    {
        anim.SetFloat(speedID, Mathf.Abs(movement.xVelocity));
        anim.SetBool(isJumpID, movement.isJump);
        anim.SetBool(isCrouchID, movement.isCrouch);
        anim.SetBool(isHurtID, movement.isHurt);

    }

    private void OnCollisionEnter2D(Collision2D collision) //与敌人碰撞 写在了动画脚本里有点乱 能力不到位 后期有能力后调整
    {

        if (collision.gameObject.tag == "Enemy") //如果碰撞的tag为Enemy
        {
            //EnemyControl_Gra deathAnim=collision.gameObject.GetComponent<EnemyControl_Gra>(); //调用其他脚本内的函数
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            movement.isHurt = true;

            if (anim.GetBool(isJumpID)) //如果是跳跃的动画
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce); //想让玩家在踩掉怪物后跳一下，不知道为什么不好使 /好了！！！！！！！！ 之间的deltaTime没用
                //deathAnim.Death();
                enemy.Death();
                anim.SetBool(isJumpID, movement.isJump);
                movement.isHurt = false;
            }
        }
        else
        {
            movement.isHurt = false;
        }
    }
}

