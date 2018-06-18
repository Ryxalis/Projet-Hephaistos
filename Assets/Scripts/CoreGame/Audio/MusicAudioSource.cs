using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAudioSource : GenericAudioSource {

	protected override float GetVolume ()
	{
		return AudioManager.MusicVolume;
	}

}
