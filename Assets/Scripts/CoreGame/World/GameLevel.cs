using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel : MonoBehaviour {

	private GameObject level;
	public bool hasBeenCompleted = false;
	public bool isActive = false;

	public EndingCollider[] endingCollider;

	public string endDirection = "";

	void Awake() {
		level = GetComponentInChildren<Transform> ().gameObject;
	}

	public void StartLevel(){
		level.SetActive (true);
		isActive = true;
	}

	void Update() {
		CheckEnd ();
	}

	public void CheckEnd(){
		foreach (EndingCollider end in endingCollider) {
			if (end.endingDirection != "" && end.isTriggered) {
				endDirection = end.endingDirection;
				Finish ();
			}
		}
	}

	public void Finish(){
		level.SetActive (false);
		isActive = false;
	}
}
