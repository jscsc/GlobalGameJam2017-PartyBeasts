using UnityEngine;
using System.Collections;

public class ButtonMasher : MonoBehaviour {

	public static bool canMash;

	void Awake() {
		canMash = false;
	}
	
	// Update is called once per frame
	void Update () {

		if(!canMash)
			return;
		
		if (Input.GetKeyDown(KeyCode.A)) {
			ScoreManager.playerOneScore++;
		}

		if (Input.GetKeyDown(KeyCode.L)) {
			ScoreManager.playerTwoScore++;
		}	
	}


}
