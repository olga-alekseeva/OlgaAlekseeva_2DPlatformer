using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

namespace Platformer_2D
{
    public class EnemyController
    {
        public float stoppingDistance;
        bool chill = false;
        bool angry = false;
        bool goBack = false;
        bool movingRight = true;
       

        private CharacterObjectConfig _enemyObjectConfig;
        private LevelObjectView _view;
        private PlayerObjectView _playerObjectView;
        private PointOfPatrouling _patrouling;
        private SpriteAnimatorController _animatorController;
        private EnemyObjectView _enemyView;

        public EnemyController(CharacterObjectConfig config, LevelObjectView view, 
           SpriteAnimatorController animatorController)
        {
            _enemyObjectConfig = config;
            _view = view;
            
            _animatorController = animatorController;
            _animatorController.StartAnimation(_view._spriteRenderer, AnimState.Idle, true, _enemyObjectConfig.animationSpeed);
        }
        public void Update()
        {
            _animatorController.Update();
            if (Vector2.Distance(_enemyView.transform.position, _patrouling.pointOfPatrouling.position) < _patrouling.patroulRange && angry == false)
            {
                chill = true;
            }
            if (Vector2.Distance(_enemyView.transform.position, _playerObjectView._transform.position) < stoppingDistance)
            {
                angry = true;
                chill = false;
                goBack = false;
            }
            if (Vector2.Distance(_enemyView.transform.position, _playerObjectView._transform.position) > stoppingDistance)
            {
                goBack = true;
                angry = false;
            }
            if (chill == true)
            {
                Chill();
            }
            else if (angry == true)
            {
                angry = true;
            }
            else if (goBack == true)
            {
                GoBack();
            }

        }
        public void Chill()
        {
            if (_enemyView.transform.position.x > _patrouling.pointOfPatrouling.position.x + _patrouling.patroulRange)
            {
                movingRight = false;
            }
            else if (_enemyView.transform.position.x < _patrouling.pointOfPatrouling.position.x - _patrouling.patroulRange)
            {
                movingRight = true;
            }
            if (movingRight)
            {
                _enemyView.transform.position = new Vector2(_enemyView.transform.position.x + _enemyObjectConfig.speed * Time.deltaTime, _enemyView.transform.position.y);
            }
            else
            {
                _enemyView.transform.position = new Vector2(_enemyView.transform.position.x - _enemyObjectConfig.speed * Time.deltaTime, _enemyView.transform.position.y);
            }

        }
        void Angry()
        {
            float newSpeed = _enemyObjectConfig.speed * 2;
            _enemyView.transform.position = Vector2.MoveTowards(_enemyView.transform.position, _playerObjectView._transform.position, newSpeed * Time.deltaTime);
        }
        void GoBack()
        {
            _enemyView.transform.position = Vector2.MoveTowards(_enemyView.transform.position, _patrouling.pointOfPatrouling.position, _enemyObjectConfig.speed * Time.deltaTime);

        }
    }
}