using UnityEngine;
using System.Collections;

public class SwitchTrigger : Triggerer {

    public override void ActionA()
    {
        if (state == TriggerState.ACTIVE_A)
        {
            state = TriggerState.ACTIVE_B;
            foreach (Triggerer t in target)
            {
                t.ActionA();
            }
        }
        else if (state == TriggerState.ACTIVE_B)
        {
            state = TriggerState.ACTIVE_A;
            foreach (Triggerer t in target)
            {
                t.ActionB();
            }
        }
    }

    public override void ActionB()
    {

    }

}
