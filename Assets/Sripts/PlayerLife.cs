using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    
    //referance to animator
    private Animator anim;
    //refrance to rigidbody
    private Rigidbody2D rb;
    
    //death sound source
    [SerializeField] private AudioSource deathSoundEffect;
    
    // Start is called before the first frame update
    private void Start()
    {
        // referance to the animator
        anim = GetComponent<Animator>();
        // get rigidbody
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if player collides with something with the trap tag
        if(collision.gameObject.CompareTag("Trap"))
        {
            
            Die();
        }
    }

    private void Die()
    {
        // play death sound
        deathSoundEffect.Play();
        //move to death animation
        anim.SetTrigger("death");

        //When player dies change rigidbody to static so player can't move any more
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void RestartLevel()
    {
       //reloads the sence when play dies
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        
    }

    private void AliveAgain()
    {
        //Change rigidbody back to Dynamic
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
