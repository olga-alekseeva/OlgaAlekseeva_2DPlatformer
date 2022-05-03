using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_2D
{
    [CreateAssetMenu(fileName = "CharacterObjectCfg", menuName = "Configs/ Character Cfg", order = 1)]
    public class CharacterObjectConfig : ScriptableObject, ICharacterConfig
    {
        [SerializeField, Range(0, 20)]
        private float _health;


        [SerializeField, Range(0, 200f)]
        private float _speed;

       
        private float _maxHealth = 20;

        private int _minHealth = 0;
        [SerializeField, Range(0, 10f)]
        private int _fireForce;

        private float _animationSpeed = 10f;
        private float _jumpSpeed = 10f;
        private float _movingTresh = 0.1f;
        private float _jumpTresh = 1f;

        public float health { get => _health; }
        public float speed { get => _speed; set => _speed = value; }
        public float maxHealth { get => _maxHealth;}
        public float minHealth { get => _minHealth;}
        public float animationSpeed { get => _animationSpeed;}
        public float jumpSpeed { get => _jumpSpeed; }
        public float movingTresh { get => _movingTresh;}
        public float jumpTresh { get => _jumpTresh; }

        public float fireForce { get => _fireForce; }
    }
}