using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_2D
{
    public class EnemyObjectView : IEnemyView
    {
        public Transform transform { get;  set; }

        public Transform bulletSpawnTransform { get; }

        public Collider collider { get; }
        public IEnemyBehaviour enemyBehaviour { get;}

        public EnemyObjectView(Transform transform)
        {
            this.transform = transform;

            enemyBehaviour = transform.GetComponent<EnemyBehaviour>();
        }
    }
}