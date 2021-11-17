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
    private GameObject[] _minigames;

    RaycastHit hit;
    Ray ray;

    void Start()
    {
        randomizeTasks();
    }
    void Update()
    {
        for(int index = 0; index < _tasks.Length; index++)
        {
           if (!_tasks[index].activeSelf && !_minigames[index].activeSelf){
                StartCoroutine(MoveToTask(_tasks[index]));
           }
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
            GameObject temp_mini = _minigames[randomIndex];
            _tasks[randomIndex] = _tasks[i];
            _tasks[i] = temp_task;
            _minigames[randomIndex] = _minigames[i];
            _minigames[i] = temp_mini;
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