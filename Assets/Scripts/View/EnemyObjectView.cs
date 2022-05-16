using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_2D
{
    public class EnemyObjectView : MonoBehaviour
    {
        [SerializeField] public CharacterObjectConfig _enemyObjectConfig;
        [SerializeField] public Transform _enemyTransformPosition;
        [SerializeField] public Transform pointOfPatrol;
        [SerializeField, Range(-50f, 50f)] public float patrolDistance;
        [SerializeField] public float stoppingDistance;
    }
}