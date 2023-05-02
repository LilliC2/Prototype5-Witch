using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectingRoadCheck : GameBehaviour
{
    public GameObject[] roadPrefabs;

    bool right;
    bool left;
    bool up;
    bool down;

    RaycastHit upHit;
    RaycastHit downHit;
    RaycastHit leftHit;
    RaycastHit rightHit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_PB.heldBuidling != gameObject)
        {
            //check +z and -z
            if (Physics.Raycast(this.transform.position, Vector3.right, out rightHit, 1f))
            {
                if (rightHit.collider.CompareTag("Road"))
                {
                    print("hit object right");
                    right = true;
                }
                else right = false;

            }

            if (Physics.Raycast(this.transform.position, Vector3.left, out leftHit, 1f))
            {
                if (leftHit.collider.CompareTag("Road"))
                {
                    print("hit object left");
                    left = true;
                }
                else left = false;
            }
            if (Physics.Raycast(this.transform.position, Vector3.forward, out upHit, 1f))
            {

                if (upHit.collider.CompareTag("Road"))
                {
                    print("hit object up");
                    up = true;

                }
                else up = false;
            }
            if (Physics.Raycast(this.transform.position, Vector3.back, out downHit, 1f))
            {

                if (downHit.collider.CompareTag("Road"))
                {
                    print("hit object down");
                    down = true;
                }
                else down = false;
            }

            #region corner
            if (right && down)
            {
                //check if already correct piece
                if (gameObject.name.Contains("RoadCorner") && gameObject.transform.eulerAngles.y == 0)
                {
                    print("Correct Piece");
                    return;
                }
                else
                {
                    //place new object
                    //rotate new object
                    GameObject.Instantiate(roadPrefabs[0], gameObject.transform.position, Quaternion.Euler(0, 0, 0));

                    //delete old object
                    Destroy(gameObject, 0);
                    //destroy script
                    Destroy(this, 0);
                }


            }
            else if (left && down)
            {
                //check if already correct piece
                if (gameObject.name.Contains("RoadCorner") && gameObject.transform.eulerAngles.y == 90)
                {
                    return;
                }
                else
                {
                    print("Ext Corner");
                    print(gameObject.name);
                    //place new object
                    //rotate new object
                    GameObject.Instantiate(roadPrefabs[0], gameObject.transform.position, Quaternion.Euler(0, 90, 0));

                    //delete old object
                    Destroy(gameObject, 0);
                    //destroy script
                    Destroy(this, 0);
                }


            }
            else if (left && up)
            {
                //check if already correct piece
                if (gameObject.name.Contains("RoadCorner") && gameObject.transform.eulerAngles.y == 180)
                {
                    //print("Correct Piece");
                    return;
                }
                else
                {
                    //place new object
                    //rotate new object
                    GameObject.Instantiate(roadPrefabs[0], gameObject.transform.position, Quaternion.Euler(0, 180, 0));

                    //delete old object
                    Destroy(gameObject, 0);
                    //destroy script
                    Destroy(this, 0);
                }


            }
            else if (right && up)
            {
                //check if already correct piece
                if (gameObject.name.Contains("RoadCorner") && gameObject.transform.eulerAngles.y == 270)
                {
                    print("Correct Piece");
                    return;
                }
                else
                {
                    //place new object
                    //rotate new object
                    GameObject.Instantiate(roadPrefabs[0], gameObject.transform.position, Quaternion.Euler(0, 270, 0));

                    //delete old object
                    Destroy(gameObject, 0);
                    //destroy script
                    Destroy(this, 0);
                }


            }
            #endregion

            #region point in correct direction

            if (up || down && !left && !right)
            {
                if (upHit.collider.name.Contains("RoadCorner") && upHit.collider.transform.eulerAngles.y == 0 || downHit.collider.name.Contains("RoadCorner") && downHit.collider.transform.eulerAngles.y == 90)
                {
                    //check if already correct piece
                    if (gameObject.name.Contains("RoadStraight") && gameObject.transform.eulerAngles.y == 0)
                    {
                        print("Correct Piece");
                        return;
                    }
                    else
                    {
                        //place new object
                        //rotate new object
                        GameObject.Instantiate(roadPrefabs[2], gameObject.transform.position, Quaternion.Euler(0, 0, 0));

                        //delete old object
                        Destroy(gameObject, 0);
                        //destroy script
                        Destroy(this, 0);
                    }

                }
              
            }
            if (left || right && !up && !down)
            {
                if (leftHit.collider.name.Contains("Corner") || rightHit.collider.name.Contains("Corner") || leftHit.collider.name.Contains("Cross") || rightHit.collider.name.Contains("Cross"))
                {                     //check if already correct piece
                    if (gameObject.name.Contains("RoadStraight") && gameObject.transform.eulerAngles.y == 90)
                    {
                        print("Correct Piece");
                        return;
                    }
                    else
                    {
                        //place new object
                        //rotate new object
                        GameObject.Instantiate(roadPrefabs[3], gameObject.transform.position, Quaternion.Euler(0, 90, 0));

                        //delete old object
                        Destroy(gameObject, 0);
                        //destroy script
                        Destroy(this, 0);
                    }

                }

            }



            #endregion

            #region T
            if (up && right && down)
            {
                print("Should T");
                //check if already correct piece
                if (gameObject.name.Contains("T") && gameObject.transform.eulerAngles.y == 0)
                {
                    print("Correct Piece");
                    return;
                }
                else
                {
                    print("Make T");
                    //place new object
                    //rotate new object
                    GameObject.Instantiate(roadPrefabs[3], gameObject.transform.position, Quaternion.Euler(0, 0, 0));

                    //delete old object
                    Destroy(gameObject, 0);
                    //destroy script
                    Destroy(this, 0);
                }
            }
            #endregion

        }
    }
}
