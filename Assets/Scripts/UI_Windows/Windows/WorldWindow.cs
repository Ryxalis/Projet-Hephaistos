using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldWindow : GenericWindow {

	public DiaMasterManager diaMasterManager;
	public WindowBackgroundStruct dialogueWindow;

	public void StartDialogue(string dialogueName){
		if (nextWindow.activateBackground) {
			WindowsManager.backgrounds.Add ((int)thisWindow - 1);
		}
		wManager.Open ((int)dialogueWindow.window - 1);
		if (DiaMasterManager.currentDialogue == "none") {
			diaMasterManager.StartDialogue (dialogueName);
		}
	}

}
