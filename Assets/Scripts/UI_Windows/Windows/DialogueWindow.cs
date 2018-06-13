//*******************************************************************************************************
//* Window for dialogue.																				*
//*																										*
//*******************************************************************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueWindow : GenericWindow {

	[Header("Window")]
	[SerializeField] private WindowBackgroundStruct worldWindow;

	public void BackToWorld(){
		OnNextWindow (worldWindow);
	}
}
