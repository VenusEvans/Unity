using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    public Button[] levelButtons;
    private void Start()
    {
        int unlockLevel = PlayerPrefs.GetInt("unlockLevel",1); //解锁关卡数
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > unlockLevel)
            {
                levelButtons[i].interactable = false;
            }
        }
    }
}
