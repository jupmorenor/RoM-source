using System;
using UnityEngine;

[Serializable]
public class TargetUI : MonoBehaviour
{
	public Transform target;

	public void Update()
	{
		transform.position = target.position;
	}
}
