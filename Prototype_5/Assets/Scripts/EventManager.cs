using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : GameBehaviour<EventManager>
{
    public delegate void EndDay();
    public static event EndDay EndofDay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallEndDay()
    {
        print("End of Day");
        if(EndofDay     != null) EndofDay();

    }
}
