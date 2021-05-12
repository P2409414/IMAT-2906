using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagEnd : MonoBehaviour
{

    public GameObject CameraEnd;
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
        CameraEnd.SetActive(true);
        Destroy(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.transform.parent = null;
    }
}
