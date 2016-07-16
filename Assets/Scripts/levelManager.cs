using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class levelManager : MonoBehaviour {


	public GameObject 	prefabPersonaje;
		   Object 		personaje1, 		personaje2;

	

	// Use this for initialization
	void Start () {
	
		personaje1 = Instantiate (prefabPersonaje, GameObject.Find ("character1Spawner").transform.position, Quaternion.identity);
		personaje1.name = "1";
	
		personaje2 = Instantiate (prefabPersonaje, GameObject.Find ("character2Spawner").transform.position, Quaternion.identity);
		personaje2.name = "2";
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetButtonDown ("Pause")) {
			if (gameObject.transform.FindChild ("CanvasPausa").GetComponent<Controller_Pause> ().getPaused ()) {
				SceneManager.UnloadScene (SceneManager.GetActiveScene().buildIndex);
				SceneManager.LoadScene (0);
			}				
			else
				gameObject.transform.FindChild ("CanvasPausa").GetComponent<Controller_Pause> ().enableAll ();
		}

		if (Input.GetButtonDown ("Salto1") || Input.GetButtonDown ("Salto2")) {

			if (gameObject.transform.FindChild ("CanvasPausa").GetComponent<Controller_Pause> ().getPaused ()) {
				gameObject.transform.FindChild ("CanvasPausa").GetComponent<Controller_Pause> ().disableAll ();
				print ("Salto");
			}
		}
	}

}
