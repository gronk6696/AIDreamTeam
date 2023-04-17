using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LaurenProjectileCollisions : MonoBehaviour
{
    public GameObject audioManagerObj;
    public AudioManager audioScript;
    public int damage = -1;


    public void Start(){
        GameObject audioManagerObj = GameObject.FindWithTag("AudioHolder");

        audioScript = audioManagerObj.GetComponent<AudioManager>();
    }
    
    public void OnCollisionEnter(Collision collision)
    {
        
        //Detects a collision between the projectile and objects tagged "Enemy"
        //If the Germz are hit, reduce the Enemy NavMeshSpeed to 1.75 for 3 seconds.
        //after 3 seconds, restore the original speed (3.5f)
        //delete the projectile on collision.
        if (collision.gameObject.CompareTag("Enemy"))
        {
            audioScript.PlaySound("Squirt");
            HealthManager healthManager = collision.gameObject.GetComponentInParent<HealthManager>();
            healthManager.ChangeHealth(damage);
            Debug.Log("ENEMY HIT");
            NavMeshAgent navMeshAgent = collision.gameObject.GetComponent<NavMeshAgent>();
            StartCoroutine(ResetSpeed(navMeshAgent));
            Destroy(gameObject);
        }
    }
    IEnumerator ResetSpeed(NavMeshAgent navMeshAgent)
    {
        navMeshAgent.speed = 1.75f;
        yield return new WaitForSeconds(3f);
        navMeshAgent.speed = 3.5f;  
        
    }
}
