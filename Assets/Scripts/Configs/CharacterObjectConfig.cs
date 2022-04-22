using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_2D
{
    [CreateAssetMenu(fileName = "CharacterObjectCfg", menuName = "Configs/ Character Cfg", order = 1)]
    public class CharacterObjectConfig : ScriptableObject
    {
        [SerializeField, Range(0, 20)] 
        public float health;
        

        [SerializeField, Range(0, 200f)]
        public float speed;


        public int MaxHealth = 20;
        
        public int MinHealth = 0;

        public float animationSpeed = 10f;
        public float jumpSpeed = 10f;
        public float movingTresh = 0.1f;
        public float jumpTresh = 1f;


    }
}