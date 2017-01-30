using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	private bool resetting;

	public static int playerOneRoundsWon;

	public static int playerTwoRoundsWon;

	public static bool gameOver;

	public static bool roundOver;

	public static bool playerOneWonRound;

	public static bool playerTwoWonRound;

	public int roundsToWin;
	
	// Awake is always called before any Start functions
	void Awake() {
		
		if (instance == null)
			instance = this;

		else if (instance != this)
			Destroy(gameObject);

	}

	void Start() {
		InitGame();
	}

	void InitGame() {
		playerOneWonRound = false;
		playerTwoWonRound = false;
		playerOneRoundsWon = 0;
		playerTwoRoundsWon = 0;
		gameOver = false;
		roundOver = false;
		ScoreManager.playerOneScore = 0;
		ScoreManager.playerTwoScore = 0;
		ButtonMasher.canMash = false;
		resetting = false;


		PlayerHandPicker.instance.pickPlayerHands();
		InitRound();
		StartCoroutine(startRound());
	}

	void InitRound() {
		roundOver = false;
		gameOver = false;
		ScoreManager.goalHit = false;
		playerOneWonRound = false;
		playerTwoWonRound = false;
		resetting = false;
		ScoreManager.playerOneScore = 0;
		ScoreManager.playerTwoScore = 0;
		ButtonMasher.canMash = false;
		ScoreManager.roundGoal = Random.Range(1, 101);
		PlayerHandPicker.instance.pickPlayerHands();
	}
	
	// Update is called once per frame
	void Update () {
		if(resetting)
			return;
		
		if (gameOver) {
			// Handle what happens if the game is over
			resetting = true;
			handleGameOver();
		} else if (roundOver) {
			// Handle what happens if the round is over
			resetting = true;
			handleRoundOver();
		}
	}

	private void handleGameOver() {
		GameUIManager.instance.showGameOverUI();
		ButtonMasher.canMash = false;
	}

	private void handleRoundOver() {
		if (playerOneWonRound) {
			playerOneRoundsWon++;
			AudioClip playerOneClip = PlayerHandPicker.currentPlayerOneHand.GetComponent<PlayerAnimationController>().animalSound;
			SoundManager.instance.playSingle(playerOneClip);
		} else if (playerTwoWonRound) {
			playerTwoRoundsWon++;
			AudioClip playerTwoclip = PlayerHandPicker.currentPlayerTwoHand.GetComponent<PlayerAnimationController>().animalSound;
			SoundManager.instance.playSingle(playerTwoclip);
		}

		if (playerOneRoundsWon == roundsToWin) {
			// Player one wins the game, end it
			GameUIManager.instance.setGameMessageText("Player 1 Wins!");
			gameOver = true;
			resetting = false;
		} else if (playerTwoRoundsWon == roundsToWin) {
			// Player two wins the game, end it
			GameUIManager.instance.setGameMessageText("Player 2 Wins!");
			gameOver = true;
			resetting = false;
		} else {
			// Round is over, go to next round
			StartCoroutine(endRound());
		}
	}


	IEnumerator startRound() {
		GameUIManager.instance.showRoundStartUI();
		GameUIManager.instance.setGameMessageText("Ready");
		yield return new WaitForSeconds(1.0f);
		GameUIManager.instance.setGameMessageText("Set");
		yield return new WaitForSeconds(1.0f);
		GameUIManager.instance.setGameMessageText("Go!");
		yield return new WaitForSeconds(1.0f);
		GameUIManager.instance.setRoundGoalText(ScoreManager.roundGoal.ToString());
		GameUIManager.instance.showGameplayUI();
		ButtonMasher.canMash = true;
	}

	
	IEnumerator endRound() {
		GameUIManager.instance.showRoundOverUI();
		ButtonMasher.canMash = false;
		yield return new WaitForSeconds(3.0f);
		InitRound();
		StartCoroutine(startRound());
	}


	IEnumerator endGame() {
		yield return new WaitForSeconds(1.0f);
		GameUIManager.instance.showGameOverUI();
		ButtonMasher.canMash = false;
	}

}
