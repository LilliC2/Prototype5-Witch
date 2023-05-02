using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectingBuildingCheck : MonoBehaviour
{
    public GameObject[] wallPrefabs;
    public GameObject[] roadPrefabs;

    
    bool right;
    bool left;
    bool up;
    bool down;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check tag then switch so it knows which prefabs to use

        //things walls should check
        /*
         * if another wall is adjacnet 
         *  if one wall is adjacent, connect
         *  if two wall is adjacent, connect and turn into corner
         *  if three wall is adjacent, connect and turn into T
         *  if 4 wall is adjacent, connect and turn into +
         * 
         * if road either side of wall, turn into entrance
         */

        //check +z and -z
        if(Physics.Raycast(this.transform.position, Vector3.right,out RaycastHit raycastHit, 2f))
        {
            if(raycastHit.collider.CompareTag("Wall"))
            {
                print("hit object right");
                right = true;
            }
            
        }
        
        if(Physics.Raycast(this.transform.position, Vector3.left,out raycastHit, 2f))
        {
            if (raycastHit.collider.CompareTag("Wall"))
            {
                print("hit object left");
                left = true;
            }
        }
        if(Physics.Raycast(this.transform.position, Vector3.forward,out raycastHit, 2f))
        {

            if (raycastHit.collider.CompareTag("Wall"))
            {
                print("hit object up");
                up = true;
            }
        }
        if(Physics.Raycast(this.transform.position, Vector3.back,out raycastHit, 2f))
        {

            if (raycastHit.collider.CompareTag("Wall"))
            {
                print("hit object down");
                down = true;
            }
        }


        //switch to corner piece
        if(right && down)
        {
            //check if already correct piece
            if(gameObject.name == "WallCorner" && gameObject.transform.position.y == 90)
            {
                return;
            }
            else
            {
                print("Right and Down!");
                //place new object
                //rotate new object
                Instantiate(wallPrefabs[1], gameObject.transform.position, Quaternion.Euler(0, 0, 0));

                //delete old object
                Destroy(gameObject);
            }

            
        }


        //check +x and -x

    }
}
