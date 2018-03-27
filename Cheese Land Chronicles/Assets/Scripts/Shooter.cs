using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public LayerMask enemyMask;
    public int damage;

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 10000, Color.yellow, 0.0f, true);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(transform.position + transform.forward, transform.forward, out hit, 10000, enemyMask))
            {
                hit.collider.gameObject.GetComponentInParent<Enemy>().TakeDamage(damage);
            }
        }
    }
}
