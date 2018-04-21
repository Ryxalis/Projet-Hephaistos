using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleOption : MonoBehaviour {

	private Toggle selectionToggle;
	private Toggle toggle;

	void Awake(){
		selectionToggle = GetComponentsInChildren<Toggle> () [0];
		toggle = GetComponentsInChildren<Toggle> () [1];
	}

	void Update(){
		if (selectionToggle.isOn) {
			if (Input.GetButtonDown ("Submit")) {
				toggle.isOn = !toggle.isOn;
			}
		}
	}

}
