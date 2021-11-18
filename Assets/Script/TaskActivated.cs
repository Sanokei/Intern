using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskActivated : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [Header("Prefab GameObject holds the Minigame")]
    [SerializeField]
    private GameObject _minigame;

    /*
    not sure how the order works but imma put the minigame in awake
    so the excalimation can be in start when they get deactivated
    */

    void Awake()
    {
        _minigame.SetActive(false);
    }

    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //checks for if the mouse is in the collider
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject == gameObject)
                {
                    _minigame.SetActive(true);
                    //TODO ^ delete this and add
                    //instatiate the minigame
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
