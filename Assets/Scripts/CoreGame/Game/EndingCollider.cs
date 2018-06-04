using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCollider : MonoBehaviour {

	public bool isTriggered;
	public string endingDirection = "";

	void InitTrigger(){
		isTriggered = false;
	}

	void OnTriggerEnter2D (Collider2D coll){
		if (coll.attachedRigidbody.name == "Player") {
			isTriggered = true;
		}
	}
}
