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
    public void PlaceBuilding1()
    {
        _PB.isBuildingHeld = true;
        _PB.buildingPrefabIndex = 1;
    }

    public void UpdateDay(int _dayCount)
    {
        //late use do tween here
        dayCounterText.text = "Day " + _dayCount;
    }
    public void UpdateMoney(int _manaCount, int _moneyCount)
    {
        //late use do tween here
        manaCountText.text = "Mana: " + manaCountText;
        moneyCountText.text = "Money: " + moneyCountText;
    }

    public void UpdateDayTimeMultipler(int _switch)
    {
        switch (_switch)
        {
            case 0:
                _LM.TimeMultiplier = 5;
                break;
            case 1:
                _LM.TimeMultiplier = 15;
                break;
            case 2:
                _LM.TimeMultiplier = 30;
                break;
        }
    }
}
