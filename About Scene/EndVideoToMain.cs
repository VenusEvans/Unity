using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndVideoToMain : MonoBehaviour
{
    float time;
    void Update()
    {
        EndToMain();
    }

    public void EndToMain()
    {
        time += Time.deltaTime;
        if (time > 12.5f)
        {
            SceneManager.LoadScene("Main");
        }
    }
}
