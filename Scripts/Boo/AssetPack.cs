using System;
using UnityEngine;

[Serializable]
public class AssetPack : MonoBehaviour
{
	public string[] paths;

	public int PackNum => (paths != null) ? paths.Length : 0;
}
