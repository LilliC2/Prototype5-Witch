using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTowerManager : GameBehaviour
{
    int towerHealth = 50;
    public float towerSpawnRadius = 1;
    Vector3 sphereRadiusPos;

    bool isEnemiesSpawned = false;

    int waveNumSpawn;

    // Start is called before the first frame update
    void Start()
    {
        waveNumSpawn = RandomIntBetweenTwoInt(2, 3);
        print("Wave will come on day " + waveNumSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        if (_LM.dayCount == waveNumSpawn && (_LM.TimeOfDay > 500 && _LM.TimeOfDay < 550)) 
        {
            if (!isEnemiesSpawned)
            {
                for (int i = 0; i < _EnM.enemiesToSpawn; i++)
                {
                    _EnM.SpawnEnemies(gameObject.transform.position, towerSpawnRadius);
                }
                isEnemiesSpawned = true;
            }
        }

        //DEBUG
        if(Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < _EnM.enemiesToSpawn; i++)
            {
                _EnM.SpawnEnemies(gameObject.transform.position, towerSpawnRadius);
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1f, gameObject.transform.position.z), towerSpawnRadius);
    }
}
