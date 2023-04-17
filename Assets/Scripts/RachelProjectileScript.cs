using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RachelProjectileScript : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
   
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("ENEMY HIT");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
