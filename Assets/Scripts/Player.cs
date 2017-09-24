using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    Stats s;
    SpriteRenderer sr;
    Rigidbody2D rb;
    Collider2D cder;
    Animator a;
    float timer = 0f;
    AudioSource source;
    public AudioClip landing;
    public AudioClip hit;
    public AudioClip death;
    float dtimer = 0f;
    GameObject health;
    public GameObject gameover;

    // Use this for initialization
    void Start()
    {
        health = transform.FindChild("Health").gameObject;
        health.SetActive(false);
        source = gameObject.GetComponent<AudioSource>();
        s = gameObject.GetComponent<Stats>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        a = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        cder = gameObject.GetComponent<Collider2D>();
        Physics2D.IgnoreLayerCollision(8, 10, true);
        
    }
    void CheckLife()
    {
        for(int i = 0; i < health.transform.childCount; i++)
        {
            GameObject c;
            c = health.transform.GetChild(i).gameObject;
            c.SetActive(false);
        }
        for(int i = 0; (i+1)*25 <= s.GetALife(); i++)
        {
            GameObject c;
            c = health.transform.GetChild(i).gameObject;
            c.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (s.IsAlive() == false)
        {
            /*
            //Destroy enemy when hp <= 0
            if (dtimer == 0)
            {
                gameObject.layer = 10;
                dtimer = 0.45f;
                source.clip = death;
                source.Play();
            }
            //a.Play("playerDeath");
            dtimer -= Time.deltaTime;
            if (dtimer <= 0)
            {
                
                Destroy(gameObject);
            }*/
            gameover.SetActive(true);
            Destroy(gameObject);
        }
        Invicibility();
        

    }
    void Invicibility()
    {
        if (s.IsInvicible() == true)
        {
            CheckLife();
            health.SetActive(true);
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
            health.SetActive(false);
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
                Vector3 center = cder.bounds.center;

                bool right = contactPoint.x < center.x;

                if (right)
                {
                    
                    
                    rb.AddForce(new Vector2(1,1) * s.GetKnockback() , ForceMode2D.Force);
                }else
                {
                    
                    rb.AddForce(new Vector2(-1, 1) * s.GetKnockback() , ForceMode2D.Force);
                }
                source.clip = hit;
                source.Play();
                PlayDamageAnimation();
                s.LoseLife(25);
                CheckLife();
                s.GiveInvicibility();
            }
            

        }
        else if (coll.gameObject.tag == "Ground")
        {
            
            source.clip = landing;
            source.Play();
        }
    }
    public void RunAnimation(bool run)
    {

       a.SetBool("run", run);
    }
    public void PlayDamageAnimation()
    {
        a.Play("damage");
    }
}
