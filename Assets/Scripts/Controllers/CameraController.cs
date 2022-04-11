using UnityEngine;

namespace Platformer_2D
{
    public class CameraController
    {
        private LevelObjectView _playerView;
        private Transform _playerTransform;
        private Transform _cameraTransform;

        private float _camSpeed = 1.2f;

        private float X;
        private float Y;

        private float offsetX;
        private float offsetY;

        private float _xAxisInput;
        private float _yAxisVelocity;

        private float _treshold;
        public CameraController(LevelObjectView player, Transform camera)
        { 
            _playerView = player;
            _cameraTransform = camera;
            _playerTransform = _playerView._transform;
            _treshold = 0.2f;

        }
       
        public void Update()
        {
            _xAxisInput = Input.GetAxis("Horizontal");
            _yAxisVelocity = _playerView._rb.velocity.y;

            X = _playerTransform.position.x;
            Y = _playerTransform.position.y;
            if(_xAxisInput > _treshold)
            {
                offsetX = 4;
            }
            else if(_xAxisInput < - _treshold)
            {
                offsetX = -4;
            }
            else
            {
                offsetX = 0;
            }
            if(_yAxisVelocity > _treshold)
            {
                offsetY = 4;
            }
            else if(_yAxisVelocity <-_treshold)
            {
                offsetY = -4;
            }
            else
            {
                offsetY = 0;
            }

            _cameraTransform.position = Vector3.Lerp(_cameraTransform.position, 
                new Vector3(X + offsetX, Y + offsetY,
                _cameraTransform.position.z),Time.deltaTime * _camSpeed);


        }
    }
}