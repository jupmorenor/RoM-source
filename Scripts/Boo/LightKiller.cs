using System;
using UnityEngine;

[Serializable]
public class LightKiller : MonoBehaviour
{
	public bool 非アクティブ含む;

	public bool IncludeInactives => 非アクティブ含む;

	public void Start()
	{
		Light[] componentsInChildren = gameObject.GetComponentsInChildren<Light>(IncludeInactives);
		int i = 0;
		Light[] array = componentsInChildren;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (array[i] != null)
			{
				UnityEngine.Object.Destroy(array[i]);
			}
		}
		UnityEngine.Object.Destroy(this);
	}
}
