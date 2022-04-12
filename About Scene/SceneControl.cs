using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public GameObject pauseMenu;

    void Awake()
    {
        //DontDestroyOnLoad(gameObject); //即使切换了场景 也不会摧毁当前游戏物体
    }

    public void ResetGame() //恢复游戏 暂停菜单后在进入下一关游戏还是停止的 需要在添加一个onclick事件
    {
        Time.timeScale = 1;
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

    public void QuitGame() //退出游戏
    {
        Application.Quit();
    }

    public void ReturnSelectLevel() //返回选择界面
    {
        SceneManager.LoadScene("SelectLevel");
    }

    public void Level1_1()
    {
        SceneManager.LoadScene("Level01_1");
    }

    public void Level1_2()
    {
        SceneManager.LoadScene("Level01_2");
    }

    public void Level1_3()
    {
        SceneManager.LoadScene("Level01_3");
    }
}
