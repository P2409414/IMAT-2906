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
        UporDown = Input.GetAxisRaw("Vertical");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (UporDown < 0)
        {
            other.transform.position = TeleportPos.transform.position;
        }
    }
}
