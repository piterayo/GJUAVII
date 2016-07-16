using UnityEngine;
using System.Collections;

public enum ButtonState{
    ON_STATE, OFF_STATE
}

public class Button : MonoBehaviour {


    public ButtonState triggerOnState = ButtonState.ON_STATE;

    public ButtonState state = ButtonState.OFF_STATE;

    public TriggeredObject[] target;

    public string[] Tags;

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other){
        foreach (string s in Tags)
        {
            if (other.tag == s)
            {
                switchState(ButtonState.ON_STATE);
                break;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        foreach (string s in Tags)
        {
            if (other.tag == s)
            {
                switchState(ButtonState.ON_STATE);
                break;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        foreach (string s in Tags)
        {
            if (other.tag == s)
            {
                switchState(ButtonState.OFF_STATE);
                break;
            }
        }
    }

    private void switchState(ButtonState new_state){
        state = new_state;
        if (state == triggerOnState)
        {
            foreach (TriggeredObject t in target)
            {
                t.ActionA();
            }
        }
        else
        {
            foreach (TriggeredObject t in target)
            {
                t.ActionB();
            }
        }
    }
}
