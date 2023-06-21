using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour
{
    public float strength;
    public Vector3 directon;
    public float speed = 1f; // Speed at which the WindArea moves

    public bool willDestroy;


    private void Update()
    {
        // Move the WindArea to the left in Z axis
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Destroy WindArea object if it passes the user and exits the camera
        if (transform.position.x > PlayerController.instance.transform.position.x && !willDestroy)
        {
            willDestroy = true;
            Destroy(gameObject, 3);
        }
    }

}