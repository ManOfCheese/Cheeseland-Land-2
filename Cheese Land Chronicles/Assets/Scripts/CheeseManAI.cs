using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CheeseManAI : Enemy {

    private NavMeshAgent navMeshAgent;
    private Animator animator;
    public GameObject target;
    public PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        navMeshAgent.SetDestination(target.transform.position);

        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance + 1)
        {
            animator.SetBool("Walk Forward", false);
            animator.SetTrigger("PunchTrigger");
        }
        else if (navMeshAgent.remainingDistance > navMeshAgent.stoppingDistance + 1)
        {
            animator.SetBool("Walk Forward", true);
        }
	}

    public void GiveDamage()
    {
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance + 1)
        {
            playerHealth.TakeDamage(10);
            Debug.Log("Taken Damage");
        }
    }
}
