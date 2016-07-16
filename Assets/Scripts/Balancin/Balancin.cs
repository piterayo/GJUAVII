using UnityEngine;
using System.Collections;

public struct EstadoBalancin
{

}

public class Balancin : MonoBehaviour {

    public float RequestedMass = 1.0f;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ReceiveCollision(Rigidbody2D collider)
    {
        if (collider.mass >= RequestedMass)
        {

        }
    }

}
