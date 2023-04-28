using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameMenu : MonoBehaviour
{
    [SerializeField] Button _mainMenuBtn;

    // Git test

    // Start is called before the first frame update
    void Start()
    {
        _mainMenuBtn.onClick.AddListener(LoadMainMenu);
    }

    private void LoadMainMenu()
    {
        // Load the main menu scene (return to the menu)
        ScenesManager.Instance.LoadMainMenu();
    }
}
