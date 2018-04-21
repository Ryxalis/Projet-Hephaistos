using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverWindow : GenericWindow {

	public Text leftStatLabel;
	public Text leftStatValues;
	public Text rightStatLabel;
	public Text rightStatValues;
	public Text ScoreValue;

	public void ClearText(){
		leftStatLabel.text = "";
		leftStatValues.text = "";
		rightStatLabel.text = "";
		rightStatValues.text = "";
		ScoreValue.text = "";
	}

	public override void Open ()
	{
		//ClearText ();
		base.Open ();
	}

	public void OnNext(){
		OnNextWindow ();
	}
}
