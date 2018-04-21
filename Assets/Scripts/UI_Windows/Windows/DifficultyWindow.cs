using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyWindow : GenericWindow {

	public ToggleGroup difficultyGroup;
	public int delay = 5;
	public string varToRecord = "Difficulty";

	private float currentDelay = 0;

	public int difficulty{
		get{
			int nbToggles = difficultyGroup.GetComponentsInChildren<Toggle> ().Length;
			for(int i = 0; i < nbToggles; i++){
				Toggle to = difficultyGroup.GetComponentsInChildren<Toggle>()[i];
				if (to.isOn) {
					return i;
				}
			}
			return -1;
		}
		set{
			value = (int)Mathf.Repeat(value, difficultyGroup.transform.childCount);

			int nbToggles = difficultyGroup.GetComponentsInChildren<Toggle> ().Length;
			for(int i = 0; i < nbToggles; i++){
				Toggle to = difficultyGroup.GetComponentsInChildren<Toggle>()[i];
				to.isOn = false;
			}
			difficultyGroup.GetComponentsInChildren<Toggle> () [value].isOn = true;
		}
	}

	public void OnSelect(){
		PlayerPrefs.SetInt (varToRecord, difficulty);
		OnNextWindow ();
	}

	void Start () {
		difficulty = PlayerPrefs.GetInt (varToRecord, 1);
	}

	void Update () {
		if (Input.GetButtonDown ("Submit")) {
			OnSelect ();
		}

		++ currentDelay;

		if (currentDelay > delay) {
			var newDifficulty = difficulty;

			if (Input.GetButton("Right")) {
				newDifficulty++;
			} else if (Input.GetButton("Left")) {
				newDifficulty--;
			}

			if (newDifficulty != difficulty) {
				print ("OK");
				difficulty = newDifficulty;
				currentDelay = 0;
			}

		}

	}
}
