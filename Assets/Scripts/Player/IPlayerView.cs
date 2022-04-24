using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_2D
{
    public interface IPlayerView
    {
        public Transform transform { get; }
    }
}