﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelPerfectCamera : MonoBehaviour {

	public static float pixelToUnits = 1f;
	public static float scale = 1f;

	public static Vector2 nativeResolution = new Vector2(480, 320);

	void Awake () {
		var camera = GetComponent<Camera> ();

		if (camera.orthographic) {
			scale = Screen.height / nativeResolution.y;
			pixelToUnits *= scale;
			camera.orthographicSize = (Screen.height / 2.0f) / pixelToUnits;
		}
	}
}
