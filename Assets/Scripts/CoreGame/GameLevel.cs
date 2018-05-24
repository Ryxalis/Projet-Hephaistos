using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel : MonoBehaviour {

	private GameObject level;
	public bool hasBeenCompleted = false;
	public bool isActive = false;

	public GameObject endUp;
	public GameObject endDown;
	public GameObject endLeft;
	public GameObject endRight;

	public string endDirection = "";

	void Awake() {
		level = GetComponentInChildren<Transform> ().gameObject;
	}

	public void StartLevel(){
		level.SetActive (true);
		isActive = true;
	}

	void Update() {
		CheckEndUp ();
		CheckEndDown ();
		CheckEndLeft ();
		CheckEndRight ();
	}

	public void CheckEndUp(){
		//we should do a contition more like if player collides with endUp
		if (Input.GetKeyDown (KeyCode.K)) {
			endDirection = "Up";
			Finish ();
		}
	}
	public void CheckEndDown(){
		if (Input.GetKeyDown (KeyCode.L)) {
			endDirection = "Down";
			Finish ();
		}
	}
	public void CheckEndLeft(){
		if (Input.GetKeyDown (KeyCode.M)) {
			endDirection = "Left";
			Finish ();
		}
	}
	public void CheckEndRight(){
		if (Input.GetKeyDown (KeyCode.L)) {
			endDirection = "Right";
			Finish ();
		}
	}

	public void Finish(){
		level.SetActive (false);
		isActive = false;
	}
}
