using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour {

	public GameObject worldMap;

	private int profilNumber = -1;
	private int[] nodeStatus;

	public void SetProfilNumber(int newProfilNumber){
		profilNumber = newProfilNumber;
	}

	void Start(){
		//Save ();
	}

	public void Save(){
		AbstractGameNode[] gameNodes = 	worldMap.GetComponentsInChildren<AbstractGameNode> ();
		nodeStatus = new int[gameNodes.Length];
		for(int i = 0; i<gameNodes.Length; ++i){
			nodeStatus[i] = (int)gameNodes[i].nodeStatus;
		}
	}

	public void Load(){

	}
}
