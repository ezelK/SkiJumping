using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{

    // Make this class accessible by other classes
    public static ScenesManager Instance;

    void Awake()
    {
        Instance = this;
    }

    // List of constances that we cannot change
    public enum Scene
    {
        MenuScene,
        Level01
    }

    // Load the passed scene
    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    
    public void LoadNewGame()
    {
        SceneManager.LoadScene(Scene.Level01.ToString());
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Scene.MenuScene.ToString());
    }
}
