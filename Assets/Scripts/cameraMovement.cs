using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {

    
    public GameObject player;
    
    

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > 0 && player.transform.position.x < 30) {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, -10);
        } 

      /*  var movement = Vector3.zero;

        transform.Translate(movement * speed * Time.deltaTime, Space.Self);
        transform.position = new Vector3
            (Mathf.Clamp(transform.position.x, -13.96, 14.85),
          Mathf.Clamp(transform.position.y, 5.19595, 5.19595),
          Mathf.Clamp(transform.position.z, 22.85295, -26.27));
    */}
}
