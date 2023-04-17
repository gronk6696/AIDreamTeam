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
    private List<GameObject> enemies;

    // This script is responsible for firing projectiles at enemies within range
// It uses a coroutine to periodically check for enemies and fire projectiles at them
// The script keeps track of the number of projectiles fired and limits the number of projectiles per wave
// The projectiles are fired towards the closest enemy within range
// The script calculates the direction to face the closest enemy and sets the rotation of the character accordingly
// It then instantiates the projectile prefab, sets its direction and velocity, and destroys it after a set time
// If no enemies are in range, the coroutine waits for a short time before checking again
// The script can also destroy enemies with the "Enemy" tag one by one, keeping track of the remaining enemies on the board.


    void Start()
    {
        enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        StartCoroutine(FireCoroutine());
    }

    IEnumerator FireCoroutine()
    {
        while (enemies.Count > 0)
        {
            List<GameObject> enemiesInRange = new List<GameObject>();
            foreach (GameObject enemy in enemies)
            {
                if (enemy != null)
                {
                    float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                    if (distanceToEnemy <= fireDistance)
                    {
                        enemiesInRange.Add(enemy);
                    }
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
                        if (enemy != null)
                        {
                            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

                            if (distanceToEnemy <= fireDistance && distanceToEnemy < closestDistance)
                            {
                                closestEnemy = enemy;
                                closestDistance = distanceToEnemy;
                            }
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

            // Remove destroyed enemies from the list
            enemies.RemoveAll(enemy => enemy == null);
        }
    }
}



