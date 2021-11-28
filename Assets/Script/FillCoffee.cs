using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FillCoffee : MonoBehaviour, IPointerDownHandler, IPointerUpHandler 
{
    [SerializeField] private Image _coffee;
    [SerializeField] private Image _button;
    [SerializeField] private Sprite _buttonUp;
    [SerializeField] private Sprite _buttonDown; 
    [SerializeField] private GameObject _minigame;

    // Update is called once per frame
    void Update()
    {
        if(_coffee.fillAmount >= 0.9)
        {
            _button.sprite = _buttonDown;
            Destroy(_minigame);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //change button image
        _button.sprite = _buttonDown;
        _coffee.fillAmount += 0.1f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //change button image
        _button.sprite = _buttonUp;
    }

}
