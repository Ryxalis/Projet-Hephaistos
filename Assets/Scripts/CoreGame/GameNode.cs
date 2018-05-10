using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameNode : MonoBehaviour {

	public GameNode nodeLeft = null;		// null if there is none
	public GameNode nodeRight = null;
	public GameNode nodeUp = null;
	public GameNode nodeDown = null;

	public string dialogueSceneName = "";
	public int levelNumber = -1;

	public bool isLocked = true;

}