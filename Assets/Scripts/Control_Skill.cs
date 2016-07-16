using UnityEngine;
using System.Collections;

public class Control_Skill : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
