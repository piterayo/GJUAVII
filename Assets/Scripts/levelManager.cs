using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class levelManager : MonoBehaviour {


	public GameObject 	prefabPersonaje;
		   Object 		personaje1, 		personaje2;


           private float restartTimer;


	// Use this for initialization
	void Start () {
	
		personaje1 = Instantiate (prefabPersonaje, GameObject.Find ("character1Spawner").transform.position, Quaternion.identity);
		personaje1.name = "1";
	
		personaje2 = Instantiate (prefabPersonaje, GameObject.Find ("character2Spawner").transform.position, Quaternion.identity);
		personaje2.name = "2";
	
	}
	
	// Update is called once per frame
	void Update () {

        if (restartTimer > 0.0f)
        {
            restartTimer -= Time.deltaTime;
            if (restartTimer <= 0.0f)
            {
                restartLevel();
            }
        }

		if (Input.GetButtonDown ("Pause")) {
			if (gameObject.transform.FindChild ("CanvasPausa").GetComponent<Controller_Pause> ().getPaused ()) {
				SceneManager.UnloadScene (SceneManager.GetActiveScene().buildIndex);
				SceneManager.LoadScene (0);
			}				
			else
				gameObject.transform.FindChild ("CanvasPausa").GetComponent<Controller_Pause> ().enableAll ();
		}

		if (Input.GetButtonDown ("Back")) {
			restartLevel ();

		}

		if (Input.GetButtonDown ("Salto1") || Input.GetButtonDown ("Salto2")) {

			if (gameObject.transform.FindChild ("CanvasPausa").GetComponent<Controller_Pause> ().getPaused ()) {
				gameObject.transform.FindChild ("CanvasPausa").GetComponent<Controller_Pause> ().disableAll ();
				print ("Salto");
			}
		}
	}

    public void startRestartTimer()
    {
        restartTimer = 4.0f;
    }

	public void restartLevel()
	{
		int aux = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.UnloadScene (SceneManager.GetActiveScene().buildIndex);
		SceneManager.LoadScene (aux);
	}
}


