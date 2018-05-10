using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GenericWindow : MonoBehaviour {

	public static WindowsManager wManager;
	public WindowBackgroundStruct nextWindow;
	public WindowBackgroundStruct previousWindow;
	//public Windows nextWindow;
	//public Windows previousWindow;

	public Windows thisWindow;
	//public bool activateBackground = false;

	public GameObject firstSelected;

	protected EventSystem eventSystem{
		get { return GameObject.Find ("EventSystem").GetComponent<EventSystem> (); }
	}

	public virtual void OnFocus(){
		eventSystem.SetSelectedGameObject (firstSelected);
	}

	protected virtual void Display(bool value){
		gameObject.SetActive (value);
	}

	public virtual void Open(){
		Display (true);
		OnFocus ();
		if (WindowsManager.backgrounds.Contains((int)thisWindow - 1)) {
			WindowsManager.backgrounds.Remove ((int)thisWindow - 1);
		}
	}

	public virtual void Close(){
		Display(false);
	}

	protected virtual void Awake(){
		Close ();
	}

	public virtual void OnNextWindow(){
		if (nextWindow.activateBackground) {
			WindowsManager.backgrounds.Add ((int)thisWindow - 1);
		}
		wManager.Open ((int)nextWindow.window - 1);
	}

	public virtual void OnNextWindowCustom(int arg_previousWindow = -1, bool arg_prevWinBakground = false, int arg_nextWindow = -1, bool arg_nextWinBakground = false){
		if (nextWindow.activateBackground) {
			WindowsManager.backgrounds.Add ((int)thisWindow - 1);
		}
		wManager.Open ((int)nextWindow.window - 1);
	}

	public virtual void NextWindowSetBackground(bool background){
		//wManager
	}

	public virtual void OnPreviousWindow(){
		if (previousWindow.activateBackground) {
			WindowsManager.backgrounds.Add((int)thisWindow - 1);
		}
		wManager.Open ((int)previousWindow.window - 1);
	}
}
