using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_2D
{
    public class EnemyBehaviour : MonoBehaviour, IEnemyBehaviour
   
    {
        public event Action<IEnemy, Collision> actionOnColliderEnter;
        public IEnemy enemy { get;  set; }

        public void OnCollisionEnter(Collision collision)
        {
            actionOnColliderEnter?.Invoke(enemy, collision);
        }

    }
}