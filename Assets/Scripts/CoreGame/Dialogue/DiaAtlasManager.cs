//*******************************************************************************************************
//* Resource manager.																					*
//* Load the resources.																					*
//*																										*
//*******************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaAtlasManager : MonoBehaviour, DiaManager {
		
	public static Sprite[] sprites;
	public DiaManagerState currentState { get; private set; }

	public void BootSequence(int sceneNumber){
		sprites = Resources.LoadAll<Sprite> ("Artwork/EventAtlas");
		currentState = DiaManagerState.Completed;
	}

	public Sprite loadSprite(string spriteName){
		foreach (Sprite s in sprites) {
			if (s.name == spriteName) {
				return s;
			}
		}

		return null;
	}
}
