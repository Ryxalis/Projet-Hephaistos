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
			if (Input.GetAxis ("Vertical") > 0 && currentGameNode.nodeUp && !currentGameNode.nodeUp.isLocked) {
				print ("Go up");
				StartCoroutine (Travel ());
				currentGameNode.LeaveNode();
				currentGameNode = currentGameNode.nodeUp;
				currentGameNode.SetCurrent ();
			}
			if (Input.GetAxis ("Vertical") < 0 && currentGameNode.nodeDown && !currentGameNode.nodeDown.isLocked) {
				print ("Go down");
				StartCoroutine (Travel ());
				currentGameNode.LeaveNode();
				currentGameNode = currentGameNode.nodeDown;
				currentGameNode.SetCurrent ();
			}
			if (Input.GetAxis ("Horizontal") > 0 && currentGameNode.nodeRight && !currentGameNode.nodeRight.isLocked) {
				print ("Go right");
				StartCoroutine (Travel ());
				currentGameNode.LeaveNode ();
				currentGameNode = currentGameNode.nodeRight;
				currentGameNode.SetCurrent ();
			}
			if (Input.GetAxis ("Horizontal") < 0 && currentGameNode.nodeLeft && !currentGameNode.nodeLeft.isLocked) {
				print ("Go left");
				StartCoroutine (Travel ());
				currentGameNode.LeaveNode ();
				currentGameNode = currentGameNode.nodeLeft;
				currentGameNode.SetCurrent ();
			}
			if (Input.GetKeyDown (KeyCode.Space)) {
				currentGameNode.LevelSequence ();
			}
			if (!currentGameNode.hasDoneDialogue && Input.GetKeyDown(KeyCode.Space)) {
				currentGameNode.DialogueSequence ();

			}
		}
	}

	IEnumerator Travel(){
		isTravelling = true;
		yield return new WaitForSeconds (1);
		isTravelling = false;
	}
}
