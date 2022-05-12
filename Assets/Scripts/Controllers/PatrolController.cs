using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_2D
{
    public class PatrolController
    {
        private PatrolView _patrolView;
        private PlayerObjectView _playerObjectView;
        private CharacterObjectConfig _enemyObjectConfig;
        private EnemyObjectView _enemyObjectView;

        bool movingSide = true;
        bool patrouling = false;
        bool attack = false;
        bool goOnPatrolPoint = false;
        

        public PatrolController
            (PatrolView patrolView,
            PlayerObjectView playerObjectView,
            CharacterObjectConfig enemyObjectConfig)
        {
            _patrolView = patrolView;   
            _playerObjectView = playerObjectView;
            _enemyObjectConfig = enemyObjectConfig;
        }
        
       public void Update()
        {
            if(Vector2.Distance(_enemyObjectView._enemyTransformPosition.transform.position, _patrolView.pointOfPatrol.position) < 
                _patrolView.patrolDistance && attack == false)
            {
                patrouling = true;
            }
            if(Vector2.Distance(_enemyObjectView.
                _enemyTransformPosition.transform.position,
                _playerObjectView._transform.position) 
                < _patrolView.stoppingDistance)
            {
                attack = true;
                patrouling = false;
                goOnPatrolPoint = false;
            }
            if(Vector2.Distance(_enemyObjectView.
                _enemyTransformPosition.transform.position, 
                _playerObjectView._transform.position)> 
                _patrolView.stoppingDistance)
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
            if(_enemyObjectView._enemyTransformPosition.
                transform.position.x >
                _patrolView.pointOfPatrol.position.x
                + _patrolView.patrolDistance)
            {

                movingSide = false;
            }
            else if(_enemyObjectView.
                _enemyTransformPosition.transform.
                position.x < _patrolView.pointOfPatrol.
                position.x - _patrolView.patrolDistance)
            {
                movingSide=true;
            }
            if(movingSide)
            {
                _enemyObjectView._enemyTransformPosition.
                    transform.position = new Vector2
                    (_enemyObjectView._enemyTransformPosition.
                    transform.position.x + _enemyObjectConfig.
                    speed * Time.deltaTime, _enemyObjectView.
                    _enemyTransformPosition.
                    transform.position.y);
            }
            else
            {
                _enemyObjectView._enemyTransformPosition.
                    transform.position =
                    new Vector2(_enemyObjectView.
                    _enemyTransformPosition.transform.
                    position.x - _enemyObjectConfig.speed *
                    Time.deltaTime, _enemyObjectView.
                    _enemyTransformPosition.
                    transform.position.y);
            }
        }
        void Attack()
        {
            _enemyObjectView._enemyTransformPosition.
                transform.position = 
                Vector2.MoveTowards
                (_enemyObjectView._enemyTransformPosition.
                transform.position, 
                _playerObjectView._transform.position,
                _enemyObjectConfig.speed * Time.deltaTime*2);

        }
        void GoOnPatrolPoint()
        {
            _enemyObjectView._enemyTransformPosition.
                transform.position =
                Vector2.MoveTowards
                (_enemyObjectView._enemyTransformPosition.
                transform.position, _patrolView.pointOfPatrol.
                position, 
                _enemyObjectConfig.speed * Time.deltaTime);
        }
    }
}