using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour {

	public static GameUIManager instance = null;

	public Button restartButton;

	public Button quitButton;

	public Text goalText;

	public Text gameMessageText;

	public Text playerOneRoundsWonText;

	public Text playerTwoRoundsWonText;

	public Text pressAText;

	public Text pressLText;

	void Awake() {
		if (instance == null)
			instance = this;

		else if (instance != this)
			Destroy(gameObject);

		setAllUI(false);
	}

	void Update() {

		playerOneRoundsWonText.text = "Wins: " + GameManager.playerOneRoundsWon.ToString();
		playerTwoRoundsWonText.text = "Wins: " + GameManager.playerTwoRoundsWon.ToString();
		
	}
	
	void setAllUI(bool setting) {
		restartButton.gameObject.SetActive(setting);
		quitButton.gameObject.SetActive(setting);
		goalText.gameObject.SetActive(setting);
		gameMessageText.gameObject.SetActive(setting);
		playerOneRoundsWonText.gameObject.SetActive(setting);
		playerTwoRoundsWonText.gameObject.SetActive(setting);
		pressAText.gameObject.SetActive(setting);
		pressLText.gameObject.SetActive(setting);
	}

	void setRoundOverUI(bool setting) {
		setAllUI(false);
		gameMessageText.gameObject.SetActive(setting);
		playerOneRoundsWonText.gameObject.SetActive(setting);
		playerTwoRoundsWonText.gameObject.SetActive(setting);
	}

	void setGameOverUI(bool setting) {
		setAllUI(false);
		gameMessageText.gameObject.SetActive(setting);
		restartButton.gameObject.SetActive(setting);
		quitButton.gameObject.SetActive(setting);
	}

	void setGameplayUI(bool setting) {
		setAllUI(false);
		goalText.gameObject.SetActive(setting);
		playerOneRoundsWonText.gameObject.SetActive(setting);
		playerTwoRoundsWonText.gameObject.SetActive(setting);
		pressAText.gameObject.SetActive(setting);
		pressLText.gameObject.SetActive(setting);
	}

	void setRoundStartUI(bool setting) {
		setAllUI(false);
		playerOneRoundsWonText.gameObject.SetActive(setting);
		playerTwoRoundsWonText.gameObject.SetActive(setting);
		gameMessageText.gameObject.SetActive(setting);
	}

	public void showRoundStartUI() {
		setRoundStartUI(true);
	}

	public void showRoundOverUI() {
		setRoundOverUI(true);
	}

	public void showGameplayUI() {
		setGameplayUI(true);
	}

	public void showGameOverUI() {
		setGameOverUI(true);
	}

	public void setGameMessageText(string text) {
		gameMessageText.text = text;
	}

	public void setRoundGoalText(string text) {
		goalText.text = text;
	}

	public void restartGame() {
		SceneManager.LoadScene(2);
	}

	public void goToMainMenu() {
		SceneManager.LoadScene(1);
	}

}
