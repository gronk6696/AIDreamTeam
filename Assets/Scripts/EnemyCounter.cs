using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyCounter : MonoBehaviour
{

    public int EnemiesLeft;
    public TextMeshProUGUI EnemyCountText;


    // Start is called before the first frame update
    void Start()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        EnemiesLeft = enemies.Length;
        EnemyCountText.text = EnemiesLeft.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        EnemiesLeft = enemies.Length;
        EnemyCountText.text = EnemiesLeft.ToString();

    }
}
