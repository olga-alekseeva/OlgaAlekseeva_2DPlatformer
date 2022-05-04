using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PatrolRoute : MonoBehaviour
{
    
    
      [SerializeField] private List<Transform> _patrolPoints;

    public List<Transform> patrolPoints { get { return _patrolPoints; } }
}
