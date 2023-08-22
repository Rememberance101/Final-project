using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    [SerializeField]
    private Transform player;
    // Update is called once per frame
    private void Update()
    {
        //This code in is the camera control script in the update function. This code will need a Vector 3 instead of a vector 2. This is because the camera is always at a Z position of -10. 
//This script is attached to the main camera with a serializedfield so that I can attach the player to this. This will cause the camera to follow the player at all times. This will transform the camera’s position according to the player’s position. 

        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
