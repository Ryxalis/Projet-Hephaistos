using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBehavior : MonoBehaviour {

	public Buttons[] inputButtons;

	protected InputState inputState;
	protected Rigidbody2D body2D;
	protected CollisionState collisionState;

	protected virtual void Awake(){
		inputState = GetComponent<InputState> ();
		body2D = GetComponent<Rigidbody2D> ();
		collisionState = GetComponent<CollisionState> ();
	}

	void Start () {
		
	}

	void Update () {
		
	}
}
