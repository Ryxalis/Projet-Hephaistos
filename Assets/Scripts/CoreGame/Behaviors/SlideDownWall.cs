using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDownWall : AbstractBehavior {

	public bool onWallDetected;
	public float newGravityScale;
	public float newVelocityY = -5;

	public GameObject dustPrefab;
	public float dustSpawnDelay = 0.5f;

	private float timeElapsed = 0f;

	protected float defaultGravityScale;
	protected float defaultDrag;

	void Start () {
		defaultGravityScale = body2D.gravityScale;
		defaultDrag = body2D.drag;
	}

	protected virtual void Update () {
		
		var buttonLeft  = inputState.GetButtonValue (inputButtons [0]);
		var buttonRight = inputState.GetButtonValue (inputButtons [1]);

		if (collisionState.onWall) {
			if (!onWallDetected && !collisionState.standing && body2D.velocity.y < 0) {
				if ((inputState.direction == Direction.Left && buttonLeft) || (inputState.direction == Direction.Right && buttonRight)) {
					OnStick ();
					ToggleScripts (false);
					onWallDetected = true;
				}
			}
		}
		if(!collisionState.onWall || collisionState.standing || (!buttonLeft && !buttonRight)){
			if (onWallDetected) {
				OffWall ();
				ToggleScripts (true);
				onWallDetected = false;
			}
		}

		if (onWallDetected && !collisionState.standing) {
			if(timeElapsed > dustSpawnDelay){
				var dust = Instantiate (dustPrefab);
				var pos = transform.position;
				pos.y += 2;
				pos.z += 1;
				dust.transform.position = pos;
				dust.transform.localScale = transform.localScale;
				dust.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-InputState.absLevelSpeed, 0);

				timeElapsed = 0;
			}

			timeElapsed += Time.deltaTime;
		}
	}

	protected virtual void OnStick(){
		body2D.velocity = new Vector2(0, newVelocityY);
		body2D.gravityScale	= newGravityScale;
		//body2D.drag = 100;
	}

	protected virtual void OffWall(){
		if (body2D.gravityScale != defaultGravityScale) {
			body2D.gravityScale = defaultGravityScale;
			//body2D.drag = defaultDrag;
			timeElapsed = 0;
		}
	}
}
