using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGrowing : GameBehaviour
{

    float treeSize;
    Vector3 minTreeSize;
    Vector3 maxTreeSize;
    float speed = 25;
    public bool mature;
    public bool cutDown;


    // Start is called before the first frame update
    void Start()
    {
        maxTreeSize = new Vector3(1.5f,1.5f, 1.5f);
        minTreeSize = new Vector3(1,1, 1);
        treeSize = RandomFloatBetweenTwoFloats(1f, 1.5f);
        gameObject.transform.localScale = new Vector3(treeSize,treeSize,treeSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (!mature)
        {
            gameObject.transform.localScale = Vector3.Lerp(transform.localScale, maxTreeSize, speed * Time.deltaTime);

            if (gameObject.transform.localScale == maxTreeSize) mature = true;
        }

        if(cutDown)
        {
            gameObject.transform.localScale = minTreeSize;
            ExecuteAfterSeconds(2, () => cutDown = false);
            ExecuteAfterSeconds(2, () => mature = false);
        }
        
    }
}
