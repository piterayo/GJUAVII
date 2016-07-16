using UnityEngine;
using System.Collections;

public enum ButtonState{
    ON_STATE, OFF_STATE
}

public class Button : MonoBehaviour {


    public ButtonState triggerOnState = ButtonState.ON_STATE;

    public ButtonState state = ButtonState.OFF_STATE;

    public TriggeredObject[] target;


    void Start()
    {
        switchState(state);
    }

    void OnTriggerEnter2D(Collider2D other){
        switchState(ButtonState.ON_STATE);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        switchState(ButtonState.OFF_STATE);
    }

    private void switchState(ButtonState new_state){
        state = new_state;
        if (state == triggerOnState)
        {
            foreach (TriggeredObject t in target)
            {
                t.Activate();
            }
        }
        else
        {
            foreach (TriggeredObject t in target)
            {
                t.Deactivate();
            }
        }
    }

}
