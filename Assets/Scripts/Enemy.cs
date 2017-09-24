using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    Stats s;
    Door d;
    SpriteRenderer sr;
    float timer = 0f;
    float dtimer = 0f;
    Animator a;
    AudioSource source;
    public AudioClip dies;
    public GameObject health;


    // Use this for initialization
    void Start ()
    {
        health = transform.FindChild("Health").gameObject;
        health.SetActive(false);
        s = gameObject.GetComponent<Stats>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        a = gameObject.GetComponent<Animator>();
        source = gameObject.GetComponent<AudioSource>();
        

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (s.IsAlive() == false)
        {

            if (dtimer == 0)
            {
                gameObject.layer = 10;
                dtimer = 0.45f;
                source.clip = dies;
                source.Play();
            }
            //Destroy enemy when hp <= 0
            a.Play("turtleDeath");
            dtimer -= Time.deltaTime;
            if (dtimer <= 0)
            {
                Destroy(gameObject);
            }

        }
        else
        {
            Invicibility();
        }
        
	}
    void CheckLife()
    {
        for (int i = 0; i < health.transform.childCount; i++)
        {
            GameObject c;
            c = health.transform.GetChild(i).gameObject;
            c.SetActive(false);
        }
        for (int i = 0; (i+1) * 25 <= s.GetALife(); i++)
        {
            GameObject c;
            c = health.transform.GetChild(i).gameObject;
            c.SetActive(true);
        }
    }
    void Invicibility()
    {
        if (s.IsInvicible() == true)
        {
            CheckLife();
            //health.SetActive(true);
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
    public void PlayHitSound()
    {
        source.Play();
    }
}
