using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_2D
{
    //[Serializable]
    //public struct PatrolConfig
    //{
    //    public float speed;
    //    public float minDistanceToTarget;
    //    public Transform[] waypoints;
    //}
    public class PatrolModel
    {
        //private PatrolView _patrolView;
        //private Transform _target;
        //private int _currentPointIndex;

        //public PatrolModel(PatrolView patrolView)
        //{
        //    _patrolView = patrolView;
        //    _target = GetNextWaypoint();
            
        //}
        //public Vector2 CalculateVelocity(Vector2 fromPosition)
        //{
        //    var sqrDistance = Vector2.SqrMagnitude((Vector2)_target.position - fromPosition);
        //    if(sqrDistance <= _patrolView.minDistanceToTarget)
        //    {
        //        _target = GetNextWaypoint();
        //    }
        //    var direction = ((Vector2)_target.position - fromPosition).normalized;
        //    return _patrolView.speed * direction;
        //}
        //private Transform GetNextWaypoint()
        //{
        //    _currentPointIndex = (_currentPointIndex + 1) % _patrolView.waypoints.Length; 
        //    return _patrolView.waypoints[_currentPointIndex];
        //}
       
    }
}