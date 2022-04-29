using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_2D
{
    public interface ISpawnPositionSettings 
    {
        public string groundNameGameObject { get; }
        public float fieldMaxX { get; }
        public float fieldMaxY { get; }
        public float fieldMinX { get; }
        public float fieldMinY { get; }
        public float radiusOverlapSphere { get; }
        public int maxColliders { get; }

    }
}