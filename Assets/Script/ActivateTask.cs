using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTask : MonoBehaviour
{
    private GameObject _exclamation;
    private bool _inBounds = false;
    private Camera _camera;
    void Start()
    {
        _exclamation =  Resources.Load<GameObject>("Prefab/Exclamation Point");
        _camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    void Update()
    {
        if(_inBounds && transform.childCount == 0){
            
            StartActivateTask();
            
        }
    }
    void OnTriggerEnter(Collider other)
    {
        _inBounds = true;
    }
    void OnTriggerExit(Collider other)
    {
        _inBounds = false;
    }
    void StartActivateTask()
    {
        GameObject task = Instantiate(_exclamation, transform.position + new Vector3(0, 1, 0), Quaternion.identity, transform);
        task.GetComponent<TaskActivated>()._camera = _camera;
        
        PlayerNavMesh.Instance.GoToRandomTask();
    }
}
