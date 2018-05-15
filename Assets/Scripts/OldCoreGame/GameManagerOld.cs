using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerOld : MonoBehaviour {

	public delegate void OnDestroy ();
	public event OnDestroy DestroyCallback;
	// Pour tuer le joueur : 
	//	if(DestroyCallback != null)
	//		DestroyCallback();
	public TimeManager timeManager;
	public float groundRatio = 0.6f;
	public GameObject playerPrefab;

	private GameObject player;
	private GameObject floor;
	private Spawner spawner;
	private bool gameStarted;
	public bool get_gameStarted(){ return gameStarted; }

	void Awake(){
		floor = GameObject.Find ("Foreground");
		spawner = GameObject.Find ("Spawner").GetComponent<Spawner>();
		timeManager = GetComponent<TimeManager> ();
		Cursor.visible = false;
	}

	void Start () {
		var floorHeight = floor.transform.localScale.y;
		var pos = floor.transform.position;

		pos.x = 0;
		pos.y = -((Screen.height / PixelPerfectCamera.pixelToUnits) / 2) + floorHeight/2 - floorHeight * (1-groundRatio);
		floor.transform.position = pos;

		spawner.active = false;

		Time.timeScale = 0;
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			GameObjectUtil.Destroy (player);
			if(DestroyCallback != null)
				DestroyCallback();
		}
		if (!gameStarted && Time.timeScale == 0) {
			if (Input.GetKeyDown (KeyCode.Z)) {
				timeManager.ManipulateTime (1, 1.0f);
				ResetGame ();
			}
		}
	}

	void OnPlayerKilled(){
		spawner.active = false;
		player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;

		DestroyCallback -= OnPlayerKilled;

		timeManager.ManipulateTime (0, 5.0f);
		gameStarted = false;
	}

	void ResetGame(){
		spawner.active = true;

		player = GameObjectUtil.Instantiate (playerPrefab, new Vector3 (0, Screen.height/PixelPerfectCamera.pixelToUnits, -5));

		DestroyCallback += OnPlayerKilled;

		gameStarted = true;
	}
}
