using UnityEngine;
using System.Collections;

public enum TriggerState
{
    IDLE_A, ACTIVE_A, IDLE_B, ACTIVE_B 
}

public class TriggeredObject : MonoBehaviour
{

    private float timer = 0.0f;
    private TriggerState state = TriggerState.IDLE_A;
    private float endTime = -1.0f;


    public float EndTime
    {
        set
        {
            endTime = value;
        }
    }

    public float Timer
    {
        get { return timer; }
    }

    public TriggerState State
    {
        get { return state; }
    }

    public void ActionA()
    {
        if (state != TriggerState.IDLE_B)
        {
            timer = 0.0f;
            state = TriggerState.ACTIVE_A;
        }
    }

    public void ActionB()
    {
        if (state != TriggerState.IDLE_A)
        {
            timer = 0.0f;
            state = TriggerState.ACTIVE_B;
        }
    }

    public void Halt()
    {
        timer = endTime;
        if (state == TriggerState.ACTIVE_A)
        {
            state = TriggerState.IDLE_B;
        }
        else if (state == TriggerState.ACTIVE_B)
        {
            state = TriggerState.IDLE_A;
        }
    }
    
    void Update()
    {
        if (endTime > 0.0f)
        {
            if (state == TriggerState.ACTIVE_A || state == TriggerState.ACTIVE_B)
            {
                if (timer < endTime)
                {
                    timer += Time.deltaTime;
                }
                else
                {
                    Halt();
                }
            }
        }
    }

}
