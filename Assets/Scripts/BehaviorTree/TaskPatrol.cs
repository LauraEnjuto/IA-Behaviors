using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTrees;

public class TaskPatrol : Node
{
    private Transform _transform;
    private Transform[] _waypoints;  
        
    private int _currentWaypointIndex = 0;

    private float _waitCounter = 0f;
    private bool _isWaiting = false;

    public TaskPatrol(Transform transform, Transform[] waypoints)
    {
        _transform = transform;
        _waypoints = waypoints;
    }

    public override NodeState Evaluate()
    {
        if (_isWaiting == true)
        {
            _waitCounter += Time.deltaTime;

            if(_waitCounter >= BirdBT.waitTime)
            {
                _isWaiting = false;
            }                    
        }

        else
        {
            Transform wp = _waypoints[_currentWaypointIndex];
            if (Vector3.Distance(_transform.position, wp.position) < 0.01f)
            {
                _transform.position = wp.position;
                _waitCounter = 0;
                _isWaiting = true;

                _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
            }

            else
            {
                _transform.position = Vector3.MoveTowards(_transform.position,wp.position, BirdBT.speed * Time.deltaTime);
                _transform.LookAt(wp.position);
            }
        }

        state = NodeState.RUNNING;
        return state;
    }

}

