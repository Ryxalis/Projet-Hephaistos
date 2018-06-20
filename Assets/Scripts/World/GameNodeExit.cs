using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameNodeExit : AbstractGameNode {

	[SerializeField] private GameNodeEnter nextNode;
	[SerializeField] private GameObject nextMap;
	public GameNodeEnter NextNode {get { return nextNode; } }
	public GameObject NextMap {get { return nextMap; } }

	void Awake(){
		nodeType = NodeType.Exit;
	}

}
