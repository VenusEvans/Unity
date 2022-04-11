using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartVideoToNextScene : MonoBehaviour
{
    float time;
    private void Update()
    {
        StartToNext();
    }
    public void StartToNext()
    {
        time += Time.deltaTime;
        if (time > 2.5f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    /*想用协程自动跳转但是不好使*/
    //void Start()
    //{
    //    StartCoroutine("StartToNext");
    //}
    //IEnumerable StartToNext()
    //{

    //    yield return new WaitForSeconds(2.5f);
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //}
}
