using UnityEngine;
using System.Collections;

public class ORTrigger : Triggerer
{


    public override void ActionA()
    {
        state = TriggerState.ACTIVE_A;
        foreach (Triggerer t in target)
        {
            t.ActionA();
        }
    }

    public override void ActionB()
    {

        state = TriggerState.ACTIVE_B;
        for (int i = 0; i < triggers.Length; i++)
        {
            if (triggers[i].State == TriggerState.ACTIVE_A)
            {
                state = TriggerState.ACTIVE_A;
                break;
            }
        }
        if (state == TriggerState.ACTIVE_B)
        {
            foreach (Triggerer t in target)
            {
                t.ActionB();
            }
        }
    }
}
