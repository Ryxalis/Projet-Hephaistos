//*******************************************************************************************************
//* Manager that deals with all sound things.															*
//* Deals with volume, sounds effects...																*
//*																										*
//*******************************************************************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MyAudioType{
	Music = 1,
	Sound = 2,
	Other = 3,
};

public class AudioManager : MonoBehaviour {

	private float globalVolume;
	private float musicVolume;
	private float soundVolume;
	public float GlobalVolume { get { return globalVolume; } }
	public float MusicVolume { get { return musicVolume; } }
	public float SoundVolume { get { return soundVolume; } }

	void Start () {
		
	}
	
	void Update () {
		
	}

}
