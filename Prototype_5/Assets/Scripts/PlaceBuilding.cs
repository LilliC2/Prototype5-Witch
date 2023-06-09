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
    public GameObject heldBuidling;
    public GameObject crossHair;

    bool isRotating;
    bool isValidPos;
    string heldTag;
    Vector3 goalRotation;
    public Collider[] inRange;

    Tweener tweener;
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

        if (isBuildingHeld)
        {
            Cursor.visible = false;
            TagSwitch();
            
            crossHair.SetActive(true);

            MoveBuilding();

            if (Input.GetKeyDown(KeyCode.R))
            {
                if (!isRotating)
                {
                    isRotating = true;
                    goalRotation = crossHair.transform.eulerAngles + new Vector3(0, 90, 0);
                    crossHair.transform.DORotate(goalRotation, 0.5f);
                    ExecuteAfterSeconds(0.5f, () => ResetRotation());
                }


            }
            //place it down
            if (Input.GetMouseButtonDown(0) && isValidPos)
            {
                //remove costs
                isBuildingHeld = false;

                //place building change below to 1.5f later when juiced
                heldBuidling = Instantiate(buildingPrefabs[buildingPrefabIndex], new Vector3(houseTilePos.x, 1.5f, houseTilePos.z), Quaternion.Euler(goalRotation));
                heldBuidling.tag = "HeldBuilding";
                if (tweener != null) tweener.Kill();
                tweener = heldBuidling.transform.DOMoveY(1, 0.5f).SetEase(Ease.InBack).OnComplete(() => ResetTag()); //.OnComplete(() => //instaniate particle here);

        
            }

            //cancel
            if (Input.GetMouseButtonDown(1))
            {
                crossHair.SetActive(false);
                isBuildingHeld = false;
                Cursor.visible = true;
                
            }

        }
        else
        {
            _CC.isTouching = false;
            Cursor.visible = true;
            crossHair.SetActive(false);
        }

        //MoveBuilding(testCube);
        //check if there is something in the targetted spot using raycast
       

    }

    void ResetTag()
    {
        heldBuidling.tag = heldTag;
        heldBuidling = null;
    }

    void TagSwitch()
    {
        switch(buildingPrefabIndex)
        {
            case 0:
                heldTag = "Building";
                break;
            case 1:
                heldTag = "Wall";
                break;
            case 2:
                heldTag = "Building";
                break;
            case 3:
                heldTag = "Road";
                break;

        }
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
        houseTilePos = new Vector3(tpos.x, 1f, tpos.y);

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
