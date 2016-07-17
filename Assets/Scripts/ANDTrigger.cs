using UnityEngine;
using System.Collections;

public class ANDTrigger : Triggerer
{

    public override void ActionA()
    {
        state = TriggerState.ACTIVE_A;
        for (int i = 0; i < triggers.Length; i++)
        {
            if (triggers[i].State == TriggerState.ACTIVE_B)
            {
                state = TriggerState.ACTIVE_B;
                break;
            }
        }
        if (state == TriggerState.ACTIVE_A)
        {
            foreach (Triggerer t in target)
            {
                t.ActionA();
            }
        }
    }

    public override void ActionB()
    {
        state = TriggerState.ACTIVE_B;
        foreach (Triggerer t in target)
        {
            t.ActionB();
        }
    }

}
