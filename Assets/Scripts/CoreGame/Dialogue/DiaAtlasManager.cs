//*******************************************************************************************************
//* Resource manager.																					*
//* Load the resources.																					*
//*																										*
//*******************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaAtlasManager : DiaManager {
		
	private Sprite[] sprites;

	public override void BootSequence(string sceneName){
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
