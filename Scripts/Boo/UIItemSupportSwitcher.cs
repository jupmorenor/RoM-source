using System;
using Boo.Lang.Runtime;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class UIItemSupportSwitcher : MonoBehaviour
{
	public bool doInitEachTimeOpen;

	private bool showSupport;

	public UIListItemDetail.SupportInfo supportInfo;

	public GameObject skillWindow;

	public GameObject supportWindow;

	public void Start()
	{
		showSupport = false;
		ShowSupport(showSupport);
	}

	public void SetInfo(RespWeapon weapon)
	{
		if (weapon == null)
		{
			throw new AssertionFailedException("weapon != null");
		}
		if (doInitEachTimeOpen)
		{
			showSupport = false;
		}
		checked
		{
			int ba = (int)DamageCalc.SupportWeaponAttackRevise(weapon, null);
			int bh = (int)DamageCalc.SupportWeaponHpRevise(weapon, null);
			int ma = (int)DamageCalc.SupportWeaponAttackRevise(weapon, weapon);
			int mh = (int)DamageCalc.SupportWeaponHpRevise(weapon, weapon);
			UIListItemDetail.SetSupport(new UIListItemDetail.SupportInfo[1] { supportInfo }, ba, bh, ma, mh, weapon.ElementId, weapon.StyleId, showSupport);
			ShowSupport(showSupport);
		}
	}

	public void SetInfo(RespPoppet muppet)
	{
		if (muppet == null)
		{
			throw new AssertionFailedException("muppet != null");
		}
		if (doInitEachTimeOpen)
		{
			showSupport = false;
		}
		checked
		{
			int ba = (int)DamageCalc.PoppetAttackRevice(muppet, null);
			int bh = (int)DamageCalc.PoppetHpRevice(muppet, null);
			int ma = (int)DamageCalc.PoppetRevice(muppet, muppet.TotalAttack, muppet.ElementId);
			int mh = (int)DamageCalc.PoppetRevice(muppet, muppet.TotalHP, muppet.ElementId);
			UIListItemDetail.SetSupport(new UIListItemDetail.SupportInfo[1] { supportInfo }, ba, bh, ma, mh, muppet.ElementId, -1, showSupport);
			ShowSupport(showSupport);
		}
	}

	private void ShowSupport(bool show)
	{
		if ((bool)skillWindow && (bool)supportWindow)
		{
			Vector3 one = Vector3.one;
			Vector3 zero = Vector3.zero;
			skillWindow.transform.localScale = (show ? zero : one);
			supportWindow.transform.localScale = ((!show) ? zero : one);
		}
	}

	public void SwitchSkillArea()
	{
		showSupport = !showSupport;
		ShowSupport(showSupport);
	}

	public void PushSkillArea()
	{
		SwitchSkillArea();
	}
}
