//*******************************************************************************************************
//* Deals with all behaviours.																			*
//* Chooses the good animation to display.																*
//*																										*
//*******************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	private InputState inputState;
	private Walk walkBehaviour;
	private Animator animator;
	private CollisionState collisionState;
	private Duck duckBehaviour;
	private SlideDownWall wallBehaviour;

	void Awake(){
		inputState = GetComponent<InputState> ();
		walkBehaviour = GetComponent<Walk> ();
		animator = GetComponent<Animator> ();
		collisionState = GetComponent<CollisionState> ();
		duckBehaviour = GetComponent<Duck> ();
		wallBehaviour = GetComponent<SlideDownWall> ();
	}

	void Start () {
		
	}

	void Update () {

		if(collisionState.standing){
			ChangeAnimationState (0);
		}
		if(inputState.absVelX - InputState.absLevelSpeed > 0){
			ChangeAnimationState (1);
		}
		if (inputState.absVelY > 0 && !collisionState.standing) {
			ChangeAnimationState (2);
		}
		animator.speed = walkBehaviour.running ? walkBehaviour.runMultiplier : 1;

		if (duckBehaviour.ducking) {
			ChangeAnimationState (3);
		}

		if (!collisionState.standing && wallBehaviour.onWallDetected) {
			ChangeAnimationState (4);
		}
	}

	void ChangeAnimationState(int value){
		animator.SetInteger ("AnimState", value);
	}
}
