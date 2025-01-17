using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] Button _playBtn;
    [SerializeField] Button _exitBtn;

    // Start is called before the first frame update
    void Start()
    {
        _playBtn.onClick.AddListener(StartNewGame);
        _exitBtn.onClick.AddListener(ExitGame);
    }

    private void StartNewGame()
    {
        // Load the game scene (new game)
        ScenesManager.Instance.LoadNewGame();
    }

    private void ExitGame()
    {
        // Quit the app
        Application.Quit();
    }
}
