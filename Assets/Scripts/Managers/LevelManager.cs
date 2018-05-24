using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	static public bool isDoingLevel;

	public GameLevel[] levels;
	public GameLevel currentLevel;
	public GameObject player;

	private DiaMasterManager diaMasterManager;
	private bool isPaused;
	public bool get_isPaused(){ return isPaused; }
	private TimeManager timeManager;

	void Awake() {
		currentLevel = null;
		levels = GetComponentsInChildren<GameLevel> ();
		timeManager = GameObject.Find ("TimeManager").GetComponent<TimeManager> ();	
		isPaused = false;
	}

	void Update () {
		if(!currentLevel.isActive){
			isDoingLevel= false;
			currentLevel = null;
		}
	}

	public void StartLevel(int level){
		isDoingLevel = true;
		currentLevel = levels [level];
		currentLevel.StartLevel();
	}

	public void TogglePause(bool toggle){
		if (toggle && Time.timeScale == 1)
			timeManager.ManipulateTime (0, 5.0f);
		else if (!toggle && Time.timeScale == 0)
			timeManager.ManipulateTime (1, 2.0f);
	}
}
