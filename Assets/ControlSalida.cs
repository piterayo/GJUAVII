using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ControlSalida : MonoBehaviour {

    private int playerCount = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (playerCount == 2) LoadNextLevel();
        playerCount = 0;
	}

	public void LoadNextLevel(){

		int numero = SceneManager.GetActiveScene ().buildIndex;
		print ("cargo " + numero);

		SceneManager.UnloadScene (SceneManager.GetActiveScene().buildIndex);
		SceneManager.LoadScene (numero+1);

	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
            playerCount++;
    }
}
