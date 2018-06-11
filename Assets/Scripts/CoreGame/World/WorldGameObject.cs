using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGameObject : MonoBehaviour {

	private GameObject worldGO;
	private WorldPlayer worldPlayer;

	public GameObject[] maps;
	public GameObject currentMap;

	void Awake(){
		worldPlayer = GetComponentInChildren<WorldPlayer> ();
		worldGO = GetComponentInChildren<Transform> ().gameObject;
		worldGO.SetActive (false);
		foreach (GameObject map in maps) {
			map.SetActive (false);
		}
		ChangeMap (currentMap, worldPlayer.transform.position);
	}

	public void Boot(){
		worldGO.SetActive (true);
	}

	public void Close(){
		worldGO.SetActive (false);
	}

	public void ChangeMap(GameObject newMap, Vector3 newPlayerPosition){
		currentMap.SetActive (false);
		newMap.SetActive (true);
		currentMap = newMap;
		worldPlayer.transform.position = new Vector3 (newPlayerPosition.x, newPlayerPosition.y, worldPlayer.transform.position.z);
	}
}