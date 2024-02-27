using System;
using UnityEngine;

[Serializable]
public class TestRotation : MonoBehaviour
{
	public void Update()
	{
		float y = transform.eulerAngles.y + 1f;
		Vector3 eulerAngles = transform.eulerAngles;
		float num = (eulerAngles.y = y);
		Vector3 vector2 = (transform.eulerAngles = eulerAngles);
	}
}
