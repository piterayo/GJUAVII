using UnityEngine;
using System.Collections;

public class Controller_Pause : MonoBehaviour {

	bool paused = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public bool getPaused(){
		return paused;
	}

	public void enableAll(){
		paused = true;
		gameObject.GetComponent<Canvas> ().enabled = true;
	}

	public void disableAll(){
		paused = false;
		gameObject.GetComponent<Canvas> ().enabled = false;
	}


}
