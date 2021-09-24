using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highscoreText;
    TextMeshProUGUI scoreText;

    Bank bank;

    // Start is called before the first frame update
    void Awake()
    {
        bank = FindObjectOfType<Bank>();
        scoreText = GetComponent<TextMeshProUGUI>();
        if (highscoreText)
        {
            highscoreText.text = "HIGHSCORE : " + PlayerPrefs.GetFloat("Highscore", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!bank) return;

        int score = bank.CurrentScore;
        scoreText.text = "SCORE : " + score;

        if (!highscoreText) return;

        if (score > PlayerPrefs.GetFloat("Highscore", 0))
        {
            PlayerPrefs.SetFloat("Highscore", score);
            highscoreText.text = "HIGHSCORE : " + score;
        }
    }
}
