using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [Tooltip("Adds amount to maxHitPoints when enemy dies")]
    [SerializeField] int difficultyRamp = 1;
    [SerializeField] GameObject enemyExplosionVFX;
    [SerializeField] AudioClip enemyExplosionSFX;

    int currentHitPoint = 0;
    Enemy enemy;
    MusicPlayer musicPlayer;

    // Start is called before the first frame update
    private void Start()
    {
        enemy = GetComponent<Enemy>();
        musicPlayer = FindObjectOfType<MusicPlayer>();
    }

    void OnEnable()
    {
        currentHitPoint = maxHitPoints;
    }

    // Update is called once per frame
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentHitPoint--;
        if (currentHitPoint <= 0)
        {
            ProcessDeathSequence();
        }
    }

    private void ProcessDeathSequence()
    {
        musicPlayer.PlaySFX(enemyExplosionSFX);
        var explosionVFX = Instantiate(enemyExplosionVFX, transform.position, Quaternion.identity);
        Destroy(explosionVFX, 5f);
        gameObject.SetActive(false);
        maxHitPoints += difficultyRamp;
        enemy.RewardGold();
        enemy.GetScore();
    }
}
