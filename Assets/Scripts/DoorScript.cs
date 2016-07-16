using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {


    public float openTime = 1.0f;


    public Transform closePosition;
    public Transform openPosition;

    private TriggeredObject trigger;

	// Use this for initialization
	void Start () {
        trigger = GetComponent<TriggeredObject>();
	}
	
	// Update is called once per frame
    void Update()
    {
        if (trigger != null)
        {
            if (trigger.Timer< openTime)
            {
                print("LLEGA");//TODO Arreglar para que vaya por tiempo
                if (trigger.State)
                {
                    transform.position=Vector3.Lerp(transform.position, openPosition.position, 0.1f);
                }
                else
                {
                    transform.position=Vector3.Lerp(transform.position, closePosition.position, 0.2f);
                }
            }
        }
	}
    
}
