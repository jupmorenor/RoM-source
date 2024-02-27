using System;
using UnityEngine;

[Serializable]
public class TargetOutlineFlash : MonoBehaviour
{
	public void Update()
	{
		renderer.material.SetColor("_OutlineColor", new Color(1f, 1f, 1f, Mathf.PingPong(Time.time, 0.75f)));
	}
}
