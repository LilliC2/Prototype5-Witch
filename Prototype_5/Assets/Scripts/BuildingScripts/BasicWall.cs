using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWall : BuildingManager.Building
{
    ParticleSystem explosion;
    // Start is called before the first frame update
    void Start()
    {
        buildingName = "Basic Wall";
        ID = 0;
        description = "The basic first line of defense.";
        moneyPerDay = 0;
        manaPerDay = 0;
        health = 40;
    }

    // Update is called once per frame
    void Update()
    {
        switch(health)
        {
            case <= 0:
                gameObject.GetComponentInChildren<Renderer>().enabled = false;
                Destroy(this.gameObject,1);
                break;

            case < 5:
                gameObject.GetComponentInChildren<Renderer>().material.color = Color.red;
                break;
            case < 20:
                gameObject.GetComponentInChildren<Renderer>().material.color = Color.yellow;
                break;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Enemy"))
        {
            int _dmg = collision.collider.gameObject.GetComponentInParent<Enemy>().dmg;
            Hit(_dmg);
        }
    }
}
