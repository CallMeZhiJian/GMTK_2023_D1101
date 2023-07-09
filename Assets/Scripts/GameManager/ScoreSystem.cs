using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public static int score = 0;
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private void Start()
    {
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        if(score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = "High Score: " + score;
        }    
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScoreText.text = "High Score: 0";
    }
}
