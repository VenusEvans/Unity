using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*这是一个异步场景加载，我的游戏内存占用率特别小就不使用啦*/
public class LoadSceneManager : MonoBehaviour
{
    public GameObject loadPanel;
    public Text text;
   
    public void loadScene()
    {
        StartCoroutine(loadNextLevel());
    }

    IEnumerator loadNextLevel()
    {
        loadPanel.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        operation.allowSceneActivation = false;
        if (!operation.isDone)
        {
            if (operation.progress >= 0.9f)
            {
                text.text = "PRESS ANYKEY TO CONTINUE";
                if (Input.anyKeyDown)
                {
                    operation.allowSceneActivation = true;
                }
            }
            
        }
        yield return null;

    }
}
