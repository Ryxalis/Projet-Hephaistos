using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DiaManagerState {
	Offline, Initializing, Completed
}

public interface DiaManager {
	DiaManagerState currentState { get; }

	void BootSequence();
}