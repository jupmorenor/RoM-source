using System;
using UnityEngine;

[Serializable]
public class PlayerFaceIcon : MonoBehaviour
{
	public void Start()
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			return;
		}
		int angelGender = current.AngelGender;
		int demonGender = current.DemonGender;
		UISprite component = gameObject.GetComponent<UISprite>();
		if (!component)
		{
			return;
		}
		if (component.spriteName == "icon_change1" || component.spriteName == "icon_change3")
		{
			if (angelGender == 2)
			{
				component.spriteName = "icon_change1";
			}
			else
			{
				component.spriteName = "icon_change3";
			}
		}
		else if (component.spriteName == "icon_change2" || component.spriteName == "icon_change4")
		{
			if (demonGender == 2)
			{
				component.spriteName = "icon_change2";
			}
			else
			{
				component.spriteName = "icon_change4";
			}
		}
	}
}
