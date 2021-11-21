using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMesh : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent _navMeshAgent;
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private GameObject[] _tasks;

    //go to a random task location
    public void GoToRandomTask()
    {
        int randomTaskIndex;
        do{
            randomTaskIndex = Random.Range(0, _tasks.Length);
        }
        while(_tasks[randomTaskIndex].transform.childCount != 0);
        _navMeshAgent.SetDestination(_tasks[randomTaskIndex].transform.position);
    }

    //call GoToRandomTask() when the navMeshAgent has no other destination
    private void Update()
    {
        if (_navMeshAgent.remainingDistance < 0.01f)
        {
            GoToRandomTask();
        }
    }
}