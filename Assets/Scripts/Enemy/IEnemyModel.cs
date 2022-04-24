using System;

namespace Platformer_2D
{
    public interface IEnemyModel : ICloneable
    {
        public float health { get; }
        public float speed { get; }

        public int damageForce { get; }

    }
}