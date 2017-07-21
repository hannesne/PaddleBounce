using System;
using UnityEngine;

public class ScoreboardBehaviour : MonoBehaviour
{
    public TextMesh ScoreText;
    private int currentScore;
    private int highScore;

    private void Start()
    {
        ScoreText.text = "Grab the\npaddle\nto\n<b>start</b>";
        currentScore = 0;
    }


    internal void IncrementScore()
    {
        currentScore++;
        SetScore();
    }

    private void SetScore()
    {
        ScoreText.text = "Score\n<b>" + currentScore + "</b>\n<i>High\n" + highScore + "</i>";
    }

    internal void ResetScore()
    {
        if (currentScore > highScore)
            highScore = currentScore;
        currentScore = 0;
    }
}