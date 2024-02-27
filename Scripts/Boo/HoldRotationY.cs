using System;
using UnityEngine;

[Serializable]
public class HoldRotationY : MonoBehaviour
{
	public float holdRotatinY;

	public void Update()
	{
		float y = holdRotatinY;
		Quaternion rotation = transform.rotation;
		float num = (rotation.y = y);
		Quaternion quaternion2 = (transform.rotation = rotation);
	}
}
