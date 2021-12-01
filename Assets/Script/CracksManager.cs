using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CracksManager : MonoBehaviour
{
    public static CracksManager Instance{get; private set;}
    private int _cracksCounter;
    [SerializeField]
    private GameObject[] _tasks;
    private GameObject _cracks;
    public int amountOfCracks;

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
    void Start()
    {
        _cracks = Resources.Load<GameObject>("Prefab/Cracks");
    }
    void Update()
    {
        if(amountOfCracks <= 10){
            GameObject[] filteredTask = System.Array.FindAll(_tasks, x => x.transform.childCount == 0);
            if(filteredTask.Length > 0)
            {
                _cracksCounter = 0;
            }
            else
            {
                StartCoroutine(WaitForCracks());
            }
            if(_cracksCounter % 1200 == 0 && _cracksCounter != 0)
            {
                Instantiate(_cracks, new Vector3(0, 0, 0), new Quaternion(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360),Random.Range(0, 360)));
                amountOfCracks++;
            }
        }
    }

    IEnumerator WaitForCracks()
    {
        yield return new WaitForSeconds(6f);
        _cracksCounter++;
    }
}
