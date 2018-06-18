//*******************************************************************************************************
//* Manager that deals with all sound things.															*
//* Deals with volume, sounds effects...																*
//*																										*
//*******************************************************************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	[Header("Master")]
	[SerializeField] private ManagerManager MM;

	[SerializeField] private float globalVolume;
	[SerializeField] private float musicVolume;
	[SerializeField] private float soundVolume;
	public float GlobalVolume { get { return globalVolume; } }
	public float MusicVolume { get { return musicVolume; } }
	public float SoundVolume { get { return soundVolume; } }

}
