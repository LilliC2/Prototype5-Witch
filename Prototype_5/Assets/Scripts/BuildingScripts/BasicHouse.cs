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
        print("My Name is " + buildingName);
    }




}
