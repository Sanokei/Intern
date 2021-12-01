using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMouseAroundPivot : MonoBehaviour
{
    [SerializeField]
    private Transform _camera;
    
    void Update(){
        //rotate the camera around an object
        if(Input.GetMouseButton(1) && GameManager.Instance.isGameStarted){ 
            //Vector3 point, Vector3 axis, float angle
            _camera.RotateAround(transform.position, Vector3.up, Input.GetAxis("Mouse X") * 10);
        }
    }

}
