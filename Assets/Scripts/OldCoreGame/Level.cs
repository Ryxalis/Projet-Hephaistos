using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Level : MonoBehaviour {

	public int numLevel = 1;
	public GameObject terrainPrefab;
	public Vector2 velocity = Vector2.zero;
	public float threshold = 200;

	private int levelLength = 0;
	private int levelHeight = 6;
	private int[][] levelMatrix;
	private float size;
	private Rigidbody2D myBody2D;
	private BoxCollider2D terrainCollider;

	private int columnNumber = 0;

	void Awake () {

		// Load level
		string path = "Assets/Resources/Levels/1.txt";

		StreamReader reader = new StreamReader(path);
		int.TryParse(reader.ReadLine (), out levelLength);

		levelMatrix = new int[levelLength][];
		for (int i = 0; i < levelLength; ++i) {
			levelMatrix [i] = new int[levelHeight];
			for (int j = 0; j < levelHeight; ++j) {
				levelMatrix [i] [j] = reader.Read ();
			}
			reader.ReadLine();	//to finish the line and to avoid problems with '\n' or 10 13 in windows.
		}

		// Initialize all the rest
		myBody2D = GetComponent<Rigidbody2D> ();
		//transform.position = new Vector3 ((Screen.width / PixelPerfectCamera.pixelToUnits) / 2 + threshold * 2, -(Screen.height / PixelPerfectCamera.pixelToUnits) / 2, -1);
		size = GetComponent<BoxCollider2D> ().size.x;
		terrainCollider = terrainPrefab.GetComponent<BoxCollider2D> ();
	}

	void FixedUpdate(){
		myBody2D.velocity = velocity;
		if (transform.position.x < (Screen.width / PixelPerfectCamera.pixelToUnits) / 2 + threshold) {
			transform.Translate (new Vector3 (size, 0, 0));
			if (Input.GetKey (KeyCode.C) && columnNumber < levelLength) {
				GameObject go = GameObjectUtil.Instantiate (terrainPrefab, transform.position);
				go.GetComponent<TerrainColumn> ().Set (levelMatrix [columnNumber]);
				columnNumber++;
			}
		}
	}

}
