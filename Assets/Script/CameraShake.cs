using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float _cameraIntensity = 0.1f;
    private float _cameraDuration = 10f;
    private float _xPos;
    private float _zPos;
    [SerializeField]
    private Transform _cameraHolderTransform;
    public static CameraShake Instance{get; private set;}

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

    void Update()
    {
        StartShake();
    }

    private void StartShake()
    {
        _cameraIntensity++;
        StartCoroutine(ShakeCamera());
        ResetCamera();
    }

    private void ResetCamera()
    {
        transform.position = _cameraHolderTransform.position;
    }

    IEnumerator ShakeCamera()
    {
        yield return new WaitForSeconds(5f);
        _xPos = Random.Range(-_cameraIntensity, _cameraIntensity);
        _zPos = Random.Range(-_cameraIntensity, _cameraIntensity);
        while (_cameraDuration > 0)
        {
            transform.position = new Vector3(_xPos, transform.position.y, _zPos);
            _cameraDuration -= Time.deltaTime;
            yield return null;
        }
        ResetCamera();
    }

}
