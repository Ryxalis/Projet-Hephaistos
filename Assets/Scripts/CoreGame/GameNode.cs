using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameNode : AbstractGameNode {

	public Sprite lockedSprite;
	public Sprite unlockedSprite;
	public Sprite deadSprite;


	public AbstractGameNode nodeLeft = null;		// null if there is none
	public AbstractGameNode nodeRight = null;
	public AbstractGameNode nodeUp = null;
	public AbstractGameNode nodeDown = null;

	public bool hasFork = false;
	public int levelNumber = -1;
	public string dialogueStartLevelName = "";
	public string dialogueEndLevelName = "";

	public LevelManager levelManager;
	private SpriteRenderer spriteRenderer;
	private WorldWindow worldWindow;

	void Awake(){
		worldWindow = GetComponentInParent<WorldWindow> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		if (nodeStatus == NodeStatus.Locked) {
			spriteRenderer.sprite = lockedSprite;
		} else {
			spriteRenderer.sprite = unlockedSprite;
		}
	}

	public void DialogueStartSequence(){
		if(dialogueStartLevelName != ""){
			worldWindow.StartDialogue(dialogueStartLevelName);
		}
	}
	public void DialogueEndSequence(){
		if(dialogueEndLevelName != ""){
			worldWindow.StartDialogue(dialogueEndLevelName);
		}
	}

	public void LevelSequence(){
		if (levelNumber >= 0) {
			worldWindow.StartLevel (levelNumber);
		}
	}

	public void ForkSequence(AbstractGameNode nextGameNode){
		if (nodeUp && nodeUp != nextGameNode) {nodeUp.KillNode ();}
		if (nodeDown && nodeDown != nextGameNode) {nodeDown.KillNode ();}
		if (nodeLeft && nodeLeft != nextGameNode) {nodeLeft.KillNode ();}
		if (nodeRight && nodeRight != nextGameNode) {nodeRight.KillNode ();}
	}

	public void ForkSequence(string chosenDirection){
		if (chosenDirection != "Up" && nodeUp) {nodeUp.KillNode ();}
		if (chosenDirection != "Down" && nodeDown) {nodeDown.KillNode ();}
		if (chosenDirection != "Left" && nodeLeft) {nodeLeft.KillNode ();}
		if (chosenDirection != "Right" && nodeRight) {nodeRight.KillNode ();}
	}

	public override void KillNode(){
		if (nodeStatus == NodeStatus.Locked) {
			nodeStatus = NodeStatus.Dead;
			spriteRenderer.sprite = deadSprite;
		}
	}

	public override void UnlockNode(){
		nodeStatus = NodeStatus.Unlocked;
		spriteRenderer.sprite = unlockedSprite;
	}

}