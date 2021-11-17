using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCanvasSize : MonoBehaviour
{
    
    public void OnEnter()
    {
        transform.localScale = new Vector3(0.08f, 0.08f, 0.08f);
    }

    public void OnExit()
    {
        transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);
    }

}
