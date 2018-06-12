using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsManager : MonoBehaviour {
	[HideInInspector]
	public GenericWindow[] windows;
	public int currentWindowID;
	public int defaultWindowID;

	public GenericWindow GetWindow(int value){
		return windows [value];
	}

	void Start(){
		Open (defaultWindowID);
	}

	public void Open(int value){
		if(value < 0 || value >= windows.Length){
			return;
		}
		var total = windows.Length;
		for (var i = 0; i < total; ++i) {
			var window = GetWindow (i);
			if (i == value && !window.gameObject.activeSelf) {
				window.gameObject.SetActive (true);
				window.Open ();
			} else if (i == value && window.gameObject.activeSelf) {
				window.OnFocus ();
			} else if (!window.IsBackground && window.gameObject.activeSelf) {
				window.Close ();
				window.gameObject.SetActive (false);
			}
		}
	}

}
