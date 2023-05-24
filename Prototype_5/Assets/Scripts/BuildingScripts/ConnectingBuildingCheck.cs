using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ConnectingBuildingCheck : GameBehaviour
{
    public GameObject[] wallPrefabs;
    
    public bool right;
    public bool left;
    public bool up;
    public bool down;

    public GameObject wall;

    int straight = 0;
    int corner = 1;
    int T = 2;
    int plus = 3;

    // Start is called before the first frame update
    void Start()
    {
        wall = gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
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

        CollisionCheck();

        #region Make Straight Wall Correct Rotation

        if(right && (!left && !up && !down))
        {
            if (!gameObject.name.Contains("Straight"))
            {
                ChangePiece(straight, 0);
            }

            wall.transform.eulerAngles = new Vector3(0, 0, 0);
        }
            
        if(left && (!right && !up && !down))
        {
            if (!gameObject.name.Contains("Straight"))
            {
                ChangePiece(straight, 0);
            }

            wall.transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (up && (!right && !left && !down))
        {
            if (!gameObject.name.Contains("Straight"))
            {
                ChangePiece(straight, 90);
            }

            wall.transform.eulerAngles = new Vector3(0, 90, 0);
        }
        
        if (down && (!right && !left && !up))
        {
            if (!gameObject.name.Contains("Straight"))
            {
                ChangePiece(straight, 90);
            }

            wall.transform.eulerAngles = new Vector3(0, 90, 0);
        }
        
        if (down && up && (!right && !left))
        {
            if (!gameObject.name.Contains("Straight"))
            {
                ChangePiece(straight, 90);
            }

            wall.transform.eulerAngles = new Vector3(0, 90, 0);
        }
        
        if (left && right && (!up && !down))
        {
            if (!gameObject.name.Contains("Straight"))
            {
                ChangePiece(straight, 0);
            }

            wall.transform.eulerAngles = new Vector3(0, 0, 0);
        }




        #endregion

        #region Make Wall Corner and Correct Rotation

        if (right && down && (!left || !up))
        {
            if (!gameObject.name.Contains("Corner"))
            {
                ChangePiece(corner, 0);
            }

            wall.transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (right && up && (!left || !down))
        {
            if (!gameObject.name.Contains("Corner"))
            {
                ChangePiece(corner, 270);
            }

            wall.transform.eulerAngles = new Vector3(0, 270, 0);
        }
        
        if (left && down && (!right || !up))
        {
            if (!gameObject.name.Contains("Corner"))
            {
                ChangePiece(corner, 90);
            }

            wall.transform.eulerAngles = new Vector3(0, 90, 0);
        }
        
        if (left && up && (!right || !down))
        {
            if (!gameObject.name.Contains("Corner"))
            {
                ChangePiece(corner, 180);
            }

            wall.transform.eulerAngles = new Vector3(0, 180, 0);
        }

        #endregion

        #region Make T and Correct Rotation

        if (right && down && up && (!left))
        {
            if (!gameObject.name.Contains("T"))
            {
                ChangePiece(T, 0);
            }

            wall.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        
        if (left && down && right && (!up))
        {
            if (!gameObject.name.Contains("T"))
            {
                ChangePiece(T, 90);
            }

            wall.transform.eulerAngles = new Vector3(0, 90, 0);
        }
        
        if (left && down && up && (!right))
        {
            if (!gameObject.name.Contains("T"))
            {
                ChangePiece(T, 180);
            }

            wall.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        
        if (left && right && up && (!down))
        {
            if (!gameObject.name.Contains("T"))
            {
                ChangePiece(T, 270);
            }

            wall.transform.eulerAngles = new Vector3(0, 270, 0);
        }

        #endregion

        #region Make Plus and Correct Rotation

        if (right && down && left && up)
        {
            if (!gameObject.name.Contains("Plus"))
            {
                ChangePiece(plus, 0);
            }

            wall.transform.eulerAngles = new Vector3(0, 0, 0);
        }

        #endregion

    }

    /// <summary>
    /// Change wall segement to correct piece and rotation
    /// </summary>
    /// <param name="_index"></param>
    /// <param name="rotation"></param>
    void ChangePiece(int _index, int rotation)
    {
        var newWall = GameObject.Instantiate(wallPrefabs[_index], gameObject.transform.position, Quaternion.Euler(0, rotation, 0));
        newWall.transform.parent = gameObject.transform;
        Destroy(wall);
        wall = newWall;

        switch (_index)
        {
            case 0:
                gameObject.name = "StraightWall";
                break;
            case 1:
                gameObject.name = "CornerWall";
                break;
            case 2:
                gameObject.name = "TWall";
                break;
            case 3:
                gameObject.name = "PlusWall";
                break;
        }


    }

    /// <summary>
    /// Find if there are any adjacent walls and in which direction
    /// </summary>
    void CollisionCheck()
    {
        up = gameObject.transform.Find("UpCollider").GetComponentInChildren<CollisionDetector>().isTouching;
        down = gameObject.transform.Find("DownCollider").GetComponentInChildren<CollisionDetector>().isTouching;
        left = gameObject.transform.Find("LeftCollider").GetComponentInChildren<CollisionDetector>().isTouching;
        right = gameObject.transform.Find("RightCollider").GetComponentInChildren<CollisionDetector>().isTouching;

        //print("Up " + up);
        //print("Down " + down);
        //print("Left " + left);
        //print("Right " + right);
    }
}
