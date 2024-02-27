using System;
using UnityEngine;

[Serializable]
public class Ef_SpotPlane : MonoBehaviour
{
	public GameObject meshObj;

	public Transform spot1;

	public Transform spot2;

	private Material mat;

	private bool rady;

	public void Start()
	{
		if ((bool)spot1 && (bool)spot2 && (bool)meshObj && (bool)meshObj.renderer && (bool)meshObj.renderer.material)
		{
			mat = meshObj.renderer.material;
			rady = true;
		}
	}

	public void Update()
	{
		if (rady)
		{
			Vector3 position = meshObj.transform.position;
			Quaternion rotation = meshObj.transform.rotation;
			Quaternion quaternion = Quaternion.Inverse(rotation);
			Vector3 localScale = meshObj.transform.localScale;
			Vector2 scale = default(Vector2);
			Vector3 vector = default(Vector3);
			Vector2 offset = default(Vector2);
			Vector3 vector2 = default(Vector3);
			if ((bool)spot1)
			{
				vector2 = spot1.localScale;
				scale.x = localScale.x / vector2.x;
				scale.y = localScale.z / vector2.z;
				vector = quaternion * (spot1.position - position);
				offset.x = ((0f - vector.x) / localScale.x - 0.5f) * scale.x + 0.5f;
				offset.y = ((0f - vector.z) / localScale.z - 0.5f) * scale.y + 0.5f;
				mat.SetTextureScale("_MainTex", scale);
				mat.SetTextureOffset("_MainTex", offset);
			}
			if ((bool)spot2)
			{
				vector2 = spot2.localScale;
				scale.x = localScale.x / vector2.x;
				scale.y = localScale.z / vector2.z;
				vector = quaternion * (spot2.position - position);
				offset.x = ((0f - vector.x) / localScale.x - 0.5f) * scale.x + 0.5f;
				offset.y = ((0f - vector.z) / localScale.z - 0.5f) * scale.y + 0.5f;
				mat.SetTextureScale("_SubTex", scale);
				mat.SetTextureOffset("_SubTex", offset);
			}
		}
	}

	public void OnDestroy()
	{
		if ((bool)mat)
		{
			UnityEngine.Object.Destroy(mat);
		}
	}
}
