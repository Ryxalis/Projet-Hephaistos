using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameNodeExit : AbstractGameNode {

	[SerializeField] private GameNodeEnter nextNode;
	public GameNodeEnter NextNode {get { return nextNode; } }

	void Awake(){
		nodeType = NodeType.Exit;
	}

}
