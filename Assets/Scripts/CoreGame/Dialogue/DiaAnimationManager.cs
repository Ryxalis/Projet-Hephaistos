//*******************************************************************************************************
//* Deals with animations.																				*
//* We have only two animations : the start and the end of a dialogue.									*
//*																										*
//*******************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DiaConstants;

public class DiaAnimationManager : MonoBehaviour, DiaManager {

	public DiaManagerState currentState { get; private set; }
	public bool isAnimating;

	Animator leftPanelAnimator;
	Animator rightPanelAnimator;

	public void BootSequence(string sceneName){
		leftPanelAnimator  = GetComponentsInChildren<Animator> ()[0];
		rightPanelAnimator = GetComponentsInChildren<Animator> ()[1];
		currentState = DiaManagerState.Completed;
		isAnimating = false;
	}

	public IEnumerator DiaAnimation(string side, string moment){
		isAnimating = true;
		DiaAnimationTuple dialogueAnim;
		if (moment == "Start") {
			dialogueAnim = DiaConstants.DiaAnimationTuples.diaStartAnimation;
		} else { //if(moment == "End")
			dialogueAnim = DiaConstants.DiaAnimationTuples.diaEndAnimation;
		}
		if (side == "Left") {
			leftPanelAnimator.SetBool (dialogueAnim.parameter, dialogueAnim.value);
		} else if (side == "Right") {
			rightPanelAnimator.SetBool (dialogueAnim.parameter, dialogueAnim.value);
		}

		yield return new WaitForSeconds (1);	// should wait until the animaton ends instead

		isAnimating = false;
	}
}