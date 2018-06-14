using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KeyOption : MonoBehaviour {

	[SerializeField] private GameObject MiniKeyPanel;

	private Toggle selectionToggle;
	private Button keyButton;
	private Text keyText;

	protected EventSystem eventSystem{
		get { return GameObject.Find ("EventSystem").GetComponent<EventSystem> (); }
	}

	void Awake(){
		selectionToggle = GetComponentsInChildren<Toggle> () [0];
		keyButton = GetComponentsInChildren<Button> () [0];
		keyText = keyButton.GetComponentsInChildren<Text> () [0];
		MiniKeyPanel.SetActive (false);
	}

	void Update(){
		if (selectionToggle.isOn){
			if(!MiniKeyPanel.activeSelf && Input.GetButtonDown ("Submit")){
				MiniKeyPanel.SetActive(true);
				eventSystem.SetSelectedGameObject (null);
			}
			else if (Input.anyKeyDown && MiniKeyPanel.activeSelf){
				bool newKey = false;
				foreach (char c in Input.inputString) {
					string key;
					if (char.IsLower(c)) {
						key = char.ToUpper (c).ToString ();
						if (Input.GetKeyDown ((KeyCode)System.Enum.Parse (typeof(KeyCode), key))) {
							keyText.text = key;
							newKey = true;
						}
					}
				}
				if (Input.GetKeyDown (KeyCode.Space)) {
					keyText.text = KeyCode.Space.ToString ();
					newKey = true;
				}

				if (newKey) {
					MiniKeyPanel.SetActive (false);
					eventSystem.SetSelectedGameObject (selectionToggle.gameObject);
				}

			}
		}
	}
}
