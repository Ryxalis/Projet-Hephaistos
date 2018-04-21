using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SmartToggle : MonoBehaviour {

	protected EventSystem eventSystem{
		get { return GameObject.Find ("EventSystem").GetComponent<EventSystem> (); }
	}

	private Toggle toggle;

	void Awake(){
		toggle = GetComponent<Toggle> ();
	}

	void Update () {
		if (eventSystem.currentSelectedGameObject == gameObject) {
			toggle.isOn = true;
		} else if(eventSystem.currentSelectedGameObject != null) {
			toggle.isOn = false;
		}
	}
}
