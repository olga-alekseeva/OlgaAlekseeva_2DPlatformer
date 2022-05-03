using System;
using UnityEngine;

namespace Platformer_2D
{
    public interface IEnemyBehaviour
    {
        public event Action<IEnemy, Collision> actionOnColliderEnter;
        IEnemy enemy { get;  set; }
        public void OnCollisionEnter(Collision collision);
    }
}