using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStatus{Menu, WorldMap, WorldMapDialogue, Level};

public class MainLoop : MonoBehaviour {

	private GameStatus gameStatus;
	private bool isTravelling = false;
	private bool isDoingCurrentNode = false;

	public GameNode currentGameNode;
	//public GameManager gameManager;

	//private WorldWindow worldWindow;

	void Awake() {
		gameStatus = GameStatus.Menu;
		//worldWindow = GetComponentInParent<WorldWindow> ();
	}

	void Update () {
		if (!isTravelling && !isDoingCurrentNode) {
			if (Input.GetAxis ("Vertical") > 0 && currentGameNode.nodeUp) {
				if (currentGameNode.nodeUp.nodeStatus == NodeStatus.Unlocked || currentGameNode.nodeStatus == NodeStatus.Unlocked) {
					StartCoroutine (Travel ());
					currentGameNode = currentGameNode.nodeUp;
					currentGameNode.SetCurrent ();
				}
			}
			if (Input.GetAxis ("Vertical") < 0 && currentGameNode.nodeDown) {
				if (currentGameNode.nodeDown.nodeStatus == NodeStatus.Unlocked || currentGameNode.nodeStatus == NodeStatus.Unlocked) {
					StartCoroutine (Travel ());
					currentGameNode = currentGameNode.nodeDown;
					currentGameNode.SetCurrent ();
				}
			}
			if (Input.GetAxis ("Horizontal") > 0 && currentGameNode.nodeRight) {
				if (currentGameNode.nodeRight.nodeStatus == NodeStatus.Unlocked || currentGameNode.nodeStatus == NodeStatus.Unlocked) {
					StartCoroutine (Travel ());
					currentGameNode = currentGameNode.nodeRight;
					currentGameNode.SetCurrent ();
				}
			}
			if (Input.GetAxis ("Horizontal") < 0 && currentGameNode.nodeLeft) {
				if (currentGameNode.nodeLeft.nodeStatus == NodeStatus.Unlocked || currentGameNode.nodeStatus == NodeStatus.Unlocked) {
					StartCoroutine (Travel ());
					currentGameNode = currentGameNode.nodeLeft;
					currentGameNode.SetCurrent ();
				}
			}
			if (Input.GetKeyDown (KeyCode.Space)) {
				isDoingCurrentNode = true;
				StartCoroutine(executeLevel ());
			}
		}
	}

	IEnumerator Travel(){
		isTravelling = true;
		yield return new WaitForSeconds (1);
		print ("END OF TRAVEL");
		isTravelling = false;
	}

	IEnumerator executeLevel(){
		if (currentGameNode.hasDialogueStartLevel && currentGameNode.dialogueStartLevelName != "") {
			currentGameNode.DialogueStartSequence ();
			while (DiaMasterManager.currentDialogue != "none") {
				print ("WAIT");
				yield return null;//new WaitForSeconds (0.1f);
			}
		}

		print ("OK");
		//currentGameNode.LevelSequence ();

		currentGameNode.UnlockNode ();
		isDoingCurrentNode = false;
	}
}
