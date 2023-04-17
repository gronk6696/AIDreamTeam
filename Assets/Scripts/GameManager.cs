using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public Vector3 targetLocation;

    public void MoveAllAIControllersToTarget()
    {
        AIController[] aiControllers = FindObjectsOfType<AIController>();
        foreach (AIController aiController in aiControllers)
        {
            aiController.MoveToTargetLocation(targetLocation);
        }
    }
}
