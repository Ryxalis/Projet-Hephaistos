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

	public bool isTalking;
	public static bool isWriting = false;

	public Image avatarImage;
	public Image textBG;
	public Text characterName;
	public Text dialogue;
	public float textPrintDelay = 0.05f;

	private Color maskActiveColor = new Color(100.0f/255.0f, 100.0f/255.0f, 100.0f/255.0f);

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
		avatarImage.sprite = DiaMasterManager.atlasManager.loadSprite(currentDialogue.atlasImageName);
		characterName.text = currentDialogue.name;

		if (isTalking) {
			StartCoroutine (AnimateText (currentDialogue.dialogueText));
		} else {
			dialogue.text = "";
		}
	}

	IEnumerator AnimateText(string dialogueText) {
		isWriting = true;
		dialogue.text = "";

		foreach (char letter in dialogueText) {
			dialogue.text += letter;
			yield return new WaitForSeconds (textPrintDelay);
		}
		isWriting = false;
	}

}
