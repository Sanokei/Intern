using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class GameLoop : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer[] _checkmarks;
    [SerializeField]
    private Sprite _checkmarkSprite;
    [SerializeField]
    private GameObject _minigame;
    
    private float _gameLength,timeCount;
    
    void Update()
    {
        while(_minigame.activeSelf)
        {
            _gameLength += Time.deltaTime;
            if(_gameLength >= 30)
            {
                Destroy(_minigame);
                //since its instatiated in the scene, we need to destroy it
            }
            //instatiate the junk or fax
        }
    }
}
