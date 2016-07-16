using UnityEngine;
using System.Collections;

//public enum ButtonState{
//    ON_STATE, OFF_STATE
//}

public class Button : Triggerer
{


    //public ButtonState triggerOnState = ButtonState.ON_STATE;

    //public ButtonState state = ButtonState.OFF_STATE;


    //public string[] Tags;

    private int triggerCounter = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        triggerCounter++;
        if(triggerCounter==1)
            ActionA();
    }


    void OnTriggerExit2D(Collider2D other)
    {
        triggerCounter--;
        if(triggerCounter==0)
            ActionB();
    }

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
        foreach (Triggerer t in target)
        {
            t.ActionB();
        }
    }

    //private void switchState(ButtonState new_state){
    //    state = new_state;
    //    if (state == triggerOnState)
    //    {
    //        foreach (Triggerer t in target)
    //        {
    //            t.ActionA();
    //        }
    //    }
    //    else
    //    {
    //        foreach (Triggerer t in target)
    //        {
    //            t.ActionB();
    //        }
    //    }
    //}
}
