//*******************************************************************************************************
//* Initializes all managers.																			*
//* Each manager does something useful for dialogues : sprites, animations and panels.					*
//*																										*
//*******************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using JSONFactory;

public class DiaPanelManager : MonoBehaviour, DiaManager {

	public DiaManagerState currentState { get; private set; }

	private DiaPanelConfig rightPanel;
	private DiaPanelConfig leftPanel;
	private DiaNarrativeEvent currentEvent;
	private bool leftCharacterActive = true;
	private int stepIndex = 0;

	public void BootSequence(){
		rightPanel = GameObject.Find ("RightCharacterPanel").GetComponent<DiaPanelConfig> ();
		leftPanel  = GameObject.Find ("LeftCharacterPanel" ).GetComponent<DiaPanelConfig> ();
		currentEvent = JSONAssembly.RunJSONFactoryForScene (1);
		//InitializePanels ();
		UpdatePanelState();
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Space) && !DiaPanelConfig.isWriting) {
			UpdatePanelState ();
		}
	}

	void UpdatePanelState(){
		if (stepIndex < currentEvent.dialogues.Count) {
			UpdatePanels ();

			if (currentEvent.dialogues [stepIndex].characterLocation == DiaCharacterLocation.Left) {
				leftCharacterActive = true;
			} else {
				leftCharacterActive = false;
			}
			stepIndex++;
		}/* else {
			StartCoroutine (DiaMasterManager.animationManager.DiaLeftEndAnimation());
			StartCoroutine (DiaMasterManager.animationManager.DiaRightEndAnimation());
		}*/
	}

	private void UpdatePanels(){
		DiaDialogue currentDialogue = currentEvent.dialogues [stepIndex];

		if (currentDialogue.characterLocation == DiaCharacterLocation.Left) {
			leftCharacterActive = true;
			if (currentDialogue.animation == DiaPanelAnimation.Start) {
				StartCoroutine(DiaMasterManager.animationManager.DiaLeftStartAnimation ());
			}
			if (currentDialogue.animation == DiaPanelAnimation.End) {
				StartCoroutine(DiaMasterManager.animationManager.DiaLeftEndAnimation ());
			}
		} else if (currentDialogue.characterLocation == DiaCharacterLocation.Right) {
			leftCharacterActive = false;
			if (currentDialogue.animation == DiaPanelAnimation.Start) {
				StartCoroutine(DiaMasterManager.animationManager.DiaRightStartAnimation ());
			}
			if (currentDialogue.animation == DiaPanelAnimation.End) {
				StartCoroutine(DiaMasterManager.animationManager.DiaRightEndAnimation ());
			}
		}

		if (leftCharacterActive) {
			leftPanel.isTalking = true;
			rightPanel.isTalking = false;

			leftPanel.Configure (currentDialogue);
			rightPanel.ToggleCharacterMask ();
		} else {
			leftPanel.isTalking = false;
			rightPanel.isTalking = true;

			rightPanel.Configure (currentDialogue);
			leftPanel.ToggleCharacterMask ();
		}
	}




	/*private void InitializePanels(){
		if (currentEvent.dialogues [stepIndex].characterLocation == DiaCharacterLocation.Left) {
			leftPanel.Configure (currentEvent.dialogues [stepIndex]);
		} else if (currentEvent.dialogues [stepIndex].characterLocation == DiaCharacterLocation.Right) {
			rightPanel.Configure (currentEvent.dialogues [stepIndex]);
		}

		if (currentEvent.dialogues [stepIndex+1].characterLocation == DiaCharacterLocation.Left) {
			leftCharacterActive = true;
			leftPanel.isTalking = true;
			rightPanel.isTalking = false;
			leftPanel.Configure (currentEvent.dialogues [stepIndex+1]);
			rightPanel.ToggleCharacterMask ();
		} else if (currentEvent.dialogues [stepIndex+1].characterLocation == DiaCharacterLocation.Right) {
			leftCharacterActive = false;
			leftPanel.isTalking = false;
			rightPanel.isTalking = true;
			rightPanel.Configure (currentEvent.dialogues [stepIndex+1]);
			leftPanel.ToggleCharacterMask ();
		}

		StartCoroutine(DiaMasterManager.animationManager.DiaLeftStartAnimation ());
		StartCoroutine(DiaMasterManager.animationManager.DiaRightStartAnimation ());

		stepIndex += 2;
	}*/
}