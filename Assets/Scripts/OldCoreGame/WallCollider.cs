using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollider : MonoBehaviour {

	public GameObject player;

	private Transform playerT;
	private BoxCollider2D playerColl;
	private BoxCollider2D coll2D;

	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		coll2D = GetComponent<BoxCollider2D> ();
		playerT = player.GetComponent<Transform> ();
		playerColl = player.GetComponent<BoxCollider2D> ();
	}

	void Update () {
		float topCollider = transform.position.y + coll2D.size.y*transform.lossyScale.y / 2 + coll2D.offset.y;
		float botPlayer = playerT.position.y - playerColl.size.y*playerT.lossyScale.y / 2 + playerColl.offset.y;

		if (botPlayer > topCollider) {
			coll2D.isTrigger = false;
		} else {
			coll2D.isTrigger = true;
		}
	}
}
