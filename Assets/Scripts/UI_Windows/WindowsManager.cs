using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsManager : MonoBehaviour {
	[HideInInspector]
	public GenericWindow[] windows;
	public int currentWindowID;
	public int defaultWindowID;

	public static List<int> backgrounds = new List<int>();

	public GenericWindow GetWindow(int value){
		return windows [value];
	}

	private void ToggleVisibility(int value){
		var total = windows.Length;

		for (var i = 0; i < total; ++i) {
			var window = GetWindow (i);
			if (i == value) {
				window.Open ();
			} else if (!backgrounds.Contains (i)) {
				window.Close ();
			}
		}
	}

	public GenericWindow Open(int value, int background = -1){
		if(value < 0 || value >= windows.Length){
			return null;
		}
		currentWindowID = value;
		ToggleVisibility(currentWindowID);

		return GetWindow (currentWindowID);
	}

	void Start(){
		GenericWindow.wManager = this;
		Open (defaultWindowID);
	}
}
