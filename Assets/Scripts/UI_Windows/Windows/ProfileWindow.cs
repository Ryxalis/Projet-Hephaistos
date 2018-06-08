﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileWindow : GenericWindow {

	public WindowBackgroundStruct worldWindow;
	public GameObject worldLoop;
	public SaveManager saveManager;

	public int profileNumber = -1;
	
	public void OpenWorldWindow(int number){
		if (nextWindow.activateBackground) {
			WindowsManager.backgrounds.Add ((int)thisWindow - 1);
		}
		worldLoop.SetActive (true);
		wManager.Open ((int)worldWindow.window - 1);

		profileNumber = number;
		saveManager.Load ();
	}

}
