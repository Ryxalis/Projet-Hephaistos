using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeStatus {Locked, Unlocked, Dead}

public class AbstractGameNode : MonoBehaviour {

	public NodeStatus nodeStatus = NodeStatus.Locked;
	public bool isTravelNode = false;

	public virtual void Boot(){}

	public virtual void KillNode(){}
	public virtual void UnlockNode(){}
}
