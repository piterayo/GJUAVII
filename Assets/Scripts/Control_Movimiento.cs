using UnityEngine;
using System.Collections;

public class Control_Movimiento : MonoBehaviour {

	public float maxSpeed = 10f;
	public float AlturaSalto = 10f;
	public int powerUp = 0; // 0 NO HAY - 1 ROCA - ETC
	bool powerUpActivo = false;
	bool facingRight = true;
	Animator anim;

	bool grounded = false;

	Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void Update() {

		if (!powerUpActivo) {
			float move = Input.GetAxis("MovimientoHorizontal"+transform.name);
			anim.SetFloat ("Speed", Mathf.Abs (move));

			if(grounded && Input.GetButton("Salto"+transform.name))
				rigidBody.velocity = new Vector2 (rigidBody.velocity.x, AlturaSalto);

			rigidBody.velocity = new Vector2 (move * maxSpeed, rigidBody.velocity.y);

			if (move > 0 && !facingRight)
				Flip ();
			else if(move <0 && facingRight)
				Flip();

		}

		if (GetComponentInChildren<colisionSuelo> ().isGrounded ()) {
			grounded = true;

		} else {
			grounded = false;
		}


		switch (powerUp) {
		case 0: // no llevo nada
			GetComponentInChildren<Control_Skill>().disableAll();

			break;
		case 1: // Lleva DA ROCK
			if (Input.GetButtonDown ("Skill" + transform.name)) {
				if (!powerUpActivo) {
					
					GetComponentInChildren<Control_Skill> ().enableAll ();
					powerUpActivo = true;

				} else {
					GetComponentInChildren<Control_Skill> ().disableAll ();
					powerUpActivo = false;
				}
			}
			break;

		}



	}

	void FixedUpdate () {

		//float move = Input.GetAxis ("Horizontal");


	
	}


	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnTriggerEnter2D(Collider2D Collider)
	{
		print (Collider.transform.name);


		switch(Collider.transform.name) {
		case "Altar":
			print ("LOL");

			if (Collider.gameObject.GetComponent<Control_Altar> ().getPowerUP () != 0) {
				int temp = powerUp;
				powerUp = Collider.gameObject.GetComponent<Control_Altar> ().getPowerUP ();
				Collider.gameObject.GetComponent<Control_Altar> ().setPowerUP (temp);
			}
			break;
		case "Salida":
			Collider.gameObject.GetComponent<ControlSalida> ().LoadNextLevel ();
			break;
		}
	}


}
