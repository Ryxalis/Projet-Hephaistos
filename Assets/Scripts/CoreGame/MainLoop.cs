using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStatus{Menu, WorldMap, WorldMapDialogue, Level};

public class MainLoop : MonoBehaviour {

	private GameStatus gameStatus;

	public GameNode currentGameNode;
	public GameManager gameManager;

	void Awake() {
		gameStatus = GameStatus.Menu;

	}

	void Update () {

		if(Input.GetAxis("Vertical") > 0 && currentGameNode.nodeUp && !currentGameNode.nodeUp.isLocked){
			print ("Go up");
			currentGameNode = currentGameNode.nodeUp;
		}
		if(Input.GetAxis("Vertical") < 0 && currentGameNode.nodeDown && !currentGameNode.nodeDown.isLocked){
			print ("Go down");
			currentGameNode = currentGameNode.nodeDown;
		}
		if(Input.GetAxis("Horizontal") > 0 && currentGameNode.nodeRight && !currentGameNode.nodeRight.isLocked){
			print ("Go right");
			currentGameNode = currentGameNode.nodeRight;
		}
		if(Input.GetAxis("Horizontal") < 0 && currentGameNode.nodeLeft && !currentGameNode.nodeLeft.isLocked){
			print ("Go left");
			currentGameNode = currentGameNode.nodeLeft;
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			currentGameNode.LevelSequence ();
		}
		if (!currentGameNode.hasDoneDialogue) {
			currentGameNode.DialogueSequence ();
		}

		if (!currentGameNode.isExplored) {
			currentGameNode.isExplored = true;
		}
	}
}
