using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStatus{Menu, WorldMap, WorldMapDialogue, InGame};

public class ManagerManager : MonoBehaviour {

	private GameStatus gameStatus;
	public GameStatus M_GameStatus{ get { return gameStatus; } }

	[SerializeField] private GenericWindow InGameWindow;
	[SerializeField] private GenericWindow WorldWindow;
	[SerializeField] private GenericWindow DialogueWindow;
	[SerializeField] private AudioManager AudioManager;

	public void SetGameStatus(GameStatus newGameStatus){
		gameStatus = newGameStatus;
	}

	void Update () {
		GetGameStatus ();
	}

	void GetGameStatus(){
		if (DialogueWindow.isActiveAndEnabled) {
			gameStatus = GameStatus.WorldMapDialogue;
		}
		else if (WorldWindow.isActiveAndEnabled) {
			gameStatus = GameStatus.WorldMap;
		}
		else if (InGameWindow.isActiveAndEnabled) {
			gameStatus = GameStatus.InGame;
		}
		else{
			gameStatus = GameStatus.Menu;
		}
	}
}
