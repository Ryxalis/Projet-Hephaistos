//*******************************************************************************************************
//* Initializes panel managers.																			*
//* Each manager does something useful for dialogues : sprites, animations and panels.					*
//*******************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using JSONFactory;

public class DiaPanelManager : DiaManager {

	[SerializeField] private DialogueManager masterManager;
	[Header("Panels")]
	[SerializeField] private DiaPanelConfig leftPanel;
	[SerializeField] private DiaPanelConfig rightPanel;
	private DiaNarrativeEvent currentEvent;
	private bool leftCharacterActive;
	private int stepIndex;

	public override void BootSequence(string sceneName){
		leftCharacterActive = true;
		stepIndex = 0;
		leftPanel. Boot ();
		rightPanel.Boot ();
		currentEvent = JSONAssembly.RunJSONFactoryForScene (sceneName);
		UpdatePanelState ();
	}

	void Update(){
		if(masterManager.CurrentDialogue != "none")
			UpdatePanelState ();
	}

	public bool IsWriting(){
		return leftPanel.IsWriting || rightPanel.IsWriting;
	}

	void UpdatePanelState(){
		if (Input.GetKeyDown (KeyCode.Space) && !IsWriting() && !masterManager.IsAnimating) {
			if (stepIndex < currentEvent.dialogues.Count) {
				UpdatePanels ();
				stepIndex++;
			}
		}
		if (!IsWriting() && !masterManager.IsAnimating && stepIndex >= currentEvent.dialogues.Count) {
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
			leftPanel.setIsTalking(true);
			rightPanel.setIsTalking (false);

			leftPanel.Configure (currentDialogue);
			rightPanel.ToggleCharacterMask ();
		} else {
			leftPanel.setIsTalking(false);
			rightPanel.setIsTalking(true);

			rightPanel.Configure (currentDialogue);
			leftPanel.ToggleCharacterMask ();
		}
	}
}