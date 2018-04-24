using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartWindow : GenericWindow {

	public Button continueButton;
	public WindowBackgroundStruct optionsWindow;

	public override void Open ()
	{
		var canContinue = true;

		continueButton.gameObject.SetActive (canContinue);

		if (continueButton.gameObject.activeSelf) {
			firstSelected = continueButton.gameObject;
		}

		base.Open();
	}

	public void NewGame(){
		OnNextWindow ();
	}

	public void Continue(){
		OnNextWindow ();
	}

	public void Options(){
		if (optionsWindow.activateBackground) {
			WindowsManager.backgrounds.Add ((int)thisWindow - 1);
		}
		wManager.Open ((int)optionsWindow.window - 1);
	}

	public void Quit(){
		Application.Quit ();
	}
}