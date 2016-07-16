using UnityEngine;
using System.Collections;

public class Control_Altar : MonoBehaviour {

	public int PowerUP; //0 - VACIO / 1 - ROCK / 2 - BROCHA
	int PowerUPNumber = 2;

	// Use this for initialization
	void Start () {
		PowerUP = 1; 
	}
	
	// Update is called once per frame
	void Update () {


		//print (GetComponent<GameObject>().name);



		switch (PowerUP) {
		case 0:
			gameObject.transform.FindChild("rock").GetComponent<SpriteRenderer> ().enabled = false;
			gameObject.transform.FindChild("brocha").GetComponent<SpriteRenderer> ().enabled = false;

			break;
		case 1:
			gameObject.transform.FindChild("rock").GetComponent<SpriteRenderer> ().enabled = true;
			gameObject.transform.FindChild("brocha").GetComponent<SpriteRenderer> ().enabled = false;

			break;
		case 2:
			gameObject.transform.FindChild("rock").GetComponent<SpriteRenderer> ().enabled = false;
			gameObject.transform.FindChild("brocha").GetComponent<SpriteRenderer> ().enabled = true;

			break;
		}
	
	}

	public int getPowerUP()
	{
		return PowerUP;
	}

	public void setPowerUP(int numero)
	{
		print ("Cambio " + PowerUP + " por " + numero);
		PowerUP = numero;
	}


	public void disableAll()
	{
		GetComponent<BoxCollider2D> ().enabled = false;
		GetComponent<SpriteRenderer> ().enabled = false;
	}

	public void enableAll()
	{
		GetComponent<BoxCollider2D> ().enabled = true;
		GetComponent<SpriteRenderer> ().enabled = true;
	}
}
