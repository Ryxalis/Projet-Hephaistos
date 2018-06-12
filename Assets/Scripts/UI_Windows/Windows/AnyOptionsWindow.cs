//*******************************************************************************************************
//* Window for some optitons.																			*
//* Deals with a particular type of option, loads and save.												*
//*																										*
//*******************************************************************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnyOptionsWindow : GenericWindow {

	public OptionVariable[] options;
	[Header("Window")]
	[SerializeField] private WindowBackgroundStruct optionsWindow;

	public void OnPreviousWindow ()
	{
		SaveOptions ();
		base.OnNextWindow (optionsWindow);
	}

	public override void Open ()
	{
		LoadOptions ();
		base.Open ();
	}

	private void SaveOptions()		// this saves as playerPrefs
	{
		foreach (OptionVariable op in options) {
			if (op.UIObject.GetComponentInChildren<Slider> ()) {
				PlayerPrefs.SetInt (op.name, (int)op.UIObject.GetComponentInChildren<Slider> ().value);
			}
			else if (op.UIObject.GetComponentInChildren<Toggle> ()) {
				PlayerPrefs.SetInt(op.name, op.UIObject.GetComponentInChildren<Toggle> ().isOn ? 1 : 0);
			}
			else if (op.UIObject.GetComponentInChildren<Button> ()) {
				Button butt = op.UIObject.GetComponentInChildren<Button> ();
				PlayerPrefs.SetString(op.name, butt.gameObject.GetComponentInChildren<Text>().text);
			}
		}
	}

	private void LoadOptions(){
		foreach (OptionVariable op in options) {
			if (op.UIObject.GetComponentInChildren<Slider> ()) {
				op.UIObject.GetComponentInChildren<Slider> ().value = PlayerPrefs.GetInt (op.name);
			}
			else if (op.UIObject.GetComponentInChildren<Toggle> ()) {
				op.UIObject.GetComponentInChildren<Toggle> ().isOn = PlayerPrefs.GetInt (op.name) == 1 ? true : false;
			}
			else if (op.UIObject.GetComponentInChildren<Button> ()) {
				Button butt = op.UIObject.GetComponentInChildren<Button> ();
				butt.gameObject.GetComponentInChildren<Text> ().text = PlayerPrefs.GetString(op.name);
			}
		}
	}
}
