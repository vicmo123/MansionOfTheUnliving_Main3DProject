using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAgentScript : MonoBehaviour
{
    public Transform followTarget { get; set; }
    public NavMeshAgent agent { get; set; }
    
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        if (followTarget)
        {
            agent.SetDestination(followTarget.position);
        }
    }

    public void SetTarget(Transform _followTarget)
    {
        followTarget = _followTarget;
    }
}
