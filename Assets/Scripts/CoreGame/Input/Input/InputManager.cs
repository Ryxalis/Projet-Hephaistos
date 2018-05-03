using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Buttons{
	Left, 
	Right,
	Up, 
	Down, 
	Q, 
	W,
	E,
	R,
	Space
}

public enum Condition{
	GreaterThan,
	SmallerThan
}

[System.Serializable]
public class InputAxisState{
	public string axisName;
	public float offValue;
	public Buttons button;
	public Condition condition;

	public bool value{
		
		get {
			var val = KeysBinder.getKey (axisName);
			switch (condition) {
			case Condition.GreaterThan:
				return val > offValue;
			case Condition.SmallerThan:
				return val < offValue;
			}

			return false;
		}

	}
}

public class InputManager : MonoBehaviour {

	public InputAxisState[] inputs;
	public InputState inputState;

	void Start () {
		//PlayerPrefs.DeleteAll ();
		InitializePrefsInput();
		UpdateInputs();
	}

	void Update () {
		foreach (var input in inputs) {
			inputState.SetButtonValue (input.button, input.value);
		}
	}

	void InitializePrefsInput(){
		//save as in settingsManager.
		if (!PlayerPrefs.HasKey ("Spell1")) {
			PlayerPrefs.SetString ("Spell1", "A");
		}
		if (!PlayerPrefs.HasKey ("Spell2")) {
			PlayerPrefs.SetString ("Spell2", "Z");
		}
		if (!PlayerPrefs.HasKey ("Spell3")) {
			PlayerPrefs.SetString ("Spell3", "E");
		}
		if (!PlayerPrefs.HasKey ("Spell4")) {
			PlayerPrefs.SetString ("Spell4", "R");
		}
		if (!PlayerPrefs.HasKey ("Jump")) {
			PlayerPrefs.SetString ("Jump", "Space");
		}
	}

	void UpdateInputs(){
		KeysBinder.loadBinding ("Spell1");
		KeysBinder.loadBinding ("Spell2");
		KeysBinder.loadBinding ("Spell3");
		KeysBinder.loadBinding ("Spell4");
		KeysBinder.loadBinding ("Jump");
	}
}
