using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_2D
{
    public class EnemyController
    {
        private PlayerObjectView _playerObjectView;
        private CharacterObjectConfig _enemyObjectConfig;
        private CharacterObjectConfig _playerObjectConfig;
        private EnemyObjectView _enemyObjectView;
        private SetHealthValueController _changeHealth;
        private EnemyDamage _damage;
        private Player _player;
        private UIView _UIView;

        bool movingSide = true;
        bool patrouling = false;
        bool attack = false;
        bool goOnPatrolPoint = false;
        

        public EnemyController
            (PlayerObjectView playerObjectView,CharacterObjectConfig enemyObjectConfig, EnemyObjectView enemyObjectView,CharacterObjectConfig playerObjectConfig, UIView uIView)
        {
            
            _playerObjectView = playerObjectView;
            _enemyObjectConfig = enemyObjectConfig;
            _enemyObjectView = enemyObjectView;
            _playerObjectConfig = playerObjectConfig;
            _UIView = uIView;
        }

        void OnCollisionEnter(Collider2D collider)
        {
            
            if (_playerObjectView._collider.gameObject.tag == "Player")
            {
                Damage();
                if ( _UIView._healthValueSlider.value < 10)
                {
                    GoOnPatrolPoint();
                }
            }
        }

        public void Update()
        {


            if(Vector2.Distance(_enemyObjectView._enemyTransformPosition.transform.position, _enemyObjectView.pointOfPatrol.position) <
                _enemyObjectView.patrolDistance && attack == false)
            {
                patrouling = true;
            }
            if(Vector2.Distance(_enemyObjectView._enemyTransformPosition.transform.position,
                _playerObjectView._transform.position) < _enemyObjectView.stoppingDistance)
            {
                attack = true;
               
                patrouling = false;
                goOnPatrolPoint = false;
            }
            if(Vector2.Distance(_enemyObjectView.
                _enemyTransformPosition.transform.position, _playerObjectView._transform.position) >
                _enemyObjectView.stoppingDistance)
            {
                goOnPatrolPoint = true;
                attack = false;
            }
            if(patrouling == true)
            {
                Patrouling();
            }
            else if (attack == true)
            {
                Attack();

        
            }
            else if (goOnPatrolPoint == true)
            {
                GoOnPatrolPoint();
            }

        }
      

        void Patrouling()
        {
            if(_enemyObjectView._enemyTransformPosition.transform.position.x >
                _enemyObjectView.pointOfPatrol.position.x + _enemyObjectView.patrolDistance)
            {

                movingSide = false;
            }
            else if(_enemyObjectView._enemyTransformPosition.transform.position.x < _enemyObjectView.pointOfPatrol.position.x 
                - _enemyObjectView.patrolDistance)
            {
                movingSide=true;
            }
            if(movingSide)
            {
                _enemyObjectView._enemyTransformPosition.transform.position = new Vector2(_enemyObjectView._enemyTransformPosition.transform.position.x +
                    _enemyObjectConfig.speed * Time.deltaTime, _enemyObjectView._enemyTransformPosition.transform.position.y);
            }
            else
            {
                _enemyObjectView._enemyTransformPosition.transform.position =
                    new Vector2(_enemyObjectView._enemyTransformPosition.transform.position.x - _enemyObjectConfig.speed *
                    Time.deltaTime, _enemyObjectView._enemyTransformPosition.transform.position.y);
            }
        }
        void Attack()
        {
            _enemyObjectView._enemyTransformPosition.transform.position = Vector2.MoveTowards(_enemyObjectView._enemyTransformPosition.transform.position,
                _playerObjectView._transform.position, _enemyObjectConfig.speed * Time.deltaTime);
            OnCollisionEnter(_playerObjectView._collider);
        }
        void GoOnPatrolPoint()
        {
            _enemyObjectView._enemyTransformPosition.transform.position =
                Vector2.MoveTowards(_enemyObjectView._enemyTransformPosition.transform.position, _enemyObjectView.pointOfPatrol.position, 
                _enemyObjectConfig.speed * Time.deltaTime);
        }
         void Damage()
        {
          
                _UIView._healthValueSlider.value -= _enemyObjectConfig.fireForce;
                if (_UIView._healthValueSlider.value == 0)
                {
                    attack = false;
                }

            
        }
        


    }
}