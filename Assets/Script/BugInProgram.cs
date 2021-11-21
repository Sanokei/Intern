using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BugInProgram : MonoBehaviour
{
    [SerializeField]
    private Image[] _checkmarks;
    [SerializeField]
    private Sprite _checkmarkSprite;
    [SerializeField]
    private GameObject _minigame;
    
    [SerializeField]
    private Sprite[] _bugs;
    [SerializeField]
    private Sprite[] _codes;
    [SerializeField]
    private Button[] _codeButtons;
    [SerializeField]
    private Sprite _transparent;
    private bool _isDebugging = false;


    void Update(){
        if(!_isDebugging){
            StartDebug();
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

    public void StartDebug(){
        _isDebugging = true;
        //choose random from ProgramSprites
        _codeButtons[Random.Range(0, _codeButtons.Length)].image.sprite = _bugs[Random.Range(0, _bugs.Length)];
        //change the other ProgramSprites that are not the chosen one
        foreach(Button code in _codeButtons){
            //choose if none
            if(code.image.sprite.name == "transparent"){
                code.image.sprite = _codes[Random.Range(0, _codes.Length)];
            }
        }
    }

    public void onButtonClick(Button button){
        if(button.image.sprite.name.Contains("Bug")){
            AddScore();
        }
        else{
            //do nothing
        }
        _isDebugging = false;
        //reset all sprites
        foreach(Button code in _codeButtons){
            //choose if none
            code.image.sprite = _transparent;
        }
    }
}
