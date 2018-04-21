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
		KeysBinder.saveBinding ("Spell1", "A");
		KeysBinder.saveBinding ("Spell2", "Z");
		KeysBinder.saveBinding ("Spell3", "E");
		KeysBinder.saveBinding ("Spell4", "R");
		KeysBinder.saveBinding ("Jump", "Space");
		KeysBinder.loadBinding ("Spell1");
		KeysBinder.loadBinding ("Spell2");
		KeysBinder.loadBinding ("Spell3");
		KeysBinder.loadBinding ("Spell4");
		KeysBinder.loadBinding ("Jump");
	}

	void Update () {
		foreach (var input in inputs) {
			inputState.SetButtonValue (input.button, input.value);
		}
	}
}
