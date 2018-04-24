//*******************************************************************************************************
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

	void Awake(){
		atlasManager = GetComponent<DiaAtlasManager> ();
		panelManager = GetComponent<DiaPanelManager> ();
		animationManager = GetComponent<DiaAnimationManager> ();

		_managerList.Add (atlasManager);
		_managerList.Add (animationManager);
		_managerList.Add (panelManager);

		StartCoroutine (BootAllManagers ());
	}

	private IEnumerator BootAllManagers(){
		foreach (DiaManager manager in _managerList) {
			manager.BootSequence ();
		}
		yield return null;
	}
}