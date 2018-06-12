using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueWindow : GenericWindow {

	[Header("Window")]
	[SerializeField] private WindowBackgroundStruct worldWindow;

	public void BackToWorld(){
		if (DiaMasterManager.currentDialogue == "none") {
			OnNextWindow (worldWindow);
		}
	}

	void Update(){
		BackToWorld ();
	}

}
