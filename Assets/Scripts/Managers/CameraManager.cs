
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Camera follows the player with specified offset position
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void FixedUpdate()// LateUpdate() for camera but changed to FixedUpdate() for smoothness
    {   
        Vector3 desiredPosition = target.position + offset; // offset is the distance between the player and the camera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Lerp is used to smooth the camera movement
        transform.position = smoothedPosition; // Camera follows the player with specified offset position

        transform.LookAt(target); // Camera looks at the player
    }
}
