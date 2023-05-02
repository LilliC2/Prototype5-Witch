using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : GameBehaviour<BuildingManager>
{
    [System.Serializable]
    public class Building : MonoBehaviour
    {
        //subcribe to event


        public string buildingName;
        public string description;
        public int ID;
        public int moneyPerDay;
        public int manaPerDay;

        
        public virtual void AddProfitEvent()
        {
            print("Add todays profit");
            _CM.moneyCount =+ moneyPerDay;
            _CM.manaCount =+ manaPerDay;
        }
        //add cost to build later

    }

    int todaysMoney;
    int todaysMana;

    public Building[] buildings;

    public Building BasicHouse;

    // Start is called before the first frame update
    void Start()
    {
        SetBuildingClasses();


    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DayCycleEndGain()
    {
        //call script on all houses etc,
        

    }

    void SetBuildingClasses()
    {
        BasicHouse = new Building();
        BasicHouse.buildingName = "Basic House";
        BasicHouse.ID = 0;
        BasicHouse.description = "A small starter home.";
        BasicHouse.moneyPerDay = 5;
        BasicHouse.manaPerDay = 0;
    }
}
