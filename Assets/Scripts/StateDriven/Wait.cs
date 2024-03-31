using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : BirdState
{    
    private PatrolStateDriven newAgent;
    
    public override void Execute(PatrolStateDriven agent)
    {
        newAgent = agent;
        if (!agent.isWaiting)
        {
            agent.UpdatePatrolIndex();
            agent.StartWaiting();
        }
        if (Vector3.Distance(agent.transform.position, agent.target.transform.position) < agent.lookDistance)
        {
            agent.StopWaiting();
            agent.state = new Looking();
        }
    }

}
