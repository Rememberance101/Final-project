using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
  public void StartGame()
  {
    //Check in index of which scene the game is in and plus it by 1. Then loads the next scene. 
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }
}
