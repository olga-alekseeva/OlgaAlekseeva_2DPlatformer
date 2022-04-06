using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_2D
{
    public class Player : IPlayer
    {
        [SerializeField, Range(0, 100)] private float _health;
        [SerializeField, Range(0, 10)] private float _speed;

    }
}