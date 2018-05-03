using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject game;
	public GameObject[] levels;

	private bool gameStarted;
	public bool get_gameStarted(){ return gameStarted; }

	void Awake() {
		foreach (var level in levels) {
			level.SetActive (false);
		}
		gameStarted = false;
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

	public void Pause(){
		print ("Pause");
	}
}
