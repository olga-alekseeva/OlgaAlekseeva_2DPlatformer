using System;
using UnityEngine;
using static UnityEngine.ParticleSystem;

namespace Platformer_2D
{
    public class BulletView : LevelObjectView

    {
        [SerializeField] private TrailRenderer _trail;
        public void SetVisible(bool visible)
        {
            if (_trail) _trail.enabled = visible;
            if (_trail) _trail.Clear();
            SpriteRenderer spriteRenderer = new SpriteRenderer();
            spriteRenderer.enabled = visible;
        }
    }
}
