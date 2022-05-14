using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_2D
{
    public class EnemyDamage
    {
        
        public void Damage(float health, float damage)
        {
            health -= damage;
        }
    }
}