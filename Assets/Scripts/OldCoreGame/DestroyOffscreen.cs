using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffscreen : MonoBehaviour {

	public float offset = 100f;

	private bool offScreen;
	private float offScreenX = 0;
	private Rigidbody2D body2d;

	void Awake () {
		body2d = GetComponent<Rigidbody2D> ();
	}

	void Start(){
		offScreenX = (Screen.width / PixelPerfectCamera.pixelToUnits)/2 + offset;
	}

	void Update () {
		var posX = transform.position.x;
		var dirX = body2d.velocity.x;

		if (Mathf.Abs(posX) > offScreenX) {
			if (dirX < 0 && posX < -offScreenX) {
				offScreen = true;
			} else if (dirX > 0 && posX > offScreenX) {
				offScreen = true;
			}
		}
		else {
			offScreen = false;
		}
		if (offScreen) {
			OnOutBounds ();
		}
	}

	public void OnOutBounds(){
		offScreen = false;
		GameObjectUtil.Destroy (gameObject);
	}
}
