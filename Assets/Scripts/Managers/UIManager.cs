using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;
    public TextMeshProUGUI scoreText;

    public Animator finishMenuAnimator;
    public TextMeshProUGUI finishMenuScoreText;

    private void Awake()
    {
        MakeSingleton();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Set the score as 0 initial score
        scoreText.text = ScoreManager.instance.initialScoreString;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void MakeSingleton()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(this.gameObject);
        }
    }


    // Calculate the player's score according to the its flying time WHEN THE PLAYER FALLS
    public void UpdateScoreText(double score)
    {
        score = Convert.ToInt32(score);
        scoreText.text = "Score: "+ score.ToString();
        finishMenuScoreText.text = "Your score: "+ score.ToString();

    }

    public IEnumerator ShowFinishMenuInTime()
    {
        // wait 2 sec
        yield return new WaitForSeconds(2);

        // Enable animator
        finishMenuAnimator.enabled = true;
    }
}
