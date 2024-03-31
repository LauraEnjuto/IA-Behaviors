using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BirdState : MonoBehaviour
{
    public abstract void Execute(PatrolStateDriven agent);
}
