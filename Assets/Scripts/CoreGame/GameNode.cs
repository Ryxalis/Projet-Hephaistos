using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeStatus {Locked, Unlocked}

public class GameNode : MonoBehaviour {

	public Sprite lockedSprite;
	public Sprite unlockedSprite;
	//public Sprite currentSprite;

	public GameNode nodeLeft = null;		// null if there is none
	public GameNode nodeRight = null;
	public GameNode nodeUp = null;
	public GameNode nodeDown = null;

	public bool hasFork = false;
	public bool hasLevel = false;
	public bool hasDialogueStartLevel = false;
	public bool hasDialogueEndLevel = false;
	public bool hasDoneDialogueStartLevel = false;	// put it private?
	public bool hasDoneDialogueEndLevel = false;	// put it private?

	public string dialogueStartLevelName = "";
	public string dialogueEndLevelName = "";
	public int levelNumber = -1;
	//fork thing?

	public NodeStatus nodeStatus = NodeStatus.Locked;
	public bool isCurrent;

	public LevelManager levelManager;
	private SpriteRenderer spriteRenderer;
	private WorldWindow worldWindow;

	public void UnlockNode(){
		nodeStatus = NodeStatus.Unlocked;
		spriteRenderer.sprite = unlockedSprite;
	}

	public void SetCurrent(){
		//spriteRenderer.sprite = currentSprite;
		isCurrent = true;
	}

	void Awake(){
		worldWindow = GetComponentInParent<WorldWindow> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		if (nodeStatus == NodeStatus.Locked) {
			spriteRenderer.sprite = lockedSprite;
		} else {
			spriteRenderer.sprite = unlockedSprite;
		}
		if(isCurrent){
			//spriteRenderer.sprite = currentSprite;
		}
	}

	public void DialogueStartSequence(){
		if(hasDialogueStartLevel && dialogueStartLevelName != ""){
			worldWindow.StartDialogue(dialogueStartLevelName);
		}
	}
	public void DialogueEndSequence(){
		if(hasDialogueEndLevel && dialogueEndLevelName != ""){
			worldWindow.StartDialogue(dialogueEndLevelName);
		}
	}

	public void LevelSequence(){
		if (hasLevel && levelNumber >= 0) {
			worldWindow.StartLevel (levelNumber);
		}
	}

	public void ForkSequence(){
		// do fork things
	}
}