using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public static int score = 0;
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    [SerializeField] private AudioClip clickButtonSFX;

    private void Start()
    {
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0);
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        if(score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            
        }
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("HighScore");
        SoundManager.instance.PlaySound(clickButtonSFX);
    }
}
