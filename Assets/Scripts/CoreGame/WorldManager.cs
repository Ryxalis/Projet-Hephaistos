using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStatus{Menu, WorldMap, WorldMapDialogue, InGame};

public class WorldManager : MonoBehaviour {

	private GameStatus gameStatus;
	private bool isTravelling = false;
	private bool isDoingCurrentNode = false;

	public LevelManager levelManager;
	public GameObject worldPlayer;
	public AbstractGameNode currentAbstractNode;
	public float speed = 10f;

	public GenericWindow InGameWindow;
	public GenericWindow WorldWindow;
	public GenericWindow DialogueWindow;

	void Awake(){
		gameStatus = GameStatus.Menu;
		Boot ();
	}

	public void Boot() {
		worldPlayer.transform.position = currentAbstractNode.transform.position;
	}

	void Update () {
		AbstractGameNode nextAbstractNode = currentAbstractNode;
		if (gameStatus == GameStatus.WorldMap && !isTravelling) {
			if (!currentAbstractNode.isTravelNode) {
				GameNode currentGameNode = (GameNode)currentAbstractNode;
				if (!isTravelling && !isDoingCurrentNode) {
					if (Input.GetAxis ("Vertical") > 0 && currentGameNode.nodeUp && currentGameNode.nodeUp.nodeStatus != NodeStatus.Dead) {
						if (currentGameNode.nodeUp.nodeStatus == NodeStatus.Unlocked || currentGameNode.nodeStatus == NodeStatus.Unlocked) {
							nextAbstractNode = currentGameNode.nodeUp;
						}
					}
					if (Input.GetAxis ("Vertical") < 0 && currentGameNode.nodeDown && currentGameNode.nodeDown.nodeStatus != NodeStatus.Dead) {
						if (currentGameNode.nodeDown.nodeStatus == NodeStatus.Unlocked || currentGameNode.nodeStatus == NodeStatus.Unlocked) {
							nextAbstractNode = currentGameNode.nodeDown;
						}
					}
					if (Input.GetAxis ("Horizontal") < 0 && currentGameNode.nodeLeft && currentGameNode.nodeLeft.nodeStatus != NodeStatus.Dead) {
						if (currentGameNode.nodeLeft.nodeStatus == NodeStatus.Unlocked || currentGameNode.nodeStatus == NodeStatus.Unlocked) {
							nextAbstractNode = currentGameNode.nodeLeft;
						}
					}
					if (Input.GetAxis ("Horizontal") > 0 && currentGameNode.nodeRight && currentGameNode.nodeRight.nodeStatus != NodeStatus.Dead) {
						if (currentGameNode.nodeRight.nodeStatus == NodeStatus.Unlocked || currentGameNode.nodeStatus == NodeStatus.Unlocked) {
							nextAbstractNode = currentGameNode.nodeRight;
						}
					}
					if (Input.GetKeyDown (KeyCode.Space)) {
						isDoingCurrentNode = true;
						StartCoroutine (executeLevel (currentGameNode));
					}
				}
			} else {
				GameNodeTravel currentTravelNode = (GameNodeTravel)currentAbstractNode;
				nextAbstractNode = currentTravelNode.nextNode;
				currentAbstractNode.UnlockNode ();
			}
		}


		if(currentAbstractNode != nextAbstractNode){
			StartCoroutine( Travel (nextAbstractNode ) );

			if (nextAbstractNode.isTravelNode) {
				GameNodeTravel nextTravelNode = (GameNodeTravel)nextAbstractNode;
				if (currentAbstractNode == nextTravelNode.nextNode1) {
					nextTravelNode.nextNode = nextTravelNode.nextNode2;
				}
				if (currentAbstractNode == nextTravelNode.nextNode2) {
					nextTravelNode.nextNode = nextTravelNode.nextNode1;
				}
			}
		}


		if (DialogueWindow.isActiveAndEnabled) {
			gameStatus = GameStatus.WorldMapDialogue;
		}
		else if (WorldWindow.isActiveAndEnabled) {
			gameStatus = GameStatus.WorldMap;
		}
		else if (InGameWindow.isActiveAndEnabled) {
			gameStatus = GameStatus.InGame;
		}
		else{
			gameStatus = GameStatus.Menu;
		}
	}

	IEnumerator Travel(AbstractGameNode nextNode){
		isTravelling = true;
		Vector3 CurrentToDest = worldPlayer.transform.position - nextNode.transform.position;
		while (	(worldPlayer.transform.position - nextNode.transform.position).magnitude > 1 ) {
			CurrentToDest = worldPlayer.transform.position - nextNode.transform.position;
			worldPlayer.transform.position += -CurrentToDest.normalized * Time.deltaTime * speed;
			yield return null;
		}
		worldPlayer.transform.position = nextNode.transform.position;
		isTravelling = false;
		currentAbstractNode = nextNode;
	}

	IEnumerator executeLevel(GameNode currentGameNode){
		if (currentGameNode.nodeStatus == NodeStatus.Locked) {
			//Do the startDialogue if there is one
			if (currentGameNode.dialogueStartLevelName != "") {
				currentGameNode.DialogueStartSequence ();
				while (DiaMasterManager.currentDialogue != "none") {
					yield return null;
				}
			}

			//Do the level if there is one
			string end = "";
			if (currentGameNode.levelNumber != -1) {
				currentGameNode.LevelSequence ();
				while (LevelManager.isDoingLevel) {
					if (levelManager.currentLevel.endDirection != "") {
						end = levelManager.currentLevel.endDirection;
					}
					yield return null;
				}
			}

			//Do the endDialogue if there is one
			if (currentGameNode.dialogueEndLevelName != "") {
				currentGameNode.DialogueEndSequence ();
				while (DiaMasterManager.currentDialogue != "none") {
					yield return null;
				}
			}

			currentGameNode.UnlockNode ();

			//better to fork once the node is unlocked
			if (currentGameNode.hasFork && end != "") {
				currentGameNode.ForkSequence (end);
			}
		}
		else if (currentGameNode.nodeStatus == NodeStatus.Unlocked) {
			if (currentGameNode.additionalDialogues.Length > 0) {
				currentGameNode.DialogueAdditionalSequence();
				while (DiaMasterManager.currentDialogue != "none") {
					yield return null;
				}
			}
		}
		isDoingCurrentNode = false;
	}
}