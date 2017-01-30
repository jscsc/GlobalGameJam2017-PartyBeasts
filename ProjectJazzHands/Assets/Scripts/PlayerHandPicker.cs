using UnityEngine;
using System.Collections;

public class PlayerHandPicker : MonoBehaviour {

	public static PlayerHandPicker instance = null;

	// Left hands
	public GameObject[] playerOneHands;

	// Right hands
	public GameObject[] playerTwoHands;

	public Vector3 playerOneSpawnValues;

	public Vector3 playerTwoSpawnValues;

	public static GameObject currentPlayerOneHand;

	public static GameObject currentPlayerTwoHand;

	void Awake() {
		
		if (instance == null)
			instance = this;

		else if (instance != this)
			Destroy(gameObject);

	}


	public void pickPlayerHands() {
		destroyOldHands();
		int playerOneHandIndex = Random.Range(0, playerOneHands.Length);
		int playerTwoHandIndex = Random.Range(0, playerTwoHands.Length);

		Vector3 playerOneSpawnPosition = new Vector3(playerOneSpawnValues.x, playerOneSpawnValues.y, playerOneSpawnValues.z);
		Vector3 playerTwoSpawnPosition = new Vector3(playerTwoSpawnValues.x, playerTwoSpawnValues.y, playerTwoSpawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;

		currentPlayerOneHand = (GameObject) Instantiate(playerOneHands[playerOneHandIndex], playerOneSpawnPosition, spawnRotation);
		currentPlayerTwoHand = (GameObject) Instantiate(playerTwoHands[playerTwoHandIndex], playerTwoSpawnPosition, spawnRotation);
	}

	private void destroyOldHands() {
		if (currentPlayerOneHand != null)
			Destroy(currentPlayerOneHand);

		if(currentPlayerTwoHand != null)
			Destroy(currentPlayerTwoHand);
	}

}
