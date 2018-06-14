using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeStatus {Locked, Unlocked, Dead}

public class AbstractGameNode : MonoBehaviour {

	protected NodeStatus nodeStatus = NodeStatus.Locked;
	protected bool isTravelNode = false;
	public NodeStatus NodeStatus { get { return nodeStatus; } }
	public bool IsTravelNode { get { return isTravelNode; } }

	public void SetNodeStatus(NodeStatus newStatus){
		nodeStatus = newStatus;
	}

	public virtual void Boot(){}
	public virtual void KillNode(){}
	public virtual void UnlockNode(){}
}
