using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text Score;
    public Text highScore;

    public float scoreCount,highScoreCount;

    public float pointsPerSec;

    public bool isIncreasing;
    // Start is called before the first frame update
    void Start()
    {
        isIncreasing = false;

        if(PlayerPrefs.HasKey("HighScore"))
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerManager.isGameStarted)
        {
            isIncreasing = true;
        }
        else
        {
            isIncreasing = false;
            
        }
        if(isIncreasing)
        {
        scoreCount += pointsPerSec * Time.deltaTime;
        }
        if(scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore",highScoreCount);
        }
        Score.text = "Score: " + Mathf.Round(scoreCount);
        highScore.text = "highScore: " + Mathf.Round(highScoreCount);
    }


    //SCORE MULTIPLIER POWERUP


}
