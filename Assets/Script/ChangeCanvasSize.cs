using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeCanvasSize : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = new Vector3(0.08f, 0.08f, 0.08f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);
    }

}
