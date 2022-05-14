using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_2D
{
    public class EnemyController
    {
        private PlayerObjectView _playerObjectView;
        private CharacterObjectConfig _enemyObjectConfig;
        //private CharacterObjectConfig _playerObjectConfig;
        private EnemyObjectView _enemyObjectView;
        private SetHealthValueController _changeHealth;
        private EnemyDamage _damage;
        private Player _player;

        bool movingSide = true;
        bool patrouling = false;
        bool attack = false;
        bool goOnPatrolPoint = false;
        

        public EnemyController
            (PlayerObjectView playerObjectView,CharacterObjectConfig enemyObjectConfig, EnemyObjectView enemyObjectView )
        {
            
            _playerObjectView = playerObjectView;
            _enemyObjectConfig = enemyObjectConfig;
            _enemyObjectView = enemyObjectView;
        }
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                _damage.Damage(_player.health, _enemyObjectConfig.fireForce);
            }
        }

        public void Update()
        {
         OnTriggerEnter2D(_playerObjectView._collider);
      

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

        }
        void GoOnPatrolPoint()
        {
            _enemyObjectView._enemyTransformPosition.transform.position =
                Vector2.MoveTowards(_enemyObjectView._enemyTransformPosition.transform.position, _enemyObjectView.pointOfPatrol.position, 
                _enemyObjectConfig.speed * Time.deltaTime);
        }
    }
}