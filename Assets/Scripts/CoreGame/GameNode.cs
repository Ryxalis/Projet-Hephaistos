using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameNode : MonoBehaviour {

	public GameNode nodeLeft = null;		// null if there is none
	public GameNode nodeRight = null;
	public GameNode nodeUp = null;
	public GameNode nodeDown = null;

	public bool isFork = false;
	public bool isLevel = false;
	public bool isDialogue = false;
	public bool isDialogueEndLevel = false;
	public bool hasDoneDialogue = false;	// put it private?
	public bool hasDoneDialogueEndLevel = false;	// put it private?

	public string dialogueName = "";
	public string dialogueEndLevelName = "";
	public int levelNumber = -1;
	//fork thing?

	public bool isLocked = false;
	public bool isExplored = false;

	private GameManager gameManager;

	void Start(){
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}

	public void DialogueSequence(){
		if(isDialogue && dialogueName != ""){
			print ("IsDialogue");
			gameManager.StartDialogue (dialogueName);
		}
	}

	public void LevelSequence(){
		if (isLevel && levelNumber > 0) {
			gameManager.StartLevel (levelNumber);
		}
	}

	public void ForkSequence(){
		// do fork things
	}
}