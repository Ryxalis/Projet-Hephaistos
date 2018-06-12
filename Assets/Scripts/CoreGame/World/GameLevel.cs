using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel : MonoBehaviour {

	[SerializeField] private EndingCollider[] endingCollider;
	private GameObject level;
	private bool isFinished = false;
	private string endDirection = "";
	//public bool hasBeenCompleted = false;

	public bool IsFinished { get { return isFinished; } }
	public string EndDirection { get { return endDirection; } }

	void Awake() {
		level = GetComponentInChildren<Transform> ().gameObject;
	}

	public void Boot(){
		isFinished = false;
		foreach (EndingCollider end in endingCollider) {
			end.Boot ();
		}
	}

	void Update() {
		CheckEnd ();
	}

	public void CheckEnd(){
		foreach (EndingCollider end in endingCollider) {
			if (end.IsTriggered) {
				endDirection = end.EndingDirection;
				isFinished = true;
			}
		}
	}
}
