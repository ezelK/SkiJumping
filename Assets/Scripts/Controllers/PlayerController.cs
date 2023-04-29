using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Transform playerTransform;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
        
    }

    // Used for phyisic updates
    private void FixedUpdate()
    {
        // Handle screen clicks.
        if (Input.GetMouseButtonDown(0))
        {
            // Get current velocity of player
            Vector3 currentVelocity = GetComponent<Rigidbody>().velocity;
            //Debug.Log("Current Velocity: " + currentVelocity);

            // Increase velocity in the forward direction by 5 units per click
            Vector3 newVelocity = currentVelocity + playerTransform.forward * 5f;
            currentVelocity = newVelocity;

            // Increase velocity in the down in Y axis by 5 units per click
            newVelocity = currentVelocity + Vector3.down * 5f;

            // Apply new velocity to player
            GetComponent<Rigidbody>().velocity = newVelocity;

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        UIManager.instance.UpdateScoreText();
    }
}
