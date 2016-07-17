using UnityEngine;
using System.Collections;


public enum TriggerState
{
    ACTIVE_A, ACTIVE_B, IDLE_A, IDLE_B
}

public abstract class Triggerer : MonoBehaviour {

    public abstract void ActionA();
    public abstract void ActionB();

    public Triggerer[] target;

    public Triggerer[] triggers;

    protected TriggerState state = TriggerState.ACTIVE_B;

    public TriggerState State
    {
        get { return state; }
    }
}
