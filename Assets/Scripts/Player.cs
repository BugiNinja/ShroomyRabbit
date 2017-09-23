using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    Stats s;
    SpriteRenderer sr;
    Rigidbody2D rb;
    Collider2D collider;
    float timer = 0f;
    // Use this for initialization
    void Start()
    {
        s = gameObject.GetComponent<Stats>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        collider = gameObject.GetComponent<Collider2D>();
        Physics2D.IgnoreLayerCollision(8, 10, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (s.IsAlive() == false)
        {
            //Destroy enemy when hp <= 0
            Destroy(gameObject);
        }
        Invicibility();

    }
    void Invicibility()
    {
        if (s.IsInvicible() == true)
        {
            gameObject.layer = 10; //Move to invicible layer
            //invicible visual effect
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                if (sr.enabled)
                {
                    sr.enabled = false;
                    timer = 0.1f;
                }
                else
                {
                    sr.enabled = true;
                    timer = 0.1f;
                }
            }
        }
        else
        {
            
            gameObject.layer = 8; //Back to character layer
            sr.enabled = true;
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {

            
            if (!s.IsInvicible())
            {
                rb.velocity = new Vector2(0, 0);
                //rb.AddForce(transform.up * s.GetKnockback(), ForceMode2D.Force);
               
                Vector3 contactPoint = coll.contacts[0].point;
                Vector3 center = collider.bounds.center;

                bool right = contactPoint.x < center.x;

                if (right)
                {
                    Debug.Log("oikea");
                    
                    rb.AddForce(new Vector2(10,1) * s.GetKnockback() , ForceMode2D.Force);
                }else
                {
                    Debug.Log("Vasen");
                    rb.AddForce(new Vector2(-10, 1) * s.GetKnockback() , ForceMode2D.Force);
                }
                    
                
                s.LoseLife(10);
                s.GiveInvicibility();
            }
            

        }
        else if (coll.gameObject.tag == "Ground")
        {
            
        }
    }
}
