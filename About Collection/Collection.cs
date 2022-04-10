using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collection : MonoBehaviour
{
    public int cherry;
    public Text textCherryNum;

    private void OnTriggerEnter2D(Collider2D collision) //收集物品 触发器
    {
        if(collision.tag== "Collection")
        {
            AudioManager.PlayCollectionAudio();
            Destroy(collision.gameObject);
            cherry++;
            textCherryNum.text = cherry.ToString();
        }

        if (collision.tag == "GameOver")
        {
            gameObject.GetComponent<AudioSource>().mute = true; //禁用声音组件 不播放主音乐 要播放下面的掉落音频
            AudioManager.PlayGameOverAudio();
            Invoke("Restart", 4f); //延时调用方法
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //重新加载场景
    }
}
