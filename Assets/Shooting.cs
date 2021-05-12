/**
 * ... This script is used to allow the player to shoot, it also instantiates the bullets and moves them in the direction the character is facing. ...
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Shooting : MonoBehaviour
{
    public GameObject Bullet;  //!< Creation of variables used to instantiate the bullets
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
        if (Input.GetKeyDown("space"))  //!< Looking for the space key being pressed once
        {
            if (gameObject.transform.parent.transform.localScale.x == 1)
            {
                Bullets = Instantiate(Bullet, BulletSpawn.transform.position, new Quaternion(0, 0, 0, 0), MainScene);  //!< If the player is facing right the bullet will move right
                Bullets.GetComponent<Rigidbody2D>().velocity = new Vector2(40, 0);
            }
            else
            {
                Bullets = Instantiate(Bullet, BulletSpawn.transform.position, new Quaternion(0, 0, 0, 0), MainScene);  //!< If the player is facing left the bullet will move left.
                Bullets.GetComponent<Rigidbody2D>().velocity = new Vector2(-40, 0);
            }
        }
    }

    void FixedUpdate()
    {
    }
}
