using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Transform playerTransform;
    public float speed;
    public bool inWindArea = false;
    public GameObject Player;
    public GameObject windArea;
    private double score;

    private ParticleSystem snowParticle;
    Rigidbody rb;
    private Quaternion previousRotation;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
        rb = GetComponent<Rigidbody>();  
        animator = GetComponent<Animator>();
        snowParticle = GetComponent<ParticleSystem>();
    }

    // Used for phyisic updates
    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity))
        {
            // Calculate the slope angle
            float slopeAngle = Vector3.Angle(Vector3.up, hit.normal);

            if (slopeAngle > 5f)
            {
                animator.SetBool("isMoving", true);

                // Apply rotation adjustment
                Quaternion targetRotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
                Quaternion smoothRotation = Quaternion.Slerp(previousRotation, targetRotation, 1.2f * Time.deltaTime);
                smoothRotation = smoothRotation.normalized;
                rb.MoveRotation(smoothRotation);
                previousRotation = smoothRotation;
            }
            
        }
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
            rb.velocity = newVelocity;

        }

        // If player in Wind Area, add a force to player's rigidbody
        if(inWindArea)
        {
            rb.AddForce(windArea.GetComponent<WindArea>().directon * windArea.GetComponent<WindArea>().strength);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        // Rotate user around itself in X axis
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(new Vector3(0.5f, 0, 0));
        } else if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(new Vector3(-0.5f, 0, 0));
        }else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isJumped", true);
            Vector3 currentVelocity = GetComponent<Rigidbody>().velocity;
            Vector3 newVelocity = currentVelocity + playerTransform.forward* 0.08f; ;
            currentVelocity = newVelocity;
            rb.velocity = newVelocity;
            
        }
       
   
        
    }

  

    void OnTriggerEnter(Collider coll)
    {
        // Check the player in Wind Area
        if(coll.gameObject.tag == "WindArea")
        {
            windArea = coll.gameObject;
            inWindArea = true;
        }

        // Check players falls or not, if he fell calculate the score
        if (coll.gameObject.tag == "FinishRamp")
        {
            
            animator.SetBool("isFalling", true);
            animator.SetBool("isJumped", false);



            snowParticle.Play();
            // Calculate the score 
            score= ScoreManager.instance.CalculateScore(Player.transform.position.x);


            // Update score text
            UIManager.instance.UpdateScoreText(score);

            // Finish game
            StartCoroutine(UIManager.instance.ShowFinishMenuInTime());



            // Stop player 
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.isKinematic = true;
            }

        }

    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "WindArea")
        {
            inWindArea = false;
        }
    }

}
