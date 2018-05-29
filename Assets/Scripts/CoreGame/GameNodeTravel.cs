using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameNodeTravel : AbstractGameNode {

	public AbstractGameNode nextNode1;
	public AbstractGameNode nextNode2;
	public AbstractGameNode nextNode;

	public override void KillNode(){
		print ("KILL");
		if (nodeStatus == NodeStatus.Locked) {
			nodeStatus = NodeStatus.Dead;
		}
		if (nextNode1.nodeStatus == NodeStatus.Locked) {
			nextNode1.KillNode ();
		}
		if (nextNode2.nodeStatus == NodeStatus.Locked) {
			nextNode2.KillNode();
		}
	}

	public override void UnlockNode(){
		nodeStatus = NodeStatus.Unlocked;
	}

	void Awake(){
		isTravelNode = true;
	}
}
