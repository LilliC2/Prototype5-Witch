using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float minFOV = 15f;
    float maxFOV = 90f;
    float senesitivity = 50;
    float FOV;
    public GameObject pivotPoint;
    // Update is called once per frame
    private void Start()
    {
        FOV = Camera.main.fieldOfView;
    }
    void Update()
    {
        
        FOV += Input.GetAxis("Mouse ScrollWheel") * senesitivity ;
        FOV = Mathf.Clamp(FOV, minFOV, maxFOV);
        Camera.main.fieldOfView = FOV;
        
        if(Input.GetMouseButton(1))
        {
            print("Holding button");
            float rotation = Input.GetAxis("Mouse X");
            print(rotation);
            pivotPoint.transform.Rotate(0, rotation*10, 0);

        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        pivotPoint.transform.Translate(new Vector3(horizontal, 0, vertical));
    }
}
