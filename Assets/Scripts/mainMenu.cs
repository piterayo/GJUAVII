using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class mainMenu : MonoBehaviour {

	public Canvas quitMenu;
	public Button startText;
	public Button exitText;
	Scene prueba;

	// Use this for initialization
	void Start () {
	
		quitMenu = quitMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		quitMenu.enabled = false;


	}

	public void openQuitMenu(){
		quitMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
		SceneManager.LoadSceneAsync("Prueba", LoadSceneMode.Additive);
	}

	public void closeQuitMenu(){
		quitMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;


	}

	public void StartGame() {
		SceneManager.UnloadScene (SceneManager.GetActiveScene().buildIndex);
	}

	public void ExitGame()	{
		Application.Quit ();
	}

}
