using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Transform pointA;
    private Transform pointB;
    private Rigidbody2D rb;
    private int point;
    private Vector3 currentTarget;
    private float speed;
    private float allowedspeed;
    private float delayStart;
    public float delayTimer;
    private bool move = true;
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
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(rb.position, 5f, LayerMask.GetMask("Character"));
        if (colliders.Length == 0)
        {
            if (currentTarget == pointA.position && transform.localScale.x == 1)
            {
                Vector3 theScale = transform.localScale;
                theScale.x = -1;
                transform.localScale = theScale;
            }
            if (currentTarget == pointB.position && transform.localScale.x == -1)
            {
                Vector3 theScale = transform.localScale;
                theScale.x = 1;
                transform.localScale = theScale;
            }
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
                    else if (point == 2)
                    {
                        point = 1;
                        currentTarget = pointB.position;
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject && colliders[i].gameObject.name == "Soldier")
                {
                    print("Shooting at Player");
                }
                else
                {
                    print("Enemy Hit");
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
