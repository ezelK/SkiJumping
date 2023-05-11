using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerEnter(Collider coll)
    {
       // If MainCamera enters to the plane, switch to Side Camera
       if (coll.gameObject.tag == "Player")
       {
            GeneralCameraManager.instance.ShowSideView();
       } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
