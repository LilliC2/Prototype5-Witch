using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : GameBehaviour<GameManager>
{
    public enum GameState { Playing, MenuPause, TimePause}
    public GameState gameState;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch(gameState)
        {
            case GameState.Playing:
                
                break;
            case GameState.MenuPause:
                Time.timeScale = 0;
                break;

        }
    }

    public void TimeSclaeUpdater(int _switch)
    {
        switch (_switch)
        {
            case 0:
                Time.timeScale = 0;
                break;
            case 1:
                Time.timeScale = 1;
                break;
            case 2:
                Time.timeScale = 2;
                break;
            case 3:
                Time.timeScale = 3;
                break;
        }
    }
}
