using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabelledResolutionSlider : MonoBehaviour {

	private Slider slider;
	private Text text;
	private Resolution[] resolutions;

	void Start () {
		slider = GetComponentInChildren <Slider> ();
		text = GetComponentInChildren<Text> ();
		resolutions =  SettingsManager.myResolutions.ToArray();
		slider.maxValue = resolutions.Length - 1;
	}

	void Update () {
		Resolution res = resolutions [(int)slider.value];
		text.text = res.width + "x" + res.height;
	}
}
