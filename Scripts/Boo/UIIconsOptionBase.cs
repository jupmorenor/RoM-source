using System;
using UnityEngine;

[Serializable]
public class UIIconsOptionBase : MonoBehaviour
{
	public virtual GameObject GetObject(int layout)
	{
		return null;
	}
}
