using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    

   private void OnTriggerEnter2D(Collider2D collision)
   {
        // if the player is trouching the platform the player will stick to it and the player will move with the platform by transforming the player position.
        if(collision.gameObject.name == "Player")
        {
            //make the player a child object of the platform.
            collision.gameObject.transform.SetParent(transform);
        }
   }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //check if the player leaves the platform and reset it back to not being a child of the object
        if(collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
   
}
