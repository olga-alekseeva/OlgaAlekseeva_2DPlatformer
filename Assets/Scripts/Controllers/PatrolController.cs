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

        bool movingSide = true;
        bool patrouling = false;
        bool angry = false;
        bool goBack = false;

        public PatrolController(PatrolView patrolView, PlayerObjectView playerObjectView, CharacterObjectConfig enemyObjectConfig)
        {
            _patrolView = patrolView;   
            _playerObjectView = playerObjectView;
            _enemyObjectConfig = enemyObjectConfig;
            _playerObjectView._transform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        void Update()
        {

        }

        void Patrouling()
        {
            if(_patrolView.enemyTransform.position.x > _patrolView.pointOfPatrol.position.x + _patrolView.patrolDistance)
            {

                movingSide = true;
            }
            else if(_patrolView.enemyTransform.position.x < _patrolView.pointOfPatrol.position.x - _patrolView.patrolDistance)
            {
                movingSide=false;
            }
            if(movingSide)
            {
                _patrolView.enemyTransform.position = new Vector2(_patrolView.enemyTransform.position.x + _enemyObjectConfig.speed * Time.deltaTime, _patrolView.pointOfPatrol.position.y);
            }
            else
            {
                _patrolView.enemyTransform.position = new Vector2(_patrolView.enemyTransform.position.x + _enemyObjectConfig.speed * Time.deltaTime, _patrolView.pointOfPatrol.position.y);
            }
        }
        void Attack()
        {
            _patrolView.pointOfPatrol.position = Vector2.MoveTowards(_patrolView.enemyTransform.position, _playerObjectView._transform.position, _enemyObjectConfig.speed * Time.deltaTime*2);

        }
        void GoOnPatrolPoint()
        {
            _patrolView.pointOfPatrol.position = Vector2.MoveTowards(_patrolView.enemyTransform.position, _patrolView.pointOfPatrol.position, _enemyObjectConfig.speed * Time.deltaTime);
        }
    }
}