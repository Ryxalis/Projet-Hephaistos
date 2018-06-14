using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameNode : AbstractGameNode {

	private SpriteRenderer spriteRenderer;
	[SerializeField] private WorldWindow worldWindow;
	[Header("Sprites")]
	[SerializeField] private Sprite lockedSprite;
	[SerializeField] private Sprite unlockedSprite;
	[SerializeField] private Sprite deadSprite;
	[Header("Nodes")] 
	public AbstractGameNode nodeLeft = null;		// null if there is none
	public AbstractGameNode nodeRight = null;
	public AbstractGameNode nodeUp = null;
	public AbstractGameNode nodeDown = null;
	[Header("Parameters")]
	[SerializeField] private bool hasFork = false;
	[SerializeField] private int levelNumber = -1;
	[SerializeField] private string dialogueStartLevelName = "";
	[SerializeField] private string dialogueEndLevelName = "";
	[SerializeField] private string[] additionalDialogues;
	private int currentAdditionalDialogueID = 0;

	public bool HasFork { get { return hasFork; } }
	public int LevelNumber{ get { return levelNumber; } }
	public string DialogueStartLevelName { get { return dialogueStartLevelName; } }
	public string DialogueEndLevelName   { get { return dialogueEndLevelName;   } }
	public int AdditionalDialoguesLength { get { return additionalDialogues.Length; } }


	void Awake(){
		spriteRenderer = GetComponent<SpriteRenderer> ();
		Boot ();
	}

	public override void Boot(){
		if (nodeStatus == NodeStatus.Locked) {
			spriteRenderer.sprite = lockedSprite;
		} else if (nodeStatus == NodeStatus.Unlocked) {
			spriteRenderer.sprite = unlockedSprite;
		} else if (nodeStatus == NodeStatus.Dead) {
			spriteRenderer.sprite = deadSprite;
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
	public void DialogueAdditionalSequence(){
		if(additionalDialogues.Length > 0 && currentAdditionalDialogueID < additionalDialogues.Length){
			if (additionalDialogues [currentAdditionalDialogueID] != "") {
				worldWindow.StartDialogue (additionalDialogues [currentAdditionalDialogueID]);
			}
			currentAdditionalDialogueID = Mathf.Min(currentAdditionalDialogueID+1, additionalDialogues.Length-1);
		}
	}

	public void LevelSequence(){
		worldWindow.StartLevel (levelNumber);
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