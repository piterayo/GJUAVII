using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour
{


    public float openTime = 1.0f;

    public float verticalMovement = 2.0f;

    private Vector3 closePosition;
    private Vector3 openPosition;

    private TriggeredObject trigger;
    private float speed;

    // Use this for initialization
    void Start()
    {
        trigger = GetComponent<TriggeredObject>();

        speed = verticalMovement / openTime;

        closePosition = openPosition = transform.position;
        closePosition.y += verticalMovement;

    }

    // Update is called once per frame
    void Update()
    {
        if (trigger != null)
        {
            if (trigger.State == TriggerState.ACTIVE_A)
            {
                transform.position += new Vector3(0, speed * Time.deltaTime, 0);
                if ((transform.position - closePosition).sqrMagnitude < 0.01f) trigger.Halt();
            }
            else if (trigger.State == TriggerState.ACTIVE_B)
            {
                transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
                if ((transform.position - openPosition).sqrMagnitude < 0.01f) trigger.Halt();
            }
        }
    }

}
