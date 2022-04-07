using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    Animator anim;
    PlayerMovement movement;

    int speedID;
    int isJumpID;
    int isCrouchID;

    void Start()
    {
        anim = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>(); //为了让两个代码可以互相访问 要获取另一个代码（代码也是一个组件）

        /*根据手册介绍，将Parameters中的属性转换为Int型兼容性更好*/
        speedID = Animator.StringToHash("Speed");
        isJumpID = Animator.StringToHash("isJump");
        isCrouchID = Animator.StringToHash("isCrouch");
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
    }


}
