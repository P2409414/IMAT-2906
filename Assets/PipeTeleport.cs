/**
 * ... This script is used to get the press of the down axis and move the player to another pipe. ...
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeTeleport : MonoBehaviour
{
    public GameObject TeleportPos;
    float UporDown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UporDown = Input.GetAxisRaw("Vertical"); //!< Gets the input vertical input axis
    }

    private void OnTriggerStay2D(Collider2D other) //!< If the player is on the pipe and presses down it will activate this and change their position to just above another pipe.
    {
        if (UporDown < 0)
        {
            other.transform.position = TeleportPos.transform.position;
        }
    }
}
