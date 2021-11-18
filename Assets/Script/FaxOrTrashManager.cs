using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class FaxOrTrashManager : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private float _gameLength,timeCount;
    [SerializeField]
    private Canvas _Canvas;
    [SerializeField]
    private Image _image;
    [SerializeField]
    private RectTransform _canvasRectTransform;
    [SerializeField]
    private RectTransform _imageRectTransform;
    Vector2 pos, mousePos;

    public void OnDrag(PointerEventData data)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_Canvas.transform as RectTransform, data.position, _Canvas.worldCamera, out pos);
        if(pos.x + (_imageRectTransform.rect.width / 2) < _canvasRectTransform.rect.width / 2 && pos.x - (_imageRectTransform.rect.width / 2) > -_canvasRectTransform.rect.width / 2)
        {
            _imageRectTransform.anchoredPosition = new Vector2(pos.x, _imageRectTransform.anchoredPosition.y);
        }
        if(pos.y + (_imageRectTransform.rect.height / 2) < _canvasRectTransform.rect.height / 2 && pos.y - (_imageRectTransform.rect.height / 2) > -_canvasRectTransform.rect.height / 2)
        {
            _imageRectTransform.anchoredPosition = new Vector2(_imageRectTransform.anchoredPosition.x, pos.y);
        }
    }

    public void OnEndDrag(PointerEventData data)
    {
        //check which image it is on
        
    }

}
