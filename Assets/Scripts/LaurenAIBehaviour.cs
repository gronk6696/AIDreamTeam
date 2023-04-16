using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaurenAIBehaviour : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public float fireDistance = 10f;
    public int maxProjectilesPerWave = 5;
    public float delayBetweenWaves = 3f;
    private int currentProjectiles = 0;

            // Find all enemies within range
            // If an enemy is in range, Fire projectiles at the closest enemy.
            // Calculate direction to face the closest enemy.
            // Instantiate the projectile and calculate the direction to fire in.
            // Add force to the projectile.
            //increase the count of active projectiles.
            // after 1 second, destroy the fired projectile regardless of hit or not.
            //wait 3 seconds before firing again at enemies in range.
            //if no enemies in range, wait another 0.5 second(s) and check again.
    void Start()
    {
        StartCoroutine(FireCoroutine());
    }

    IEnumerator FireCoroutine()
    {
        while (true)
        {

            List<GameObject> enemiesInRange = new List<GameObject>();
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy <= fireDistance)
                {
                    enemiesInRange.Add(enemy);
                }
            }

            if (enemiesInRange.Count > 0)
            {
                for (int i = 0; i < Mathf.Min(maxProjectilesPerWave, enemiesInRange.Count); i++)
                {
                    GameObject closestEnemy = null;
                    float closestDistance = Mathf.Infinity;

                    foreach (GameObject enemy in enemiesInRange)
                    {
                        float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

                        if (distanceToEnemy <= fireDistance && distanceToEnemy < closestDistance)
                        {
                            closestEnemy = enemy;
                            closestDistance = distanceToEnemy;
                        }
                    }

                    if (closestEnemy != null)
                    {
                        Vector3 directionToEnemy = closestEnemy.transform.position - transform.position;
                        directionToEnemy.y = 0f;
                        Quaternion targetRotation = Quaternion.LookRotation(directionToEnemy);
                        targetRotation.eulerAngles = new Vector3(0f, targetRotation.eulerAngles.y, 0f);
                        transform.rotation = targetRotation;
                        GameObject projectile = Instantiate(projectilePrefab, transform.position + transform.forward, Quaternion.identity);
                        Vector3 directionToFire = closestEnemy.transform.position - projectile.transform.position;
                        directionToFire.Normalize();
                        Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
                        projectileRigidbody.velocity = directionToFire * projectileSpeed;
                        currentProjectiles++;
                        Destroy(projectile, 1f);
                    }

                    yield return new WaitForSeconds(1f);
                }
                yield return new WaitForSeconds(delayBetweenWaves);
            }
            else
            {
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}



