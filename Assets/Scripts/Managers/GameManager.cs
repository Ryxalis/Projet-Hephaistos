﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject game;
	public GameObject[] levels;

	private bool isPaused;
	public bool get_isPaused(){ return isPaused; }
	private bool gameStarted;
	public bool get_gameStarted(){ return gameStarted; }
	private TimeManager timeManager;

	void Awake() {
		timeManager = GameObject.Find ("TimeManager").GetComponent<TimeManager> ();
		foreach (var level in levels) {
			level.SetActive (false);
		}
		gameStarted = false;
		isPaused = false;
		game.SetActive (false);
	}

	void Update () {
		
	}

	public void StartGame(){
		gameStarted = true;
		game.SetActive (true);
	}

	public void StartGame(int level){
		gameStarted = true;
		game.SetActive (true);
		levels [level].SetActive (true);
	}

	public void StartDialogue(string dialogueName){

	}

	public void TogglePause(bool toggle){
		if (toggle && Time.timeScale == 1)
			timeManager.ManipulateTime (0, 5.0f);
		else if (!toggle && Time.timeScale == 0)
			timeManager.ManipulateTime (1, 2.0f);
	}
}