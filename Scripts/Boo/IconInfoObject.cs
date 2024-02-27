using System;
using UnityEngine;

[Serializable]
public class IconInfoObject : MonoBehaviour
{
	public UIListItem icon;

	public UISprite sprite;

	public bool IsEmpty => sprite == null;

	public void CopyOut(UIListItemDetail.IconInfo dist)
	{
		dist.icon = GetComponent<UIListItem>();
		dist.sprite = sprite;
	}

	public void CopyOut(UIListItem dist)
	{
		if (dist is WeaponInfo)
		{
			CopyOut(dist as WeaponInfo);
		}
		else if (dist is MuppetInfo)
		{
			CopyOut(dist as MuppetInfo);
		}
	}

	public void CopyOut(WeaponInfo dist)
	{
		dist.curIconSprite = sprite;
	}

	public void CopyOut(MuppetInfo dist)
	{
		dist.curIconSprite = sprite;
	}
}
