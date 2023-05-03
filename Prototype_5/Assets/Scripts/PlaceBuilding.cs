using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using DG.Tweening;


public class PlaceBuilding : GameBehaviour<PlaceBuilding>
{
    public Tilemap buildingTileMap;
    public GameObject testCube;
    public GameObject testCube2;
    Vector3 houseTilePos;
    public bool isBuildingHeld;

    public GameObject[] buildingPrefabs;
    public int buildingPrefabIndex;
    bool isInstantiatedBuilding;
    public GameObject heldBuidling;
    public GameObject crossHair;

    bool isRotating;
    bool isValidPos;
    Vector3 goalRotation;
    public Collider[] inRange;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //click button for building prefab

        //instantiate building at tileHousePos

        //show building on mouse pos
        //rotate building with r
        //click again to place building
        //once placed remove cost

        if(isBuildingHeld)
        {
            crossHair.SetActive(true);  

            MoveBuilding();

            if (Input.GetKeyDown(KeyCode.R))
            {
                if(!isRotating)
                {
                    isRotating = true;
                    goalRotation = crossHair.transform.eulerAngles + new Vector3(0, 90, 0);
                    crossHair.transform.DORotate(goalRotation, 0.5f);
                    ExecuteAfterSeconds(0.5f, () => ResetRotation());
                }
                

            }
            //place it down
            if(Input.GetMouseButtonDown(0) && isValidPos)
            {
                //remove costs
                isBuildingHeld = false;
                isInstantiatedBuilding=false;
                


                //place building
                heldBuidling = Instantiate(buildingPrefabs[buildingPrefabIndex],houseTilePos,Quaternion.Euler(goalRotation));

                heldBuidling = null;
            }

            //cancel
            if (Input.GetMouseButtonDown(1))
            {
                crossHair.SetActive(false);
                isBuildingHeld = false;
                isInstantiatedBuilding = false;
                
                
            }

        }
        else crossHair.SetActive(false);

        //MoveBuilding(testCube);
        //check if there is something in the targetted spot using raycast
       

    }

    void ResetRotation()
    {
        isRotating = false;
    }

    void MoveBuilding()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 newMousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));
        Vector3 housePos = new Vector3(newMousePos.x, 1, newMousePos.z);
        var tpos = buildingTileMap.WorldToCell(housePos);
        houseTilePos = new Vector3(tpos.x, 1, tpos.y);

        crossHair.transform.position = houseTilePos;
        
        if (_CC.isTouching)
        {

            isValidPos = false;

        }
        else
        {
            isValidPos = true;
        }


        
        

    }


}
