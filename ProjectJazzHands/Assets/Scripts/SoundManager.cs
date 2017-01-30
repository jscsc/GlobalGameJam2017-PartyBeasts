using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public AudioSource efxSource;

	public AudioSource musicSource;

	public static SoundManager instance = null;

	public AudioClip gameStartClip;

	public AudioClip gameLoopClip;


	// Awake is always called before any Start functions
	void Awake() {
		
		if (instance == null)
			instance = this;

		else if (instance != this)
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);

		musicSource.loop = true;

		if (musicSource != null) {
			StartCoroutine(gameMusicRoutine());
		}

	}

	public void playSingle(AudioClip clip) {
		efxSource.clip = clip;

		efxSource.Play();
	}



	IEnumerator gameMusicRoutine() {

		musicSource.clip = gameStartClip;

		musicSource.Play();

		yield return new WaitForSeconds(musicSource.clip.length);

		musicSource.clip = gameLoopClip;
		musicSource.Play();
	}


}
