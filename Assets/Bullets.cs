/**
 * ... This script is used to allow bullets to destroy themselves when coming into contact with any other collider. ...
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    private Rigidbody2D rb; //!< Creation of rigidbody variable
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //!< Finding the rigidbody from the gameObject.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(rb.position, 0.2f, ~0); //!< Creating an array of colliders that are nearby
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                Destroy(gameObject);  //!< Destroy the bullet
            }
        }
    }
}
