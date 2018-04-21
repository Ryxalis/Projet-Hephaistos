﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITileBackground : MonoBehaviour {

	public int textureSize = 32;
	public bool scaleHorizontal = true;
	public bool scaleVertical = true;

	void Start () {
		var newWidth = scaleHorizontal ? Mathf.Ceil(Screen.width / (textureSize * PixelPerfectCamera.scale)) : 1;
		var newHeight = scaleVertical? Mathf.Ceil(Screen.height / (textureSize * PixelPerfectCamera.scale)) : 1;

		transform.localScale = new Vector3 (newWidth * textureSize, newHeight * textureSize, 1);

		GetComponent<Image> ().material.mainTextureScale = new Vector3 (newWidth, newHeight, 1);
	}
}
