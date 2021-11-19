using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.EventSystems;

public class FaxOrTrash_MinigameLoop : MonoBehaviour
{
    [SerializeField]
    private Image[] _checkmarks;
    [SerializeField]
    private Sprite _checkmarkSprite;
    [SerializeField]
    private GameObject _minigame;
    [SerializeField]
    private GameObject JunkPrefab;
    [SerializeField]
    private Sprite ShredSprite;
    [SerializeField]
    private Sprite FaxSprite;
    [SerializeField]
    private RectTransform _canvasRectTransform;
    [SerializeField]
    private RectTransform _graphicsRectTransform;
    [HideInInspector]
    public bool _isJunkActive = false;

    public static FaxOrTrash_MinigameLoop Instance { get; private set; }
    void Start()
    {
        Instance = this;
    }
    void Update(){
        if(!_isJunkActive){
            SpawnJunk();
        }
    }

    public void AddScore(){
        foreach(Image checkmark in _checkmarks){
            if(checkmark.sprite != _checkmarkSprite){
                checkmark.sprite = _checkmarkSprite;
                break;
            }
        }
        if(_checkmarks[2].sprite == _checkmarkSprite){
            Destroy(_minigame);
        }
    }
    public void SpawnJunk()
    {
        _isJunkActive = true;
        GameObject Junk = Instantiate(JunkPrefab, _canvasRectTransform.position , _canvasRectTransform.rotation, _graphicsRectTransform);
        Junk.GetComponent<Image>().sprite = Random.Range(0,2) == 0 ? ShredSprite : FaxSprite;
    }
}
