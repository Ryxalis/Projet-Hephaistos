using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeStatus {Locked, Unlocked, Dead}
public enum NodeType {Normal, Travel, Exit, Enter}

public class AbstractGameNode : MonoBehaviour {

	protected NodeStatus nodeStatus = NodeStatus.Locked;
	protected NodeType nodeType = NodeType.Normal;
	public NodeStatus NodeStatus { get { return nodeStatus; } }
	public NodeType NodeType { get { return nodeType; } }

	public void SetNodeStatus(NodeStatus newStatus){
		nodeStatus = newStatus;
	}

	public virtual void Boot(){}
	public virtual void KillNode(){}
	public virtual void UnlockNode(){}
}
