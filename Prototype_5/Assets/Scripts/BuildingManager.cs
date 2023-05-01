using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : GameBehaviour<BuildingManager>
{
    int manaProducingHouses;
    public int moneyProducingHouses;

    int manaProduced = 5;
    int moneyProduced = 5;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print("moneyProducingHouses=" + moneyProducingHouses);
    }

    public void DayCycleEndGain()
    {
        print("Add money");
        _CM.manaCount = _CM.manaCount +(manaProducingHouses * manaProduced);
        _CM.moneyCount = _CM.moneyCount + ( moneyProducingHouses * moneyProduced);
        _UI.UpdateMoney(_CM.manaCount, _CM.moneyCount);
    }
}
