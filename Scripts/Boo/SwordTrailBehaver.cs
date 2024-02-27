using System;
using UnityEngine;

[Serializable]
public class SwordTrailBehaver : MonoBehaviour
{
	public Transform stObj;

	public void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			stObj.SendMessage("Slash", 1f);
		}
	}
}
