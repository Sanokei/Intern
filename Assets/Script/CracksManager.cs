using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CracksManager : MonoBehaviour
{
    public static CracksManager Instance{get; private set;}

    public int _cracksCounter;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
