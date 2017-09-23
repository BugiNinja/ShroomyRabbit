using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigShroom : MonoBehaviour {

    Stats s;

    // Use this for initialization
    void Start ()
    {
        GetComponent<SpriteRenderer>();
	}

    // Update is called once per frame
    void Update()
    {
      
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Stats s = coll.gameObject.GetComponent<Stats>();  //coll.gameObject.GetComponent<Stats>();
            s.AddLife(100);
            Destroy(gameObject);          
        }
        else if (coll.gameObject.tag == "Enemy")
        {
            Stats s = coll.gameObject.GetComponent<Stats>();  //coll.gameObject.GetComponent<Stats>();
            s.AddLife(100);
            Destroy(gameObject);
        }
    }

}
