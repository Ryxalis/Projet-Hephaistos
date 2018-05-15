using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ButtonState{
	public bool onKeyPressed;
	public bool onKeyReleased;
	public bool value;
	public float holdTime = 0;
	public float holdTimeMod = 0;
	public bool timeTrigger;
}

public enum Direction{
	Left = -1,
	Right = 1,
}

public class InputState : MonoBehaviour {

	static public float absLevelSpeed = 20f;

	public Direction direction = Direction.Right;

	public float absVelX = 0f;
	public float absVelY = 0f;

	private Rigidbody2D body2D;
	private Dictionary<Buttons, ButtonState> buttonStates = new Dictionary<Buttons, ButtonState>();

	void Awake(){
		body2D = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate(){
		absVelX = Mathf.Abs (body2D.velocity.x);
		absVelY = Mathf.Abs (body2D.velocity.y);
	}

	public void SetButtonValue(Buttons key, bool value){
		if (!buttonStates.ContainsKey (key)) {
			buttonStates.Add (key, new ButtonState ());
		}

		var state = buttonStates [key];

		bool pressed = false;
		bool released = false;

		if (state.value && !value) {
			// Button released frame
			released = true;
			state.holdTime = 0;
		} else if (state.value && value) {
			// Button pressed
			if (state.holdTime == 0) {
				pressed = true;
			}
			state.holdTime += Time.deltaTime;
		}

		state.value = value;
		state.onKeyPressed  = pressed;
		state.onKeyReleased = released;

		state.timeTrigger = state.holdTimeMod > 0.5f ? true : false;
		state.holdTimeMod = state.holdTime % 0.5f;
	}

	public bool GetButtonValue(Buttons key){
		if (buttonStates.ContainsKey (key)) {
			return buttonStates [key].value;
		} else {
			return false;
		}
	}

	public float GetButtonHoldTime(Buttons key){
		if (buttonStates.ContainsKey (key)) {
			return buttonStates [key].holdTime;
		} else {
			return 0;
		}
	}

}
