using UnityEngine;
using System.Collections;

public class TriggeredObject : MonoBehaviour
{

    private float timer = 0.0f;
    private bool state = false;

    public float Timer
    {
        get {  return timer; }
    }

    public bool State
    {
        get { return state; }
    }

    public void Activate()
    {
        timer = 0.0f;
        state = true;
    }

    public void Deactivate()
    {
        timer = 0.0f;
        state = false;
    }

    void Update()
    {
        timer += Time.deltaTime;
    }

}
