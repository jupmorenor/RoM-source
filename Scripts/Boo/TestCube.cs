using System;
using UnityEngine;

public static class TestCube
{
	[NonSerialized]
	public static Transform current;

	public static Transform Current
	{
		get
		{
			if (current == null)
			{
				current = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
				UnityEngine.Object.Destroy(current.collider);
			}
			return current;
		}
	}
}
