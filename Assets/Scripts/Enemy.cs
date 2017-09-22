﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    Stats s;
    SpriteRenderer sr;
    float timer = 0f;
	// Use this for initialization
	void Start ()
    {
        s = gameObject.GetComponent<Stats>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreLayerCollision(8, 10, true); //siirrä myöhemmin järkevämpään paikkaan
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(s.IsAlive() == false)
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
}