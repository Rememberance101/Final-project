using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;


public class ItemCollector : MonoBehaviour
{
    // Items collected starts at 0
    private int kiwis = 0;

    [SerializeField]
    public TextMeshProUGUI kiwisText;


    //collect sound 
   [SerializeField] private AudioSource collectionSoundEffect;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
       //collect item increament item counter then destroy it also play sound
        if (collision.gameObject.CompareTag("Kiwi"))
        {
           collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            kiwis++;
            kiwisText.text = "Kiwis " + kiwis;
        }
    }
}
