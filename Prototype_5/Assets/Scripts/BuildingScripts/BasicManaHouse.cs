using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BuildingManager;

public class BasicManaHouse : BuildingManager.Building
{
    void OnEnable()
    {
        EventManager.EndofDay += AddProfitEvent;
    }

    void OnDisable()
    {
        EventManager.EndofDay -= AddProfitEvent;
    }
    // Start is called before the first frame update
    void Start()
    {
        buildingName = "Basic Mana House";
        ID = 2;
        description = "A small factory that produces a bit of mana.";
        moneyPerDay = 0;
        manaPerDay = 5;
        health = 20;
    }

    // Update is called once per frame
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
