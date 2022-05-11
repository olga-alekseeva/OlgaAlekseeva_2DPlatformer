using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_2D
{
    public class PatrolView : MonoBehaviour
    {
        [SerializeField] public Transform enemyTransform;
        [SerializeField] public Transform pointOfPatrol;
        [SerializeField, Range(-50f, 50f)] public float patrolDistance;
        public float stoppingDistance;
        


    }
}