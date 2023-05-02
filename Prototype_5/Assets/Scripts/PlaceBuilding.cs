using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

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
    string tag;
    public GameObject crossHair;

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
            if(!isInstantiatedBuilding)
            {
                //needs to be only done once
                heldBuidling = Instantiate(buildingPrefabs[buildingPrefabIndex]);
                if (heldBuidling.name.Contains("Wall")) tag = "Wall";
                heldBuidling.tag = "HeldBuilding";
                isInstantiatedBuilding = true;
                
            }
            
            

            MoveBuilding(heldBuidling);

            //place it down
            if(Input.GetMouseButtonDown(0))
            {
                //remove costs
                isBuildingHeld = false;
                isInstantiatedBuilding=false;
                print(tag);
                heldBuidling.tag = tag;
                heldBuidling = null;
            }

            //cancel
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(heldBuidling);
                isBuildingHeld = false;
                isInstantiatedBuilding = false;
                
                
            }

        }
        else crossHair.SetActive(false);

        //MoveBuilding(testCube);

    }

    void MoveBuilding(GameObject _buildingSelected)
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 newMousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));
        Vector3 housePos = new Vector3(newMousePos.x, 1, newMousePos.z);
        var tpos = buildingTileMap.WorldToCell(housePos);
        houseTilePos = new Vector3(tpos.x, 1, tpos.y);

        //check if there is something in the targetted spot using raycast
        //if(Physics.Raycast)


        _buildingSelected.transform.position = houseTilePos;
        crossHair.transform.position = houseTilePos;

    }
}
