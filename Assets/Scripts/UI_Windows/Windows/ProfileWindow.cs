﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileWindow : GenericWindow {

	public WindowBackgroundStruct worldWindow;
	public GameObject worldLoop;

	public void OpenWorldWindow(){
		if (nextWindow.activateBackground) {
			WindowsManager.backgrounds.Add ((int)thisWindow - 1);
		}
		worldLoop.SetActive (true);
		wManager.Open ((int)worldWindow.window - 1);
	}

}
