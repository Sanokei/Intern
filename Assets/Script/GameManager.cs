using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Transform _camera;
    public static GameManager Instance { get; private set; }
    [HideInInspector]
    public bool isGameStarted;
    [SerializeField]
    Canvas gameCanvas;
    [SerializeField]
    Canvas timeCanvas;
    [SerializeField]
    private TextMeshProUGUI timeText;
    private bool isRotating;
    void Awake()
    {
        isGameStarted = false;
        isRotating = false;
        timeCanvas.enabled = false;
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetGameStarted()
    {
        isGameStarted = true;
        gameCanvas.enabled = false;
    }
    void Update(){
        //rotate the camera around an object
        if(!isGameStarted && !isRotating)
        {
            StartCoroutine(RotateCamera());
        }
        if(isGameStarted)
        {
            timeCanvas.enabled = true;
            timeText.text = ((int)Time.timeSinceLevelLoad).ToString();
        }
    }

    IEnumerator RotateCamera()
    {
        isRotating = true;
        for(float i = 0; i < 360; i++)
        {
            _camera.RotateAround(transform.position, Vector3.up, (i/1200) * Time.deltaTime);
        }
        isRotating = false;
        yield return null;
    }
}
