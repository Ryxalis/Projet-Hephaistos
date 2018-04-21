using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBehavior : MonoBehaviour {

	public Buttons[] inputButtons;

	protected InputState inputState;
	protected Rigidbody2D body2D;

	protected virtual void Awake(){
		inputState = GetComponent<InputState> ();
		body2D = GetComponent<Rigidbody2D> ();
	}

	void Start () {
		
	}

	void Update () {
		
	}
}
