using UnityEngine;
using System.Collections;

public class ControlMusica : MonoBehaviour {


	GameObject sonidoSinLoop, sonidoLoop;
	bool primerLoop = false;

	// Use this for initialization
	void Start () {
		sonidoLoop = transform.FindChild ("SonidoLoop").gameObject;
		sonidoSinLoop = transform.FindChild ("SonidoSinLoop").gameObject;
	}
	
	// Update is called once per frame
	void Update () {

		ControlMusicaFondo.tiempoCancion = 0;
		
		bool playable = false;
		bool bajoVol = false;



		if (sonidoSinLoop.GetComponent<AudioSource> ().time > sonidoSinLoop.GetComponent<AudioSource> ().clip.length - 0.05) {
			playable = true;
		}
		if (!sonidoLoop.GetComponent<AudioSource> ().isPlaying && playable) {
			sonidoLoop.GetComponent<AudioSource> ().Play ();
		}
		if (sonidoLoop.GetComponent<AudioSource> ().time > sonidoLoop.GetComponent<AudioSource> ().clip.length - 0.05)
			primerLoop = true;


		float avanceCancion = (sonidoLoop.GetComponent<AudioSource> ().time * 100 / sonidoLoop.GetComponent<AudioSource> ().clip.length);


		print (avanceCancion);
	


		if (avanceCancion < 5) {
			sonidoLoop.GetComponent<AudioSource> ().volume = 0.6f;
			print ("menos audio");
		} else {
			sonidoLoop.GetComponent<AudioSource> ().volume = sonidoLoop.GetComponent<AudioSource> ().volume + 0.1f;
		}

		if (avanceCancion > 99.9)
			sonidoLoop.GetComponent<AudioSource> ().Play ();
	

		//transform.FindChild ("SonidoLoop").GetComponent<AudioSource> ().time(transform.FindChild ("SonidoSinLoop").GetComponent<AudioSource> ().clip.length);

		/*if (!transform.FindChild ("SonidoSinLoop").GetComponent<AudioSource> ().isPlaying && !transform.FindChild ("SonidoLoop").GetComponent<AudioSource> ().isPlaying) {
			transform.FindChild ("SonidoLoop").GetComponent<AudioSource> ().Play ();
		}*/

	}


}
