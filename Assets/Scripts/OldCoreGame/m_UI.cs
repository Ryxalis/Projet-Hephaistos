using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class m_UI : MonoBehaviour {

	public Text continueText;
	public float blinkTime;

	//private GameManager gManager;
	private bool isBlink;

	void Start () {
		//gManager = GameObject.FindObjectOfType<GameManager> ();
		isBlink = true;
		continueText.text = "PRESS Z KEY TO START";
	}

	void Update () {
		/*if (!gManager.get_gameStarted ()) {
			blinkTime++;
			if (blinkTime % 40 == 0) {
				isBlink = !isBlink;
			}
			continueText.canvasRenderer.SetAlpha (isBlink ? 1 : 0);
		} else {
			continueText.canvasRenderer.SetAlpha (0);
			blinkTime = 0;
			isBlink = true;
		}*/
	}
}
