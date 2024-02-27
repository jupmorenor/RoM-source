using System;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;

[Serializable]
public class UserBoxData
{
	private Dictionary<BoxId, RespWeapon> weapons;

	private Dictionary<BoxId, RespPoppet> poppets;

	public RespWeapon[] Weapons => (RespWeapon[])Builtins.array(typeof(RespWeapon), weapons.Values);

	public RespPoppet[] Muppets => (RespPoppet[])Builtins.array(typeof(RespPoppet), poppets.Values);

	public RespPlayerBox[] AllItems
	{
		get
		{
			RespPlayerBox[] lhs = Gen_array_macrosModule.GenArray<RespPlayerBox, RespWeapon>(Weapons, (__UserData_0024callable345_0024839_22__)((RespWeapon _0024genarray_00241610) => _0024genarray_00241610.RefPlayerBox));
			RespPlayerBox[] rhs = Gen_array_macrosModule.GenArray<RespPlayerBox, RespPoppet>(Muppets, (__UserData_0024callable346_0024839_22__)((RespPoppet _0024genarray_00241611) => _0024genarray_00241611.RefPlayerBox));
			return (RespPlayerBox[])RuntimeServices.AddArrays(typeof(RespPlayerBox), lhs, rhs);
		}
	}

	public UserBoxData()
	{
		weapons = new Dictionary<BoxId, RespWeapon>();
		poppets = new Dictionary<BoxId, RespPoppet>();
	}

	public bool haveItem(BoxId id)
	{
		bool num = haveWeapon(id);
		if (!num)
		{
			num = havePoppet(id);
		}
		return num;
	}

	public bool haveWeapon(BoxId wpn_box_id)
	{
		return weapons.ContainsKey(wpn_box_id);
	}

	public bool havePoppet(BoxId ppt_box_id)
	{
		return poppets.ContainsKey(ppt_box_id);
	}

	public RespWeapon weapon(BoxId wpn_box_id)
	{
		return (!weapons.ContainsKey(wpn_box_id)) ? null : weapons[wpn_box_id];
	}

	public RespPoppet poppet(BoxId ppt_box_id)
	{
		return (!poppets.ContainsKey(ppt_box_id)) ? null : poppets[ppt_box_id];
	}

	public RespPlayerBox get(BoxId box_id)
	{
		RespWeapon respWeapon = weapon(box_id);
		return (respWeapon != null) ? respWeapon.RefPlayerBox : poppet(box_id)?.RefPlayerBox;
	}

	public bool haveMWeapon(MWeapons mstWep)
	{
		bool flag;
		foreach (RespWeapon value in weapons.Values)
		{
			if (value.Master.Id != mstWep.Id)
			{
				continue;
			}
			flag = true;
			goto IL_005b;
		}
		int result = 0;
		goto IL_005c;
		IL_005b:
		result = (flag ? 1 : 0);
		goto IL_005c;
		IL_005c:
		return (byte)result != 0;
	}

	public bool haveMPoppet(MPoppets mstPet)
	{
		bool flag;
		foreach (RespPoppet value in poppets.Values)
		{
			if (value.Master.Id != mstPet.Id)
			{
				continue;
			}
			flag = true;
			goto IL_005b;
		}
		int result = 0;
		goto IL_005c;
		IL_005b:
		result = (flag ? 1 : 0);
		goto IL_005c;
		IL_005c:
		return (byte)result != 0;
	}

	public bool knowMWeapon(MWeapons mstWep)
	{
		return UserData.Current != null && UserData.Current.userMiscInfo.weaponBookData.isLook(mstWep);
	}

	public bool knowMPoppet(MPoppets mstPet)
	{
		return UserData.Current != null && UserData.Current.userMiscInfo.poppetBookData.isLook(mstPet);
	}

