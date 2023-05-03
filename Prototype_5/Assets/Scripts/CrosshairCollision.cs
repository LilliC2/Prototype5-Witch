using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairCollision : GameBehaviour<CrosshairCollision>
{
    public bool isTouching;


   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            isTouching = true;
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            isTouching = false;
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
