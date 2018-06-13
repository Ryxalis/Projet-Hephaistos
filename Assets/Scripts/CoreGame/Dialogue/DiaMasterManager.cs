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
	
	[SerializeField] private DialogueWindow dialogueWindow;

	private List<DiaManager> _managerList = new List<DiaManager>();
	private DiaAtlasManager atlasManager;// { get; private set; }
	private DiaPanelManager panelManager;// { get; private set; }
	private DiaAnimationManager animationManager;// { get; private set; }
	private string currentDialogue = "none";
	public string CurrentDialogue { get { return currentDialogue; } }
	public bool IsAnimating { get { return animationManager.IsAnimating; } }

	public void StartDialogue(string sceneName){
		atlasManager = GetComponent<DiaAtlasManager> ();
		panelManager = GetComponent<DiaPanelManager> ();
		animationManager = GetComponent<DiaAnimationManager> ();

		_managerList = new List<DiaManager> ();
		_managerList.Add (atlasManager);
		_managerList.Add (animationManager);
		_managerList.Add (panelManager);

		StartCoroutine (BootAllManagers (sceneName));

		if (currentDialogue != "none") {
			print ("ERROR");
		}
		currentDialogue = sceneName;
	}


	public void EndDialogue(){
		currentDialogue = "none";
		dialogueWindow.BackToWorld ();
	}

	private IEnumerator BootAllManagers(string sceneName){
		foreach (DiaManager manager in _managerList) {
			manager.BootSequence (sceneName);
		}
		yield return null;
	}

	public Sprite loadSprite(string name){
		return atlasManager.loadSprite(name);
	}

	public void Animate(string side, string moment){
		StartCoroutine(animationManager.DiaAnimation (side, moment));
	}
}