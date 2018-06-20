using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGameObject : MonoBehaviour {

	[SerializeField] private GameObject worldGOChild;
	[SerializeField] private WorldPlayer worldPlayer;

	[SerializeField] private GameObject[] maps;
	[SerializeField] private GameObject currentMap;
	public GameObject CurrentMap { get { return currentMap; } }

	public void Boot(){
		worldGOChild.SetActive (true);
		foreach (GameObject map in maps) {
			map.SetActive (false);
		}
		ChangeMap (	currentMap, worldPlayer.transform.position);
	}

	public void Close(){
		worldGOChild.SetActive (false);
	}

	public void ChangeMap(GameObject newMap, Vector3 newPlayerPosition){
		currentMap.SetActive (false);
		newMap.SetActive (true);
		currentMap = newMap;
		worldPlayer.transform.position = new Vector3 (newPlayerPosition.x, newPlayerPosition.y, worldPlayer.transform.position.z);
	}
}