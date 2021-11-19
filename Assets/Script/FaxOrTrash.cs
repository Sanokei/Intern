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
        _Canvas = GetComponentInParent<Canvas>();
        _canvasRectTransform = _Canvas.GetComponent<RectTransform>();
        _faxRectTransform = _Canvas.transform.Find("Screen/Game/Graphics/Fax").GetComponent<RectTransform>();
        _trashRectTransform = _Canvas.transform.Find("Screen/Game/Graphics/Shredder").GetComponent<RectTransform>();
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
        //check which image it is on
        if(_imageRectTransform.rect.Overlaps(_faxRectTransform.rect) && _imageRectTransform.rect.Overlaps(_trashRectTransform.rect))
        {
            Destroy(_image.gameObject);
            FaxOrTrash_MinigameLoop.Instance._isJunkActive = false;
            if(_image.sprite.name == "toFax"){
                //correct
                FaxOrTrash_MinigameLoop.Instance.AddScore();
            }
        }
        if(_imageRectTransform.rect.Overlaps(_trashRectTransform.rect) && !_imageRectTransform.rect.Overlaps(_faxRectTransform.rect) )
        {
            Destroy(_image.gameObject);
            FaxOrTrash_MinigameLoop.Instance._isJunkActive = false;
            if(_image.sprite.name == "toJunk"){
                //correct
                FaxOrTrash_MinigameLoop.Instance.AddScore();
            }
        }
    }

}
