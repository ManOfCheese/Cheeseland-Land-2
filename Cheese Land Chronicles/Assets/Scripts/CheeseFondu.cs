using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseFondu : MonoBehaviour {

    public PlayerHealth playerHealth;
    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        playerHealth.TakeDamage(damage);
    }

    private void OnTriggerStay(Collider other)
    {
        playerHealth.TakeDamage(damage);
    }
}
