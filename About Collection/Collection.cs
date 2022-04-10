using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*简单的收集物品*/
public class Collection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) //收集物品 触发器
    {
        if(collision.tag== "Collection")
        {
            AudioManager.PlayCollectionAudio();
            Destroy(collision.gameObject);
        }
    }
}
