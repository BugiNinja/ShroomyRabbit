using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {


    public float enemyNumber;
    public GameObject nextEnemies;
    int[] doors = new int[2];
    int i = 0;
    // Use this for initialization
    void Start ()
    {
        doors[0] = 2;
        doors[1] = 2;

       enemyNumber = doors[i];
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (enemyNumber <= 0)
        {
         //   nextEnemies.SetActive(true);
            Destroy(transform.GetChild(0).gameObject);
            i++;
            enemyNumber = doors[i];
        }
	}
}
