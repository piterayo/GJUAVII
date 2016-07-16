using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class mainMenu : MonoBehaviour {

	public Canvas quitMenu;
	public Button TextoJugar;
	public Button TetoSalir;
	Scene prueba;

	// Use this for initialization
	void Start () {
	
		quitMenu = quitMenu.GetComponent<Canvas> ();
		TextoJugar = TextoJugar.GetComponent<Button> ();
		TetoSalir = TetoSalir.GetComponent<Button> ();
		quitMenu.enabled = false;


	}

	public void openQuitMenu(){
		quitMenu.enabled = true;
		TextoJugar.enabled = false;
		TetoSalir.enabled = false;

	}

	public void closeQuitMenu(){
		quitMenu.enabled = false;
		TextoJugar.enabled = true;
		TetoSalir.enabled = true;
	}

	public void StartGame() {
		SceneManager.UnloadScene (SceneManager.GetActiveScene().buildIndex);
		SceneManager.LoadScene(1);
	}

	public void ExitGame()	{
		Application.Quit ();
	}

}
