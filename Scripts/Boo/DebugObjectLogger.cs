using System;
using UnityEngine;

[Serializable]
public class DebugObjectLogger : MonoBehaviour
{
	public bool logging;

	public Vector3 position;

	public Vector3 localPosition;

	public void Update()
	{
		Transform transform = this.transform;
		position = transform.position;
		localPosition = transform.localPosition;
		if (!logging)
		{
		}
	}
}
