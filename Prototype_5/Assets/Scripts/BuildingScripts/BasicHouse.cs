using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BuildingManager;

public class BasicHouse : BuildingManager.Building
{

    void OnEnable()
    {
        EventManager.EndofDay += AddProfitEvent;
    }

    void OnDisable()
    {
        EventManager.EndofDay -= AddProfitEvent;
    }

    private void Start()
    {
        buildingName = "Basic House";
        ID = 0;
        description = "A small starter home.";
        moneyPerDay = 5;
        manaPerDay = 0;
        health = 20;
    }

    void Update()
    {
        switch (health)
        {
            case <= 0:
                Destroy(this.gameObject);
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
        if (collision.collider.CompareTag("Enemy"))
        {
            int _dmg = collision.collider.gameObject.GetComponentInParent<Enemy>().dmg;
            Hit(_dmg);
        }
    }


}
