using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCamera : MonoBehaviour {

	public GameObject worldPlayer;
	public WorldManager worldManager;
	public WorldGameObject worldGO;

	private Camera m_camera;

	void Start () {
		m_camera = GetComponent<Camera> ();
	}

	void Update () {
		if (worldManager.gameStatus == GameStatus.WorldMap){
			Vector3 newPos = new Vector3 (worldPlayer.transform.position.x, worldPlayer.transform.position.y, m_camera.transform.position.z);

			/*if (Mathf.Abs (worldPlayer.transform.position.y) + m_camera.scaledPixelHeight / PixelPerfectCamera.pixelToUnits / 2 > worldGO.currentMap.GetComponent<SpriteRenderer> ().size.y * worldGO.currentMap.transform.lossyScale.y * 100 / 2) {
				print ("OUT");
				newPos.y = m_camera.transform.position.y;
			}*/

			m_camera.transform.position = newPos;

			//print (worldGO.currentMap.GetComponent<SpriteRenderer> ().size * worldGO.currentMap.transform.lossyScale.x * 100);
			//print (m_camera.scaledPixelHeight + " " + m_camera.scaledPixelWidth);
			//print(m_camera.scaledPixelHeight / PixelPerfectCamera.pixelToUnits / 2);
			//print(m_camera.scaledPixelWidth / PixelPerfectCamera.pixelToUnits);
		}
	}
}
