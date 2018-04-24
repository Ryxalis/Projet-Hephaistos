//*******************************************************************************************************
//* Struct to get things from JSON file.																*
//*																										*
//*******************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaNarrativeEvent {
	public List<DiaDialogue> dialogues;
}

public struct DiaDialogue{
	public DiaCharacterType characterType;
	public DiaCharacterLocation characterLocation;
	public DiaPanelAnimation animation;
	public string name;
	public string atlasImageName;
	public string dialogueText;
}

public enum DiaCharacterLocation{
	Left, Right
}

public enum DiaCharacterType{
	Hero, Ally, Mentor
}

public enum DiaPanelAnimation{
	End=-1, Nothing=0, Start=1
}