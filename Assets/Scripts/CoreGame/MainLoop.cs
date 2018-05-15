using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStatus{Menu, WorldMap, WorldMapDialogue, Level};

public class MainLoop : MonoBehaviour {

	private GameStatus gameStatus;
	private bool isTravelling = false;

	public GameNode currentGameNode;
	//public GameManager gameManager;

	//private WorldWindow worldWindow;

	void Awake() {
		gameStatus = GameStatus.Menu;
		//worldWindow = GetComponentInParent<WorldWindow> ();
	}

	void Update () {
		if (!isTravelling) {
			if (Input.GetAxis ("Vertical") > 0 && currentGameNode.nodeUp && currentGameNode.nodeUp.nodeStatus == NodeStatus.Unlocked) {
				print ("Go up");
				StartCoroutine (Travel ());
				currentGameNode.UnlockNode();
				currentGameNode = currentGameNode.nodeUp;
				currentGameNode.SetCurrent ();
			}
			if (Input.GetAxis ("Vertical") < 0 && currentGameNode.nodeDown && currentGameNode.nodeDown.nodeStatus == NodeStatus.Unlocked) {
				print ("Go down");
				StartCoroutine (Travel ());
				currentGameNode.UnlockNode();
				currentGameNode = currentGameNode.nodeDown;
				currentGameNode.SetCurrent ();
			}
			if (Input.GetAxis ("Horizontal") > 0 && currentGameNode.nodeRight && currentGameNode.nodeRight.nodeStatus == NodeStatus.Unlocked) {
				print ("Go right");
				StartCoroutine (Travel ());
				currentGameNode.UnlockNode();
				currentGameNode = currentGameNode.nodeRight;
				currentGameNode.SetCurrent ();
			}
			if (Input.GetAxis ("Horizontal") < 0 && currentGameNode.nodeLeft && currentGameNode.nodeLeft.nodeStatus == NodeStatus.Unlocked) {
				print ("Go left");
				StartCoroutine (Travel ());
				currentGameNode.UnlockNode();
				currentGameNode = currentGameNode.nodeLeft;
				currentGameNode.SetCurrent ();
			}
			if (Input.GetKeyDown (KeyCode.Space)) {
				StartCoroutine(executeLevel ());
			}
		}
	}

	IEnumerator Travel(){
		isTravelling = true;
		yield return new WaitForSeconds (1);
		isTravelling = false;
	}

	IEnumerator executeLevel(){
		if (currentGameNode.hasDialogueStartLevel && currentGameNode.dialogueStartLevelName != "") {
			currentGameNode.DialogueStartSequence ();
			while (DiaMasterManager.currentDialogue != "none") {
				print ("WAIT");
				yield return new WaitForSeconds (0.1f);
			}
			/*while(!currentGameNode.hasDoneDialogueStartLevel){
				yield return new WaitForSeconds (1);
			}*/
		}

		print ("OK");

		//currentGameNode.LevelSequence ();


	}
}
