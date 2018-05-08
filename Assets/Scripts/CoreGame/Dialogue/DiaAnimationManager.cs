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

	Animator leftPanelAnimator;
	Animator rightPanelAnimator;

	public void BootSequence(string sceneName){
		leftPanelAnimator  = GetComponentsInChildren<Animator> ()[0];
		rightPanelAnimator = GetComponentsInChildren<Animator> ()[1];
		currentState = DiaManagerState.Completed;

	}

	public IEnumerator DiaLeftStartAnimation(){
		DiaAnimationTuple dialogueStartAnim = DiaConstants.DiaAnimationTuples.diaStartAnimation;
		leftPanelAnimator.SetBool (dialogueStartAnim.parameter, dialogueStartAnim.value);

		yield return new WaitForSeconds (1);
	}

	public IEnumerator DiaLeftEndAnimation(){
		DiaAnimationTuple dialogueEndAnim = DiaConstants.DiaAnimationTuples.diaEndAnimation;
		leftPanelAnimator.SetBool (dialogueEndAnim.parameter, dialogueEndAnim.value);

		yield return new WaitForSeconds (1);
	}

	public IEnumerator DiaRightStartAnimation(){
		DiaAnimationTuple dialogueStartAnim = DiaConstants.DiaAnimationTuples.diaStartAnimation;
		rightPanelAnimator.SetBool (dialogueStartAnim.parameter, dialogueStartAnim.value);

		yield return new WaitForSeconds (1);
	}

	public IEnumerator DiaRightEndAnimation(){
		DiaAnimationTuple dialogueEndAnim = DiaConstants.DiaAnimationTuples.diaEndAnimation;
		rightPanelAnimator.SetBool (dialogueEndAnim.parameter, dialogueEndAnim.value);

		yield return new WaitForSeconds (1);
	}
}
