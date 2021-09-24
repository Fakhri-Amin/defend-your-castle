using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem particleProjectile;
    [SerializeField] float range = 15f;
    Transform target;

    // Update is called once per frame
    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    private void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float distanceBetween = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceBetween < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = distanceBetween;
            }
        }
        target = closestTarget;
    }

    private void AimWeapon()
    {
        if (!target) return;

        weapon.transform.LookAt(target);
        float distanceBetween = Vector3.Distance(transform.position, target.transform.position);
        if (distanceBetween < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    void Attack(bool isActive)
    {
        var emissionModule = particleProjectile.emission;
        emissionModule.enabled = isActive;
    }
}
