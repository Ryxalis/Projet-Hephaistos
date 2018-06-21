using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour {

	[SerializeField] private WorldGameObject worldGO;
	[SerializeField] private ProfileWindow profileWindow;
	[SerializeField] private WorldManager worldManager;

	private SaveData data;

	void Update(){
		if(Input.GetKeyDown(KeyCode.G))
			Save ();
	}

	public void Load(){
		string path = "Save_" + profileWindow.ProfileNumber.ToString () + ".game";
		if (File.Exists (path)) {
			data = new SaveData ();
			LoadFromFile (path);
			SetData ();
		}
	}

	public void LoadCurrentMap(){
		string path = "Player_" + profileWindow.ProfileNumber.ToString ();
		if (Directory.Exists(path) && File.Exists(path + "\\Save_" + profileWindow.ProfileNumber.ToString () + ".game")) {
			data = new SaveData ();
			LoadFromFile (path);
			SetData ();
		}
	}

	public void Save(){
		data = new SaveData ();
		CollectData ();
		SaveInFile ();
	}

	public void SaveCurrentMap(){
		data = new SaveData ();
		CollectMapData ();
		SaveMapInFile ();
	}

	void CollectMapData(){
		AbstractGameNode[] gameNodes = worldGO.CurrentMap.GetComponentsInChildren<AbstractGameNode> ();
		data.nodeStatus = new int[gameNodes.Length];
		for(int i = 0; i<data.nodeStatus.Length; ++i){
			data.nodeStatus[i] = (int)gameNodes[i].NodeStatus;
		}
	}


	void CollectData (){
		AbstractGameNode[] gameNodes = 	worldGO.GetComponentsInChildren<AbstractGameNode> ();
		data.nodeStatus = new int[gameNodes.Length];
		for(int i = 0; i<data.nodeStatus.Length; ++i){
			data.nodeStatus[i] = (int)gameNodes[i].NodeStatus;
			if (gameNodes[i] == worldManager.currentAbstractNode) {
				data.currentNode = i;
			}
		}
		for(int i = 0; i<worldGO.Maps.Length; ++i){
			if (worldGO.CurrentMap == worldGO.Maps[i]) {
				data.currentMap = i;
			}
		}
	}

	void SetData(){
		AbstractGameNode[] gameNodes = 	worldGO.GetComponentsInChildren<AbstractGameNode> ();
		worldManager.currentAbstractNode = gameNodes[data.currentNode];
		for (int i = 0; i < data.nodeStatus.Length; ++i) {
			gameNodes[i].SetNodeStatus((NodeStatus)data.nodeStatus[i]);
			gameNodes [i].Boot ();
		}
		worldGO.ChangeMap (worldGO.Maps[data.currentMap]);
		worldManager.Boot ();
	}

	void SaveInFile(){
		Stream stream = File.Open ("Save_" + profileWindow.ProfileNumber.ToString() + ".game", FileMode.Create);
		BinaryFormatter bformatter = new BinaryFormatter ();
		bformatter.Binder = new VersionDeserializationBinder ();
		Debug.Log ("Game Saved");
		bformatter.Serialize (stream, data);
		stream.Close ();
	}

	void SaveMapInFile(){
		Debug.Log ("Map Saved");
		string path = "Player_" + profileWindow.ProfileNumber.ToString ();
		if(!Directory.Exists(path)){
			Directory.CreateDirectory (path);
		}
		Stream stream = File.Open (path + "\\Save_" + worldGO.CurrentMap.name + ".game", FileMode.Create);
		BinaryFormatter bformatter = new BinaryFormatter ();
		bformatter.Binder = new VersionDeserializationBinder ();
		bformatter.Serialize (stream, data);
		stream.Close ();
	}

	void LoadFromFile(string path){
		Stream stream = File.Open (path, FileMode.Open);
		BinaryFormatter bformatter = new BinaryFormatter ();
		bformatter.Binder = new VersionDeserializationBinder (); 
		Debug.Log ("Game Loaded");
		data = (SaveData)bformatter.Deserialize (stream);
		stream.Close ();
	}

	void LoadMapFromFile(string path){
		Stream stream = File.Open (path + "\\Save_" + profileWindow.ProfileNumber.ToString () + ".game", FileMode.Open);
		BinaryFormatter bformatter = new BinaryFormatter ();
		bformatter.Binder = new VersionDeserializationBinder (); 
		Debug.Log ("Game Loaded");
		data = (SaveData)bformatter.Deserialize (stream);
		stream.Close ();
	}
}
