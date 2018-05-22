using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStatus{Menu, WorldMap, WorldMapDialogue, Level};

public class WorldManager : MonoBehaviour {

	private GameStatus gameStatus;
	private bool isTravelling = false;
	private bool isDoingCurrentNode = false;

	public GameObject worldPlayer;
	public GameNode currentGameNode;
	public GameNode nextGameNode;
	public float speed = 10f;

	void Awake() {
		gameStatus = GameStatus.Menu;
		worldPlayer.transform.position = currentGameNode.transform.position;
		nextGameNode = currentGameNode;
		//worldWindow = GetComponentInParent<WorldWindow> ();
	}

	void Update () {
		if (!isTravelling && !isDoingCurrentNode) {
			if (Input.GetAxis ("Vertical") > 0 && currentGameNode.nodeUp && currentGameNode.nodeUp.nodeStatus != NodeStatus.Dead) {
				if (currentGameNode.nodeUp.nodeStatus == NodeStatus.Unlocked || currentGameNode.nodeStatus == NodeStatus.Unlocked) {
					nextGameNode = currentGameNode.nodeUp;
				}
			}
			if (Input.GetAxis ("Vertical") < 0 && currentGameNode.nodeDown && currentGameNode.nodeDown.nodeStatus != NodeStatus.Dead) {
				if (currentGameNode.nodeDown.nodeStatus == NodeStatus.Unlocked || currentGameNode.nodeStatus == NodeStatus.Unlocked) {
					nextGameNode = currentGameNode.nodeDown;
				}
			}
			if (Input.GetAxis ("Horizontal") < 0 && currentGameNode.nodeLeft && currentGameNode.nodeLeft.nodeStatus != NodeStatus.Dead) {
				if (currentGameNode.nodeLeft.nodeStatus == NodeStatus.Unlocked || currentGameNode.nodeStatus == NodeStatus.Unlocked) {
					nextGameNode = currentGameNode.nodeLeft;
				}
			}
			if (Input.GetAxis ("Horizontal") > 0 && currentGameNode.nodeRight && currentGameNode.nodeRight.nodeStatus != NodeStatus.Dead) {
				if (currentGameNode.nodeRight.nodeStatus == NodeStatus.Unlocked || currentGameNode.nodeStatus == NodeStatus.Unlocked) {
					nextGameNode = currentGameNode.nodeRight;
				}
			}
			if (Input.GetKeyDown (KeyCode.Space)) {
				isDoingCurrentNode = true;
				StartCoroutine(executeLevel ());
			}
			if (currentGameNode != nextGameNode) {
				StartCoroutine (Travel ());
				currentGameNode = nextGameNode;
			}
		}
	}

	IEnumerator Travel(){
		isTravelling = true;
		if (currentGameNode.hasFork) {
			currentGameNode.ForkSequence (nextGameNode);
		}
		Vector3 CurrentToDest = worldPlayer.transform.position - nextGameNode.transform.position;
		while (	(worldPlayer.transform.position - nextGameNode.transform.position).magnitude > 1 ) {
			CurrentToDest = worldPlayer.transform.position - nextGameNode.transform.position;
			worldPlayer.transform.position += -CurrentToDest.normalized * Time.deltaTime * speed;
			yield return null;
		}
		worldPlayer.transform.position = currentGameNode.transform.position;
		isTravelling = false;
	}

	IEnumerator executeLevel(){
		if (currentGameNode.dialogueStartLevelName != "") {
			currentGameNode.DialogueStartSequence ();
			while (DiaMasterManager.currentDialogue != "none") {
				yield return null;
			}
		}

		if (currentGameNode.levelNumber != -1) {
			currentGameNode.LevelSequence();
			while (LevelManager.isDoingLevel) {
				yield return null;
			}
		}
		currentGameNode.UnlockNode ();
		isDoingCurrentNode = false;
	}
}