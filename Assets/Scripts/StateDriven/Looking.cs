using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looking : BirdState
{
    public override void Execute(PatrolStateDriven agent)
    {
       agent.transform.LookAt(agent.target.transform);

        if (Vector3.Distance(agent.transform.position, agent.target.transform.position) > agent.lookDistance)
        {
            agent.state = new Patrol();
        }
    }
}
