using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : GameBehaviour
{
    public bool isTouching;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            print("update istouching + " + gameObject.name);
            isTouching = true;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Wall")) isTouching = false;
    }
}
