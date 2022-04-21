using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_2D
{
    public class QuestObjectView : LevelObjectView
    {
        [SerializeField] private int _id;
        [SerializeField] private Color _completedColor;
        [SerializeField] private Color _defaultColor;

        public int Id { get => _id; set => _id = value; }

        private void Awake()
        {
            _defaultColor = _spriteRenderer.color;
        }

        public void ProcessComplete()
        {
            _spriteRenderer.color = _completedColor;
        }
        public void ProcessActivate()
        {
            _spriteRenderer.color = _defaultColor;
        }
    }
}