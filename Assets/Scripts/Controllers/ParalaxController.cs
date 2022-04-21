using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_2D
{
    public sealed class ParalaxController
    {
        public Transform _camera;
        public Transform _back;
        public Transform _middleBack;
        public Transform _front;
        public Vector3 _backStartPosition;
        public Vector3 _middleBackStartPos;
        public Vector3 _frontStartPos;
        public Vector3 _cameraStartPosition;
       // private const float _coef = 0.3f;
        private const float _midCoef = 0.5f;
        private const float _frontCoef = -1f;


        public ParalaxController(Transform camera, Transform back, Transform middleBack, Transform front)
        {
            _camera = camera;
            _back = back;
            _middleBack = middleBack;
            _front = front;
            _backStartPosition = _back.transform.position;
            _middleBackStartPos = _middleBack.transform.position;
            _frontStartPos = _front.transform.position;
            _cameraStartPosition = _camera.transform.position;
        }
        public void Update()
        {
            _back.position = _backStartPosition + (_camera.position -
            _cameraStartPosition) ;
            _middleBack.position = _middleBackStartPos + (_camera.position - _cameraStartPosition) * _midCoef;
            _front.position = _frontStartPos + (_camera.position - _cameraStartPosition) * _frontCoef;

        }

    }
}