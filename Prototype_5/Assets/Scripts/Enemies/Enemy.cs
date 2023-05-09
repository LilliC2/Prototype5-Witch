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

    bool findNewStructure;

    public enum EnemyType { Troll}
    public EnemyType enemyType;

    public GameObject goalStructure;
    public Vector3 goal;
    Vector3 goalParent;

    public GameObject prevStrucutre;

    GameObject currentTarget;

    public Collider[] colliders;

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
        if (CheckForStructures())
        {


            if(goalStructure != prevStrucutre)
            {
                findNewStructure = false;
                StartCoroutine(ResetPathFinding());
                
                prevStrucutre = goalStructure;
                
            }
            else if (prevStrucutre == null)
            {
                prevStrucutre = goalStructure;
                agent.SetDestination(FindClosestStructure().transform.position);
                goalStructure = FindClosestStructure();

            }



            if (Vector3.Distance(gameObject.transform.position, goal) < range)
            {
                print("In range to attack");
                //stop
                if (!hasAttacked    )
                {
                    animator.SetTrigger("TrollAttack");
                    StartCoroutine(ResetAttack());
                    hasAttacked = true;
                }
            }
            else
            {
                if (findNewStructure)
                {
                    print("looking for new target");
                    goalStructure = FindClosestStructure();
                    agent.SetDestination(FindClosestStructure().transform.position);
                    goalStructure = FindClosestStructure();

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
        
        yield return new WaitForSeconds(4);
        hasAttacked = false;
    }
    IEnumerator ResetPathFinding()
    {
        print("WAIT");
        yield return new WaitForSeconds(4);
        findNewStructure = true;
    }

    void SwitchBasedOnType()
    {
        switch(enemyType)
        {
            case EnemyType.Troll:
                health = 10;
                dmg = 5;
                range = 0.2f;
    
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
            currentDistance = Vector3.Distance(transform.position, go.transform.localPosition);
            if(currentDistance < closestWallDistance)
            {
                closestWallDistance = currentDistance;
                closestWall = go;
                
            }
        }
        
        foreach(GameObject go2 in building)
        {
            float currentDistance;
            currentDistance = Vector3.Distance(transform.position, go2.transform.localPosition);
            if(currentDistance < closestBuildingDistance)
            {
                closestBuildingDistance = currentDistance;
                closestBuilding = go2;
                
            }
        }

        if(closestBuildingDistance < closestWallDistance)
        {
            closestStructure = closestBuilding;
        }
        else if (closestBuildingDistance > closestWallDistance)
        {
            closestStructure = closestWall;
        }


        return closestStructure;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Fireball"))
        {
            health -= _SM.fireball.dmg;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(gameObject.transform.position, range);
        


    }
}
