using UnityEngine;
using System.Collections;

public class Control_Movimiento : MonoBehaviour {

	public float maxSpeed = 10f;
	public float AlturaSalto = 10f;
	public int powerUp = 0; // 0 NO HAY - 1 ROCA - ETC
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
		float move = Input.GetAxis("MovimientoHorizontal"+transform.name.ToString());
		anim.SetFloat ("Speed", Mathf.Abs (move));

		if (GetComponentInChildren<colisionSuelo> ().isGrounded ()) {
			grounded = true;

		} else {
			grounded = false;
		}

		if(grounded && Input.GetButton("Salto"+transform.name.ToString()))
			rigidBody.velocity = new Vector2 (rigidBody.velocity.x, AlturaSalto);

		switch (powerUp) {
		case 0: // No lleva power up
			GetComponentInChildren<ControlRoca>().disableAll();

			break;
		case 1: // Lleva DA ROCK
			GetComponentInChildren<ControlRoca>().enableAll();

			break;

		}


	}

	void FixedUpdate () {

		//float move = Input.GetAxis ("Horizontal");

		float move = Input.GetAxis("MovimientoHorizontal"+transform.name.ToString());

		anim.SetFloat ("Speed", Mathf.Abs (move));

		rigidBody.velocity = new Vector2 (move * maxSpeed, rigidBody.velocity.y);
	
		if (move > 0 && !facingRight)
			Flip ();
		else if(move <0 && facingRight)
			Flip();
	
	}


	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnCollisionEnter2D(Collision2D Colision)
	{
		print (Colision.transform.name);


		if (Colision.transform.name == "rock")
			powerUp = 1;


	}


}
