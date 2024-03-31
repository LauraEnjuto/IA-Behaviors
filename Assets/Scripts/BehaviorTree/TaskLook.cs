using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTrees;

public class TaskLook : Node
{
    private Transform _transform;

    public TaskLook(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _transform.LookAt(player.transform);

        if (Vector3.Distance(_transform.position, player.transform.position) > BirdBT.lookDistance)
        {            
            state = NodeState.FAILURE;
            return state;
        }

        state = NodeState.RUNNING;
        return state;

    }
}
