using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabelledSlider : MonoBehaviour {

	private Slider slider;
	private Text text;

	void Start () {
		slider = GetComponentInChildren <Slider> ();
		text = GetComponentInChildren<Text> ();
	}

	void Update () {
		text.text = slider.value.ToString();
	}
}
