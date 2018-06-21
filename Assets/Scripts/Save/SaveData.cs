﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;

[System.Serializable]
public class SaveData : ISerializable {
	public int[] nodeStatus;
	public int currentNode;
	public int currentMap;

	public SaveData(){
	}

	public SaveData(SerializationInfo info, StreamingContext ctxt){
		nodeStatus  = (int[])info.GetValue ("nodeStatus",  typeof(int[]));
		currentMap  = (int)info.GetValue   ("currentMap",  typeof(int));
		currentNode = (int)info.GetValue   ("currentNode", typeof(int));
	}

	public void GetObjectData(SerializationInfo info, StreamingContext ctxt){
		info.AddValue ("nodeStatus",  nodeStatus);
		info.AddValue ("currentMap",  currentMap);
		info.AddValue ("currentNode", currentNode);
	}
}
