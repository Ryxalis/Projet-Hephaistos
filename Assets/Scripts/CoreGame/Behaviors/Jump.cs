using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : AbstractBehavior {

	public float jumpSpeed = 200f;
	public float jumpDelay = 0.1f;
	public int jumpCount = 2;
	public GameObject dustEffectPrefab;

	protected float lastJumpTime = 0;
	protected int jumpsRemaining = 0;

	void Start () {
		
	}

	protected virtual void Update () {
		var buttonJump = inputState.GetButtonValue (inputButtons [0]);
		var buttonHoldTime = inputState.GetButtonHoldTime (inputButtons [0]);

		if (collisionState.standing) {// || collisionState.onWall) {
			if (buttonJump && buttonHoldTime < 0.1f) {
				jumpsRemaining = jumpCount - 1;
				OnJump ();
			}
		} else {
			if (buttonJump && buttonHoldTime < 0.1f && Time.time - lastJumpTime > jumpDelay) {
				if (jumpsRemaining > 0) {
					OnJump ();
					jumpsRemaining--;
					var clone = Instantiate (dustEffectPrefab);
					clone.transform.position = transform.position;
				}
			}
		}
	}

	protected virtual void OnJump (){
		var vel = body2D.velocity;

		body2D.velocity = new Vector2 (vel.x, jumpSpeed);

		lastJumpTime = Time.time;
	}
}
