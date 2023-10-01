using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public int score;//Рекорд игры
    private int HighScore;//Максимальный рекод игры
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI highScoreText;
    void Awake()
    {
        score = 0;
        SetScoreText();
        SetHighScore();
        SetHighScoreText();
    }
    //Отобразить score
    public void SetScoreText()
    {
        scoreText.text = "Score:" + score.ToString();
    }
    //Запомнить максимальный рекорд
    public void SetHighScore()
    {
        if (PlayerPrefs.GetInt("HighScore") < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
        }
        HighScore = PlayerPrefs.GetInt("HighScore");
    }
    //Отобразить highScore
    public void SetHighScoreText()
    {
        highScoreText.text = "HighScore:" + HighScore.ToString();
    }
}
