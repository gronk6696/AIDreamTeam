using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public Vector3 targetLocation;
    public int enemiesRemaining;
    public TextMeshProUGUI enemyText;

    public void Start(){

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesRemaining = enemies.Length;
        enemyText.text = "Enemies Remaining " + enemiesRemaining.ToString();

    }

    public void Update(){

GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
enemiesRemaining = enemies.Length;
enemyText.text = "Enemies Remaining " + enemiesRemaining.ToString();

    }




    public void MoveAllAIControllersToTarget()
    {
        AIController[] aiControllers = FindObjectsOfType<AIController>();
        foreach (AIController aiController in aiControllers)
        {
            aiController.MoveToTargetLocation(targetLocation);
        }
    }
}
