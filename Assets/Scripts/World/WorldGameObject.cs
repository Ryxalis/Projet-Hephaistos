﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGameObject : MonoBehaviour {

	[SerializeField] private SaveManager saveManager;

	[SerializeField] private GameObject worldGOChild;
	[SerializeField] private WorldPlayer worldPlayer;

	[SerializeField] private GameObject[] maps;
	[SerializeField] private GameObject currentMap;
	public GameObject CurrentMap { get { return currentMap; } }
	public GameObject[] Maps { get { return maps; } }

	public void Boot(){
		foreach (GameObject map in maps) {
			map.SetActive (false);
		}
		worldGOChild.SetActive (true);
		ChangeMap (currentMap);
		ChangePosition (worldPlayer.transform.position);
	}

	public void Close(){
		worldGOChild.SetActive (false);
	}

	public void ChangeMap(GameObject newMap){
		if (currentMap != newMap) {
			saveManager.SaveCurrentMap ();
		}
		currentMap.SetActive (false);
		newMap.SetActive (true);
		currentMap = newMap;
		saveManager.LoadCurrentMap ();
	}

	public void ChangePosition(Vector3 newPlayerPosition){
		worldPlayer.transform.position = new Vector3 (newPlayerPosition.x, newPlayerPosition.y, worldPlayer.transform.position.z);
	}
}