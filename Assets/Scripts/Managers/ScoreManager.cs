using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    public int score;
    public string initialScoreString;

    private void Awake()
    {
        MakeSingleton();
    }

    // Start is called before the first frame update
    void Start()
    {
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

    public double CalculateScore(float lastPos)
    {

        // Last Z pos - starting Z pos
        // lastZpos - 139.4
        return Math.Abs(lastPos - 139.4);

    }

}
