//*******************************************************************************************************
//* Ingame Window.																						*
//* Window displayed while playing the game.															*
//*																										*
//*******************************************************************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameWindow : GenericWindow {

	[Header("Level-related")]
	[SerializeField] private LevelManager levelManager;
	[SerializeField] private SaveManager saveManager;
	[Header("Window")]
	[SerializeField] private WindowBackgroundStruct worldWindow;

	public void BackToWorld(){
		OnNextWindow (worldWindow);
	}

}