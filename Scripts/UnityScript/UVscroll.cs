using System;
using UnityEngine;

[Serializable]
public class UVscroll : MonoBehaviour
{
	public float scrollSpeed;

	public float offset;

	public UVscroll()
	{
		scrollSpeed = -0.25f;
	}

	public virtual void Update()
	{
		offset += Time.deltaTime * scrollSpeed;
		renderer.material.mainTextureOffset = new Vector2(0f, offset);
	}

	public virtual void Main()
	{
	}
}
