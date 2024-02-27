using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class BoxDeckPanel : MonoBehaviour
{
	protected int deckIndex;

	public IconCreatorEx mainWeaponIcon;

	public IconCreatorEx sub1WeaponIcon;

	public IconCreatorEx sub2WeaponIcon;

	public IconCreatorEx muppetIcon;

	public WeaponInfo mainWeaponInfo;

	public WeaponInfo sub1WeaponInfo;

	public WeaponInfo sub2WeaponInfo;

	public MuppetInfo muppetInfo;

	public UILabelBase playerHpLabel;

	public UILabelBase playerAtkLabel;

	public UISprite deckBgWindow;

	public int DeckIndex
	{
		get
		{
			return deckIndex;
		}
		set
		{
			deckIndex = value;
			if (deckIndex < 0)
			{
				deckIndex = 4;
			}
			if (deckIndex >= 5)
			{
				deckIndex = 0;
			}
			if ((bool)deckBgWindow)
			{
				float a = deckBgWindow.color.a;
				UISprite uISprite = deckBgWindow;
				Color[] deckColors = MyHomeEquipMain.DeckColors;
				uISprite.color = deckColors[RuntimeServices.NormalizeArrayIndex(deckColors, value)];
				float a2 = a;
				Color color = deckBgWindow.color;
				float num = (color.a = a2);
				Color color3 = (deckBgWindow.color = color);
			}
		}
	}

	public void Start()
	{
		if ((bool)mainWeaponInfo && (bool)mainWeaponIcon)
		{
			mainWeaponInfo.curIconSprite = mainWeaponIcon.WeaponInfo.curIconSprite;
		}
		if ((bool)sub1WeaponInfo && (bool)sub1WeaponIcon)
		{
			sub1WeaponInfo.curIconSprite = sub1WeaponIcon.WeaponInfo.curIconSprite;
		}
		if ((bool)sub2WeaponInfo && (bool)sub2WeaponIcon)
		{
			sub2WeaponInfo.curIconSprite = sub2WeaponIcon.WeaponInfo.curIconSprite;
		}
		if ((bool)muppetInfo && (bool)muppetIcon)
		{
			muppetInfo.curIconSprite = muppetIcon.MuppetInfo.curIconSprite;
		}
	}

	public void Update()
	{
	}
}