	public void haveAllBox()
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			return;
		}
		foreach (RespWeapon value in weapons.Values)
		{
			current.userMiscInfo.weaponBookData.have(value.Master);
		}
		foreach (RespPoppet value2 in poppets.Values)
		{
			current.userMiscInfo.poppetBookData.have(value2.Master);
		}
	}

	public RespWeapon boxMWeapon(MWeapons mstWep)
	{
		RespWeapon respWeapon;
		foreach (RespWeapon value in weapons.Values)
		{
			if (value.Master.Id != mstWep.Id)
			{
				continue;
			}
			respWeapon = value;
			goto IL_005b;
		}
		object result = null;
		goto IL_005c;
		IL_005b:
		result = respWeapon;
		goto IL_005c;
		IL_005c:
		return (RespWeapon)result;
	}

	public RespPoppet boxMPoppet(MPoppets mstPet)
	{
		RespPoppet respPoppet;
		foreach (RespPoppet value in poppets.Values)
		{
			if (value.Master.Id != mstPet.Id)
			{
				continue;
			}
			respPoppet = value;
			goto IL_005b;
		}
		object result = null;
		goto IL_005c;
		IL_005b:
		result = respPoppet;
		goto IL_005c;
		IL_005c:
		return (RespPoppet)result;
	}

	public void setBox(RespPlayerBox[] box)
	{
		if (box == null)
		{
			return;
		}
		HashSet<BoxId> hashSet = new HashSet<BoxId>();
		foreach (RespWeapon value in weapons.Values)
		{
			if (value.favorite != 0)
			{
				hashSet.Add(value.Id);
			}
		}
		foreach (RespPoppet value2 in poppets.Values)
		{
			if (value2.favorite != 0)
			{
				hashSet.Add(value2.Id);
			}
		}
		weapons.Clear();
		poppets.Clear();
		int i = 0;
		for (int length = box.Length; i < length; i = checked(i + 1))
		{
			if (box[i].IsWeapon)
			{
				RespWeapon respWeapon = box[i].toRespWeapon();
				weapons[respWeapon.Id] = respWeapon;
				respWeapon.favorite = (hashSet.Contains(respWeapon.Id) ? 1 : 0);
			}
			else if (box[i].IsPoppet)
			{
				RespPoppet respPoppet = box[i].toRespPoppet();
				poppets[respPoppet.Id] = respPoppet;
				respPoppet.favorite = (hashSet.Contains(respPoppet.Id) ? 1 : 0);
			}
		}
		haveAllBox();
		UserData.Current?.RefreshNewItem();
	}

	public void setWeaponBox(RespWeapon[] box)
	{
		if (box == null)
		{
			return;
		}
		HashSet<BoxId> hashSet = new HashSet<BoxId>();
		foreach (RespWeapon value in weapons.Values)
		{
			if (value.favorite != 0)
			{
				hashSet.Add(value.Id);
			}
		}
		weapons.Clear();
		int i = 0;
		for (int length = box.Length; i < length; i = checked(i + 1))
		{
			if (!box[i].IsValidInBox)
			{
				throw new AssertionFailedException("invalid weapon boxid(${w.Id})");
			}
			weapons[box[i].Id] = box[i];
			box[i].favorite = (hashSet.Contains(box[i].Id) ? 1 : 0);
		}
	}

	public void setPoppetBox(RespPoppet[] box)
	{
		if (box == null)
		{
			return;
		}
		HashSet<BoxId> hashSet = new HashSet<BoxId>();
		foreach (RespPoppet value in poppets.Values)
		{
			if (value.favorite != 0)
			{
				hashSet.Add(value.Id);
			}
		}
		poppets.Clear();
		int i = 0;
		for (int length = box.Length; i < length; i = checked(i + 1))
		{
			if (!box[i].IsValidInBox)
			{
				throw new AssertionFailedException("invalid poppet boxid(${p.Id})");
			}
			poppets[box[i].Id] = box[i];
			box[i].favorite = (hashSet.Contains(box[i].Id) ? 1 : 0);
		}
	}

	public void setBoxCapasity(int c)
	{
	}

	internal RespPlayerBox _0024get_AllItems_0024closure_00243386(RespWeapon _0024genarray_00241610)
	{
		return _0024genarray_00241610.RefPlayerBox;
	}

	internal RespPlayerBox _0024get_AllItems_0024closure_00243387(RespPoppet _0024genarray_00241611)
	{
		return _0024genarray_00241611.RefPlayerBox;
	}
}
