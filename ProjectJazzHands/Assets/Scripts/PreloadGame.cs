using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PreloadGame : MonoBehaviour {

	void Start() {
		SceneManager.LoadScene(1);
	}
	
}
