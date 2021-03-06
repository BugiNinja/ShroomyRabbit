﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

	private Rigidbody2D myRigidBody;

	public float movSpeed;

	public float jumpPower;
    public AudioClip jump;
    AudioSource source;

    Player pl;

	// Use this for initialization
	void Start () 
	{
        source = gameObject.GetComponent<AudioSource>();
        pl = gameObject.GetComponent<Player>();
		myRigidBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
        //Input & call movement void
        
        float horizontal = Input.GetAxis ("Horizontal");
        if(horizontal != 0)
        {
            pl.RunAnimation(true);
        }
        else
        {
            pl.RunAnimation(false);
        }
		movement (horizontal);
	}

	void OnCollisionStay2D(Collision2D coll)
	{
        //Ground check & jump
        if (coll.gameObject.tag == "Ground" && Input.GetKey ("space")) 
		{
            source.clip = jump;
            source.Play();
			myRigidBody.AddForce(Vector2.up * jumpPower, ForceMode2D.Force);
		}
        if (coll.gameObject.tag == "Wall")
        {
            myRigidBody.velocity = new Vector3(0, 0, 0);
        }
	}

	private void movement(float horizontal)
	{
        //Movement
        myRigidBody.velocity = new Vector2(horizontal * movSpeed, myRigidBody.velocity.y); //-Vector2.right
	} 
}
