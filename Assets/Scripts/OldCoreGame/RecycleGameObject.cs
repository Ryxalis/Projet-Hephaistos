using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRecycle{
	void Restart ();
	void ShutDown();
}

public class RecycleGameObject : MonoBehaviour {

	private List<IRecycle> recycleComponent;

	void Awake(){
		var components = GetComponents<MonoBehaviour> ();
		recycleComponent = new List<IRecycle> ();
		foreach (var component in components) {
			if (component is IRecycle) {
				recycleComponent.Add (component as IRecycle);
			}
		}
	}

	public void Restart(){
		gameObject.SetActive (true);
		foreach (var component in recycleComponent) {
			component.Restart ();
		}
	}

	public void ShutDown(){
		gameObject.SetActive (false);
		foreach (var component in recycleComponent) {
			component.ShutDown ();
		}
	}
}
