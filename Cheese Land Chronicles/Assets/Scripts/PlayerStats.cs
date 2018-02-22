using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public int maxHealth;
    public float health;
    public static bool hasOxygen = false;
    public float suffocationSpeed;

	// Use this for initialization
	void Start () {
        health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (hasOxygen == false)
        {
            health -= suffocationSpeed;
        }
	}
}
