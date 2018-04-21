using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectUtil {

	private static Dictionary<RecycleGameObject, ObjectPool> pools = new Dictionary<RecycleGameObject, ObjectPool>();

	public static GameObject Instantiate(GameObject m_prefab, Vector3 position){
		GameObject instance = null;

		var recycledGameObject = m_prefab.GetComponent<RecycleGameObject> ();
		if (recycledGameObject != null) {
			var pool = GetObjectPool (recycledGameObject);
			instance = pool.NextObject (position).gameObject;
		} else {
			instance = GameObject.Instantiate (m_prefab);
			instance.transform.position = position;
		}

		return instance;
	}

	public static void Destroy(GameObject m_prefab){
		var recycledGameObject = m_prefab.GetComponent<RecycleGameObject> ();
		if (recycledGameObject) {
			recycledGameObject.ShutDown ();
		} else {
			GameObject.Destroy (m_prefab);
		}
	}

	private static ObjectPool GetObjectPool(RecycleGameObject reference){
		ObjectPool pool = null;

		if (pools.ContainsKey (reference)) {
			pool = pools [reference];
		} else {
			var poolContainer = new GameObject (reference.gameObject.name = "ObjectPool");
			pool = poolContainer.AddComponent<ObjectPool> ();
			pool.prefab = reference;
			pools.Add (reference, pool);
		}
		return pool;
	}
}
