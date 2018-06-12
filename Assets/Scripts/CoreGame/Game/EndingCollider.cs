using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCollider : MonoBehaviour {

	[SerializeField] private string endingDirection = "";
	private bool isTriggered;

	public bool IsTriggered { get { return isTriggered; } }
	public string EndingDirection { get { return endingDirection; } }

	public void Boot(){
		isTriggered = false;
	}

	void OnTriggerEnter2D (Collider2D coll){
		if (coll.attachedRigidbody.name == "Player") {
			isTriggered = true;
		}
	}
}
