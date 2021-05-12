/**
 * ... This script is used to hide the pickup once touched and set the player's weapon to active. ...
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)//!< On the player touching the object the gameobject is set to false and the player weapon is set to true.
    {
        this.gameObject.SetActive(false);
        other.gameObject.transform.Find("Weapons_0").gameObject.SetActive(true);
    }
}
