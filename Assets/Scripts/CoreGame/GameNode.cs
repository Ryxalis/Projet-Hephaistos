using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeStatus {Locked, Unlocked, Dead}

public class GameNode : MonoBehaviour {

	public Sprite lockedSprite;
	public Sprite unlockedSprite;
	public Sprite deadSprite;

	public GameNode nodeLeft = null;		// null if there is none
	public GameNode nodeRight = null;
	public GameNode nodeUp = null;
	public GameNode nodeDown = null;

	public bool hasFork = false;
	public bool hasStartDialogue = false;
	public bool hesEndDialogue = false;

	public int levelNumber = -1;
	public string dialogueStartLevelName = "";
	public string dialogueEndLevelName = "";
	//fork things?

	public NodeStatus nodeStatus = NodeStatus.Locked;

	public LevelManager levelManager;
	private SpriteRenderer spriteRenderer;
	private WorldWindow worldWindow;

	public void UnlockNode(){
		nodeStatus = NodeStatus.Unlocked;
		spriteRenderer.sprite = unlockedSprite;
	}

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

	public void ForkSequence(GameNode nextGameNode){
		print (nextGameNode);
		if (nodeUp && nodeUp != nextGameNode) {nodeUp.KillNode ();}
		if (nodeDown && nodeDown != nextGameNode) {nodeDown.KillNode ();}
		if (nodeUp && nodeLeft != nextGameNode) {nodeLeft.KillNode ();}
		if (nodeRight && nodeRight != nextGameNode) {nodeRight.KillNode ();}
	}

	public void KillNode(){
		if (nodeStatus == NodeStatus.Locked) {
			nodeStatus = NodeStatus.Dead;
			spriteRenderer.sprite = deadSprite;
		}
	}

	public void ForkSequence(string chosenDirection){
		// do fork things
	}
}