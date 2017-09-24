using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGun : MonoBehaviour {

    enemyMovement em;

    public bool rotateUp = false;

    bool foundPlayer = false;

    float searchTimer;

    public float shootDelay = 1;
    float shootTimer;

    public GameObject eBulletPrefab;

    SpriteRenderer sr;

    Transform player;

    Transform muzzle;

    Transform flipper;

    SpriteRenderer srEnemy;

    // Use this for initialization
    void Start ()
    {
        em = gameObject.GetComponentInParent<enemyMovement>();
        muzzle = transform.GetChild(0);
        sr = gameObject.GetComponent<SpriteRenderer>();
        srEnemy = transform.parent.parent.GetComponent<SpriteRenderer>();
        shootTimer = shootDelay;
        flipper = transform.parent.transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
        RotateGun();
        LookForPlayer();
        Shoot();
	}
    void RotateGun()
    {
        if (foundPlayer)
        {

            Vector3 diff = player.position - transform.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

            if (srEnemy.flipX == true)
            {
                sr.flipY = true;
                sr.flipX = false;
                flipper.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                sr.flipY = true;
                sr.flipX = true;
                flipper.localScale = new Vector3(1, 1, 1);
            }

        }
        else if (em.left == true)
        {
            if (transform.rotation.eulerAngles.z > 180)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 90);
            }

            if (rotateUp)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z - 1.0f);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + 1.0f);
            }

            if (transform.rotation.eulerAngles.z < 10.0f && transform.rotation.eulerAngles.z > 5f)
            {
                rotateUp = false;

            }
            else if (transform.rotation.eulerAngles.z > 110.0f && transform.rotation.eulerAngles.z < 130f)
            {
                rotateUp = true;
            }
        }
        else if (em.left == false)
        {

            if (transform.rotation.eulerAngles.z < 180)
            {

                transform.rotation = Quaternion.Euler(0f, 0f, 270);
            }
            if (rotateUp)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + 1.0f);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z - 1.0f);
            }

            if (transform.rotation.eulerAngles.z > 360 - 10.0f && transform.rotation.eulerAngles.z < 360 - 5f)
            {
                rotateUp = false;

            }
            else if (transform.rotation.eulerAngles.z < 360 - 110.0f && transform.rotation.eulerAngles.z > 360 - 130f)
            {
                rotateUp = true;
            }
        }
        if (!foundPlayer)
        {
            if (transform.rotation.eulerAngles.z < 180)
            {
                sr.flipY = true;
                flipper.localScale = new Vector3(-1, 1, 1);
            }
            else if (transform.rotation.eulerAngles.z > 180)
            {
                sr.flipY = true;
                //sr.flipX = false;
                flipper.localScale = new Vector3(1, 1, 1);
            }
        }

    }
    void LookForPlayer()
    {
        Vector2 diff =  muzzle.position - transform.position;
        diff.Normalize();
        RaycastHit2D hit = Physics2D.Raycast(muzzle.position, diff, Mathf.Infinity);
        Debug.DrawRay(muzzle.position, diff);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Player")
            {
                
                foundPlayer = true;
                player = hit.transform;
                searchTimer = 0.5f;
            }
            else
            {
                searchTimer -= Time.deltaTime;
                if (searchTimer <= 0)
                {
                    foundPlayer = false;
                }
            }
                
        }
    }
    void Shoot()
    {
        if (foundPlayer)
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0)
            {
                Instantiate(eBulletPrefab, muzzle.transform.position, transform.rotation);
                shootTimer = shootDelay;
            }
        }
        else
        {
            shootTimer = shootDelay;
        }
    }
}
