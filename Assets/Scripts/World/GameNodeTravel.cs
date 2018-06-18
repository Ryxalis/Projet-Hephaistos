using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameNodeTravel : AbstractGameNode {

	[SerializeField] private AbstractGameNode nextNode1;
	[SerializeField] private AbstractGameNode nextNode2;
	[SerializeField] private AbstractGameNode nextNode;

	public AbstractGameNode NextNode { get { return nextNode; } }

	public override void Boot (){
		
	}

	public override void KillNode(){
		if (nodeStatus == NodeStatus.Locked) {
			nodeStatus = NodeStatus.Dead;
		}
		if (nextNode1.NodeStatus == NodeStatus.Locked) {
			nextNode1.KillNode ();
		}
		if (nextNode2.NodeStatus == NodeStatus.Locked) {
			nextNode2.KillNode();
		}
	}

	public override void UnlockNode(){
		nodeStatus = NodeStatus.Unlocked;
	}

	void Awake(){
		isTravelNode = true;
	}

	public void SetTravellingPath(AbstractGameNode currentAbstractNode){
		if (currentAbstractNode == nextNode1) {
			nextNode = nextNode2;
		}
		if (currentAbstractNode == nextNode2) {
			nextNode = nextNode1;
		}
	}
}
