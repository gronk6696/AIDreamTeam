using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int health = 10;
    public Slider healthBar;
    public GameObject body;
    public int barHeight;
    public void ChangeHealth(int value)
    {
        Debug.Log("Health changed by " + value.ToString());
        health += value;
    }

    private void Update()
    {
        healthBar.value = health;
        healthBar.transform.position = body.transform.position + new Vector3(0,barHeight,0);
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
