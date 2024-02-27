using System;
using UnityEngine;

[Serializable]
public class LightmapReader : MonoBehaviour
{
	public void Update()
	{
		if (Input.GetMouseButton(0))
		{
			RaycastHit hitInfo = default(RaycastHit);
			if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hitInfo))
			{
				Renderer renderer = hitInfo.collider.renderer;
				MeshCollider meshCollider = hitInfo.collider as MeshCollider;
				LightmapData lightmapData = LightmapSettings.lightmaps[0];
				Texture2D lightmapFar = lightmapData.lightmapFar;
				Vector2 lightmapCoord = hitInfo.lightmapCoord;
				Color pixelBilinear = lightmapFar.GetPixelBilinear(lightmapCoord.x, lightmapCoord.y);
			}
		}
	}
}
