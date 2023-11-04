using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreText;
    private int currentScore = 0;

    void Update()
    {
        // Atualize o texto da pontuação com a pontuação atual
        scoreText.text = "Score: " + currentScore;
    }

    public void UpdateScore(int newScore)
    {
        currentScore = newScore;
    }
}
