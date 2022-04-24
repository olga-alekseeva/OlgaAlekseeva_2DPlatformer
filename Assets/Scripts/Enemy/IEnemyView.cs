using System;
using UnityEngine;

namespace Platformer_2D
{
    public interface IEnemyView : ICloneable
    {
        public Transform transform { get; }

        public Transform bulletSpawnTransform { get; }

        public Collider collider { get; }


    }
}