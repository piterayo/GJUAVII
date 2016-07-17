using UnityEngine;
using System.Collections;

public class NOTTrigger : Triggerer
{



    public override void ActionA()
    {
        state = TriggerState.ACTIVE_B;
        foreach (Triggerer t in target)
        {
            t.ActionB();
        }
    }

    public override void ActionB()
    {
        state = TriggerState.ACTIVE_A;
        foreach (Triggerer t in target)
        {
            t.ActionA();
        }
    }

}
