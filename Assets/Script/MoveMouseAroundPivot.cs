using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMouseAroundPivot : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    
    void Update(){
        //rotate the camera around an object
        if(Input.GetMouseButton(1)){ 
            //Vector3 point, Vector3 axis, float angle
            _camera.transform.RotateAround(transform.position, Vector3.up, Input.GetAxis("Mouse X") * 10);
        }
    }

}
