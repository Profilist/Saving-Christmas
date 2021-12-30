using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveItem : MonoBehaviour
{
    [SerializeField] GameObject item;

    public void SpawnItem()
    {
        if (item != null)
        {
            item.GetComponent<SpriteRenderer>().enabled = true;
            item.gameObject.tag = item.name;
            //item.GetComponent<BoxCollider2D>().enabled = true;
        } 
    }
}
