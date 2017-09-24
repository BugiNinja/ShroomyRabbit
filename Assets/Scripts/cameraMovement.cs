using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {

    public float speed = 10;
    public GameObject thisCamera;
    Door d;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Door d = GameObject.FindGameObjectWithTag("Wall").GetComponent<Door>();
        if (d.Camera = true)
        {
            thisCamera.SetActive(true);
        }
        

      /*  var movement = Vector3.zero;

        transform.Translate(movement * speed * Time.deltaTime, Space.Self);
        transform.position = new Vector3
            (Mathf.Clamp(transform.position.x, -13.96, 14.85),
          Mathf.Clamp(transform.position.y, 5.19595, 5.19595),
          Mathf.Clamp(transform.position.z, 22.85295, -26.27));
    */}
}
