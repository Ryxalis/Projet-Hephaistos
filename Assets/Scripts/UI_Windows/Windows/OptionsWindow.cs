//*******************************************************************************************************
//* Option Window.																						*
//* Link between Start window andd all different options.												*
//*																										*
//*******************************************************************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsWindow : GenericWindow {

	[Header("Windows")]
	[SerializeField] private WindowBackgroundStruct[] SubOptionsWindows;
	[SerializeField] private WindowBackgroundStruct startWindow;

	public void OpenOptionsWindows(int i)
	{
		OnNextWindow (SubOptionsWindows [i]);
	}

	public void OnPreviousWindow(){
		OnNextWindow (startWindow);
	}
}
