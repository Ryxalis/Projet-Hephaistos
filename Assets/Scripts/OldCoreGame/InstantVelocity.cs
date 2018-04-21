using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantVelocity : MonoBehaviour {

	public Vector2 velocity = Vector2.zero;

	private Rigidbody2D myBody2D;

	void Awake(){
		myBody2D = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate(){
		myBody2D.velocity = velocity;
	}
}
