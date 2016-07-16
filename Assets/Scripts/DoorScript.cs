using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ScriptedPath))]
public class DoorScript : MonoBehaviour
{

    private ScriptedPath path;

    public float openTime = 1.0f;

    private TriggeredObject trigger;

    // Use this for initialization
    void Start()
    {
        trigger = GetComponent<TriggeredObject>();
        path = GetComponent<ScriptedPath>();
        path.time = openTime;
        path.Target = transform.GetChild(0).transform;
        path.StartPath();
        path.PausePath();
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger != null)
        {
            if (trigger.State == TriggerState.ACTIVE_A)
            {
                if (path.AtStart)
                {
                    path.ContinuePath();
                }
                else if (!path.isForward)
                {
                    path.Reverse();
                }
            }
            else if (trigger.State == TriggerState.ACTIVE_B)
            {
                if (path.AtEnd)
                {
                    path.ContinuePath();
                }
                else if(path.isForward)
                {
                    path.Reverse();
                }
            }
        }
    }

}
