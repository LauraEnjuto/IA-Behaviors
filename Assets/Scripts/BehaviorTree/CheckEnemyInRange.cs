using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTrees;

public class CheckEnemyInRange : Node
{
    private Transform _transform;
    
    public CheckEnemyInRange(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (Vector3.Distance(_transform.position, player.transform.position) <= BirdBT.lookDistance)
        {
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}

