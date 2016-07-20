using UnityEngine;
using System.Collections;

public class ControlMusicaFondo : MonoBehaviour {

	public static float tiempoCancion = 0;

	// Use this for initialization
	void Start () {
	
		if (tiempoCancion != 0)
			GetComponent<AudioSource> ().time = tiempoCancion;

	}
	
	// Update is called once per frame
	void Update () {
		tiempoCancion = GetComponent<AudioSource> ().time;

	}
}
