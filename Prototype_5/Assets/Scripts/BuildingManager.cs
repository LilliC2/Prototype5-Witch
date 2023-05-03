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
        public bool isTouching;
        
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
    public Building BasicManaHouse;

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
        
        
        BasicManaHouse = new Building();
        BasicManaHouse.buildingName = "Basic Mana House";
        BasicManaHouse.ID = 2;
        BasicManaHouse.description = "A small factory that produces a bit of mana.";
        BasicManaHouse.moneyPerDay = 0;
        BasicManaHouse.manaPerDay = 5;
    }
}
