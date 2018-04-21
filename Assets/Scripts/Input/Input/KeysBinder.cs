//*******************************************************************************************************
//* Bind Virtual keys with real keyboard keys.															*
//* If a key doesn't exist, we use the default InputManager instead.									*
//* We use PlayPrefs to save and load bindings.															*
//*																										*
//*******************************************************************************************************


// KeysBinder.saveBinding (Dictionnary_entry, KeyString);		to save a key
// KeysBinder.loadBinding (Dictionnary_entry);					to load a key

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class KeysBinder {

	public static Dictionary<string, string> keysMapper = new Dictionary<string, string>(){
		{"Spell1", "Q"},
		{"Spell2", "W"},
		{"Spell3", "E"},
		{"Spell4", "R"},
		{"Jump", "Space"},
	};

	public static float getKey(string keyName){
		if (keysMapper.ContainsKey (keyName)) {
			KeyCode kc = (KeyCode)System.Enum.Parse (typeof(KeyCode), keysMapper [keyName]);	// cast a string to a keycode =p
			return Input.GetKey (kc) ? 1 : 0;
		} else {
			return Input.GetAxis(keyName);
		}
	}

	public static void saveBinding(string myKeyCode, string keyString){
		PlayerPrefs.SetString (myKeyCode, keyString);
	}

	public static void loadBinding(string myKeyCode){
		if (keysMapper.ContainsKey (myKeyCode)) {
			if (PlayerPrefs.HasKey (myKeyCode)) {
				keysMapper [myKeyCode] = PlayerPrefs.GetString (myKeyCode);
			} else {
				Debug.Log ("Warning: this key was not saved.");
			}
		} else {
			Debug.Log ("ERROR: This key is not recognized by the dictionnary.");
		}
	}
}
