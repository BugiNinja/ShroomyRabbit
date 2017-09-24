using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {

    public float enemySpeed;

    public float enemyHealth;

    private Rigidbody2D enemyBody;

    //private Transform myTrans;

    private SpriteRenderer sr;

    public bool left;

    public bool faster;
   
	// Use this for initialization
	void Start ()
    {
        left = false;

        faster = false;

        enemyHealth = 10;

        enemyBody = this.GetComponent<Rigidbody2D>();

        sr = this.GetComponent<SpriteRenderer>();

        //myTrans = this.transform;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (faster == false)
        {
            if (left == false)
            {
                //Move right
                enemySpeed = 5;
                Vector2 enemyVel = enemyBody.velocity;
                enemyVel.x = enemySpeed;
                enemyBody.velocity = enemyVel;
                sr.flipX = false;
            }
            else if (left == true)
            {
                //Move left
                enemySpeed = -5;
                Vector2 enemyVel = enemyBody.velocity;
                enemyVel.x = enemySpeed;
                enemyBody.velocity = enemyVel;
                sr.flipX = true;
            }
        }
        else if (faster == true)
        {
            if (left == false)
            {
                //Move right
                enemySpeed = 15;
                Vector2 enemyVel = enemyBody.velocity;
                enemyVel.x = enemySpeed;
                enemyBody.velocity = enemyVel;
                sr.flipX = false;
            }
            else if (left == true)
            {
                //Move left
                enemySpeed = -15;
                Vector2 enemyVel = enemyBody.velocity;
                enemyVel.x = enemySpeed;
                enemyBody.velocity = enemyVel;
                sr.flipX = true;
            }
        }
    }


        void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag != "Wall")
        {
            if (coll.gameObject.tag == "Enemy")
            {
                if (left == false)
                {
                    left = true;
                }
                else if (left == true)
                {
                    left = false;
                }
            }
        }
        }
        void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Wall")
        {
                if (left == false)
                {
                    left = true;
                }
                else if (left == true)
                {
                    left = false;
                }
        }
        }
}
