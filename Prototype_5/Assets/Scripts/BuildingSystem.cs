using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : GameBehaviour<BuildingSystem>
{
    //singletone

    public static BuildingSystem current;

    public GridLayout gridLayout;
    private Grid grid;
    [SerializeField] private Tilemap MainTileMap;
    [SerializeField] private TileBase whiteTile;
    [SerializeField] private GameObject pivot;

    public GameObject prefab1;
    public GameObject landPrefab;

    private PlaceableObject objectToPlace;

    private void Awake()
    {
        current = this;
        grid = gridLayout.gameObject.GetComponent<Grid>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out RaycastHit raycastHit))
        {
            return raycastHit.point;
        }
        else
        {
            return Vector3.zero;
        }
    }

    public Vector3 SnapCoordinateToGride(Vector3 _position)
    {
        //vector 3 using ints
        Vector3Int cellPos = gridLayout.WorldToCell(_position);
        _position = grid.GetCellCenterWorld(cellPos);
        return _position;
    }

    public void InitalizeWithObject(GameObject _prefab, Vector3 position)
    {
        

        GameObject obj = Instantiate(_prefab,position,Quaternion.identity);
        objectToPlace = obj.GetComponent<PlaceableObject>();
        obj.AddComponent<DragObject>();
    }

    #region buttonSpawn

    public void InitalizeLand()
    {
        Vector3 position = SnapCoordinateToGride(Vector3.zero);
        InitalizeWithObject(landPrefab, position);
    }
    public void InitalizeHouse()
    {
        Vector3 position = SnapCoordinateToGride(pivot.transform.position);
        InitalizeWithObject(landPrefab, position);
    }


    #endregion
}
