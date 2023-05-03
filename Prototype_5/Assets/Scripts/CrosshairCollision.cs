using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairCollision : GameBehaviour<CrosshairCollision>
{
    public bool isTouching;

    private void Update()
    {
        switch(isTouching)
        {
            case false:
                gameObject.GetComponent<Renderer>().material.color = Color.green;
                break;
            case true:
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                break;
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            isTouching = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            isTouching = false;
            
        }
    }
}
