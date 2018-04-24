using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : AbstractBehavior {

	public float jumpSpeed = 200f;

	void Start () {
		
	}

	void Update () {
		var canJump = inputState.GetButtonValue (inputButtons [0]);
		var buttonHoldTime = inputState.GetButtonHoldTime (inputButtons [0]);

		if (collisionState.standing) {
			if (canJump && buttonHoldTime < 0.1f) {
				OnJump ();
			}
		}
	}

	protected virtual void OnJump (){
		var vel = body2D.velocity;

		body2D.velocity = new Vector2 (vel.x, jumpSpeed);
	}
}
