using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] private Transform target;
    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation= false;
        agent.updateUpAxis= false;
    }

    void Update()
    {
        agent.SetDestination(target.position);
    }
}
