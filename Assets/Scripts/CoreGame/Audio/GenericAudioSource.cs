using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericAudioSource : MonoBehaviour {

	[SerializeField] protected AudioSource audioSource;
	[SerializeField] protected AudioManager AudioManager;
	private bool isFading = false;

	protected virtual float GetVolume(){
		return 0.0f;
	}

	public void FadeOut(float fadeTime){
		StartCoroutine (IFadeOut (fadeTime));
	}

	public void FadeIn(float fadeTime, float musicMoment){
		StartCoroutine (IFadeIn (fadeTime, musicMoment));
	}

	private IEnumerator IFadeIn(float fadeTime, float musicMoment){
		while (isFading) {
			yield return null;
		}
		isFading = true;
		audioSource.Play();

		audioSource.volume = 0.0f;
		while (audioSource.volume < GetVolume()) {
			audioSource.volume += GetVolume() * Time.deltaTime / fadeTime;
			yield return null;
		}
		isFading = false;
	}

	private IEnumerator IFadeOut(float fadeTime){
		while (isFading) {
			yield return null;
		}
		isFading = true;
		float volume = GetVolume ();
		while (audioSource.volume > 0) {
			audioSource.volume -= volume * Time.deltaTime / fadeTime;
			yield return null;
		}
		audioSource.Pause ();
		isFading = false;
	}

}
