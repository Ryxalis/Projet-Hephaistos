using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardWindow : GenericWindow {

	public Text inputField;
	public int maxCharacter = 10;
	public GameObject keyboard;
	public GameObject keyboardCaps;
	public string varToRecord = "Name";
	public GameObject capsKey;
	public GameObject capsCapsKey;

	private float delay = 0;
	private float cursorDelay = 0.5f;
	private bool blink;
	private string _text = "";

	void Update(){
		var text = _text;

		if(_text.Length < maxCharacter){
			text += '_';
			if (blink) {
				text = text.Remove (text.Length - 1);
				text += "  ";
			}
		}

		inputField.text = text;

		delay += Time.deltaTime;

		if (delay > cursorDelay) {
			delay = 0;
			blink = !blink;
		}
	}

	public void OnKeyPressed(string key){
		if (_text.Length < maxCharacter) {
			_text += key;
		}
	}

	public void OnDelPressed(){
		if (_text.Length > 0) {
			_text = _text.Remove (_text.Length - 1);
		}
	}

	public void OnRetPressed(){
		PlayerPrefs.SetString (varToRecord, _text);
		OnNextWindow ();
	}

	public void OnCancelPressed(){
		OnPreviousWindow ();
	}

	public void OnCapsPressed(){
		keyboard.SetActive (!keyboard.activeSelf);
		keyboardCaps.SetActive (!keyboardCaps.activeSelf);

		if (keyboard.activeSelf) {
			eventSystem.SetSelectedGameObject (capsKey);
		} else {
			eventSystem.SetSelectedGameObject (capsCapsKey);
		}
	}

	protected override void Display (bool value)
	{
		keyboard.SetActive (true);
		keyboardCaps.SetActive (false);
		base.Display (value);
	}
}