using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : BirdState
{
    private float _distanceToWait = 0.05f;
    private PatrolStateDriven newAgent;

    public override void Execute(PatrolStateDriven agent)
    {
        agent.transform.LookAt(agent.CurrentPatrolIndex());
        agent.transform.Translate(Vector3.forward * agent.speed * Time.deltaTime);

        if (Vector3.Distance(agent.transform.position, agent.target.transform.position) < agent.lookDistance)
        {
            agent.state = new Looking();
        }
        if (Vector3.Distance(agent.transform.position, agent.CurrentPatrolIndex()) < _distanceToWait)
        {
            agent.state = new Wait();
        }
    }
}
