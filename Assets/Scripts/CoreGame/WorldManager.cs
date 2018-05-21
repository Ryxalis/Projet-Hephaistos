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
	public float speed = 10f;

	void Awake() {
		gameStatus = GameStatus.Menu;
		worldPlayer.transform.position = currentGameNode.transform.position;
		//worldWindow = GetComponentInParent<WorldWindow> ();
	}

	void Update () {
		if (!isTravelling && !isDoingCurrentNode) {
			if (Input.GetAxis ("Vertical") > 0 && currentGameNode.nodeUp) {
				if (currentGameNode.nodeUp.nodeStatus == NodeStatus.Unlocked || currentGameNode.nodeStatus == NodeStatus.Unlocked) {
					currentGameNode = currentGameNode.nodeUp;
					currentGameNode.SetCurrent ();
					StartCoroutine (Travel ());
				}
			}
			if (Input.GetAxis ("Vertical") < 0 && currentGameNode.nodeDown) {
				if (currentGameNode.nodeDown.nodeStatus == NodeStatus.Unlocked || currentGameNode.nodeStatus == NodeStatus.Unlocked) {
					currentGameNode = currentGameNode.nodeDown;
					currentGameNode.SetCurrent ();
					StartCoroutine (Travel ());
				}
			}
			if (Input.GetAxis ("Horizontal") > 0 && currentGameNode.nodeRight) {
				if (currentGameNode.nodeRight.nodeStatus == NodeStatus.Unlocked || currentGameNode.nodeStatus == NodeStatus.Unlocked) {
					currentGameNode = currentGameNode.nodeRight;
					currentGameNode.SetCurrent ();
					StartCoroutine (Travel ());
				}
			}
			if (Input.GetAxis ("Horizontal") < 0 && currentGameNode.nodeLeft) {
				if (currentGameNode.nodeLeft.nodeStatus == NodeStatus.Unlocked || currentGameNode.nodeStatus == NodeStatus.Unlocked) {
					currentGameNode = currentGameNode.nodeLeft;
					currentGameNode.SetCurrent ();
					StartCoroutine (Travel ());
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
		Vector3 CurrentToDest = worldPlayer.transform.position - currentGameNode.transform.position;
		while (	(worldPlayer.transform.position - currentGameNode.transform.position).magnitude > 1 ) {
			CurrentToDest = worldPlayer.transform.position - currentGameNode.transform.position;
			worldPlayer.transform.position += -CurrentToDest.normalized * Time.deltaTime * speed;
			yield return null;
		}
		worldPlayer.transform.position = currentGameNode.transform.position;
		print ("END OF TRAVEL");
		isTravelling = false;
	}

	IEnumerator executeLevel(){
		if (currentGameNode.hasDialogueStartLevel && currentGameNode.dialogueStartLevelName != "") {
			print ("Dialogue");
			currentGameNode.DialogueStartSequence ();
			while (DiaMasterManager.currentDialogue != "none") {
				yield return null;
			}
		}

		if (currentGameNode.hasLevel && currentGameNode.levelNumber != -1) {
			currentGameNode.LevelSequence();
			print ("InGame");
			while (LevelManager.isDoingLevel) {
				yield return null;
			}
		}
		currentGameNode.UnlockNode ();
		isDoingCurrentNode = false;
	}
}
