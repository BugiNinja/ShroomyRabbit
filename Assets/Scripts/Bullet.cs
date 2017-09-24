using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float bulletSpeed = 800.0f;
    public bool enemyBullet;
    Vector2 target;

    Vector2 direction;

    Rigidbody2D rb;
    



    void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();


        BulletDirection();
    }
    void BulletDirection()
    {
        if (!enemyBullet)
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
            direction = target - myPos;
            direction.Normalize();
        }else
        {
            target = GameObject.FindGameObjectWithTag("Player").transform.position;
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
            direction = target - myPos;
            direction.Normalize();
        }
    }

    void FixedUpdate ()
    {
        rb.velocity = direction * bulletSpeed * Time.deltaTime;
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == 8)
        {
            if (coll.gameObject.tag == "Untagged")
            {
                Destroy(coll.gameObject);
                Destroy(gameObject);
            }
            else
            {
                
                if(coll.gameObject.tag == "Enemy")
                {
                    Enemy e = coll.gameObject.GetComponent<Enemy>();
                    e.PlayHitSound();
                    
                }
                Stats s = coll.gameObject.GetComponent<Stats>();
                Rigidbody2D rb = coll.gameObject.GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(0, 0);
                rb.AddForce(new Vector2(1, 1) * s.GetKnockback());
                
                s.LoseLife(25);
                s.GiveInvicibility();
                
                Destroy(gameObject);
            }
            
        }
        else if (coll.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
