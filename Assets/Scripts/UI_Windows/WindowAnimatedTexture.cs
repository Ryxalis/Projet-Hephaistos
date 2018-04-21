using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowAnimatedTexture : MonoBehaviour {

	public Vector2 speed = Vector2.zero;
	private Vector2 offset = Vector2.zero;
	private Material material;

	void Start () {
		material = GetComponent<Image> ().material;
		offset = material.GetTextureOffset ("_MainTex");
	}

	void Update () {
		offset += speed * 1/100;
		material.SetTextureOffset("_MainTex", offset);
	}
}
