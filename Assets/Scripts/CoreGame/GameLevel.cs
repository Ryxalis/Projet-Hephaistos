using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel : MonoBehaviour {

	private GameObject level;
	public bool hasBeenCompleted = false;
	public bool isActive = false;

	void Awake() {
		level = GetComponentInChildren<Transform> ().gameObject;
	}

	public void StartLevel(){
		level.SetActive (true);
		isActive = true;
	}

	void Update() {
		
	}

	public void Finish(){
		level.SetActive (false);
		isActive = false;
	}
}
