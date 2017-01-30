using UnityEngine;
using System.Collections;

public class PlayerAnimationController : MonoBehaviour {

	public Sprite frameOne;

	public Sprite frameTwo;

	public Sprite frameThree;

	public Sprite frameFour;

	public bool isPlayerOne;

	public AudioClip animalSound;

	private KeyCode key;

	private int currentIndex;

	private Sprite[] frames;

	private SpriteRenderer myRenderer;

	void Awake() {
		frames = new Sprite[4];
		frames[0] = frameOne;
		frames[1] = frameTwo;
		frames[2] = frameThree;
		frames[3] = frameFour;

		myRenderer = this.gameObject.GetComponent<SpriteRenderer>();
	}
	 
	
	// Use this for initialization
	void Start () {
		if (isPlayerOne)
			key = KeyCode.A;
		else
			key = KeyCode.L;

		currentIndex = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(key) && ButtonMasher.canMash) {
			myRenderer.sprite = frames[currentIndex];
			currentIndex++;
			if (currentIndex >= 4)
				currentIndex = 0;
		}
	}
}
