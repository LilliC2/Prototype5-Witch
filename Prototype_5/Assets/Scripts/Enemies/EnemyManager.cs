using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : GameBehaviour<EnemyManager>
{
    public List<GameObject> EnemyList;
    public GameObject trollPrefab;

    public int enemiesToSpawn = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemies(Vector3 _towerPos, float _towerRadius)
    {
        Vector3 spawnPos = Random.insideUnitSphere * _towerRadius + _towerPos;
        spawnPos = new Vector3(spawnPos.x, 1, spawnPos.z);
        GameObject enemy = Instantiate(trollPrefab, spawnPos, Quaternion.identity);
        EnemyList.Add(enemy);
    }

  
}
