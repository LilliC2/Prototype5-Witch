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

    void ChangePiece(int _index, int rotation)
    {
        var newWall = GameObject.Instantiate(wallPrefabs[_index], gameObject.transform.position, Quaternion.Euler(0, rotation, 0));
        newWall.transform.parent = gameObject.transform;
        Destroy(wall);
        wall = newWall;

        switch(_index)
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

    // Update is called once per frame
    void Update()
    {


        CollisionCheck();

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
                ChangePiece(corner, 180);
            }

            wall.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        
        #endregion
        //make corner

        //if(right && down && (!left || !up))
        //{
        //    //check if already correct if not change
        //    if (!gameObject.name.Contains("Corner") && gameObject.transform.eulerAngles.y != 0)
        //    {
        //        GameObject.Instantiate(wallPrefabs[1], gameObject.transform.position, Quaternion.Euler(0, 0, 0));
        //        Destroy(gameObject);
        //        Destroy(this);
        //    }

        //}


        //place new object
        //            //rotate new object
        //            GameObject.Instantiate(wallPrefabs[0], gameObject.transform.position, Quaternion.Euler(0, 0, 0));

        //            //delete old object
        //            Destroy(gameObject, 0);
        //            //destroy script
        //            Destroy(this, 0);

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




        #region old code

        //only change once placed

        //if(_PB.heldBuidling != gameObject)
        //{


        //    //check +z and -z
        //    if (Physics.Raycast(this.transform.position, Vector3.right, out rightHit, 1f))
        //    {
        //        if (rightHit.collider.CompareTag("Wall"))
        //        {
        //            //print("hit object right");
        //            right = true;
        //        }
        //        else right = false;

        //    }

        //    if (Physics.Raycast(this.transform.position, Vector3.left, out leftHit, 1f))
        //    {
        //        if (leftHit.collider.CompareTag("Wall"))
        //        {
        //            //print("hit object left");
        //            left = true;
        //        }
        //        else left = false;
        //    }
        //    if (Physics.Raycast(this.transform.position, Vector3.forward, out upHit, 1f))
        //    {

        //        if (upHit.collider.CompareTag("Wall"))
        //        {
        //            //print("hit object up");
        //            up = true;

        //        }
        //        else up = false;
        //    }
        //    if (Physics.Raycast(this.transform.position, Vector3.back, out downHit, 1f))
        //    {

        //        if (downHit.collider.CompareTag("Wall"))
        //        {
        //            //print("hit object down");
        //            down = true;
        //        }
        //        else down = false;
        //    }





        //    #region corner




        //    #endregion


        //    //switch to corner piece
        //    #region corner
        //    if (right && down)
        //    {
        //        //check if already correct piece
        //        if (gameObject.name.Contains("WallCorner") && gameObject.transform.eulerAngles.y == 0)
        //        {
        //            print("Correct Piece");
        //            return;
        //        }
        //        else
        //        {
        //            //place new object
        //            //rotate new object
        //            GameObject.Instantiate(wallPrefabs[0], gameObject.transform.position, Quaternion.Euler(0, 0, 0));

        //            //delete old object
        //            Destroy(gameObject, 0);
        //            //destroy script
        //            Destroy(this, 0);
        //        }


        //    }
        //    else if (left && down)
        //    {
        //        //check if already correct piece
        //        if (gameObject.name.Contains("WallCorner") && gameObject.transform.eulerAngles.y == 90)
        //        {
        //            return;
        //        }
        //        else if (leftHit.collider.name.Contains("Straight") && leftHit.collider.transform.eulerAngles.y == 180 && (downHit.collider.name.Contains("Straight")) && downHit.collider.transform.eulerAngles.y == 90)
        //        {
        //            print("Int Corner");
        //            //place new object
        //            //rotate new object
        //            GameObject.Instantiate(wallPrefabs[2], gameObject.transform.position, Quaternion.Euler(0, 0, 0));

        //            //delete old object
        //            Destroy(gameObject, 0);
        //            //destroy script
        //            Destroy(this, 0);
        //        }
        //        else
        //        {
        //            print("Ext Corner");
        //            print(gameObject.name);
        //            //place new object
        //            //rotate new object
        //            GameObject.Instantiate(wallPrefabs[0], gameObject.transform.position, Quaternion.Euler(0, 90, 0));

        //            //delete old object
        //            Destroy(gameObject, 0);
        //            //destroy script
        //            Destroy(this, 0);
        //        }


        //    }
        //    else if (left && up)
        //    {
        //        //check if already correct piece
        //        if (gameObject.name.Contains("WallCorner") && gameObject.transform.eulerAngles.y == 180)
        //        {
        //            //print("Correct Piece");
        //            return;
        //        }
        //        else
        //        {
        //            //place new object
        //            //rotate new object
        //            GameObject.Instantiate(wallPrefabs[0], gameObject.transform.position, Quaternion.Euler(0, 180, 0));

        //            //delete old object
        //            Destroy(gameObject, 0);
        //            //destroy script
        //            Destroy(this, 0);
        //        }


        //    }
        //    else if (right && up)
        //    {
        //        //check if already correct piece
        //        if (gameObject.name.Contains("WallCorner") && gameObject.transform.eulerAngles.y == 270)
        //        {
        //            print("Correct Piece");
        //            return;
        //        }
        //        else
        //        {
        //            //place new object
        //            //rotate new object
        //            GameObject.Instantiate(wallPrefabs[0], gameObject.transform.position, Quaternion.Euler(0, 270, 0));

        //            //delete old object
        //            Destroy(gameObject, 0);
        //            //destroy script
        //            Destroy(this, 0);
        //        }


        //    }

        //    #endregion

        //    //switch internal corner piece
        //    #region internal corner piece WIP

        //    if (left && down)
        //    {

        //    }

        //    #endregion

        //    //switch to face outside if connected to corner
        //    #region face corner side
        //    if (up)
        //    {
        //        if (upHit.collider.name.Contains("WallCorner") && upHit.collider.transform.eulerAngles.y == 0)
        //        {
        //            //check if already correct piece
        //            if (gameObject.name.Contains("WallStraight") && gameObject.transform.eulerAngles.y == 270)
        //            {
        //                //print("Correct Piece");
        //                return;
        //            }
        //            else
        //            {
        //                //place new object
        //                //rotate new object
        //                GameObject.Instantiate(wallPrefabs[1], gameObject.transform.position, Quaternion.Euler(0, 270, 0));

        //                //delete old object
        //                Destroy(gameObject, 0);
        //                //destroy script
        //                Destroy(this, 0);
        //            }

        //        }
        //        else if (upHit.collider.name.Contains("WallCorner") && upHit.collider.transform.eulerAngles.y == 90)
        //        {
        //            //check if already correct piece
        //            if (gameObject.name.Contains("WallStraight") && gameObject.transform.eulerAngles.y == 90)
        //            {
        //                return;
        //            }
        //            else
        //            {
        //                //place new object
        //                //rotate new object
        //                GameObject.Instantiate(wallPrefabs[1], gameObject.transform.position, Quaternion.Euler(0, 90, 0));

        //                //delete old object
        //                Destroy(gameObject, 0);
        //                //destroy script
        //                Destroy(this, 0);
        //            }

        //        }
        //    }

        //    if (down)
        //    {
        //        if (downHit.collider.name.Contains("WallCorner") && downHit.collider.transform.eulerAngles.y == 180)
        //        {
        //            //check if already correct piece
        //            if (gameObject.name.Contains("WallStraight") && gameObject.transform.eulerAngles.y == 90)
        //            {
        //                //print("Correct Piece");
        //                return;
        //            }
        //            else
        //            {
        //                //place new object
        //                //rotate new object
        //                GameObject.Instantiate(wallPrefabs[1], gameObject.transform.position, Quaternion.Euler(0, 90, 0));

        //                //delete old object
        //                Destroy(gameObject, 0);
        //                //destroy script
        //                Destroy(this, 0);
        //            }

        //        }
        //        else if (downHit.collider.name.Contains("WallCorner") && downHit.collider.transform.eulerAngles.y == 270)
        //        {
        //            //check if already correct piece
        //            if (gameObject.name.Contains("WallStraight") && gameObject.transform.eulerAngles.y == 270)
        //            {
        //                //print("Correct Piece");
        //                return;
        //            }
        //            else
        //            {
        //                //place new object
        //                //rotate new object
        //                GameObject.Instantiate(wallPrefabs[1], gameObject.transform.position, Quaternion.Euler(0, 270, 0));

        //                //delete old object
        //                Destroy(gameObject, 0);
        //                //destroy script
        //                Destroy(this, 0);
        //            }

        //        }
        //    }

        //    if (left)
        //    {
        //        if (leftHit.collider.name.Contains("WallCorner") && leftHit.collider.transform.eulerAngles.y == 270)
        //        {
        //            //check if already correct piece
        //            if (gameObject.name.Contains("WallStraight") && gameObject.transform.eulerAngles.y == 180)
        //            {
        //                return;
        //            }
        //            else
        //            {
        //                //place new object
        //                //rotate new object
        //                GameObject.Instantiate(wallPrefabs[1], gameObject.transform.position, Quaternion.Euler(0, 180, 0));

        //                //delete old object
        //                Destroy(gameObject, 0);
        //                //destroy script
        //                Destroy(this, 0);
        //            }

        //        }
        //        else if (leftHit.collider.name.Contains("WallCorner") && leftHit.collider.transform.eulerAngles.y == 0)
        //        {
        //            //check if already correct piece
        //            if (gameObject.name.Contains("WallStraight") && gameObject.transform.eulerAngles.y == 0)
        //            {
        //                print("Correct Piece");
        //                return;
        //            }
        //            else
        //            {
        //                //place new object
        //                //rotate new object
        //                GameObject.Instantiate(wallPrefabs[1], gameObject.transform.position, Quaternion.Euler(0, 0, 0));

        //                //delete old object
        //                Destroy(gameObject, 0);
        //                //destroy script
        //                Destroy(this, 0);
        //            }

        //        }
        //    }

        //    if (right)
        //    {
        //        if (rightHit.collider.name.Contains("WallCorner") && rightHit.collider.transform.eulerAngles.y == 90)
        //        {
        //            //check if already correct piece
        //            if (gameObject.name.Contains("WallStraight") && gameObject.transform.eulerAngles.y == 0)
        //            {
        //                return;
        //            }
        //            else
        //            {
        //                //place new object
        //                //rotate new object
        //                GameObject.Instantiate(wallPrefabs[1], gameObject.transform.position, Quaternion.Euler(0, 0, 0));

        //                //delete old object
        //                Destroy(gameObject, 0);
        //                //destroy script
        //                Destroy(this, 0);
        //            }

        //        }
        //        else if (rightHit.collider.name.Contains("WallCorner") && rightHit.collider.transform.eulerAngles.y == 180)
        //        {
        //            //check if already correct piece
        //            if (gameObject.name.Contains("WallStraight") && gameObject.transform.eulerAngles.y == 180)
        //            {
        //                print("Correct Piece");
        //                return;
        //            }
        //            else
        //            {
        //                //place new object
        //                //rotate new object
        //                GameObject.Instantiate(wallPrefabs[1], gameObject.transform.position, Quaternion.Euler(0, 180, 0));

        //                //delete old object
        //                Destroy(gameObject, 0);
        //                //destroy script
        //                Destroy(this, 0);
        //            }

        //        }
        //    }


        //    #endregion

        //    //match walls next to you
        //    #region match adjacent walls
        //    if (down && !up && !right && !left)
        //    {
        //        if (downHit.collider.name.Contains("Straight") && downHit.collider.transform.eulerAngles.y != gameObject.transform.eulerAngles.y)
        //        {
        //            //place new object
        //            //rotate new object
        //            GameObject.Instantiate(wallPrefabs[1], gameObject.transform.position, Quaternion.Euler(0, downHit.collider.transform.eulerAngles.y, 0));

        //            //delete old object
        //            Destroy(gameObject, 0);
        //            //destroy script
        //            Destroy(this, 0);
        //        }
        //    }
        //    if (up && !down && !right && !left)
        //    {
        //        if (upHit.collider.name.Contains("Straight") && upHit.collider.transform.eulerAngles.y != gameObject.transform.eulerAngles.y)
        //        {
        //            //place new object
        //            //rotate new object
        //            GameObject.Instantiate(wallPrefabs[1], gameObject.transform.position, Quaternion.Euler(0, upHit.collider.transform.eulerAngles.y, 0));

        //            //delete old object
        //            Destroy(gameObject, 0);
        //            //destroy script
        //            Destroy(this, 0);
        //        }
        //    }
        //    if (left && !down && !up && !left)
        //    {
        //        if (leftHit.collider.name.Contains("Straight") && leftHit.collider.transform.eulerAngles.y != gameObject.transform.eulerAngles.y)
        //        {
        //            //place new object
        //            //rotate new object
        //            GameObject.Instantiate(wallPrefabs[1], gameObject.transform.position, Quaternion.Euler(0, leftHit.collider.transform.eulerAngles.y, 0));

        //            //delete old object
        //            Destroy(gameObject, 0);
        //            //destroy script
        //            Destroy(this, 0);
        //        }
        //    }
        //    if (right && !left && !up && !down)
        //    {
        //        if (rightHit.collider.name.Contains("Straight") && rightHit.collider.transform.eulerAngles.y != gameObject.transform.eulerAngles.y)
        //        {
        //            //place new object
        //            //rotate new object
        //            GameObject.Instantiate(wallPrefabs[1], gameObject.transform.position, Quaternion.Euler(0, rightHit.collider.transform.eulerAngles.y, 0));

        //            //delete old object
        //            Destroy(gameObject, 0);
        //            //destroy script
        //            Destroy(this, 0);
        //        }
        //    }
        //    #endregion
        //}


        #endregion
    }

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
