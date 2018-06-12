﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
	
	private bool isDoingLevel;
	public bool IsDoingLevel { get { return isDoingLevel; } }
	public string GetEndDirection { get { return currentLevel.EndDirection; } }

	private GameLevel[] levels;
	private GameLevel currentLevel;
	[Header("Level-related")]
	[SerializeField] private GameObject inGameObject;
	[SerializeField] private IngameWindow inGameWindow;

	private TimeManager timeManager;
	//private bool isPaused;
	//public bool get_isPaused(){ return isPaused; }

	void Awake() {
		currentLevel = null;
		levels = inGameObject.GetComponentsInChildren<GameLevel> ();
		timeManager = GameObject.Find ("TimeManager").GetComponent<TimeManager> ();	
		//isPaused = false;
	}

	void Update () {
		if(isDoingLevel && currentLevel.IsFinished){
			isDoingLevel = false;
			currentLevel.gameObject.SetActive (false);
			currentLevel = null;
			inGameWindow.BackToWorld ();
		}
	}

	public void StartLevel(int level){
		isDoingLevel = true;
		currentLevel = levels [level];
		foreach(GameLevel f_level in levels){
			f_level.gameObject.SetActive(false);
		}
		currentLevel.gameObject.SetActive(true);
		currentLevel.Boot();
	}

	public void TogglePause(bool toggle){
		if (toggle && Time.timeScale == 1)
			timeManager.ManipulateTime (0, 5.0f);
		else if (!toggle && Time.timeScale == 0)
			timeManager.ManipulateTime (1, 2.0f);
	}
}
