using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	static public bool levelFinished;

	public GameObject[] levels;

	private DiaMasterManager diaMasterManager;
	private bool isPaused;
	public bool get_isPaused(){ return isPaused; }
	private TimeManager timeManager;

	void Awake() {
		timeManager = GameObject.Find ("TimeManager").GetComponent<TimeManager> ();
		foreach (var level in levels) {
			level.SetActive (false);
		}
		levelFinished = true;
		isPaused = false;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.K)) {  // temporary condition
			levelFinished = true;
		}
	}

	/*public void StartGame(){
		gameStarted = true;
		game.SetActive (true);
	}*/

	public void StartLevel(int level){
		levelFinished = false;
		//game.SetActive (true);
		print(level);
		levels [level].SetActive (true);
	}

	/*public void StartDialogue(string dialogueName){
		if (DiaMasterManager.currentDialogue == "none") {
			dialoguePanel.SetActive (true);
			diaMasterManager.StartDialogue (dialogueName);
		}
	}*/

	public void TogglePause(bool toggle){
		if (toggle && Time.timeScale == 1)
			timeManager.ManipulateTime (0, 5.0f);
		else if (!toggle && Time.timeScale == 0)
			timeManager.ManipulateTime (1, 2.0f);
	}
}
