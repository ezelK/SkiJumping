using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCameraManager : MonoBehaviour
{
    // Camera follows the player with specified offset position
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;


    void FixedUpdate()// LateUpdate() for camera but changed to FixedUpdate() for smoothness
    {
        // offset is the distance between the player and the camera
        Vector3 desiredPosition = new Vector3(target.position.x - 40, target.position.y, target.position.z+50);
        // Lerp is used to smooth the camera movement
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // Camera follows the player with specified offset position
        transform.position = smoothedPosition;

        // Camera looks at the player
        //transform.LookAt(target);
    }
}
