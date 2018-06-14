using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour {

	public GameObject worldMap;
	public ProfileWindow profileWindow;
	public WorldManager worldManager;

	private SaveData data;

	void Update(){
		if(Input.GetKeyDown(KeyCode.G))
			Save ();
	}

	public void Load(){
		if (File.Exists ("Save_" + profileWindow.ProfileNumber.ToString () + ".game")) {
			data = new SaveData ();
			LoadFromFile ();
			SetData ();
		}
	}

	public void Save(){
		data = new SaveData ();
		CollectData ();
		SaveInFile ();
	}


	void CollectData (){
		AbstractGameNode[] gameNodes = 	worldMap.GetComponentsInChildren<AbstractGameNode> ();
		data.nodeStatus = new int[gameNodes.Length];
		for(int i = 0; i<data.nodeStatus.Length; ++i){
			data.nodeStatus[i] = (int)gameNodes[i].NodeStatus;
			if (gameNodes[i] == worldManager.currentAbstractNode) {
				data.currentNode = i;
			}
		}
	}

	void SetData(){
		AbstractGameNode[] gameNodes = 	worldMap.GetComponentsInChildren<AbstractGameNode> ();
		worldManager.currentAbstractNode = gameNodes[data.currentNode];
		for (int i = 0; i < data.nodeStatus.Length; ++i) {
			gameNodes[i].SetNodeStatus((NodeStatus)data.nodeStatus[i]);
			gameNodes [i].Boot ();
		}
		worldManager.Boot ();
	}

	void SaveInFile(){
		Stream stream = File.Open ("Save_" + profileWindow.ProfileNumber.ToString() + ".game", FileMode.Create);
		BinaryFormatter bformatter = new BinaryFormatter ();
		bformatter.Binder = new VersionDeserializationBinder ();
		Debug.Log ("Saving...");
		bformatter.Serialize (stream, data);
		stream.Close ();
	}

	void LoadFromFile(){
		Stream stream = File.Open ("Save_" + profileWindow.ProfileNumber.ToString () + ".game", FileMode.Open);
		BinaryFormatter bformatter = new BinaryFormatter ();
		bformatter.Binder = new VersionDeserializationBinder (); 
		Debug.Log ("Loading...");
		data = (SaveData)bformatter.Deserialize (stream);
		stream.Close ();
	}
}
