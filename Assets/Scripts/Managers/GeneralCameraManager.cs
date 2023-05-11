using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralCameraManager : MonoBehaviour
{
    public Camera startCamera;
    public Camera sideCamera;
    public static GeneralCameraManager instance;

    private void Awake()
    {
        MakeSingleton();
    }

    private void MakeSingleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Call this function to disable FPS camera,
    // and enable overhead camera.
    public void ShowStartView()
    {
        sideCamera.enabled = false;
        startCamera.enabled = true;
    }

    // Call this function to enable FPS camera,
    // and disable overhead camera.
    public void ShowSideView()
    {
        sideCamera.enabled = true;
        startCamera.enabled = false;
    }
}
