﻿//*******************************************************************************************************
//* Initializes all managers.																			*
//* Each manager does something useful for dialogues : sprites, animations and panels.					*
//*																										*
//*******************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DiaAtlasManager))]
[RequireComponent(typeof(DiaPanelManager))]
[RequireComponent(typeof(DiaAnimationManager))]

public class DiaMasterManager : MonoBehaviour {

	private List<DiaManager> _managerList = new List<DiaManager>();

	public static DiaAtlasManager atlasManager { get; private set; }
	public static DiaPanelManager panelManager { get; private set; }
	public static DiaAnimationManager animationManager { get; private set; }

	public static string currentDialogue = "none";

	void Update(){
		if (Input.GetKeyDown(KeyCode.A) && currentDialogue == "none") {
			StartDialogue ("Event1");
		}
	}

	public void StartDialogue(string sceneName){

		atlasManager = GetComponent<DiaAtlasManager> ();
		panelManager = GetComponent<DiaPanelManager> ();
		animationManager = GetComponent<DiaAnimationManager> ();

		_managerList.Add (atlasManager);
		_managerList.Add (animationManager);
		_managerList.Add (panelManager);

		StartCoroutine (BootAllManagers (sceneName));

		currentDialogue = sceneName;
	}

	private IEnumerator BootAllManagers(string sceneName){
		foreach (DiaManager manager in _managerList) {
			manager.BootSequence (sceneName);
		}
		yield return null;
	}
}