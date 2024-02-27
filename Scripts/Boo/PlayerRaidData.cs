using System;
using System.Collections;
using Boo.Lang.Runtime;

[Serializable]
public class PlayerRaidData
{
	public bool isRaid;

	public EnumElements bonusWeaponElement;

	public EnumStyles bonusWeaponStyle;

	public float comboBonus;

	public PlayerRaidData()
	{
		comboBonus = 1f;
	}

	public void reset()
	{
		isRaid = false;
		bonusWeaponStyle = EnumStyles.Sword;
		bonusWeaponElement = EnumElements.fire;
		comboBonus = 1f;
	}

	public string toNguiJson()
	{
		Hashtable hashtable = new Hashtable();
		hashtable["isRaid"] = isRaid;
		hashtable["bonusWeaponElement"] = (int)bonusWeaponElement;
		hashtable["bonusWeaponStyle"] = (int)bonusWeaponStyle;
		hashtable["comboBonus"] = comboBonus;
		return NGUIJson.jsonEncode(hashtable);
	}

	public static PlayerRaidData fromNguiJson(string nj)
	{
		PlayerRaidData playerRaidData = new PlayerRaidData();
		Hashtable hashtable = NGUIJson.jsonDecode(nj) as Hashtable;
		if (hashtable.ContainsKey("isRaid"))
		{
			playerRaidData.isRaid = RuntimeServices.UnboxBoolean(hashtable["isRaid"]);
		}
		int num = default(int);
		if (hashtable.ContainsKey("bonusWeaponElement"))
		{
			num = RuntimeServices.UnboxInt32(hashtable["bonusWeaponElement"]);
		}
		playerRaidData.bonusWeaponElement = (EnumElements)num;
		int num2 = default(int);
		if (hashtable.ContainsKey("bonusWeaponStyle"))
		{
			num2 = RuntimeServices.UnboxInt32(hashtable["bonusWeaponStyle"]);
		}
		playerRaidData.bonusWeaponStyle = (EnumStyles)num2;
		if (hashtable.ContainsKey("comboBonus"))
		{
			playerRaidData.comboBonus = RuntimeServices.UnboxSingle(hashtable["comboBonus"]);
		}
		return playerRaidData;
	}

	public void copyFrom(PlayerRaidData arg)
	{
		isRaid = arg.isRaid;
		bonusWeaponElement = arg.bonusWeaponElement;
		bonusWeaponStyle = arg.bonusWeaponStyle;
		comboBonus = arg.comboBonus;
	}
}
