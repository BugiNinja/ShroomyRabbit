using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;

    public float spawnDelay = 5;

    public int maxSpawned = 3;

    int spawned = 0;

    float spawnTimer;
    


	void Start () {
        spawnTimer = spawnDelay;
	}


    void Update() {
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
