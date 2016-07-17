using UnityEngine;
using System.Collections;

//public enum ButtonState{
//    ON_STATE, OFF_STATE
//}

public class Button : Triggerer
{


    //public ButtonState triggerOnState = ButtonState.ON_STATE;

    //public ButtonState state = ButtonState.OFF_STATE;
    public Sprite inactive;
    public Sprite pushed;

    private SpriteRenderer renderer;

    private ArrayList triggering;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        triggering = new ArrayList();
    }

    void Update()
    {
        bool change=false;
        for (int i = 0; i < triggering.Count; i++)
        {
            if (!(Transform)(triggering[i]))
            {
                triggering.RemoveAt(i);
                change=true;
            }
        }
        if (triggering.Count == 0 && change)
        {
            ActionB();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        triggering.Add(other.transform);
        if(triggering.Count==1)
            ActionA();
    }


    void OnTriggerExit2D(Collider2D other)
    {
        triggering.Remove(other.transform);
        if(triggering.Count==0)
            ActionB();
    }

    public override void ActionA()
    {
        renderer.sprite = pushed;
        state = TriggerState.ACTIVE_A;
        foreach (Triggerer t in target)
        {
            t.ActionA();
        }
    }

    public override void ActionB()
    {
        renderer.sprite = inactive;
        state = TriggerState.ACTIVE_B;
        foreach (Triggerer t in target)
        {
            t.ActionB();
        }
    }
}
