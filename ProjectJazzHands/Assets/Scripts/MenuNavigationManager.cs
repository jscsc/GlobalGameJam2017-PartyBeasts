using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class MenuNavigationManager : MonoBehaviour {

	
	public Button startButton;


	public Button rulesButton;


	public Button creditsButton;


	public Button exitButton;


	public Button backButton;


	public Text rulesText;


	public Text titleText;


	public Text artText;


	public Text codeText;


	public Text SFXText;


	public Text musicText;

	public GameObject MainMenuBackgroundOne;

	public GameObject MainMenuBackgroundTwo;

	// Constant for the Gameplay scene index
	private const int GAME_PLAY_LEVEL = 2;
	
	// Use this for initialization
	void Start () {
		goToMainMenu();
	}

	//Removes the UI elements that make up the menu screen
	private void removeMenuUI () {
		startButton.gameObject.SetActive(false);
		rulesButton.gameObject.SetActive(false);
		creditsButton.gameObject.SetActive(false);
		exitButton.gameObject.SetActive(false);
		backButton.gameObject.SetActive(false);
		rulesText.gameObject.SetActive(false);
		titleText.gameObject.SetActive(false);
		artText.gameObject.SetActive(false);
		codeText.gameObject.SetActive(false);
		musicText.gameObject.SetActive(false);
		MainMenuBackgroundOne.gameObject.SetActive(false);
		MainMenuBackgroundTwo.gameObject.SetActive(false);
		SFXText.gameObject.SetActive(false);
	}


	// Displays the credits screen
	public void goToCredits () {
		removeMenuUI();
		MainMenuBackgroundTwo.gameObject.SetActive(true);
		backButton.gameObject.SetActive(true);
		artText.gameObject.SetActive(true);
		codeText.gameObject.SetActive(true);
		musicText.gameObject.SetActive(true);
		SFXText.gameObject.SetActive(true);
	}

	// Displays the rules screen
	public void goToRules () {
		removeMenuUI();
		MainMenuBackgroundTwo.gameObject.SetActive(true);
		backButton.gameObject.SetActive(true);
		rulesText.gameObject.SetActive(true);

	}

	// Displays the menu screen
	public void goToMainMenu () {
		removeMenuUI();
		MainMenuBackgroundOne.gameObject.SetActive(true);
		startButton.gameObject.SetActive(true);
		rulesButton.gameObject.SetActive(true);
		creditsButton.gameObject.SetActive(true);
		exitButton.gameObject.SetActive(true);
		titleText.gameObject.SetActive(true);
	}

	// Changes scenes to the gameplay scene
	public void goToGamePlay () {
		SceneManager.LoadScene(2);
	}

	// Exits the game in a standalone build
	public void exitGame () {
		Application.Quit();
	}

}
