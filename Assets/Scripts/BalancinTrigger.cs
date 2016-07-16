using UnityEngine;
using System.Collections;

public class BalancinTrigger : MonoBehaviour {

    private ScriptedPath p;

    void Start()
    {
        p = GetComponent<ScriptedPath>();
    }

    void Update()
    {
        if (p.AtEnd)
        {
            p.FreeTarget();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.parent==transform)
            p.StartPath();
    }

}
