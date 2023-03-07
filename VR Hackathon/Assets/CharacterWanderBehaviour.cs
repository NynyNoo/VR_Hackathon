using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterWanderBehaviour : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent _navMeshAgent;

    void Start()
    {
        _navMeshAgent.destination = Vector3.zero;
        _navMeshAgent.isStopped = false;
    }
}
