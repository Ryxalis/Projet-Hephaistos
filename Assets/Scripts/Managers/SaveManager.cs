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
		if(Input.GetKeyDown(KeyCode.H))
			Load();
	}

	public void Load(){
		data = new SaveData ();
		LoadFromFile ();
		SetData ();
	}

	public void Save(){
		data = new SaveData ();
		CollectData ();
		SaveInFile ();
	}


	public void CollectData (){
		AbstractGameNode[] gameNodes = 	worldMap.GetComponentsInChildren<AbstractGameNode> ();
		data.profileNumber = profileWindow.profileNumber;
		data.nodeStatus = new int[gameNodes.Length];
		for(int i = 0; i<data.nodeStatus.Length; ++i){
			data.nodeStatus[i] = (int)gameNodes[i].nodeStatus;
			if (gameNodes[i] == worldManager.currentAbstractNode) {
				data.currentNode = i;
			}
		}
	}

	public void SetData(){
		AbstractGameNode[] gameNodes = 	worldMap.GetComponentsInChildren<AbstractGameNode> ();
		worldManager.currentAbstractNode = gameNodes[data.currentNode];
		profileWindow.profileNumber = data.profileNumber;
		for (int i = 0; i < data.nodeStatus.Length; ++i) {
			gameNodes[i].nodeStatus = (NodeStatus)data.nodeStatus[i];
			gameNodes [i].Boot ();
		}
		worldManager.Boot ();
	}

	public void SaveInFile(){
		Stream stream = File.Open ("Save.game", FileMode.Create);
		BinaryFormatter bformatter = new BinaryFormatter ();
		bformatter.Binder = new VersionDeserializationBinder ();
		Debug.Log ("Writing information");
		bformatter.Serialize (stream, data);
		stream.Close ();
	}

	public void LoadFromFile(){
		Stream stream = File.Open("Save.game", FileMode.Open);
		BinaryFormatter bformatter = new BinaryFormatter();
		bformatter.Binder = new VersionDeserializationBinder(); 
		Debug.Log ("Reading Data");
		data = (SaveData)bformatter.Deserialize(stream);
		stream.Close();
	}
}
