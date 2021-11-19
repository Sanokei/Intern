using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTask : MonoBehaviour
{
    [SerializeField]
    private GameObject _exclamation;
    private bool _inBounds = false;

    void Update()
    {
        if(_inBounds && transform.childCount == 0){
            Instantiate(_exclamation, transform.position + new Vector3(0, 1, 0), Quaternion.identity, transform);
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
}
