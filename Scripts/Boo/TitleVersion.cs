using System;
using UnityEngine;

[Serializable]
public class TitleVersion : MonoBehaviour
{
	public void Start()
	{
		UIDynamicFontLabel component = gameObject.GetComponent<UIDynamicFontLabel>();
		string version = NativeBundleInfo.Version;
		if (component != null)
		{
			if (string.IsNullOrEmpty(version))
			{
				component.text = string.Empty;
			}
			else
			{
				component.text = "Ver " + version;
			}
		}
	}
}
