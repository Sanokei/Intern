using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTask : MonoBehaviour
{
    [SerializeField]
    private GameObject _exclamation;

    [SerializeField]
    private GameObject _minigame;

    void OnTriggerEnter(Collider other)
    {
        //checking if the exclamation is active is redundant
        if(!_minigame.activeSelf && !_exclamation.activeSelf)
            _exclamation.SetActive(true);
    }
}
