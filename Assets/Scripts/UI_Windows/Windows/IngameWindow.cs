using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameWindow : GenericWindow {

	public LevelManager levelManager;
	public WindowBackgroundStruct worldWindow;
	public SaveManager saveManager;

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Debug.Log ("Open options menu");
			saveManager.Save ();
			this.OnNextWindow ();
			levelManager.TogglePause (true);
		}
		BackToWorld ();
	}

	void BackToWorld(){
		if (LevelManager.isDoingLevel == false) {
			if (nextWindow.activateBackground) {
				WindowsManager.backgrounds.Add ((int)thisWindow - 1);
			}
			wManager.Open ((int)worldWindow.window - 1);
		}
	}
}