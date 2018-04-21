using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceDirection : AbstractBehavior {
	
	void Start () {
		
	}
	
	void Update () {
		var left  = inputState.GetButtonValue (inputButtons [0]);
		var right = inputState.GetButtonValue (inputButtons [1]);

		if (left) {
			inputState.direction = Direction.Left;
		} else if (right) {
			inputState.direction = Direction.Right;
		}

		transform.localScale = new Vector3 ((float)inputState.direction, 1, 1);
	}
}
