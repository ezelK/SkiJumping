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
        Level01,
        Finish
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

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Scene.MenuScene.ToString());
    }

    public void LoadFinish()
    {
        SceneManager.LoadScene(Scene.Finish.ToString());
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
