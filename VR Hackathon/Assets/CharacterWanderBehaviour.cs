using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterWanderBehaviour : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent _navMeshAgent;
    [SerializeField]
    private float _maxWalkDistance = 10f;

    private Vector3 _currentDestination;

    void Start()
    {
        _navMeshAgent.destination = GetRandomPositionOnNavmesh();
        _navMeshAgent.isStopped = false;
    }

    private Vector3 GetRandomPositionOnNavmesh()
    {
        Vector3 direction = Random.insideUnitSphere * _maxWalkDistance;
        direction += transform.position;

        NavMeshHit hit;
        NavMesh.SamplePosition(direction, out hit, Random.Range(0f, _maxWalkDistance), 1);

        return hit.position;
    }


}
