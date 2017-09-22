using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

	private Rigidbody2D myRigidBody;

	public float movSpeed;

	public float jumpPower;

	// Use this for initialization
	void Start () 
	{
		myRigidBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
        //Input & call movement void

        float horizontal = Input.GetAxis ("Horizontal");

		movement (horizontal);
	}

	void OnCollisionStay2D(Collision2D coll)
	{
        //Ground check & jump
        if (coll.gameObject.tag == "Ground" && Input.GetKey ("space")) 
		{
			myRigidBody.AddForce(Vector2.up * jumpPower, ForceMode2D.Force);
		}
	}

	private void movement(float horizontal)
	{
        //Movement
        myRigidBody.velocity = new Vector2(horizontal * movSpeed, myRigidBody.velocity.y); //-Vector2.right
	} 
}
