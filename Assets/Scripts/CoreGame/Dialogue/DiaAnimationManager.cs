//*******************************************************************************************************
//* Deals with animations.																				*
//* We have only two animations : the start and the end of a dialogue.									*
//*																										*
//*******************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DiaConstants;

public class DiaAnimationManager : DiaManager {

	private bool isAnimating;
	public bool IsAnimating { get { return isAnimating; } }

	private Animator leftPanelAnimator;
	private Animator rightPanelAnimator;

	public override void BootSequence(string sceneName){
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
		} else if(moment == "End") {
			dialogueAnim = DiaConstants.DiaAnimationTuples.diaEndAnimation;
		} else {
			dialogueAnim = DiaConstants.DiaAnimationTuples.diaEndAnimation;
			Debug.Log ("ERROR: moment not valid");
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