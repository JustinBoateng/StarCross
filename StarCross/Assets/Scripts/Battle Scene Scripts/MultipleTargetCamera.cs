using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
//we add this so that if a camera component isn't present, Unity will spawn it to whatever object this script is attached to
public class MultipleTargetCamera : MonoBehaviour
{
    public List<Transform> targets;

    public Vector3 offset;

    public float smoothTime = 0.5f;

    public Vector3 velocity;


    public float minZoom = 40f;
    public float maxZoom = 10f;
    public float ZoomLimiter = 10f;

    private Camera Cam;

    private void Start()
    {
        Cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if (targets.Count == 0) return;

        Move();

        Zoom();
    }
    //Late Update acts just like Update, but only RIGHT AFTER. 
    //This is good because we want our camera to move ONLY after everything else has moved that frame

    private void Move()
    {
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);

    }

    private void Zoom()
    {
        //Debug.Log(GetGreatestDistance());

        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / ZoomLimiter);
        //Mathf.Lerp scales between Variable 1 and Variable 2 depending on the Variable 3 value.
        //keep in mind that with GGD(), Variable 3 will be changing constantly
        //while we were debug.log-ing the GGD, the values tend to be between 1 and 5. 
        //so, since the third variable needs to be between 0 and 1,
        //we divide GGD by 10

        //Cam.fieldOfView = Mathf.Lerp(Cam.fieldOfView, newZoom, Time.deltaTime);
        Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, newZoom, Time.deltaTime);

    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for(int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.size.x;

    }


    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for(int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
            //resizes the bounds box to include the new target (for each target)
        }

        return bounds.center;

    }

}
