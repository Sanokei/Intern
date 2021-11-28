using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskActivated : MonoBehaviour
{
    public Camera _camera;
    private GameObject _minigame;

    /*
    not sure how the order works but imma put the minigame in awake
    so the excalimation can be in start when they get deactivated
    */
    //Scratch that i made it a prefab
    void Start()
    {
        //get the minigame from the resources folder with the name of the parent
        _minigame = Resources.Load<GameObject>("Prefab/"+gameObject.transform.parent.name);
        //_camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    void Update()
    {
        CracksManager.Instance._cracksCounter++;
        if (Input.GetMouseButtonDown(0))
        {
            //checks for if the mouse is in the collider
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject == gameObject)
                {
                    Destroy(gameObject);
                    //_minigame.SetActive(true);
                    //TODO ^ delete this and add
                    //instatiate the minigame
                    GameObject _canvas = Instantiate(_minigame, transform.parent.position + new Vector3(0, 6, 0), transform.parent.rotation, transform.parent);
                    _canvas.GetComponentInChildren<Canvas>().worldCamera = _camera;
                }
            }
        }
    }
}
