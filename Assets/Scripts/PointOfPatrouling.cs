using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_2D
{
    [CreateAssetMenu(fileName = "patroulPoint", menuName = "Patroul", order = 1)]
    public class PointOfPatrouling:ScriptableObject
    {
        [SerializeField] private Transform _pointOfPatrouling;

        [SerializeField, Range(-50f, 50f)] private float _patroulRange;

        public Transform pointOfPatrouling { get => _pointOfPatrouling; set => _pointOfPatrouling = value; }
        public float patroulRange { get => _patroulRange; set => _patroulRange = value; }
    }
}