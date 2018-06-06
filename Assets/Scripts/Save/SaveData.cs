using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;

[System.Serializable]
public class SaveData : ISerializable {
	public int[] nodeStatus = {0, 1};
	public int currentNode = 42;
	public int profileNumber = -1;

	public SaveData(){
	}

	public SaveData(SerializationInfo info, StreamingContext ctxt){
		for (int i = 0; i < nodeStatus.Length; ++i) {
			nodeStatus[i] = (int)info.GetValue ("nodeStatus_" + i.ToString(), typeof(int));
		}
		currentNode = (int)info.GetValue ("currentNode", typeof(int));
		profileNumber = (int)info.GetValue ("profileNumber", typeof(int));
	}

	public void GetObjectData(SerializationInfo info, StreamingContext ctxt){
		for (int i = 0; i < nodeStatus.Length; ++i) {
			info.AddValue ("nodeStatus_" + i.ToString(), nodeStatus[i]);
		}
		info.AddValue ("currentNode", currentNode);
		info.AddValue ("profileNumber", profileNumber);
	}
}
