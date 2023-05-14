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
        waveNumSpawn = RandomIntBetweenTwoInt(5, 6);
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

        if (_LM.dayCount >= waveNumSpawn && CheckForStructures() == true && CheckForEnemies() == false)
        {
            _UI.Victory();
        }
        else if (_LM.dayCount >= waveNumSpawn && CheckForStructures() == false && CheckForEnemies() == true) _UI.Defeat();

        //DEBUG
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    for (int i = 0; i < _EnM.enemiesToSpawn; i++)
        //    {
        //        _EnM.SpawnEnemies(gameObject.transform.position, towerSpawnRadius);
        //    }
        //}
    }

    bool CheckForStructures()
    {
        bool structuresRemain = true;
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        GameObject[] building = GameObject.FindGameObjectsWithTag("Building");
        if (walls.Length == 0 && building.Length == 0)
        {
            print("No structures");
            structuresRemain = false;
        }
        return structuresRemain;
    }

    bool CheckForEnemies()
    {
        bool enemiesRemain = true;
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemy.Length == 0)
        {
            print("No structures");
            enemiesRemain = false;
        }
        return enemiesRemain;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1f, gameObject.transform.position.z), towerSpawnRadius);
    }
}
