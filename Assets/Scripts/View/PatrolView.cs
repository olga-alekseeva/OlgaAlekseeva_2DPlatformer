using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolView : MonoBehaviour
{
    [SerializeField] public Transform[] waypoints;
    public float speed;
    public float minDistanceToTarget;
}
