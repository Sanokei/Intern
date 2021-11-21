using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class FaxOrTrash : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private Image _image;
    [SerializeField]
    private RectTransform _imageRectTransform;
    Vector2 pos, mousePos;
    //Cant get cuz of prefab
    private Canvas _Canvas;
    private RectTransform _canvasRectTransform;
    private RectTransform _faxRectTransform;
    private RectTransform _trashRectTransform;
    
    void Start()
    {
        _faxRectTransform = GameObject.Find("Fax").GetComponent<RectTransform>();
        _trashRectTransform = GameObject.Find("Shredder").GetComponent<RectTransform>();
        _Canvas = GetComponentInParent<Canvas>();
        _canvasRectTransform = _Canvas.GetComponent<RectTransform>();
    }
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
        
        if(RectTransformUtility.RectangleContainsScreenPoint(_faxRectTransform, data.position, _Canvas.worldCamera))
        {
            if(_image.sprite.name == "toFax")
            {
                FaxOrTrash_MinigameLoop.Instance.AddScore();
            }
            else
            {
                
            }
            FaxOrTrash_MinigameLoop.Instance._isJunkActive = false;
            Destroy(_image);
        }
        else if(RectTransformUtility.RectangleContainsScreenPoint(_trashRectTransform, data.position, _Canvas.worldCamera))
        {
            if(_image.sprite.name == "toJunk")
            {
                FaxOrTrash_MinigameLoop.Instance.AddScore();
            }
            else
            {
                
            }
            FaxOrTrash_MinigameLoop.Instance._isJunkActive = false;
            Destroy(_image);
        }
    }

}
