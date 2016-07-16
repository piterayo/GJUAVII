using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ControlSalida : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadNextLevel(){

		int numero = SceneManager.GetActiveScene ().buildIndex;
		print ("cargo " + numero);

		SceneManager.UnloadScene (SceneManager.GetActiveScene().buildIndex);
		SceneManager.LoadScene (numero+1);

	}

}
