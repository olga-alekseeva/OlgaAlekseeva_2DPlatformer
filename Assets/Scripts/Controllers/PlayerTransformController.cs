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
        private const Vector3 _leftScale = new Vector3(-1, 1, 1);
        private const Vector3 _rightScale = new Vector3(1, 1, 1);
        private float _yVelosity;
        private bool _doJump;
        private float _xAxisInput;

        private LevelObjectView _view;
        private SpriteAnimatorController _animatorConroller;

        public PlayerTransformController(LevelObjectView view, SpriteAnimatorController spriteAnimator )
            _view = view;
    }
}
