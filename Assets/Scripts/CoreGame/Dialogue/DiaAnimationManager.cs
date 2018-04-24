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

	Animator panelAnimator;

	public void BootSequence(){
		panelAnimator = GameObject.Find ("DialogueCanvas").GetComponent<Animator> ();
		currentState = DiaManagerState.Completed;

	}

	public IEnumerator DiaLeftStartAnimation(){
		DiaAnimationTuple dialogueStartAnim = DiaConstants.DiaAnimationTuples.diaLeftStartAnimation;
		panelAnimator.SetBool (dialogueStartAnim.parameter, dialogueStartAnim.value);

		yield return new WaitForSeconds (1);
	}

	public IEnumerator DiaLeftEndAnimation(){
		DiaAnimationTuple dialogueEndAnim = DiaConstants.DiaAnimationTuples.diaLeftEndAnimation;
		panelAnimator.SetBool (dialogueEndAnim.parameter, dialogueEndAnim.value);

		yield return new WaitForSeconds (1);
	}

	public IEnumerator DiaRightStartAnimation(){
		DiaAnimationTuple dialogueStartAnim = DiaConstants.DiaAnimationTuples.diaRightStartAnimation;
		panelAnimator.SetBool (dialogueStartAnim.parameter, dialogueStartAnim.value);

		yield return new WaitForSeconds (1);
	}

	public IEnumerator DiaRightEndAnimation(){
		DiaAnimationTuple dialogueEndAnim = DiaConstants.DiaAnimationTuples.diaRightEndAnimation;
		panelAnimator.SetBool (dialogueEndAnim.parameter, dialogueEndAnim.value);

		yield return new WaitForSeconds (1);
	}
}
