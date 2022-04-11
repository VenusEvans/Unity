using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collection : MonoBehaviour
{
    public int cherry;
    public Text textAcronNum;

    public Text textPlayerHPNum;
    PlayerAnimation HPNum;
    PlayerMovement movement;
    BoxCollider2D boxcoll;

    private void Start()
    {
        boxcoll = GetComponent<BoxCollider2D>();
        HPNum = GetComponent<PlayerAnimation>();
        movement = GetComponent<PlayerMovement>();
        
    }
    private void Update()
    {
        textPlayerHPNum.text = HPNum.HP.ToString();
        Die();
    }
    private void OnTriggerEnter2D(Collider2D collision) //收集物品 触发器
    {
        if(collision.tag== "Collection")
        {
            AudioManager.PlayCollectionAudio();
            Destroy(collision.gameObject);
            cherry++;
            textAcronNum.text = cherry.ToString();
        }

        if (collision.tag == "GameOver")
        {
            gameObject.GetComponent<AudioSource>().mute = true; //禁用声音组件 不播放主音乐 要播放下面的掉落音频
            AudioManager.PlayGameOverAudio();
            Invoke("Restart", 4f); //延时调用方法
        }
    }

    void Die() //当血量下降到0时进行的操作
    {
        if (movement.isHurt == true)
        {
            if (HPNum.HP == 0)
            {
                HPNum.isDie = true;
                boxcoll.enabled = false;
                gameObject.GetComponent<AudioSource>().mute = true;
                AudioManager.PlayGameOverAudio();
                Invoke("Restart", 4f);
            }
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //重新加载场景
    }
}
