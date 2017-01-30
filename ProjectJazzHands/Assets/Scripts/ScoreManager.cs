using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public float FailueWindowInSeconds;

	public static int playerOneScore = 0;

	public static int playerTwoScore = 0;

	public static int roundGoal;

	public static bool goalHit;

	private bool playerOneOverGoal;

	private bool playerTwoOverGoal;

	public Text playerOneText;

	public Text playerTwoText;

	void LateUpdate() {
		playerOneText.text = playerOneScore.ToString();
		playerTwoText.text = playerTwoScore.ToString();

		if ( !goalHit && (playerOneScore == roundGoal || playerTwoScore == roundGoal) ) {
			goalHit = true;
			StartCoroutine(GoalReachedRoutine());
		}
	}

	IEnumerator GoalReachedRoutine() {
		// Give the player a little time to score over the score limit
		yield return new WaitForSeconds(FailueWindowInSeconds);

		playerOneOverGoal = false;
		playerTwoOverGoal = false;

		if (playerOneScore > roundGoal) {
			playerOneOverGoal = true;
		}

		if (playerTwoScore > roundGoal) {
			playerTwoOverGoal = true;
		}

		// Determine the end of the round
		if (playerOneOverGoal && !playerTwoOverGoal) {
			// Player two wins the round
			GameUIManager.instance.setGameMessageText("Player 2 Won Round: Player 1 Over Goal");
			GameManager.playerTwoWonRound = true;
		} else if (!playerOneOverGoal && playerTwoOverGoal) {
			// Player one wins the round
			GameUIManager.instance.setGameMessageText("Player 1 Won Round: Player 2 Over Goal");
			GameManager.playerOneWonRound = true;
		} else if (playerOneOverGoal && playerTwoOverGoal) {
			// There is a draw, no one wins the round
			// Therefore do nothing. This is here for readability
			GameUIManager.instance.setGameMessageText("Draw: Both Over Goal");
		} else if (!playerOneOverGoal && !playerTwoOverGoal) {
			// See who is closer to the goal, who ever is wins the round
			pickClosestToGoal();
		}

		// End the round
		GameManager.roundOver = true;
		
	}

	private void pickClosestToGoal() {
		int playerOneDifference = roundGoal - playerOneScore;
		int playerTwoDifference = roundGoal - playerTwoScore;

		if (playerOneDifference > playerTwoDifference) {
			// Player two wins the round
			GameManager.playerTwoWonRound = true;
			GameUIManager.instance.setGameMessageText("Player 2 Won Round: Hit Goal First");
		} else if (playerOneDifference < playerTwoDifference) {
			// Player one wins the round
			GameUIManager.instance.setGameMessageText("Player 1 Won Round: Hit Goal First");
			GameManager.playerOneWonRound = true;
		} else {
			// They are equal, no one wins the round, therefore do
			// nothing. This is for readability
			GameUIManager.instance.setGameMessageText("Draw: Both Hit Goal");
		}
	}

}
