using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Vector3 targetLocation;
    public GameObject GameOverScreen;


    public void Start(){
        
        GameOverScreen.SetActive(false);

    }

    public void MoveAllAIControllersToTarget()
    {
        AIController[] aiControllers = FindObjectsOfType<AIController>();
        foreach (AIController aiController in aiControllers)
        {
            aiController.MoveToTargetLocation(targetLocation);
        }
    }


    public void ReloadLevel(){
        SceneManager.LoadScene("SampleScene");
    }
}
