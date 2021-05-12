using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private Transform pointA;
    private Transform pointB;
    private int point;
    private Vector3 currentTarget;
    private float speed;
    private float allowedspeed;
    private float delayStart;
    public float delayTimer;
    // Start is called before the first frame update
    void Start()
    {
        pointA = this.transform.parent.Find("PointA").transform;
        pointB = this.transform.parent.Find("PointB").transform;
        point = 1;
        speed = 6f;
        allowedspeed = speed * Time.deltaTime;
        currentTarget = pointB.position;
        delayTimer = 2f;
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
