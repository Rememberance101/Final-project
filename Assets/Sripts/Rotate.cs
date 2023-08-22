using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // rotates any object used for the saws
    [SerializeField] private float speed = 2f;

    // Update is called once per frame
    private void Update()
    {
        //rotates the object on the z value. This give it the inllutions of on animation.
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
    }
}
