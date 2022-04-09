using UnityEngine;

namespace Platformer_2D
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private SpriteAnimatorConfig _playerConfig;
        [SerializeField] private int _playerAnimationSpeed = 15;
        [SerializeField] private LevelObjectView _playerView;
        private SpriteAnimatorController _playerAnimator;

        [SerializeField] private SpriteAnimatorConfig _enemyConfig;
        [SerializeField] private int _enemyAnimationSpeed = 3;
        [SerializeField] private LevelObjectView _enemyView;
        private SpriteAnimatorController _enemyAnimator;

        private PlayerTransformController _playerController;
       // private ParalaxController _paralaxController;

        private void Awake()
        {
            _playerConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimCfg");
            _playerAnimator = new SpriteAnimatorController(_playerConfig);
            _playerAnimator.StartAnimation(_playerView._spriteRenderer, AnimState.Idle, true, _playerAnimationSpeed);

            _enemyConfig = Resources.Load<SpriteAnimatorConfig>("EnemyAnimCfg");
            _enemyAnimator = new SpriteAnimatorController(_enemyConfig);
            _enemyAnimator.StartAnimation(_enemyView._spriteRenderer, AnimState.Idle, true, _enemyAnimationSpeed);

            _playerController = new PlayerTransformController(_playerView, _playerAnimator);
           // _paralaxController = new ParalaxController(_paralaxController._camera, _paralaxController._back);
        }

        void Update()
        { 
           // _playerAnimator.Update();
            _enemyAnimator.Update();
            _playerController.Update();
         //   _paralaxController.Update();
        }
    }
}