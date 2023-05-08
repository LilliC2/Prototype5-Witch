using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : GameBehaviour
{

    public int health;
    public int dmg = 2;
    public float range;

    NavMeshAgent agent;
    Animator animator;
    bool hasAttacked;

    Vector3 spawn;

    public enum EnemyType { Troll}
    public EnemyType enemyType;

    GameObject goalStructure;
    Vector3 goal;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        spawn = gameObject.transform.position;

        SwitchBasedOnType();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CheckForStructures())
        {
            goalStructure = FindClosestStructure();
            goal = goalStructure.transform.position;
            agent.SetDestination(goal);

            gameObject.transform.LookAt(goalStructure.transform.position);
            if (Vector3.Distance(gameObject.transform.position, goal) < range)
            {
                //stop
                agent.SetDestination(gameObject.transform.position);
                if (!hasAttacked)
                {
                    animator.SetTrigger("TrollAttack");
                    StartCoroutine(ResetAttack());
                    hasAttacked = true;

                }

            }
        }
        else
        {
            agent.SetDestination(spawn);
            if (Vector3.Distance(gameObject.transform.position, spawn) < 0.5f)
            {
                //destroy this enemy
                _EnM.DestroyEnemy(gameObject);
            }
        }
        

        
        if (health <= 0)
        {
            _EnM.DestroyEnemy(gameObject);
        }

    }

    IEnumerator ResetAttack()
    {
        print("reset");
        
        yield return new WaitForSeconds(3);
        hasAttacked = false;
    }

    void SwitchBasedOnType()
    {
        switch(enemyType)
        {
            case EnemyType.Troll:
                health = 10;
                dmg = 5;
                range = 1;
    
                break;
        }
    }

    bool CheckForStructures()
    {
        bool structuresRemain = true;
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        GameObject[] building = GameObject.FindGameObjectsWithTag("Building");
        if (walls.Length ==0 && building.Length == 0)
        {
            print("No structures");
            structuresRemain = false;
        }
        return structuresRemain;
    }

    GameObject FindClosestStructure()
    {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        float closestWallDistance = Mathf.Infinity;
        GameObject closestWall = null;

        GameObject[] building = GameObject.FindGameObjectsWithTag("Building");
        float closestBuildingDistance = Mathf.Infinity;
        GameObject closestBuilding = null;

        GameObject closestStructure = null;

        foreach(GameObject go in walls)
        {
            float currentDistance;
            currentDistance = Vector3.Distance(transform.position, go.transform.position);
            if(currentDistance < closestWallDistance)
            {
                closestWallDistance = currentDistance;
                closestWall = go;
                
            }
        }
        
        foreach(GameObject go in building)
        {
            float currentDistance;
            currentDistance = Vector3.Distance(transform.position, go.transform.position);
            if(currentDistance < closestBuildingDistance)
            {
                closestBuildingDistance = currentDistance;
                closestBuilding = go;
                
            }
        }

        if(closestBuildingDistance<closestWallDistance)
        {
            closestStructure = closestBuilding;
        }
        else if (closestBuildingDistance > closestWallDistance)
        {
            closestStructure = closestWall;
        }

        return closestStructure;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(gameObject.transform.position, range);
    }
}
