using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_2D
{
    public interface ICharacterConfig
    {
        public float health { get; }
        public float speed { get; }
        public float maxHealth { get; }
        public float minHealth { get; }
        public float fireForce { get; }
        
        public float jumpSpeed { get; }
        public float movingTresh { get; }
        public float jumpTresh { get; }
    }
}