using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{   

    private AudioSource finishSound;
    

    // check if level completed and if true play sound only once
    private bool levelCompleted = false;
   private void Start()
    {
        // get componet to play the sound
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        // check if level completed and if true play sound only once
        if(collision.gameObject.name == "Player" && !levelCompleted)
        {
             //play sound for finishing the level
            finishSound.Play();
            //wait 2 second before loading next level
            Invoke("CompleteLevel", 2f);
            // level complete function
            //CompleteLevel();
            levelCompleted = true;
        }
       
    }

    private void CompleteLevel()
    {
        //load next level or next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
