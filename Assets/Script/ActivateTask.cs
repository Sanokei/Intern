using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ActivateTask : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private GameObject _exclamation;
    private Camera _camera;

    void Start()
    {
        _exclamation =  Resources.Load<GameObject>("Prefab/Exclamation Point");
        _camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        _navMeshAgent = GameObject.Find("Player").GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if(Vector3.Distance(gameObject.transform.position,_navMeshAgent.transform.position) < 2f && transform.childCount == 0){
             StartActivateTask();
        }
    }

    void StartActivateTask()
    {
        GameObject task = Instantiate(_exclamation, transform.position + new Vector3(0, 1, 0), Quaternion.identity, transform);
        task.GetComponent<TaskActivated>()._camera = _camera;
    }

}
