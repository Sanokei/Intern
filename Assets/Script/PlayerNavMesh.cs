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
    [SerializeField]
    private Transform[] _locationToRest;

    public static PlayerNavMesh Instance{get; private set;}
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        GoToRandomTask();
    }
    //go to a random task location
    public void GoToRandomTask()
    {

        GameObject[] filteredTask = System.Array.FindAll(_tasks, x => x.transform.childCount == 0);
        if(filteredTask.Length > 0)
        {
            _navMeshAgent.SetDestination(filteredTask[Random.Range(0,filteredTask.Length)].transform.position);
        }
        else
        {
            _navMeshAgent.SetDestination(_locationToRest[Random.Range(0,_locationToRest.Length)].position);
        }
    }

    //call GoToRandomTask() when the navMeshAgent has no other destination
}