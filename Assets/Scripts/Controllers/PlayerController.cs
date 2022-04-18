using UnityEngine;

namespace Platformer_2D
{
    public class PlayerController
    {
        private const float _speed = 150f;
        private const float _animationSpeed = 10f;
        private const float _jumpSpeed = 10f;
        private const float _movingTresh = 0.1f;
        private const float _jumpTresh = 1f;

        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);

        private float _xVelosity;
        private bool _doJump;
        private float _xAxisInput;

        private LevelObjectView _view;
        private SpriteAnimatorController _animatorConroller;
        private ContactPooler _contactPooler;

        public PlayerController(LevelObjectView view, SpriteAnimatorController spriteAnimator)
        {
            _view = view;
            _animatorConroller = spriteAnimator;
            _animatorConroller.StartAnimation(_view._spriteRenderer, AnimState.Idle, true, _animationSpeed);
             _contactPooler = new ContactPooler(_view._collider);

        }
        public void Update()
        {
            _animatorConroller.Update();
            _contactPooler.Update();
            _doJump = Input.GetAxis("Vertical") > 0;
            _xAxisInput = Input.GetAxis("Horizontal");
            bool Move = Mathf.Abs(_xAxisInput) > _movingTresh;

                if(Move)
                {
                    MoveTowards();     
                }
            if (_contactPooler.IsGrounded)
            {
                _animatorConroller.StartAnimation(_view._spriteRenderer, Move ? AnimState.Run : AnimState.Idle, true, _animationSpeed);

                if (_doJump && _view._rb.velocity.y <= _jumpTresh)
                {
                    _view._rb.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
                }
            }
            else
            {
                if (Mathf.Abs(_view._rb.velocity.y) > _jumpTresh)
                {
                    _animatorConroller.StartAnimation(_view._spriteRenderer, AnimState.Jump, true, _animationSpeed);
                }

            }
        }
        private void MoveTowards()
        {
            _xVelosity = Time.fixedDeltaTime * _speed * (_xAxisInput < 0 ? -1 : 1);
            _view._rb.velocity = _view._rb.velocity.Change(x: _xVelosity);
            _view._transform.localScale = (_xAxisInput < 0 ? _leftScale : _rightScale);
        }
    }
}