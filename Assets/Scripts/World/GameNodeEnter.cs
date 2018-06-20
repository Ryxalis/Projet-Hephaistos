using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameNodeEnter : AbstractGameNode {

	[SerializeField] private GameNode nextNode;
	public GameNode NextNode {get { return nextNode; } }

	void Awake(){
		nodeType = NodeType.Enter;
	}

}
