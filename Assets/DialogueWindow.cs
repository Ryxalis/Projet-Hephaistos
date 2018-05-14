using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueWindow : GenericWindow {

	public WindowBackgroundStruct worldWindow;

	public void BackToWorld(){
		if (DiaMasterManager.currentDialogue == "none") {
			if (nextWindow.activateBackground) {
				WindowsManager.backgrounds.Add ((int)thisWindow - 1);
			}
			wManager.Open ((int)worldWindow.window - 1);
		}
	}

	void Update(){
		BackToWorld ();
	}

}
