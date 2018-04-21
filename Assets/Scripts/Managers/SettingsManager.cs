using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour {


	public static List<Resolution> myResolutions;

	void Awake(){
		InitializeMyResolutions();
		QualitySettings.vSyncCount = 0;
		InitializeSettings ();
	}

	public void InitializeMyResolutions() {
		myResolutions = new List<Resolution> ();
		int refresh;
		if (Screen.resolutions.Length == 1) {
			refresh = Screen.resolutions [0].refreshRate;
		} else {
			refresh = Screen.resolutions [1].refreshRate;
		}
		for (int i = 0; i < Screen.resolutions.Length; i++) {
			if (Screen.resolutions [i].refreshRate == refresh) {
				myResolutions.Add (Screen.resolutions [i]);
			}
		}
	}

	public void InitializeSettings(){
		//PlayerPrefs.DeleteAll ();
		Resolution res;
		bool fullscreen;

		if (PlayerPrefs.HasKey ("ScreenResolution")) {
			res = myResolutions[PlayerPrefs.GetInt ("ScreenResolution")];
		} else {
			res = Screen.currentResolution;
			PlayerPrefs.SetInt ("ScreenResolution", myResolutions.IndexOf (res));
		}

		if (PlayerPrefs.HasKey ("Fullscreen")) {
			fullscreen = PlayerPrefs.GetInt ("Fullscreen") == 1 ? true : false;
		} else {
			fullscreen = true;
			PlayerPrefs.SetInt ("Fullscreen", 1);
		}

		Screen.SetResolution (res.width, res.height, fullscreen);
		PixelPerfectCamera.nativeResolution = new Vector2 (res.width, res.height);

		if (PlayerPrefs.HasKey ("TextureQuality")){
			QualitySettings.masterTextureLimit = 3 - PlayerPrefs.GetInt ("TextureQuality");
		} else {
			QualitySettings.masterTextureLimit = 0;
			PlayerPrefs.SetInt ("TextureQuality", 3-0);
		}

		if (PlayerPrefs.HasKey ("Antialiasing")) {
			QualitySettings.antiAliasing = PlayerPrefs.GetInt ("Antialiasing");
		} else {
			QualitySettings.antiAliasing = 3;
			PlayerPrefs.SetInt ("Antialiasing", 3);
		}

		/*if (PlayerPrefs.HasKey ("KeyUp")) {
			keysMapping.KeyUp = PlayerPrefs.GetString ("KeyUp");
		} else {
			PlayerPrefs.SetString ("KeyUp", keysMapping.KeyUp);
		}
		if (PlayerPrefs.HasKey ("KeyDown")) {
			keysMapping.KeyUp = PlayerPrefs.GetString ("KeyDown");
		} else {
			PlayerPrefs.SetString ("KeyDown", keysMapping.KeyDown);
		}
		if (PlayerPrefs.HasKey ("KeyLeft")) {
			keysMapping.KeyUp = PlayerPrefs.GetString ("KeyLeft");
		} else {
			PlayerPrefs.SetString ("KeyLeft", keysMapping.KeyLeft);
		}
		if (PlayerPrefs.HasKey ("KeyRight")) {
			keysMapping.KeyUp = PlayerPrefs.GetString ("KeyRight");
		} else {
			PlayerPrefs.SetString ("KeyRight", keysMapping.KeyRight);
		}
		if (PlayerPrefs.HasKey ("KeyJump")) {
			keysMapping.KeyUp = PlayerPrefs.GetString ("KeyJump");
		} else {
			PlayerPrefs.SetString ("KeyJump", keysMapping.KeyJump);
		}*/

	}

	public void UpdateSettings(){
		Resolution res = myResolutions[PlayerPrefs.GetInt("ScreenResolution")];
		PixelPerfectCamera.nativeResolution = new Vector2 (res.width, res.height);
		bool fullscreen = PlayerPrefs.GetInt ("Fullscreen") == 1 ? true : false;
		Screen.SetResolution (res.width, res.height, fullscreen);

		QualitySettings.masterTextureLimit = 3-PlayerPrefs.GetInt ("TextureQuality");
		QualitySettings.antiAliasing = PlayerPrefs.GetInt ("Antialiasing");

		/*keysMapping.KeyUp    = PlayerPrefs.GetString ("KeyUp");
		keysMapping.KeyDown  = PlayerPrefs.GetString ("KeyDown");
		keysMapping.KeyLeft  = PlayerPrefs.GetString ("KeyLeft");
		keysMapping.KeyRight = PlayerPrefs.GetString ("KeyRight");
		keysMapping.KeyJump  = PlayerPrefs.GetString ("KeyJump");*/
	}
}
