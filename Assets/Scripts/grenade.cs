using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenade : MonoBehaviour {

    public float ExplosionTime = 4;

    float grenadeTimer;

    public float launchForce = 300.0f;

    Vector2 target;

    Vector2 direction;

    Rigidbody2D rb;


    void Start()
    {
        grenadeTimer = ExplosionTime;

        rb = gameObject.GetComponent<Rigidbody2D>();

        Launch();
    }
    void Launch()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
        direction = target - myPos;
        direction.Normalize();
        rb.AddForce(direction * launchForce);
    }
    void Update()
    {
        grenadeTimer -= Time.deltaTime;
        if(grenadeTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {

        }
        



    }
}
