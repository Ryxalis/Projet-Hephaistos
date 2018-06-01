//*******************************************************************************************************
//* Initializes panel managers.																			*
//* Each manager does something useful for dialogues : sprites, animations and panels.					*
//*******************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using JSONFactory;

public class DiaPanelManager : MonoBehaviour, DiaManager {

	public DiaManagerState currentState { get; private set; }
	public DiaMasterManager masterManager;

	private DiaPanelConfig rightPanel;
	private DiaPanelConfig leftPanel;
	private DiaNarrativeEvent currentEvent;
	private bool leftCharacterActive;
	private int stepIndex;

	public void BootSequence(string sceneName){
		leftCharacterActive = true;
		stepIndex = 0;
		rightPanel = GameObject.Find ("RightCharacterPanel").GetComponent<DiaPanelConfig> ();
		leftPanel  = GameObject.Find ("LeftCharacterPanel" ).GetComponent<DiaPanelConfig> ();
		leftPanel.dialogue.text = "";
		rightPanel.dialogue.text = "";
		currentEvent = JSONAssembly.RunJSONFactoryForScene (sceneName);
		UpdatePanelState();
	}

	void Update(){
		UpdatePanelState ();
	}

	void UpdatePanelState(){
		if (Input.GetKeyDown (KeyCode.Space) && !DiaPanelConfig.isWriting) {// && DiaMasterManager.currentDialogue != "none") {
			
			if (stepIndex < currentEvent.dialogues.Count) {
				UpdatePanels ();

				if (currentEvent.dialogues [stepIndex].characterLocation == DiaCharacterLocation.Left) {
					leftCharacterActive = true;
				} else {
					leftCharacterActive = false;
				}
				stepIndex++;
			}
		}
		if (masterManager.animationManager.isAnimating == false && stepIndex >= currentEvent.dialogues.Count && DiaMasterManager.currentDialogue != "none") {
			masterManager.EndDialogue ();
		}
	}

	private void UpdatePanels(){
		DiaDialogue currentDialogue = currentEvent.dialogues [stepIndex];

		if (currentDialogue.characterLocation == DiaCharacterLocation.Left) {
			leftCharacterActive = true;
			if (currentDialogue.animation == DiaPanelAnimation.Start) {
				StartCoroutine(masterManager.animationManager.DiaAnimation("Left", "Start"));
			}
			if (currentDialogue.animation == DiaPanelAnimation.End) {
				StartCoroutine(masterManager.animationManager.DiaAnimation("Left", "End"));
			}
		} else if (currentDialogue.characterLocation == DiaCharacterLocation.Right) {
			leftCharacterActive = false;
			if (currentDialogue.animation == DiaPanelAnimation.Start) {
				StartCoroutine(masterManager.animationManager.DiaAnimation("Right", "Start"));
			}
			if (currentDialogue.animation == DiaPanelAnimation.End) {
				StartCoroutine(masterManager.animationManager.DiaAnimation("Right", "End"));
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
}