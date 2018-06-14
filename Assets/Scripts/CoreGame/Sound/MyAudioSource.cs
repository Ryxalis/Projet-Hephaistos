using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAudioSource : MonoBehaviour {

	private AudioSource audioSource;
	[SerializeField] private MyAudioType audioType;
	[SerializeField] private AudioManager audioManager;

	public void Boot(){
		audioSource = GetComponent<AudioSource>();
	}

	void Start () {
		Boot ();

	}

	void SetVolume(){
		if (audioType == MyAudioType.Music) {
			audioSource.volume = audioManager.MusicVolume;
		}
	}

}
