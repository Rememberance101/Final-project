using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    
    // makes an array of waypoints so it can be reused with many moving playforms
    [SerializeField] private GameObject[] waypoints;
    // keeps the current waypoints index
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 2f;

    // Update is called once per frame
    private void Update()
    {
        // checks the distance from the platform to the waypoint it has to move
        if(Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            //increments the waypoint index
            currentWaypointIndex++;
            //reset it back to 0 so the platform will move back again
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex =0;
            }
        }
        //move the platfrom frame by frame with time.  Moving the platfrom with delta time will make sure it always move at the same speed no matter the devices frame speed
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
