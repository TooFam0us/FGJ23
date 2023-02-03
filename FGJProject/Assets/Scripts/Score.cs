using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    
    public int score;
    public TMP_Text scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void UpdateScore()
    {   
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int points)
    {  
        score += points;
        UpdateScore();
    }

    public void LoseScore(int points)
    {
        if (score - points >= 0) 
        {
            score -= points; 
        } else {
            score = 0;
        }
        UpdateScore();
    }

}
