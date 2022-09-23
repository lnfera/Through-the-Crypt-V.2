using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookraduis = 10f;
    public Transform target;
    public NavMeshAgent agent;
    public LayerMask LayerGround;
    public LayerMask LayerPlayer;

    public float AttackCooldown;

    public float AttackRange;
    public float SightRange;
    private bool InAttackRange;
    private bool InSightRange;
    
    

    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player").transform;
    }

    
    // Update is called once per frame
    void Update()
    {
        InAttackRange = Physics.CheckSphere(transform.position, AttackRange, LayerPlayer);
        InSightRange = Physics.CheckSphere(transform.position, SightRange, LayerPlayer);

        if (InSightRange && !InAttackRange) ChasePlayer();
        if (InSightRange && InAttackRange) AttackPlayer();
    }

    private void ChasePlayer()
    {
        Debug.Log("SpottedPlayer");
        agent.SetDestination(target.position);
    }

    private void AttackPlayer()
    {
        Debug.Log("AttackingPlayer");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, SightRange);
    }
}
