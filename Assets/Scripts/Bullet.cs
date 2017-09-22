using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float bulletSpeed = 100.0f;

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
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
        direction = target - myPos;
        direction.Normalize();
    }

    void FixedUpdate ()
    {
        rb.velocity = direction * bulletSpeed * Time.deltaTime;
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            
            Stats s = coll.gameObject.GetComponent<Stats>();
            if (!s.IsInvicible())
            {
                Rigidbody2D rb = coll.gameObject.GetComponent<Rigidbody2D>();
                rb.AddForce(new Vector2(1, 1) * s.GetKnockback());
                s.LoseLife(10);
                s.GiveInvicibility();
            }
            Destroy(gameObject);
            
        }
        else if (coll.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
