using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeChanger : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timeText;
    void Update()
    {
        if(GameManager.Instance.isGameStarted)
        {
            if(!gameObject.activeSelf)
            {
                gameObject.SetActive(true);
            }

            timeText.text = Time.timeSinceLevelLoad.ToString();

            if(CracksManager.Instance.amountOfCracks == 10)
            {
                //show the end screen
            }
        }
    }
}
