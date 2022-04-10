using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogColl_win : MonoBehaviour
{
    public GameObject winDialog;
    GameObject obj;
    public AudioSource playerAudio;

    private void Update()
    {
        obj = GameObject.FindGameObjectWithTag("Collection"); //查找松果
        //Debug.Log(obj);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (obj == false && collision.tag == "Player") //如果松果没了而且我还在交任务
        {
            playerAudio.mute = true;
            AudioManager.PlayWinAudio();
            winDialog.SetActive(true);
        }
    }
}
