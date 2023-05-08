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
        print("My Name is " + buildingName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
