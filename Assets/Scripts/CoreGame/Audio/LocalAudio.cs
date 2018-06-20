using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalAudio : MonoBehaviour {
	
	protected float musicMoment;
	[SerializeField] protected AudioSource audioSource;
	[SerializeField] protected AudioClip audioClip;
	[SerializeField] protected float fadeTime = 1.0f;
	[SerializeField] private GenericAudioSource GAudioSource;

	void Update(){
		musicMoment = audioSource.time;
	}

	void OnDisable(){
		GAudioSource.FadeOut (fadeTime);
	}

	void OnEnable(){
		GAudioSource.FadeIn (fadeTime, musicMoment, audioClip);
	}
}
