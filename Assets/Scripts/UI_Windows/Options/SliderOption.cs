using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderOption : MonoBehaviour {
	
	private Toggle selectionToggle;
	private Slider slider;

	void Awake(){
		selectionToggle = GetComponentsInChildren<Toggle> ()[0];
		slider = GetComponentsInChildren<Slider> ()[0];
	}

	void Update(){
		if (selectionToggle.isOn) {
			if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") == -1) {
				slider.value --;
			}
			if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetAxis("Horizontal") == 1) {
				slider.value ++;
			}
		}
	}
}
