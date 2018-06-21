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

	private bool isWorking = false;

	void Update(){
		if (Input.GetKeyDown (KeyCode.G)) {
			SaveStart ();
		}
	}

	public void LoadStart(){ StartCoroutine (Work("LoadStart")); }
	public void SaveStart(){ StartCoroutine (Work("SaveStart")); }
	public void LoadCurrentMap(){ StartCoroutine (Work("LoadCurrentMap")); }
	public void SaveCurrentMap(){ StartCoroutine (Work("SaveCurrentMap")); }


	IEnumerator Work(string function){
		while (isWorking) {
			yield return null;
		}
		isWorking = true;
		if (function == "LoadStart") {
			MLoadStart ();
		} else if (function == "SaveStart") {
			MSaveStart ();
		} else if (function == "LoadCurrentMap") {
			MLoadCurrentMap ();
		} else if (function == "SaveCurrentMap") {
			MSaveCurrentMap ();
		}
		isWorking = false;
	}

	void MLoadStart(){
		string path = "Player_" + profileWindow.ProfileNumber.ToString ();
		string file = path + "\\Save_" + profileWindow.ProfileNumber.ToString () + ".game";
		if (Directory.Exists(path) && File.Exists(file)) {
			data = new SaveData ();
			LoadFromFile (file);
			SetStartData ();
		}
	}

	void MLoadCurrentMap(){
		string path = "Player_" + profileWindow.ProfileNumber.ToString ();
		string file = path + "\\Save_" + worldGO.CurrentMap.name + ".game";
		if (Directory.Exists(path) && File.Exists(file)) {
			data = new SaveData ();
			LoadFromFile (file);
			SetMapData ();
		}
	}

	void MSaveStart(){
		string path = "Player_" + profileWindow.ProfileNumber.ToString ();
		string file = path + "\\Save_" + profileWindow.ProfileNumber.ToString () + ".game";
		data = new SaveData ();
		CollectStartData ();
		SaveInFile (path, file);
	}

	void MSaveCurrentMap(){
		string path = "Player_" + profileWindow.ProfileNumber.ToString ();
		string file = path + "\\Save_" + worldGO.CurrentMap.name + ".game";
		data = new SaveData ();
		CollectMapData ();
		SaveInFile (path, file);
	}




	void CollectMapData(){
		AbstractGameNode[] gameNodes = worldGO.CurrentMap.GetComponentsInChildren<AbstractGameNode> ();
		data.nodeStatus = new int[gameNodes.Length];
		for(int i = 0; i<data.nodeStatus.Length; ++i){
			data.nodeStatus[i] = (int)gameNodes[i].NodeStatus;
		}
	}

	void CollectStartData (){
		AbstractGameNode[] gameNodes = 	worldGO.CurrentMap.GetComponentsInChildren<AbstractGameNode> ();
		for(int i = 0; i<gameNodes.Length; ++i){
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

	void SetStartData(){
		worldGO.ChangeMap (worldGO.Maps[data.currentMap]);
		AbstractGameNode[] gameNodes = 	worldGO.CurrentMap.GetComponentsInChildren<AbstractGameNode> ();
		worldManager.currentAbstractNode = gameNodes[data.currentNode];
		worldManager.Boot ();
	}

	void SetMapData(){
		AbstractGameNode[] gameNodes = 	worldGO.CurrentMap.GetComponentsInChildren<AbstractGameNode> ();
		for (int i = 0; i < data.nodeStatus.Length; ++i) {
			gameNodes[i].SetNodeStatus((NodeStatus)data.nodeStatus[i]);
			gameNodes [i].Boot ();
		}
	}

	void SaveInFile(string path, string file){
		if(!Directory.Exists(path)){
			Directory.CreateDirectory (path);
		}
		Stream stream = File.Open (file, FileMode.Create);
		BinaryFormatter bformatter = new BinaryFormatter ();
		bformatter.Binder = new VersionDeserializationBinder ();
		Debug.Log ("Game Saved");
		bformatter.Serialize (stream, data);
		stream.Close ();
	}

	void LoadFromFile(string file){
		Stream stream = File.Open (file, FileMode.Open);
		BinaryFormatter bformatter = new BinaryFormatter ();
		bformatter.Binder = new VersionDeserializationBinder (); 
		Debug.Log ("Game Loaded from " + file);
		data = (SaveData)bformatter.Deserialize (stream);
		stream.Close ();
	}
}
