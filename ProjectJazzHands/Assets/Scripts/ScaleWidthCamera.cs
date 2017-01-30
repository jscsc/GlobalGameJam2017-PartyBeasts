using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ScaleWidthCamera : MonoBehaviour {

	public int targetWidth = 640;

	public int pixelsToUnits = 100;

	private Camera gameplayCamera;

	void Start() {
		gameplayCamera = this.gameObject.GetComponent<Camera>();

	}

	void Update() {
		int height = Mathf.RoundToInt(targetWidth / (float)Screen.width * Screen.height);
		gameplayCamera.orthographicSize = height / pixelsToUnits / 2;
	}
}