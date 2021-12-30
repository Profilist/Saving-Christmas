using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int candyCanes = 0;
    private int mistletoes = 0;
    private int presents = 0;

    [SerializeField] private Text candyCaneCounter;
    [SerializeField] private Text mistletoeCounter;
    [SerializeField] private Text presentCounter;

    [SerializeField] private AudioSource collectEFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Candy Cane"))
        {
            collectEFX.Play();
            Destroy(collision.gameObject);
            candyCanes++;
            candyCaneCounter.text = "Candy Canes: " + candyCanes + "/4";
        }
        if (collision.gameObject.CompareTag("Mistletoe"))
        {
            collectEFX.Play();
            Destroy(collision.gameObject);
            mistletoes++;
            mistletoeCounter.text = "Mistletoes: " + mistletoes + "/2";
        }
        if (collision.gameObject.CompareTag("Present"))
        {
            collectEFX.Play();
            Destroy(collision.gameObject);
            presents++;
            presentCounter.text = "Presents: " + presents + "/2";
        }
    }
}
