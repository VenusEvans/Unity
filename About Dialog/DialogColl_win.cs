using UnityEngine;

public class DialogColl_win : MonoBehaviour
{
    public int levelToUnlock;
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
            Time.timeScale = 0;
            playerAudio.mute = true;
            winDialog.SetActive(true);
            AudioManager.PlayWinAudio();
            PlayerPrefs.SetInt("unlockLevel", levelToUnlock); //储存通关数
        }
    }
}
