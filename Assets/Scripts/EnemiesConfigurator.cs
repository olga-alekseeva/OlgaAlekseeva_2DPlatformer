using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_2D
{
    public class EnemiesConfigurator : MonoBehaviour
    {
        [SerializeField] private PatrolConfig _patrolConfig;
        [SerializeField] private LevelObjectView _levelObjectView;
      
        private PatrolAI _patrolAI; 
        void Start()
        {
            _patrolAI = new PatrolAI(_levelObjectView, new PatrolModel( _patrolConfig));

        }
        void FixedUpdate()
        {
            if(_patrolAI != null) _patrolAI.FixedUpdate();
        }
      
    }
}