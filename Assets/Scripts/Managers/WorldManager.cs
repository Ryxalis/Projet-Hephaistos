using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour {

	[SerializeField] private ManagerManager MM;
	[SerializeField] private WorldGameObject worldGameObject;
	private bool isTravelling = false;
	private bool isDoingCurrentNode = false;
	private float speed = 10f;

	public LevelManager levelManager;
	public DialogueManager dialogueManager;
	public AbstractGameNode currentAbstractNode;
	public WorldPlayer worldPlayer;
	public SaveManager saveManager;

	void Awake(){
		Boot ();
	}

	public void Boot() {
		worldPlayer.gameObject.transform.position = currentAbstractNode.transform.position;
		speed = worldPlayer.speed;
	}

	void Update () {
		AbstractGameNode nextAbstractNode = currentAbstractNode;
		if (MM.M_GameStatus == GameStatus.WorldMap && !isTravelling) {
			if (currentAbstractNode.NodeType == NodeType.Normal) {
				GameNode currentGameNode = (GameNode)currentAbstractNode;
				if (!isTravelling && !isDoingCurrentNode) {
					if (Input.GetAxis ("Vertical") > 0 && currentGameNode.nodeUp && currentGameNode.nodeUp.NodeStatus != NodeStatus.Dead) {
						if (currentGameNode.nodeUp.NodeStatus == NodeStatus.Unlocked || currentGameNode.NodeStatus == NodeStatus.Unlocked) {
							nextAbstractNode = currentGameNode.nodeUp;
						}
					}
					if (Input.GetAxis ("Vertical") < 0 && currentGameNode.nodeDown && currentGameNode.nodeDown.NodeStatus != NodeStatus.Dead) {
						if (currentGameNode.nodeDown.NodeStatus == NodeStatus.Unlocked || currentGameNode.NodeStatus == NodeStatus.Unlocked) {
							nextAbstractNode = currentGameNode.nodeDown;
						}
					}
					if (Input.GetAxis ("Horizontal") < 0 && currentGameNode.nodeLeft && currentGameNode.nodeLeft.NodeStatus != NodeStatus.Dead) {
						if (currentGameNode.nodeLeft.NodeStatus == NodeStatus.Unlocked || currentGameNode.NodeStatus == NodeStatus.Unlocked) {
							nextAbstractNode = currentGameNode.nodeLeft;
						}
					}
					if (Input.GetAxis ("Horizontal") > 0 && currentGameNode.nodeRight && currentGameNode.nodeRight.NodeStatus != NodeStatus.Dead) {
						if (currentGameNode.nodeRight.NodeStatus == NodeStatus.Unlocked || currentGameNode.NodeStatus == NodeStatus.Unlocked) {
							nextAbstractNode = currentGameNode.nodeRight;
						}
					}
					if (Input.GetKeyDown (KeyCode.Space)) {
						isDoingCurrentNode = true;
						StartCoroutine (executeLevel (currentGameNode));
					}
				}
			} else if (currentAbstractNode.NodeType == NodeType.Travel) {
				GameNodeTravel currentTravelNode = (GameNodeTravel)currentAbstractNode;
				nextAbstractNode = currentTravelNode.NextNode;
				currentAbstractNode.UnlockNode ();
			} else if (currentAbstractNode.NodeType == NodeType.Enter) {
				GameNodeEnter currentEnterNode = (GameNodeEnter)currentAbstractNode;
				nextAbstractNode = currentEnterNode.NextNode;
				currentAbstractNode.UnlockNode ();
			} else if (currentAbstractNode.NodeType == NodeType.Exit) {
				GameNodeExit currentExitNode = (GameNodeExit)currentAbstractNode;
				worldGameObject.ChangeMap (currentExitNode.NextMap);
				worldGameObject.ChangePosition (currentExitNode.NextNode.transform.position);

				currentAbstractNode = currentExitNode.NextNode;
				nextAbstractNode =    currentExitNode.NextNode;
				//tricky things to do
			} 
		}


		if(currentAbstractNode != nextAbstractNode){
			StartCoroutine( Travel (nextAbstractNode ) );

			if (nextAbstractNode.NodeType == NodeType.Travel) {
				GameNodeTravel nextTravelNode = (GameNodeTravel)nextAbstractNode;
				nextTravelNode.SetTravellingPath (currentAbstractNode);
			}
		}

	}

	IEnumerator Travel(AbstractGameNode nextNode){
		isTravelling = true;
		Vector3 CurrentToDest = worldPlayer.transform.position - nextNode.transform.position;
		while (	(worldPlayer.transform.position - nextNode.transform.position).magnitude >  Time.deltaTime * speed) {
			CurrentToDest = worldPlayer.transform.position - nextNode.transform.position;
			worldPlayer.transform.position += -CurrentToDest.normalized * Time.deltaTime * speed;
			yield return null;
		}
		worldPlayer.transform.position = nextNode.transform.position;
		isTravelling = false;
		currentAbstractNode = nextNode;
	}

	IEnumerator executeLevel(GameNode currentGameNode){
		if (currentGameNode.NodeStatus == NodeStatus.Locked) {
			//Do the startDialogue if there is one
			if (currentGameNode.DialogueStartLevelName != "") {
				currentGameNode.DialogueStartSequence ();
				while (dialogueManager.CurrentDialogue != "none") {
					yield return null;
				}
			}

			//Do the level if there is one
			string end = "";
			if (currentGameNode.LevelNumber > -1) {
				currentGameNode.LevelSequence ();
				while (levelManager.IsDoingLevel) {
					if (levelManager.GetEndDirection != "") {
						end = levelManager.GetEndDirection;
					}
					yield return null;
				}
			}

			//Do the endDialogue if there is one
			if (currentGameNode.DialogueEndLevelName != "") {
				currentGameNode.DialogueEndSequence ();
				while (dialogueManager.CurrentDialogue != "none") {
					yield return null;
				}
			}

			currentGameNode.UnlockNode ();

			//better to fork once the node is unlocked
			if (currentGameNode.HasFork && end != "") {
				currentGameNode.ForkSequence (end);
			}
		}
		else if (currentGameNode.NodeStatus == NodeStatus.Unlocked) {
			if (currentGameNode.AdditionalDialoguesLength > 0) {
				currentGameNode.DialogueAdditionalSequence();
				while (dialogueManager.CurrentDialogue != "none") {
					yield return null;
				}
			}
		}
		isDoingCurrentNode = false;
		saveManager.Save ();
	}
}