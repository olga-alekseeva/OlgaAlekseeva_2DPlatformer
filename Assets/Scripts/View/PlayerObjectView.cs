using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_2D
{
    public class PlayerObjectView : MonoBehaviour
    {
        public Transform _transform;
        public SpriteRenderer _spriteRenderer;
        public Collider2D _collider;
        public Rigidbody2D _rb;
         [SerializeField] public CharacterObjectConfig _playerObjectConfig;

        public Action<PlayerObjectView> OnPlayerObjectContact { get; set; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerObjectView playerObject = collision.gameObject.GetComponent<PlayerObjectView>();
            OnPlayerObjectContact?.Invoke(playerObject);
        }
    }
}