using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward = 25;
    [SerializeField] int goldPenalty = 25;
    [SerializeField] int scorePoint = 1;
    [SerializeField] int scorePenalty = 5;

    Bank bank;


    private void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    public void RewardGold()
    {
        if (bank == null) { return; }
        bank.Deposit(goldReward);
    }

    public void StealGold()
    {
        if (bank == null) { return; }
        bank.Withdraw(goldPenalty);
    }

    public void GetScore()
    {
        if (bank == null) return;
        bank.AddScore(scorePoint);
    }

    public void LoseScore()
    {
        if (bank == null) return;
        bank.SubstractScore(scorePenalty);
    }
}
