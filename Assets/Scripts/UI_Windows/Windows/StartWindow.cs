//*******************************************************************************************************
//* Starting Window.																					*
//* This is basically the mmain menu.																	*
//*																										*
//*******************************************************************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartWindow : GenericWindow {

	[SerializeField] private Button continueButton;
	[Header("Windows")]
	[SerializeField] private WindowBackgroundStruct profilWindow;
	[SerializeField] private WindowBackgroundStruct optionsWindow;
	[SerializeField] private WindowBackgroundStruct achievementsWindow;

	public override void Open ()
	{
		/*var canContinue = true;

		continueButton.gameObject.SetActive (canContinue);

		if (continueButton.gameObject.activeSelf) {
			firstSelected = continueButton.gameObject;
		}
		*/
		base.Open();
	}

	public void ProfilWindow(){
		OnNextWindow (profilWindow);
	}

	public void Options(){
		OnNextWindow (optionsWindow);
	}

	public void AchievementsWindow(){
		OnNextWindow (achievementsWindow);
	}

	public void Quit(){
		Application.Quit ();
	}
}