using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class UIManager : GameBehaviour<UIManager>
{
    public TMP_Text manaCountText;
    public TMP_Text moneyCountText;
    public TMP_Text dayCounterText;

    public GameObject buildingPanel;
    public GameObject wallsNroadsPanel;

    public enum Panels { Buildings, WallsRoads,}
    public Panels panels;

    void OnEnable()
    {
        EventManager.EndofDay += UpdateDay;
        EventManager.EndofDay += UpdateMoney;
    }

    void OnDisable()
    {
        EventManager.EndofDay -= UpdateDay;
        EventManager.EndofDay -= UpdateMoney;
    }


    void Update()
    {
        switch(panels)
        {
            case Panels.Buildings:
                buildingPanel.SetActive(true);
                wallsNroadsPanel.SetActive(false);
                break;

            case Panels.WallsRoads:
                buildingPanel.SetActive(false);
                wallsNroadsPanel.SetActive(true);
                break;
        }
    }
    #region placeBuildings
    public void PlaceBuilding0()
    {
        _PB.isBuildingHeld = true;
        _PB.buildingPrefabIndex = 0;
    }
    public void PlaceBuilding1()
    {
        _PB.isBuildingHeld = true;
        _PB.buildingPrefabIndex = 1;
    }
    
    public void PlaceBuilding2()
    {
        _PB.isBuildingHeld = true;
        _PB.buildingPrefabIndex = 2;
    }
    public void PlaceBuilding3()
    {
        _PB.isBuildingHeld = true;
        _PB.buildingPrefabIndex = 3;
    }
    #endregion
    public void UpdateDay()
    {
        //late use do tween here
        dayCounterText.text = "Day " + _LM.dayCount;
    }
    IEnumerator WaitToUpdateManaMoney()
    {
        yield return new WaitForEndOfFrame();
        manaCountText.text = "Mana: " + _CM.manaCount;
        moneyCountText.text = "Money: " + _CM.moneyCount;
        
    }

    public void OpenBuildingPanel()
    {
        panels = Panels.Buildings;
    }
    public void OpenWallsNRoadPanel()
    {
        panels = Panels.WallsRoads;
    }

    public void UpdateMoney()
    {
        //late use do tween here
        StartCoroutine(WaitToUpdateManaMoney());
    }

    public void UpdateDayTimeMultipler(int _switch)
    {
        switch (_switch)
        {
            case 0:
                _LM.TimeMultiplier = 30;
                break;
            case 1:
                _LM.TimeMultiplier = 50;
                break;
            case 2:
                _LM.TimeMultiplier = 100;
                break;
        }
    }
}
