//*******************************************************************************************************
//* Initializes panel managers.																			*
//* Each manager does something useful for dialogues : sprites, animations and panels.					*
//*******************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using JSONFactory;

public class DiaPanelManager : DiaManager {

	[SerializeField] private DiaMasterManager masterManager;
	private DiaPanelConfig rightPanel;
	private DiaPanelConfig leftPanel;
	private DiaNarrativeEvent currentEvent;
	private bool leftCharacterActive;
	private int stepIndex;

	public override void BootSequence(string sceneName){
		leftCharacterActive = true;
		stepIndex = 0;
		rightPanel = GameObject.Find ("RightCharacterPanel").GetComponent<DiaPanelConfig> ();
		leftPanel  = GameObject.Find ("LeftCharacterPanel" ).GetComponent<DiaPanelConfig> ();
		leftPanel.dialogue.text = "";
		rightPanel.dialogue.text = "";
		currentEvent = JSONAssembly.RunJSONFactoryForScene (sceneName);
		UpdatePanelState ();
	}

	void Update(){
		UpdatePanelState ();
	}

	void UpdatePanelState(){
		if (Input.GetKeyDown (KeyCode.Space) && !DiaPanelConfig.isWriting && !masterManager.IsAnimating) {
			
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
		if (masterManager.IsAnimating == false && stepIndex >= currentEvent.dialogues.Count && masterManager.CurrentDialogue != "none") {
			masterManager.EndDialogue ();
		}
	}

	private void UpdatePanels(){
		DiaDialogue currentDialogue = currentEvent.dialogues [stepIndex];

		if (currentDialogue.characterLocation == DiaCharacterLocation.Left) {
			leftCharacterActive = true;
			if (currentDialogue.animation == DiaPanelAnimation.Start) {
				masterManager.Animate("Left", "Start");
			}
			if (currentDialogue.animation == DiaPanelAnimation.End) {
				masterManager.Animate("Left", "End");
			}
		} else if (currentDialogue.characterLocation == DiaCharacterLocation.Right) {
			leftCharacterActive = false;
			if (currentDialogue.animation == DiaPanelAnimation.Start) {
				masterManager.Animate("Right", "Start");
			}
			if (currentDialogue.animation == DiaPanelAnimation.End) {
				masterManager.Animate("Right", "End");
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