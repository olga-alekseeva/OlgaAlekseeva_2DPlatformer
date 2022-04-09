using UnityEngine;

namespace Platformer_2D
{
    public class PlayerTransformController
    {
        private const float _speed = 5f;
        private const float _animationSpeed = 10f;
        private const float _jumpSpeed = 8f;
        private const float _g = -9.8f;
        private const float _movingTresh = 0.1f;
        private const float _jumpTresh = 1f;
        private const float _groundLevel = 0.2f;

        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);
        private float _yVelosity;
        private bool _doJump;
        private float _xAxisInput;

        private LevelObjectView _view;
        private SpriteAnimatorController _animatorConroller;

        public PlayerTransformController(LevelObjectView view, SpriteAnimatorController spriteAnimator)
        {
            _view = view;
            _animatorConroller = spriteAnimator;
            _animatorConroller.StartAnimation(_view._spriteRenderer, AnimState.Idle, true, _animationSpeed);
        }
        public void Update()
        {
            _doJump = Input.GetAxis("Vertical") > 0;
            _xAxisInput = Input.GetAxis("Horizontal");
            bool Move = Mathf.Abs(_xAxisInput) > _movingTresh;
            _animatorConroller.Update();             

            if(IsGrounded())
            {
                if(Move)
                {
                    MoveTowards();
                    _animatorConroller.StartAnimation(_view._spriteRenderer, Move ? AnimState.Run : AnimState.Idle, true, _animationSpeed);
                     
                }
                if(_doJump && _yVelosity == 0)
                {
                    _yVelosity = _jumpSpeed;
                }
                else if(_yVelosity<0)
                {
                    _yVelosity = 0;
                    _view._transform.position.Change(y: _groundLevel);
                }
                
            }
            else
            {
                if (Move) MoveTowards();
                if (Mathf.Abs(_yVelosity)>_jumpTresh)
                {
                    _animatorConroller.StartAnimation(_view._spriteRenderer, AnimState.Jump, true, _animationSpeed);
                }
                _yVelosity += _g * Time.deltaTime;
                _view._transform.position += Vector3.up * (Time.deltaTime * _yVelosity);
            }
        }
        private void MoveTowards()
        {
            _view._transform.position += Vector3.right * (Time.deltaTime * _speed * (_xAxisInput < 0 ? -1 : 1));
            _view._transform.localScale = (_xAxisInput < 0 ? _leftScale : _rightScale);
        }
        public bool IsGrounded()
        {
            return _view._transform.position.y <= _groundLevel && _yVelosity <= 0;
        }
    }
}