using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int maxEnemyHealth;
    public int currentEnemyHealth;

    private void Start()
    {
        currentEnemyHealth = maxEnemyHealth;
    }

    public void TakeDamage(int amount)
    {
        currentEnemyHealth -= amount;
        if (currentEnemyHealth <= 0)
        {
            currentEnemyHealth = 0;
            Destroy(this.gameObject);
        }
    }
}
