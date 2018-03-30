using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDoor : MonoBehaviour {

    public GameObject[] enemies;

    //When you enter the box/door
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].GetComponent<CheeseManAI>())
                {
                    enemies[i].GetComponent<CheeseManAI>().Activate();
                }
                if (enemies[i].GetComponent<LiftOff>())
                {
                    enemies[i].GetComponent<LiftOff>().Activate();
                }
            }
            Destroy(gameObject);
        }
    }
}
