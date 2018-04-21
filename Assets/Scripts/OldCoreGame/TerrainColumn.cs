using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainColumn : MonoBehaviour {


	public void Set(int[] columnMatrix){
		for (int i = 0; i < columnMatrix.Length; ++i) {
			if (columnMatrix [i] == '0') {
				GetComponentsInChildren<GameObject> () [i].gameObject.SetActive (false);
			}
		}
	}
}
