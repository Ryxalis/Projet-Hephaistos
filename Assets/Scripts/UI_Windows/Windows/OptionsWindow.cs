using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsWindow : GenericWindow {
	
	public WindowBackgroundStruct[] SubOptionsWindows;

	public void OpenOptionsWindows(int i)
	{
		if (SubOptionsWindows[i].activateBackground) {
			WindowsManager.backgrounds.Add ((int)thisWindow - 1);
		}
		wManager.Open ((int)SubOptionsWindows[i].window - 1);
	}
}
