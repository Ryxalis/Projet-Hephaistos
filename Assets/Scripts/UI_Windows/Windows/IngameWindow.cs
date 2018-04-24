using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameWindow : GenericWindow {
	
	void Start () {
		
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Debug.Log ("Open options menu");
			this.Open ();
		}
	}


}
