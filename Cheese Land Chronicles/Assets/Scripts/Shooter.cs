using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Animator gunAnimator;
    public LayerMask enemyMask;
    public int damage;
    public int timer = 0;
    private bool reloading;
    public int reloadTime;

    public AudioSource fire;
    public AudioSource reload;

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 10000, Color.yellow, 0.0f, true);

        if (Input.GetMouseButtonDown(0) && reloading == false)
        {
            gunAnimator.SetTrigger("Shoot");
            fire.Play();
            reloading = true;

            Ray ray = Camera.main.ScreenPointToRay(transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(transform.position + transform.forward, transform.forward, out hit, 10000, enemyMask))
            {
                hit.collider.gameObject.GetComponentInParent<Enemy>().TakeDamage(damage);
                timer = reloadTime;
            }
        }

        if (reloading)
        {
            reload.Play();
            timer -= 1;
            if (timer <= 0)
            {
                reloading = false;
            }
        }
    }
}
