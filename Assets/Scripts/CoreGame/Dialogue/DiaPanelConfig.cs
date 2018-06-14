//*******************************************************************************************************
//* Configure the panels while in dialogue.																*
//* Displays the text and the mask to see who's speaking.												*
//*																										*
//*******************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaPanelConfig : MonoBehaviour {

	[SerializeField] private DialogueManager masterManager;

	private bool isTalking;
	private bool isWriting;
	public bool IsWriting { get { return isWriting; } }
	public bool IsTalking { get { return isTalking; } }

	public void setIsTalking(bool newValue){ isTalking = newValue; }

	[Header("UI")]
	[SerializeField] private Image avatarImage;
	[SerializeField] private Image textBG;
	[SerializeField] private Text characterName;
	[SerializeField] private Text dialogue;
	[SerializeField] private float textPrintDelay = 0.05f;

	private Color maskActiveColor = new Color(100.0f/255.0f, 100.0f/255.0f, 100.0f/255.0f);

	public void Boot(){
		isWriting = false;
		isTalking = false;
		dialogue.text = "";
	}

	public void ToggleCharacterMask(){
		if (isTalking) {
			avatarImage.color = Color.white;
			textBG.color = Color.white;
		} else {
			avatarImage.color = maskActiveColor;
			textBG.color = maskActiveColor;
		}
	}

	public void Configure(DiaDialogue currentDialogue){
		ToggleCharacterMask ();
		avatarImage.sprite = masterManager.loadSprite(currentDialogue.atlasImageName);
		characterName.text = currentDialogue.name;

		if (isTalking) {
			StartCoroutine (AnimateText (currentDialogue.dialogueText));
		} else {
			dialogue.text = "";
		}
	}

	IEnumerator AnimateText(string dialogueText) {
		while (masterManager.IsAnimating == true) {
			yield return null;
		}
		isWriting = true;
		dialogue.text = "";
		foreach (char letter in dialogueText) {
			dialogue.text += letter;
			yield return new WaitForSeconds (textPrintDelay);
		}
		isWriting = false;
	}

}
