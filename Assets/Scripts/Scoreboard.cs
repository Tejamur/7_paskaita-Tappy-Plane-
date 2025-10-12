using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    public GameObject scoreBoard;

    [Header("Medals")]
    public Sprite goldMedal;
    public Sprite silverMedal;
    public Sprite bronzeMedal;

    [Header("Textboxes")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestText;

    private void Start()
    {
        scoreBoard.SetActive(false);
    }

    public void ShowScore(int score)
    {
        scoreText.text = "SCORE: " + score.ToString();
        scoreBoard.SetActive(true);

        if(PlayerPrefs.HasKey("BestScore"))
        {
            var best = PlayerPrefs.GetInt("BestScore");

            if(best > score)
            {
                bestText.text = "BEST: " + best.ToString();
            }
            else
            {
                bestText.text = "BEST: " + score.ToString();
                PlayerPrefs.SetInt("BestScore", score);
                PlayerPrefs.Save();
            }
            
        }
        else
        {
            bestText.text = "BEST: " + score.ToString();
            PlayerPrefs.SetInt("BestScore", score);
            PlayerPrefs.Save();
        }
    }

}
