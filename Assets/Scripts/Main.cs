using System.Collections.Generic;
using UnityEngine;

namespace Platformer_2D
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private GameObject _background;
        [SerializeField] private GameObject _middleBackground;
        [SerializeField] private GameObject _middleFrontBackground;
        [SerializeField] private GameObject _frontBackground;
        [SerializeField] private SpriteAnimatorConfig _playerConfig;
        [SerializeField] private SpriteAnimatorConfig _coinConfig;
        [SerializeField] private SpriteAnimatorConfig _enemyConfig;
        [SerializeField] private int _playerAnimationSpeed = 15;
        [SerializeField] private int _enemyAnimationSpeed = 3;
        [SerializeField] private LevelObjectView _playerView;
        [SerializeField] private LevelObjectView _enemyView;
        //[SerializeField] private LevelObjectView _waterView;
        [SerializeField] private CannonView _cannonView;
        [SerializeField] private List<LevelObjectView> _coinViews;
        [SerializeField] private QuestView _questView;
        [SerializeField]private CharacterObjectConfig _playerObjectConfig;
       // [SerializeField] private PlayerObjectView _playerView;

        private SpriteAnimatorController _enemyAnimator;
        private SpriteAnimatorController _playerAnimator;
        private SpriteAnimatorController _coinAnimator;
        private CannonAimController _cannonAimController;
        private BulletEmitterController _bulletEmitterController;
        private PlayerController _playerController;
        private CameraController _cameraController;
        private CoinsController _coinsController;
        private ParalaxController _paralaxController;

      //  [SerializeField] private SpriteAnimatorConfig _waterConfig;
       // private SpriteAnimatorController _waterAnimator; 
        private QuestConfiguratorController _questConfiguratorController;

        private void Awake()
        {
            _cameraController = new CameraController(_playerView, Camera.main.transform);

            _playerConfig = Resources.Load<SpriteAnimatorConfig>("Player/PlayerAnimCfg");
            _playerAnimator = new SpriteAnimatorController(_playerConfig);
            _playerAnimator.StartAnimation(_playerView._spriteRenderer, AnimState.Idle, true, _playerAnimationSpeed);
            _playerObjectConfig = Resources.Load<CharacterObjectConfig>("Player/PlayerObjectCfg");
            _playerController = new PlayerController(_playerView, _playerAnimator, _playerObjectConfig);


            _enemyConfig = Resources.Load<SpriteAnimatorConfig>("Enemies/EnemyAnimCfg");
            _enemyAnimator = new SpriteAnimatorController(_enemyConfig);
            _enemyAnimator.StartAnimation(_enemyView._spriteRenderer, AnimState.Idle, true, _enemyAnimationSpeed);

            _coinConfig = Resources.Load<SpriteAnimatorConfig>("Bonuses/CoinAnimCfg");
            _coinAnimator = new SpriteAnimatorController(_coinConfig);
            _coinsController = new CoinsController(_playerView, _coinViews, _coinAnimator);

           // _waterConfig = Resources.Load<SpriteAnimatorConfig>("WaterAnimCfg");
           // _waterAnimator = new SpriteAnimatorController(_waterConfig);
           // _waterAnimator.StartAnimation(_waterView, _spriteRenderer);

            _cannonAimController = new CannonAimController(_cannonView._muzzleTransform, _playerView._transform); 
            _bulletEmitterController = new BulletEmitterController(_cannonView._bullets, _cannonView._emitterTransform);
            _paralaxController = new ParalaxController(_camera.transform, _background.transform, _middleBackground.transform, _middleFrontBackground.transform, _frontBackground.transform);

            _questConfiguratorController = new QuestConfiguratorController(_questView);
            _questConfiguratorController.Init();    
        }

        void Update()
        { 
            _cameraController.Update();
            _playerController.Update();
            _enemyAnimator.Update();
            _cannonAimController.Update();
            _bulletEmitterController.Update();
            _coinAnimator.Update();
            _paralaxController.Update();
           // _waterAnimator.Update();
        }
    }
}