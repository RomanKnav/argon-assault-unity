using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    public int score;
    TMP_Text scoreText;     // reference to the "ScoreBoard" tmp score object

    void Start() 
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = score.ToString();
    }

    // this is called repeatedly in EnemyScript's update():
    public void IncreaseScore(int amountToIncrease) {
        score += amountToIncrease;
        scoreText.text = score.ToString();

        Debug.Log($"The current score is: {score}");
    }
}
