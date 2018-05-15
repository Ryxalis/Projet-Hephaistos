using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : AbstractBehavior {

	public float speed = 50f;
	public float runMultiplier = 2f;
	public bool running;

	void Start () {
		
	}
	
	void Update () {

		running = false;

		var left  = inputState.GetButtonValue (inputButtons [0]);
		var right = inputState.GetButtonValue (inputButtons [1]);
		var run   = inputState.GetButtonValue (inputButtons [2]);

		if (left || right) {
			
			var tmpSpeed = speed;

			if (run && runMultiplier > 0) {
				tmpSpeed *= runMultiplier;
				run = true;
			}

			var velX = tmpSpeed * (float)inputState.direction;

			body2D.velocity = new Vector2 (velX - InputState.absLevelSpeed, body2D.velocity.y);
		} else {
			body2D.velocity = new Vector2 ( - InputState.absLevelSpeed, body2D.velocity.y);
		}
	}
}
