//*******************************************************************************************************
//* Window to display the main world.																	*
//* Link between the dialogues, the menu, the levels...													*
//*																										*
//*******************************************************************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldWindow : GenericWindow {

	[Header("Dialogues")]
	[SerializeField] private DiaMasterManager diaMasterManager;
	[SerializeField] private WindowBackgroundStruct dialogueWindow;
	[Header("Level")]
	[SerializeField] private LevelManager levelManager;
	[SerializeField] private WindowBackgroundStruct levelWindow;
	[Header("World")]
	public WorldGameObject worldGameObject;

	public override void Open ()
	{
		worldGameObject.Boot ();
		base.Open ();
	}

	public override void Close ()
	{
		worldGameObject.Close ();
		base.Close ();
	}

	public void StartDialogue(string dialogueName){
		OnNextWindow (dialogueWindow);

		if (DiaMasterManager.currentDialogue == "none") {
			diaMasterManager.StartDialogue (dialogueName);
		}
	}

	public void StartLevel(int levelNumber){
		OnNextWindow (levelWindow);
		levelManager.StartLevel(levelNumber);
	}

}