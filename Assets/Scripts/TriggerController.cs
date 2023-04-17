using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
 

        public void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Enemy")){
            
            Debug.Log("Collided with thing");
        }
    }


}
