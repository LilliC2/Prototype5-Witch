using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : GameBehaviour<CurrencyManager>
{
    public int manaCount = 0;
    public int moneyCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        _UI.UpdateMoney();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
