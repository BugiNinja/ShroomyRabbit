using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour {

    AudioSource a;
    public GameObject levels;
    AudioSource alevels;
	void Start () {
        alevels = levels.GetComponent<AudioSource>();
        a = gameObject.GetComponent<AudioSource>();
        alevels.Stop();
        a.Play();
	}
	
	
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(0);
        }
    }
}
