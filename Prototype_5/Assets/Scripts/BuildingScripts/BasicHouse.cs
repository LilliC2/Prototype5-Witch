using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicHouse : BuildingManager.Building
{
    

    void OnEnable()
    {
        EventManager.EndofDay += AddProfitEvent;
    }

    void OnDisable()
    {
        EventManager.EndofDay += AddProfitEvent;
    }

    private void Start()
    {
        
        print("My Name is " + buildingName);
    }



}
