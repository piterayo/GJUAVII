using UnityEngine;
using System.Collections;

public class colisionSuelo : MonoBehaviour {

	bool grounded = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionStay2D(Collision2D colision){
		grounded = true;
			
	
	}

	void OnCollisionExit2D(Collision2D colision){
		grounded = false;
	}

	public bool isGrounded(){
		return grounded;
	}


}
