using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CheeseManAI : Enemy {

    private NavMeshAgent navMeshAgent;
    private Animator animator;
    public GameObject target;
    public int attackRadius;
    public int damage;
    public PlayerHealth playerHealth;
    public bool isActive = false;

    // Use this for initialization
    void Start() {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        animator = gameObject.GetComponent<Animator>();
        target = GameObject.Find("FPSController");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) <= attackRadius && isActive)
        {
            navMeshAgent.SetDestination(target.transform.position);

            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance + 1 && Vector3.Distance(transform.position, playerHealth.transform.position) <= 5)
            {
                animator.SetBool("Walk Forward", false);
                animator.SetTrigger("PunchTrigger");
            }
            else if (navMeshAgent.remainingDistance > navMeshAgent.stoppingDistance + 1)
            {
                animator.SetBool("Walk Forward", true);
            }
        }
    }

    public void Activate ()
    {
        isActive = true;
    }

    public void GiveDamage()
    {
        playerHealth.TakeDamage(damage);
    }
}
