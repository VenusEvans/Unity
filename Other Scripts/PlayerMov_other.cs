using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov_other : MonoBehaviour
{

    Rigidbody2D rb;
    BoxCollider2D boxcoll;

    public LayerMask ground;

    [Header("Player状态")]
    public bool isJump;
    public bool isOnGround;
    public bool isCrouch;
    public bool isTopGro;
    public bool isHurt;
    public bool isFall;

    [Header("Player移动相关属性")]
    public float speed; //玩家的移动速度
    public float xVelocity; //玩家x轴力的方向
    public float jumpForce;//跳跃的力
    public float crouchSpeed = 4f; //下蹲时除以这个数使速度减慢
    float faceDircetion; //玩家的朝向

    /*Player碰撞体的尺寸*/
    Vector2 collStandSize;
    Vector2 collStandOffset;
    Vector2 collCrouchSize;
    Vector2 collCrouchOffset;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxcoll = GetComponent<BoxCollider2D>();

        /*初始化下蹲所用到的数据*/
        collStandSize = boxcoll.size;
        collStandOffset = boxcoll.offset;
        collCrouchSize = new Vector2(boxcoll.size.x, boxcoll.size.y * 0.5f);
        //collCrouchOffset = new Vector2(boxcoll.offset.x, boxcoll.offset.y * 0.5f);
        collCrouchOffset = new Vector2(boxcoll.offset.x, boxcoll.offset.y - boxcoll.size.y / 4f); //百度的解决方案，用上面那个会出现减少下面的情况

    }

    void Update()
    {
        ifJump();
    }

    void FixedUpdate()
    {
        if (!isHurt) //如果不受伤
        {
        MoveControl(); //物理方法最好在FixedUpdate里调用 
        }
    }

    void MoveControl() //控制移动的方法
    {
        RaycastHit2D top = Raycast(new Vector2(0, boxcoll.size.y), Vector2.up, 0.5f, ground); //射线检测

        if (top) //如果头上有东西
        {
            isTopGro = true;
        }
        else
        {
            isTopGro = false;
        }

        if (Input.GetButton("Crouch") && isOnGround && !isCrouch) //判断下蹲时的操作
        {
            CrouchCollControl();
        }
        else if (!Input.GetButton("Crouch") && isCrouch && !isTopGro)
        {
            StandUpCollControl();
        }
        xVelocity = Input.GetAxis("Horizontal"); //根据按下键盘左右方向键，值会在-1到1之间浮动
        if (isCrouch) //如果蹲下 减速
        {
            xVelocity /= crouchSpeed;
        }


        rb.velocity = new Vector2(xVelocity * speed, rb.velocity.y); //控制玩家左右移动
        faceDircetion = Input.GetAxisRaw("Horizontal"); //这个方法不同于上面，他的值是-1，0，1，是三个固定值
        if (faceDircetion != 0)
        {
            transform.localScale = new Vector3(faceDircetion, 1, 1); //控制玩家的朝向
        }


    }

    void JumpControl() //控制跳跃
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioManager.PlayJumpAudio();
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void ifJump() //跳跃判断
    {
        if (rb.IsTouchingLayers(ground)) //判断跳跃
        {
            isJump = false;
            isOnGround = true;
            isFall = false;
            JumpControl();
        }
        else if (rb.velocity.y < 0)
        {
            isFall = true;
            isJump = false;
            isOnGround = false;
        }
        else  //if (rb.velocity.y != 0)
        {
            isJump = true;
            isFall = false;
            isOnGround = false;
        }
    }

    void CrouchCollControl() //下蹲时改变碰撞体参数
    {
        isCrouch = true;

        boxcoll.size = collCrouchSize;
        boxcoll.offset = collCrouchOffset;
    }

    void StandUpCollControl() //站起后恢复原有碰撞体尺寸
    {
        isCrouch = false;
        boxcoll.size = collStandSize;
        boxcoll.offset = collStandOffset;
    }

    RaycastHit2D Raycast(Vector2 offset, Vector2 rayDirection, float length, LayerMask layer) //重写射线方法
    {
        Vector2 position = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(position + offset, rayDirection, length, layer);
        Color color = hit ? Color.red : Color.green;
        Debug.DrawRay(position + offset, rayDirection * length, color);
        return hit;
    }

    private void OnCollisionExit2D(Collision2D collision) //如果不碰敌人了 isHurt设置成false
    {
        if (collision.gameObject.tag == "Enemy")
        {
            isHurt = false;
        }
    }
}
