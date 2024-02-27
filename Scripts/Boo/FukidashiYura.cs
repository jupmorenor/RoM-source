using System;
using UnityEngine;

[Serializable]
public class FukidashiYura : MonoBehaviour
{
	private float sec;

	private Vector3 pos;

	private Vector3 scl;

	public void Start()
	{
		pos = transform.localPosition;
		scl = transform.localScale;
	}

	public void Update()
	{
		sec += Time.deltaTime;
		float num = Mathf.Sin(sec * 4f) * 5f;
		transform.localPosition = pos + new Vector3(0f, num, 0f);
		transform.localScale = scl * (1f + num / 500f);
	}
}
