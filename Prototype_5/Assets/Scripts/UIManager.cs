using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.XR;

public class UIManager : GameBehaviour<UIManager>
{
    public TMP_Text manaCountText;
    public TMP_Text moneyCountText;
    public TMP_Text dayCounterText;
    public TMP_Text pauseSpeedText;

    public GameObject buildingPanel;
    public GameObject wallsNroadsPanel;
    public GameObject spellsPanel;
    public GameObject controlsPanel;
    public GameObject pausePanel;
     public GameObject noManaPanel;
    public GameObject noMoneyPanel;

    bool controls;
    int prevSpeed;
    bool pause;
    bool pauseMenu;

    public enum Panels { Buildings, WallsRoads, Spells}
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


    private void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) PauseGame();

        switch(panels)
        {
            case Panels.Buildings:
                buildingPanel.SetActive(true);
                wallsNroadsPanel.SetActive(false);
                spellsPanel.SetActive(false);
                break;

            case Panels.WallsRoads:
                buildingPanel.SetActive(false);
                spellsPanel.SetActive(false);
                wallsNroadsPanel.SetActive(true);
                break;
            case Panels.Spells:
                buildingPanel.SetActive(false);
                wallsNroadsPanel.SetActive(false);
                spellsPanel.SetActive(true);
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

    #region spells
    public void SummonFireball()
    {

        
        //enough mana to summon spell
        if (_CM.manaCount >= _SM.fireball.cost)
        {
            _SM.spellType = SpellManager.SpellType.Fireball;
        }
        else
        {
            noManaPanel.SetActive(true);
            ExecuteAfterSeconds(3, () => noManaPanel.SetActive(false));
        }

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
        UpdateManaMoney();
        
    }

    public void UpdateManaMoney()
    {
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
    public void OpenSpellPanel()
    {
        panels = Panels.Spells;
    }

    public void UpdateMoney()
    {
        //late use do tween here
        StartCoroutine(WaitToUpdateManaMoney());
    }

    public void UpdateDayTimeMultipler(int _switch)
    {
        if(_switch == 0)
        {
            pause = !pause;
            if (!pause)
            {
                pauseSpeedText.text = "Play";
                if (prevSpeed == 0) prevSpeed = 1;
                _switch = prevSpeed;
            }
            else
            {
                pauseSpeedText.text = "Pause";
                
            }
        }


        _GM.TimeSclaeUpdater(_switch);
    }

    void UpdateToolTip()
    {

    }

    public void OpenControls()
    {
        controls = !controls;

        controlsPanel.SetActive(controls);

    }

    public void PauseGame()
    {
        pauseMenu = !pauseMenu;
        pausePanel.SetActive(pauseMenu);

        if (pauseMenu) _GM.gameState = GameManager.GameState.MenuPause;
        else { 
        _GM.gameState = GameManager.GameState.Playing;
        Time.timeScale = 1;}
    }
   


}
