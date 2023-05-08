using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTowerManager : GameBehaviour
{
    int towerHealth = 50;
    public float towerSpawnRadius = 1;
    Vector3 sphereRadiusPos;

    bool isEnemiesSpaned = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isEnemiesSpaned)
        {
            for (int i = 0; i < _EnM.enemiesToSpawn; i++)
            {
                _EnM.SpawnEnemies(gameObject.transform.position, towerSpawnRadius);
            }
            isEnemiesSpaned = true;
        }
        
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1f, gameObject.transform.position.z), towerSpawnRadius);
    }
}
