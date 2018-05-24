using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldWindow : GenericWindow {

	public DiaMasterManager diaMasterManager;
	public LevelManager levelManager;
	public WindowBackgroundStruct dialogueWindow;
	public WindowBackgroundStruct levelWindow;

	public void StartDialogue(string dialogueName){
		if (nextWindow.activateBackground) {
			WindowsManager.backgrounds.Add ((int)thisWindow - 1);
		}
		wManager.Open ((int)dialogueWindow.window - 1);
		if (DiaMasterManager.currentDialogue == "none") {
			diaMasterManager.StartDialogue (dialogueName);
		}
	}

		public void StartLevel(int levelNumber){
		if (nextWindow.activateBackground) {
			WindowsManager.backgrounds.Add ((int)thisWindow - 1);
		}
		wManager.Open ((int)levelWindow.window - 1);
		if (LevelManager.isDoingLevel == false) {
			levelManager.StartLevel(levelNumber);
		}
	}

}
