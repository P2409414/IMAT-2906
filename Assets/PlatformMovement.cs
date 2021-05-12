/**
 * ... This script is used to make the moving platforms go between two points and allow the player to move with it. ...
 */

using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private Transform pointA; //!< Creation of the first point to travel to.
    private Transform pointB; //!< Creation of the second point to travel to.
    private int point; //!< Creation of an int to know which point is being travelled to by number instead of by position.
    private Vector3 currentTarget; //!< Creation of a vector3 to store the currenttarget position.
    private float speed; //!< Creation of a float for the speed the enemy will move at.
    private float allowedspeed; //!< Creation of a float for the maximum speed the enemy can move at.
    private float delayStart; //!< Creation of a float to have a set delay for movement after reaching a point.
    public float delayTimer; //!< Creation of a float to keep the current delay time.
    // Start is called before the first frame update
    void Start()
    {
        pointA = this.transform.parent.Find("PointA").transform; //!< Finding the position of the first point
        pointB = this.transform.parent.Find("PointB").transform; //!< Finding the position of the second point
        point = 1; //!< Setting the value of point to 1 to know which is being travelled to
        speed = 6f; //!< Setting the speed of the enemy
        allowedspeed = speed * Time.deltaTime; //!< Setting the allowed speed depending on the deltatime
        currentTarget = pointB.position; //!< Setting the current point that is being moved to
        delayTimer = 2f; //!< Setting the delay between reaching a point and moving to the next
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (transform.position != currentTarget)
        {
            transform.position += ((currentTarget - transform.position) / (currentTarget - transform.position).magnitude) * speed * Time.deltaTime;
            if ((currentTarget - transform.position).magnitude < allowedspeed)
            {
                transform.position = currentTarget;
                delayStart = Time.time;
            }
        }
        else
        {
            if (Time.time - delayStart > delayTimer)
            {
                if (point == 1)
                {
                    point = 2;
                    currentTarget = pointA.position;
                }
                else
                {
                    point = 1;
                    currentTarget = pointB.position;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.parent = transform;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.transform.parent = null;
    }
}
