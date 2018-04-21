using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VideoOptionsWindow : GenericWindow {

	/*public Windows backgroundWindow;

	public OptionVariable[] options;

	public override void OnNextWindow ()
	{
		foreach (OptionVariable op in options) {
			if (op.UIObject.GetComponent<Slider> ()) {
				PlayerPrefs.SetInt (op.name, (int)op.UIObject.GetComponent<Slider> ().value);
			}
			if (op.UIObject.GetComponent<Toggle> ()) {
				PlayerPrefs.SetInt(op.name, op.UIObject.GetComponent<Toggle> ().isOn ? 1 : 0);
			}
		}
		wManager.Open ((int)nextWindow - 1, (int)backgroundWindow - 1);
	}

	public override void Open ()
	{
		foreach (OptionVariable op in options) {
			if (op.UIObject.GetComponent<Slider> ()) {
				op.UIObject.GetComponent<Slider> ().value = PlayerPrefs.GetInt (op.name);
			}
			if (op.UIObject.GetComponent<Toggle> ()) {
				op.UIObject.GetComponent<Toggle> ().isOn = PlayerPrefs.GetInt (op.name) == 1 ? true : false;
			}
		}
		base.Open ();
	}*/
}
