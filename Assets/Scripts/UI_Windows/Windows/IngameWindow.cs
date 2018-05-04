using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameWindow : GenericWindow {

	public GameManager gameManager;
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Debug.Log ("Open options menu");
			this.OnNextWindow ();
			gameManager.TogglePause (true);
		}
	}
}
