//*******************************************************************************************************
//* Initializes all managers.																			*
//* Each manager does something useful for dialogues : sprites, animations and panels.					*
//*																										*
//*******************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour {
	
	[SerializeField] private DialogueWindow dialogueWindow;
	private DiaAtlasManager atlasManager;
	private DiaPanelManager panelManager;
	private DiaAnimationManager animationManager;
	private List<DiaManager> _managerList = new List<DiaManager>();
	private string currentDialogue;
	public string CurrentDialogue { get { return currentDialogue; } }
	public bool IsAnimating { get { return animationManager.IsAnimating; } }

	void Start(){
		Boot ();
	}

	public void Boot(){
		atlasManager = dialogueWindow.gameObject.GetComponent<DiaAtlasManager> ();
		panelManager = dialogueWindow.gameObject.GetComponent<DiaPanelManager> ();
		animationManager = dialogueWindow.gameObject.GetComponent<DiaAnimationManager> ();
		currentDialogue = "none";
	}

	public void StartDialogue(string sceneName){
		_managerList = new List<DiaManager> ();
		_managerList.Add (atlasManager);
		_managerList.Add (animationManager);
		_managerList.Add (panelManager);

		StartCoroutine (BootAllManagers (sceneName));

		currentDialogue = sceneName;
	}

	public void EndDialogue(){
		currentDialogue = "none";
		dialogueWindow.BackToWorld ();
	}

	public Sprite loadSprite(string name){
		return atlasManager.loadSprite(name);
	}

	public void Animate(string side, string moment){
		StartCoroutine(animationManager.DiaAnimation (side, moment));
	}

	private IEnumerator BootAllManagers(string sceneName){
		foreach (DiaManager manager in _managerList) {
			manager.BootSequence (sceneName);
		}
		yield return null;
	}
}