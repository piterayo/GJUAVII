using UnityEngine;
using System.Collections;

public class BalancinTarget : MonoBehaviour {

    private ScriptedPath path;

    void Start()
    {
        path = transform.parent.GetComponent<ScriptedPath>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.parent!=transform.parent)
            path.Target = other.transform;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.parent != transform.parent)
            path.Target = null;
    }
}
