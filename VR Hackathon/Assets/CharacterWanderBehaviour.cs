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
    [SerializeField]
    private float _minWaitTime = 5f;
    [SerializeField]
    private float _maxWaitTime = 20f;

    public bool IsWaiting;

    private Vector3 _currentDestination;

    void Start()
    {
        _navMeshAgent.destination = GetRandomPositionOnNavmesh();
        _navMeshAgent.isStopped = false;
    }

    private void Update()
    {
        if(_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            if (IsWaiting == false)
            {
                StartCoroutine(WaitBeforeWandering());
            }
        }
    }

    private Vector3 GetRandomPositionOnNavmesh()
    {
        Vector3 direction = Random.insideUnitSphere * _maxWalkDistance;
        direction += transform.position;

        NavMeshHit hit;
        NavMesh.SamplePosition(direction, out hit, Random.Range(0f, _maxWalkDistance), 1);

        return hit.position;
    }

    private IEnumerator WaitBeforeWandering()
    {
        IsWaiting = true;

        float passedTime = 0;
        float timeToWait = Random.Range(_minWaitTime, _maxWaitTime);

        while(passedTime < timeToWait)
        {
            yield return null;
            passedTime += Time.deltaTime;
        }

        GoToARandomPosition();
    }

    private void GoToARandomPosition()
    {
        _navMeshAgent.destination = GetRandomPositionOnNavmesh();
        _navMeshAgent.isStopped = false;
        IsWaiting = false;
    }

}
