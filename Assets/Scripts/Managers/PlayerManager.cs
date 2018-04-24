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

	void Awake(){
		inputState = GetComponent<InputState> ();
		walkBehaviour = GetComponent<Walk> ();
		animator = GetComponent<Animator> ();
		collisionState = GetComponent<CollisionState> ();
	}

	void Start () {
		
	}

	void Update () {
		if(collisionState.standing){
			ChangeAnimationState (0);
		}
		if(inputState.absVelX > 0){
			ChangeAnimationState (1);
		}
		if (inputState.absVelY > 0) {
			ChangeAnimationState (2);
		}
		animator.speed = walkBehaviour.running ? walkBehaviour.runMultiplier : 1;
	}

	void ChangeAnimationState(int value){
		animator.SetInteger ("AnimState", value);
	}
}
