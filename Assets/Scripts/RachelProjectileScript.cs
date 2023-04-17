using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RachelProjectileScript : MonoBehaviour
{
    public int damage = -1;
    public void OnCollisionEnter(Collision collision)
    {
   
        if (collision.gameObject.CompareTag("Enemy"))
        {
            HealthManager healthManager = collision.gameObject.GetComponentInParent<HealthManager>();
            healthManager.ChangeHealth(damage);
            Debug.Log("ENEMY HIT");
            Destroy(gameObject);
        }
    }
}
