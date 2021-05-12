using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Shooting : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject BulletSpawn;
    public Transform MainScene;
    private GameObject Bullets;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (gameObject.transform.parent.transform.localScale.x == 1)
            {
                Bullets = Instantiate(Bullet, BulletSpawn.transform.position, new Quaternion(0, 0, 0, 0), MainScene);
                Bullets.GetComponent<Rigidbody2D>().velocity = new Vector2(40, 0);
            }
            else
            {
                Bullets = Instantiate(Bullet, BulletSpawn.transform.position, new Quaternion(0, 0, 0, 0), MainScene);
                Bullets.GetComponent<Rigidbody2D>().velocity = new Vector2(-40, 0);
            }
        }
    }

    void FixedUpdate()
    {
    }
}
