using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_2D
{
    [CreateAssetMenu(fileName = "PlayerObjectCfg", menuName = "Configs/ Player Cfg", order = 1)]
    public class PlayerObjectConfig : ScriptableObject
    {
        [SerializeField, Range(0, 20)] 
        public int Health;
        
        public int MaxHealth;
        
        public int MinHealth;

        [SerializeField, Range(0, 10)]
        public int Speed;

    }
}