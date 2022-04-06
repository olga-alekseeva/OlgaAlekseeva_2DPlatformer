using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ParalaxController 
{
    public Transform _camera;
    public Transform _back;
    private Vector3 _backStartPosition;
    private Vector3 _cameraStartPosition;
    private const float _coef = 0.3f;

    public ParalaxController (Transform camera, Transform back)
    {
        _camera = camera;
        _back = back;
        _backStartPosition = _back.transform.position;
        _cameraStartPosition = _camera.transform.position;
    }
    
    public void Update()
    {
        _back.position = _backStartPosition + (_camera.position - _cameraStartPosition) * _coef;
    }
    
}
