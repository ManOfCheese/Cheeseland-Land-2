using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public const float maxHealth = 100;
    public float currentHealth = maxHealth;
    public Text health;
    public GameObject gameOverScreen;

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            gameOverScreen.SetActive(true);
            Invoke("LoadFirstScene", 5);
        }
    }

    private void LoadFirstScene ()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        Mathf.RoundToInt(currentHealth);
        health.text = "Health: " + currentHealth.ToString();
    }
}
