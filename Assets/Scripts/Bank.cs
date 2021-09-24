using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance = 0;
    [SerializeField] int score = 0;
    TextMeshProUGUI goldText;
    TextMeshProUGUI scoreText;

    public int CurrentBalance { get { return currentBalance; } }
    public int CurrentScore { get { return score; } }

    private void Awake()
    {
        SetUpSingleton();
        scoreText = FindObjectOfType<Score>().gameObject.GetComponent<TextMeshProUGUI>();
        goldText = GameObject.FindGameObjectWithTag("GoldUI").GetComponent<TextMeshProUGUI>();
        currentBalance = startingBalance;
    }

    private void Update()
    {
        // DestroySelf();
        UpdateGoldDisplay();
    }

    void SetUpSingleton()
    {
        int num = FindObjectsOfType<Bank>().Length;
        if (num > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);

        if (currentBalance < 0)
        {
            currentBalance = 0;
            FindObjectOfType<SceneLoader>().LoadNextScene();
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
    }

    public void SubstractScore(int amount)
    {
        score -= amount;
        if (score < 0)
        {
            score = 0;
        }
    }

    void UpdateGoldDisplay()
    {
        goldText.text = "GOLD : " + currentBalance;
    }

    public void RestartEverything()
    {
        Destroy(gameObject);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
