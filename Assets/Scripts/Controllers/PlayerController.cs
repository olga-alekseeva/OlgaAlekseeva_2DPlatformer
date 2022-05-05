using UnityEngine;

namespace Platformer_2D
{
    public class PlayerController
    {
        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);

        private float _xVelosity;
        private bool _doJump;
        private float _xAxisInput;

        private CharacterObjectConfig _playerObjectConfig;
        private LevelObjectView _view;
        private SpriteAnimatorController _animatorConroller;
        private ContactPooler _contactPooler;
        SpriteAnimatorConfig _animatorConfig;
        public PlayerController(LevelObjectView view, SpriteAnimatorController spriteAnimator, CharacterObjectConfig playerObjectConfig, SpriteAnimatorConfig animatorConfig)
        {
            _playerObjectConfig = playerObjectConfig;
            _view = view;
            _animatorConroller = spriteAnimator;
            _animatorConfig = animatorConfig;
            _animatorConroller.StartAnimation(_view._spriteRenderer, AnimState.Idle, true, _animatorConfig.animationSpeed);
             _contactPooler = new ContactPooler(_view._collider);

        }
        public void Update()
        {
            _animatorConroller.Update();
            _contactPooler.Update();
            _doJump = Input.GetAxis("Vertical") > 0;
            _xAxisInput = Input.GetAxis("Horizontal");
            bool Move = Mathf.Abs(_xAxisInput) > _playerObjectConfig.movingTresh;

                if(Move)
                {
                    MoveTowards();     
                }
            if (_contactPooler.IsGrounded)
            {
                _animatorConroller.StartAnimation(_view._spriteRenderer, Move ? AnimState.Run : AnimState.Idle, true, _animatorConfig.animationSpeed);

                if (_doJump && _view._rb.velocity.y <= _playerObjectConfig.jumpTresh)
                {
                    _view._rb.AddForce(Vector2.up * _playerObjectConfig.jumpSpeed, ForceMode2D.Impulse);
                }
            }
            else
            {
                if (Mathf.Abs(_view._rb.velocity.y) > _playerObjectConfig.jumpTresh)
                {
                    _animatorConroller.StartAnimation(_view._spriteRenderer, AnimState.Jump, true, _animatorConfig.animationSpeed);
                }

            }
        }
        private void MoveTowards()
        {
            _xVelosity = Time.fixedDeltaTime * _playerObjectConfig.speed * (_xAxisInput < 0 ? -1 : 1);
            _view._rb.velocity = _view._rb.velocity.Change(x: _xVelosity);
            _view._transform.localScale = (_xAxisInput < 0 ? _leftScale : _rightScale);
        }
    }
}