using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {

    private float enemySpeed;

    public float enemyHealth;

    private Rigidbody2D enemyBody;

    private Transform myTrans;

    public bool left;
   
	// Use this for initialization
	void Start ()
    {
        left = false;

        enemyHealth = 10;

        enemyBody = this.GetComponent<Rigidbody2D>();

        myTrans = this.transform;
    }

    // Update is called once per frame
	void FixedUpdate ()
    {
        if (left == false)
        {
            //Move right
            enemySpeed = 5;
            Vector2 enemyVel = enemyBody.velocity;
            enemyVel.x = enemySpeed;
            enemyBody.velocity = enemyVel;
        }
        else if (left == true)
        {
            //Move left
            enemySpeed = -5;
            Vector2 enemyVel = enemyBody.velocity;
            enemyVel.x = enemySpeed;
            enemyBody.velocity = enemyVel;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (left == false)
        {
            left = true;
        }
        else if (left == true)
        {
            left = false;
        }
        /*            else if (left = true)
                    {
                        left = false;
                    }
                }
        */
    }
}
