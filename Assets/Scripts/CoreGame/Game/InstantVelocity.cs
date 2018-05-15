using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantVelocity : MonoBehaviour {

	public Vector2 velocity = Vector2.zero;
	public bool hasLevelSpeed = true;
	public bool repeat = false;

	private Rigidbody2D myBody2D;

	void Awake(){
		myBody2D = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate(){
		if (hasLevelSpeed) {
			myBody2D.velocity = new Vector2 (-InputState.absLevelSpeed, 0);
		} else {
			myBody2D.velocity = velocity;
		}

		if (repeat && transform.position.x < -Screen.width/2f / PixelPerfectCamera.pixelToUnits) {
			
			transform.position = new Vector2 (-transform.position.x, transform.position.y);
		}
	}
}
