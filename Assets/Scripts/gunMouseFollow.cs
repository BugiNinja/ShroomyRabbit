using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunMouseFollow : MonoBehaviour {

    Vector3 mousePosition;

    Transform crosshair;

    public GameObject bulletPrefab;

    public GameObject grenadePrefab;

    float lookingSpeed;

    Transform muzzle;

    public float shootingDelay = 1;

    float shootingTimer = 0;

    public float grenadeDelay = 1;

    float grenadeTimer = 0;

    SpriteRenderer sr;

    void Start() {
        crosshair = GameObject.FindGameObjectWithTag("Crosshair").transform;
        sr = gameObject.GetComponent<SpriteRenderer>();
        muzzle = transform.GetChild(0);
    }


	void Update () {
        MoveCrosshair();
        RotateGun();
        Shoot();
    }
    void MoveCrosshair() {
        mousePosition = Input.mousePosition;
        mousePosition.z = 1.0f;
        crosshair.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }
    void RotateGun() {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        if(transform.rotation.z > 0)
        {
            sr.flipX = true;
        }
        else if (transform.rotation.z < 0)
        {
            sr.flipX = false;
        }
    }
    void Shoot() {
        if (shootingTimer > 0)
        {
            shootingTimer -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Fire1") && shootingTimer <= 0)
        {
            Instantiate(bulletPrefab, muzzle.transform.position, transform.rotation);
            shootingTimer = shootingDelay;
            
        }
        if (grenadeTimer > 0)
        {
            grenadeTimer -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Fire2") && grenadeTimer <= 0)
        {
            Instantiate(grenadePrefab, muzzle.transform.position , transform.rotation);
            grenadeTimer = grenadeDelay;

        }

    }
}
