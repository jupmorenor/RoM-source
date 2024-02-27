using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(UIButtonMessage))]
public class SortListButton : MonoBehaviour
{
	private readonly string defSpriteName;

	private readonly string selectSpriteName;

	public UILabelBase label;

	public UISprite bg;

	private UIButtonMessage button;

	public SortListButton()
	{
		defSpriteName = "button02";
		selectSpriteName = "button03";
	}

	public string Initialize(GameObject target, string sortName, bool isSimpleSort)
	{
		if (!(target != null))
		{
			throw new AssertionFailedException("target != null");
		}
		if (string.IsNullOrEmpty(sortName))
		{
			throw new AssertionFailedException("not string.IsNullOrEmpty(sortName)");
		}
		UIBasicUtility.SetLabel(label, sortName, show: true);
		if (button == null)
		{
			button = GetComponent<UIButtonMessage>();
		}
		button.target = target;
		button.mode = UIButtonMessage.SendMode.Message;
		button.message = sortName;
		if (isSimpleSort)
		{
			button.functionName = "PushSimpleSort";
		}
		else
		{
			button.functionName = "PushSort";
		}
		return null;
	}

	public void Select(bool select)
	{
		UIBasicUtility.SetSprite(bg, (!select) ? defSpriteName : selectSpriteName, null, show: true);
	}
}
