using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public const int maxHealth = 100;
    public int currentHealth = maxHealth;
    public Text health;

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }

    private void Update()
    {
        health.text = "Health: " + currentHealth.ToString();
    }
}
