using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameNode : MonoBehaviour {

	public Sprite lockedSprite;
	public Sprite unexploredSprite;
	public Sprite exploredSprite;
	public Sprite currentSprite;

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
	public bool isCurrent = false;

	private GameManager gameManager;
	private SpriteRenderer spriteRenderer;
	private WorldWindow worldWindow;

	public void LeaveNode(){
		isExplored = true;
		isCurrent = false;
		spriteRenderer.sprite = exploredSprite;
	}

	public void SetCurrent(){
		spriteRenderer.sprite = currentSprite;
		isCurrent = true;
	}

	void Awake(){
		worldWindow = GetComponentInParent<WorldWindow> ();
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		if (!isExplored) {
			spriteRenderer.sprite = unexploredSprite;
		} else {
			spriteRenderer.sprite = exploredSprite;
		}
		if(isCurrent){
			spriteRenderer.sprite = currentSprite;
		}
	}

	public void DialogueSequence(){
		if(isDialogue && dialogueName != ""){
			print ("IsDialogue");
			//gameManager.StartDialogue (dialogueName);
			worldWindow.StartDialogue(dialogueName);
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