using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;

    public float spawnDelay = 5;

    public int maxSpawned = 3;

    int spawned = 0;

    float spawnTimer;

    Animator a;

    bool stop;
    


	void Start () {
        spawnTimer = spawnDelay;
        a = transform.GetComponent<Animator>();
        
	}


    void Update() {
        if (!stop)
        {
            if (spawned < maxSpawned)
            {
                spawnTimer -= Time.deltaTime;
                if (spawnTimer <= 0)
                {
                    Instantiate(enemyPrefab, transform.position, transform.rotation);
                    spawned++;
                    spawnTimer = spawnDelay;
                }
            }
        }
    
	}
    public void PlayAnimation()
    {
        stop = true;
        a.Play("enemyspawner");
        
    }
}
