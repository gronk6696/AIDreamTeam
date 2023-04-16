using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int health = 10;
    // Start is called before the first frame update
    public void ChangeHealth(int value)
    {
        health += value;
    }

    private void Update()
    {
        DeathCheck();
    }

    public void DeathCheck()
    {
        if (health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
