using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    private NavMeshAgent laurenGermz;

    void Start()
    {
        laurenGermz = GetComponent<NavMeshAgent>();
    }



    public void MoveToTargetLocation(Vector3 targetLocation)
    {
        laurenGermz.SetDestination(targetLocation);
    }
}
