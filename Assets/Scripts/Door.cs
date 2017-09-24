using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {


    public GameObject thisLevel;
    public GameObject nextlevel;
    Transform playertf;
    Transform spawnpositio;
    public GameObject[] enemies;
    bool switchLevel = false;
    SpriteRenderer sr;
    SpriteRenderer srThis;
    public float fadeSpeed = 0.5f;
    public Color alpha;
    bool doorOpen = false;
    AudioSource source;
    public Sprite openDoor;
    // Use this for initialization
    void Start ()
    {
        source = gameObject.GetComponent<AudioSource>();
        sr = GameObject.Find("Fade").GetComponent<SpriteRenderer>();
        srThis = gameObject.GetComponent<SpriteRenderer>();
        alpha = new Color(0, 0, 0, sr.color.a);
        playertf = GameObject.FindGameObjectWithTag("Player").transform;
        spawnpositio = nextlevel.transform.GetChild(0).GetChild(0);

    }
	
	// Update is called once per frame
	void Update ()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
        {
            if (!doorOpen)
            {
                source.Play();
                srThis.sprite = openDoor;
                doorOpen = true;
            }
        }
        if (switchLevel)
        {
            LevelTransition();
        }else
        {
            FadeIn();
        }
    }
    void OnTriggerStay2D(Collider2D coll) {
        if (coll.gameObject.name == "Player")
        {
            
            
            if (doorOpen && Input.GetKeyDown(KeyCode.W))
                
            {


                switchLevel = true;

            }
        }

    }
    void LevelTransition()
    {
        if (sr.color.a < 1)
        {
            
            alpha.a += Time.deltaTime * fadeSpeed;

            sr.color = alpha;
        }
        if (sr.color.a >= 1)
        {
            
            playertf.position = spawnpositio.position;
            nextlevel.SetActive(true);
            thisLevel.SetActive(false);
        }

       

    }
    void FadeIn()
    {
        if (sr.color.a > 0)
        {

            alpha.a -= Time.deltaTime * fadeSpeed;

            sr.color = alpha;
        }
    }
    
}
