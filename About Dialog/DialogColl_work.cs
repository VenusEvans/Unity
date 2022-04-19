using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogColl_work: MonoBehaviour
{
    public GameObject tipDialog;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            tipDialog.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            tipDialog.SetActive(false);
        }
    }
}
