using System;
using UnityEngine;

[Serializable]
public class IconCreatorEx : IconCreator
{
	protected WeaponInfo weaponInfo;

	protected MuppetInfo muppetInfo;

	protected bool init;

	public WeaponInfo WeaponInfo
	{
		get
		{
			if (!init)
			{
				Init();
			}
			return weaponInfo;
		}
	}

	public MuppetInfo MuppetInfo
	{
		get
		{
			if (!init)
			{
				Init();
			}
			return muppetInfo;
		}
	}

	public void Awake()
	{
		Init();
	}

	public void Init()
	{
		if (!init)
		{
			init = true;
			iconParent = this.gameObject.transform;
			GameObject gameObject = CreateIcon();
			weaponInfo = gameObject.GetComponent<WeaponInfo>();
			muppetInfo = gameObject.GetComponent<MuppetInfo>();
		}
	}
}
