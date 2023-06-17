using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameRestart : MonoBehaviour
{

    [SerializeField] Button _restartBtn;

    // Git test

    // Start is called before the first frame update
    void Start()
    {
        _restartBtn.onClick.AddListener(LoadRestart);
    }

    private void LoadRestart()
    {
        // Load the main menu scene (return to the menu)
        ScenesManager.Instance.LoadNewGame();
    }
}
