using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SceneControl : MonoBehaviour
{
    public GameObject pauseMenu;

    void Awake()
    {
        //DontDestroyOnLoad(gameObject); //即使切换了场景 也不会摧毁当前游戏物体
    }

    public void NextScene() //下一个场景
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //加载当前游戏场景的下一个场景
    }

    public void OpenPauseMenu() //打开暂停菜单
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0; //设置成0就会停止游戏 反之1会恢复游戏
        
    }

    public void ClosePauseMenu() //关闭暂停菜单
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void UpScene() //上一个场景
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
