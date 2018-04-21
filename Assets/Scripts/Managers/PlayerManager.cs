using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	private InputState inputState;
	private Walk walkBehaviour;
	private Animator animator;

	void Awake(){
		inputState = GetComponent<InputState> ();
		walkBehaviour = GetComponent<Walk> ();
		animator = GetComponent<Animator> ();
	}

	void Start () {
		
	}

	void Update () {
		if(inputState.absVelX == 0){
			ChangeAnimationState (0);
		}
		if(inputState.absVelX > 0){
			ChangeAnimationState (1);
		}
		animator.speed = walkBehaviour.running ? walkBehaviour.runMultiplier : 1;
	}

	void ChangeAnimationState(int value){
		animator.SetInteger ("AnimState", value);
	}
}
