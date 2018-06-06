using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour {

	public GameObject worldMap;

	private int profileNumber = -1;
	private int currentNode = -1;
	private int[] nodeStatus;

	public void SetProfilNumber(int newProfilNumber){
		profileNumber = newProfilNumber;
	}

	void Start(){
		//Save ();
		Load();
	}

	/*public void Save(){
		AbstractGameNode[] gameNodes = 	worldMap.GetComponentsInChildren<AbstractGameNode> ();
		nodeStatus = new int[gameNodes.Length];
		for(int i = 0; i<gameNodes.Length; ++i){
			nodeStatus[i] = (int)gameNodes[i].nodeStatus;
		}
	}*/


	public void Save(){
		SaveData data = new SaveData ();
		Stream stream = File.Open ("Save.game", FileMode.Create);
		BinaryFormatter bformatter = new BinaryFormatter ();
		bformatter.Binder = new VersionDeserializationBinder ();
		Debug.Log ("Writing information");
		bformatter.Serialize (stream, data);
		stream.Close ();
	}

	public void Load(){
		SaveData data = new SaveData ();
		Stream stream = File.Open("Save.game", FileMode.Open);
		BinaryFormatter bformatter = new BinaryFormatter();
		bformatter.Binder = new VersionDeserializationBinder(); 
		Debug.Log ("Reading Data");
		data = (SaveData)bformatter.Deserialize(stream);
		stream.Close();

		currentNode = data.currentNode;
		profileNumber = data.profileNumber;
		for (int i = 0; i < data.nodeStatus.Length; ++i) {
			nodeStatus [i] = data.nodeStatus [i];
		}
	}
}
