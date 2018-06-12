//*******************************************************************************************************
//* Basic Window.																						*
//* All the windows inherit from this one.																*
//*																										*
//*******************************************************************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GenericWindow : MonoBehaviour {
	
	[SerializeField] protected Windows thisWindow;
	[Header("Others")]
	[SerializeField] protected GameObject firstSelected;

	private WindowsManager wManager;
	protected GameObject selectedGO;
	protected bool isBackground = false;
	public bool IsBackground { get { return isBackground; } }


	void Awake(){
		wManager = GetComponentInParent<WindowsManager> ();
	}

	public virtual void SetBackground(){
		isBackground = true;
		selectedGO = eventSystem.currentSelectedGameObject;
	}

	protected EventSystem eventSystem{
		get { return GameObject.Find ("EventSystem").GetComponent<EventSystem> (); }
	}

	public virtual void OnFocus(){
		eventSystem.SetSelectedGameObject (firstSelected);

		if (isBackground) {
			isBackground = false;
			eventSystem.SetSelectedGameObject(selectedGO);
		}
	}

	public virtual void Open(){
		OnFocus ();
	}

	public virtual void Close(){
	
	}

	public virtual void OnNextWindow(WindowBackgroundStruct nextWindow){
		if (nextWindow.activateBackground) {
			SetBackground();
		}
		wManager.Open ((int)nextWindow.window - 1);
	}

}