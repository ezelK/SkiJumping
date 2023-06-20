using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour
{
    public float strength;
    public Vector3 directon;
    public float speed = 1f; // Speed at which the WindArea moves


    private void Update()
    {
        // Move the WindArea to the left in Z axis
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

 
}
