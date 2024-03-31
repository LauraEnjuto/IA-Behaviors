using System.Collections.Generic;
using BehaviorTrees;

public class BirdBT : Tree
{
    public static float speed = 5f;
    public static float lookDistance = 5f;
    public static float waitTime = 0.5f;

    public UnityEngine.Transform[] waypoints;

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence (new List<Node>{
                new CheckEnemyInRange(transform),
                new TaskLook(transform),
            }),

            new Sequence (new List<Node>
            {
                new TaskPatrol(transform, waypoints),
            }),
            
        });

        return root;
    }
}
