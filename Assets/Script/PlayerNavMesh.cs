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

    RaycastHit hit;
    Ray ray;

    void Start()
    {
        randomizeTasks();
    }
    void Update()
    {
        int ChildCount = 0;
        for(int index = 0; index < _tasks.Length; index++)
        {
           //checks if _tasks[index] has instantiated the exclimation prefab or not
            if (_tasks[index].transform.childCount == 0)
            {
                StartCoroutine(MoveToTask(_tasks[index]));
            }
            else
            {
                ChildCount++;
            }
        }
        if( ChildCount == 0)
        {
            randomizeTasks();
        }
    }

    IEnumerator MoveToTask(GameObject task)
    {
        _navMeshAgent.SetDestination(task.transform.position);
        while (_navMeshAgent.remainingDistance > _navMeshAgent.stoppingDistance)
        {
            yield return null;
        }
    }

    void randomizeTasks()
    {
        for (int i = 0; i < _tasks.Length; i++)
        {
            int randomIndex = Random.Range(i, _tasks.Length);
            GameObject temp_task = _tasks[randomIndex];
            _tasks[randomIndex] = _tasks[i];
            _tasks[i] = temp_task;
        }
    }   
}

/*
// for testing
if (Input.GetMouseButtonDown(0))
        {
            ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                _navMeshAgent.SetDestination(hit.point);
            }
        }
*/