//*******************************************************************************************************
//* Basic class for Dialogue Managers.																	*
//*																										*
//*******************************************************************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DiaManagerState {
	Offline, Initializing, Completed
}

public class DiaManager : MonoBehaviour {
	protected DiaManagerState currentState;
	public DiaManagerState CurrentState { get { return currentState; } }

	public virtual void BootSequence(string sceneName) {}
}