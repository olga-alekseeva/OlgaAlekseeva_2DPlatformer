using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_2D
{
    public class SpawnPositionSettings : ISpawnPositionSettings
    {
        public float fieldMinX { get; } = -50f;
        public float fieldMaxX { get; } = 50f;
        public float fieldMinY { get; } = -50f;
        public float fieldMaxY { get; } = 50f;
        public float radiusOverlapSphere { get; } = 5;
        public string groundNameGameObject { get; } = "GroundPlane";
        public int maxColliders { get; } = 8;
    }
}