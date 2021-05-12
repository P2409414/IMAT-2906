﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LavaDeath : MonoBehaviour
{
    public GameObject StartPos;
    public GameObject Blackout;
    public Text Lives;
    public GameObject CameraEnd;
    private int LivesValue = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (LivesValue != 1)
        {
            StartCoroutine(Respawn(other.gameObject));
        }
        else
        {
            CameraEnd.SetActive(true);
            Destroy(other.gameObject);
        }
    }

    IEnumerator Respawn(GameObject rb)
    {
        rb.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        for (int i = 0; i < 10; i++)
        {
            Blackout.GetComponent<SpriteRenderer>().color = Blackout.GetComponent<SpriteRenderer>().color + new Color(0, 0, 0, 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
        rb.transform.position = StartPos.transform.position;
        for (int i = 0; i < 10; i++)
        {
            Blackout.GetComponent<SpriteRenderer>().color = Blackout.GetComponent<SpriteRenderer>().color - new Color(0, 0, 0, 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
        rb.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        LivesValue = LivesValue - 1;
        Lives.text = "Lives: " + LivesValue;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.transform.parent = null;
    }
}
