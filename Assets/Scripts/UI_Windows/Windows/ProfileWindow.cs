using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileWindow : GenericWindow {

	[SerializeField] private GameObject worldLoop;
	[SerializeField] private SaveManager saveManager;
	[SerializeField] private int profileNumber = -1;
	[Header("Windows")]
	[SerializeField] private WindowBackgroundStruct worldWindow;
	[SerializeField] private WindowBackgroundStruct startWindow;

	public int ProfileNumber { get { return profileNumber; } }

	public void OpenWorldWindow(int number){
		OnNextWindow (worldWindow);

		worldLoop.SetActive (true);
		profileNumber = number;
		saveManager.LoadStart ();
		saveManager.LoadCurrentMap ();
	}

	public void OnPreviousWindow(){
		OnNextWindow (startWindow);
	}

}
