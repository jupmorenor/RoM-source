using System;
using UnityEngine;

[ExecuteInEditMode]
public class SizeToView : MonoBehaviour
{
	public Camera cam;

	private Vector3 lstVec = Vector3.zero;

	private void Update()
	{
		if (!cam)
		{
			cam = Camera.main;
		}
		if ((bool)cam)
		{
			Vector3 vector = base.transform.position - cam.transform.position;
			if (!(vector == lstVec))
			{
				Vector3 vector2 = Quaternion.Inverse(cam.transform.rotation) * vector;
				float num = Mathf.Tan((float)Math.PI / 180f * cam.fieldOfView / 2f) * vector2.z / (float)Screen.height * 2f;
				base.transform.localScale = new Vector3(num, num, num);
				lstVec = vector;
			}
		}
	}
}
