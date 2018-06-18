using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Camera : MonoBehaviour {

	[SerializeField] private ManagerManager MM;

	public GameObject worldPlayer;
	public WorldManager worldManager;
	public WorldGameObject worldGO;

	private Camera m_camera;

	void Start () {
		m_camera = GetComponent<Camera> ();
	}

	void Update () {
		if (MM.M_GameStatus == GameStatus.WorldMap) {
			//Problem: works only if the map is centered in (0,0)
			Vector3 newPos = new Vector3 (worldPlayer.transform.position.x, worldPlayer.transform.position.y, m_camera.transform.position.z);

			SpriteRenderer mapSprite = worldGO.currentMap.GetComponent<SpriteRenderer> ();

			float vertPos = Mathf.Abs (worldPlayer.transform.position.y) + m_camera.scaledPixelHeight / PixelPerfectCamera.pixelToUnits / 2;
			float vertBound = mapSprite.size.y * worldGO.currentMap.transform.lossyScale.y * 100 / 2;

			float horiPos = Mathf.Abs (worldPlayer.transform.position.x) + m_camera.scaledPixelWidth / PixelPerfectCamera.pixelToUnits / 2;
			float horiBound = mapSprite.size.x * worldGO.currentMap.transform.lossyScale.x * 100 / 2;

			if (vertPos > vertBound) {
				newPos.y -= Mathf.Sign (worldPlayer.transform.position.y) * (vertPos - vertBound);
			}
			if (horiPos > horiBound) {
				newPos.x -= Mathf.Sign (worldPlayer.transform.position.x) * (horiPos - horiBound);
			}

			m_camera.transform.position = newPos;
		} 
		else if (MM.M_GameStatus == GameStatus.InGame) {
			Vector3 newPos = new Vector3 (0, 0, 0);
			m_camera.transform.position = newPos;
		}
	}
}
