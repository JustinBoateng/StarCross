using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetObject;
    private Vector2 initialOffset;
    private Vector2 cameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialOffset = transform.position - targetObject.position;
      //                this camera's position -  what the camera will be looking at's position
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cameraPosition = (Vector2)targetObject.position + initialOffset;
        transform.position = (Vector3)cameraPosition + new Vector3(0,0,-10); 
    }
}
