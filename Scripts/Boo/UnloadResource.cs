using System;
using UnityEngine;

[Serializable]
public class UnloadResource
{
	public static AsyncOperation UnloadUnusedAssets()
	{
		return Resources.UnloadUnusedAssets();
	}
}
