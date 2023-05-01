using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : GameBehaviour<UIManager>
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaceBuilding0()
    {
        _PB.isBuildingHeld = true;
        _PB.buildingPrefabIndex = 0;
    }
}
