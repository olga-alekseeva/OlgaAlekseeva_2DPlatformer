using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_2D
{
    public interface IEnemyPatrouling
    {
        public IPlayerView transform { get; }
        public Transform centralPointOfPatrol { get; set; }
        public int positionOfPatrol { get; set; }
        bool moving { get; set; }
        public float stoppingDistance { get; set; }

        bool chill { get; set; }
        bool angry { get; set; }
        bool goBack { get; set; }

    }
}