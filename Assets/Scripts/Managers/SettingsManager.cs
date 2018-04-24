//*******************************************************************************************************
//* Load and set game settings.																			*
//* When starting, save new preferences if they do not exist.											*
//* Use the UpdateSettings() method at any time to load settings from PlayPrefs							*
//* Thus to modify settings, save a new value of the parameter in PlayerPrefs then call UpdateSettings	*
//*																										*
//*******************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour {


	public static List<Resolution> myResolutions;

	void Awake(){
		InitializeMyResolutions();
		QualitySettings.vSyncCount = 0;
		InitializePrefsSettings ();
		UpdateSettings ();
	}

	public void InitializeMyResolutions() {
		myResolutions = new List<Resolution> ();
		int refresh;

		refresh = Screen.resolutions.Length == 1 ? Screen.resolutions [0].refreshRate : Screen.resolutions [1].refreshRate;

		for (int i = 0; i < Screen.resolutions.Length; i++) {
			if (Screen.resolutions [i].refreshRate == refresh) {
				myResolutions.Add (Screen.resolutions [i]);
			}
		}
	}

	public void InitializePrefsSettings(){
		//PlayerPrefs.DeleteAll ();
		Resolution res = Screen.currentResolution;

		if (!PlayerPrefs.HasKey ("ScreenResolution")) {
			PlayerPrefs.SetInt ("ScreenResolution", myResolutions.IndexOf (res));
		}
		if (!PlayerPrefs.HasKey ("Fullscreen")) {
			PlayerPrefs.SetInt ("Fullscreen", 1);
		}
		if (!PlayerPrefs.HasKey ("TextureQuality")){
			PlayerPrefs.SetInt ("TextureQuality", 3-0);
		}
		if (!PlayerPrefs.HasKey ("Antialiasing")) {
			PlayerPrefs.SetInt ("Antialiasing", 3);
		}
	}

	public void UpdateSettings(){
		Resolution res = myResolutions[PlayerPrefs.GetInt("ScreenResolution")];
		PixelPerfectCamera.nativeResolution = new Vector2 (res.width, res.height);
		bool fullscreen = PlayerPrefs.GetInt ("Fullscreen") == 1 ? true : false;
		Screen.SetResolution (res.width, res.height, fullscreen);

		QualitySettings.masterTextureLimit = 3-PlayerPrefs.GetInt ("TextureQuality");
		QualitySettings.antiAliasing = PlayerPrefs.GetInt ("Antialiasing");
	}
}
