using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class RewardIconInfo : MonoBehaviour
{
	[Serializable]
	public enum Icon
	{
		Weapon,
		Pet,
		Treasure
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024open_002421449 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal GameObject _0024eff_002421450;

			internal ParticleSystem _0024openEffect_002421451;

			internal bool _0024enableSe_002421452;

			internal RewardIconInfo _0024self__002421453;

			public _0024(bool enableSe, RewardIconInfo self_)
			{
				_0024enableSe_002421452 = enableSe;
				_0024self__002421453 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024enableSe_002421452)
					{
						GameSoundManager.PlaySe(_0024self__002421453.seFile, 0);
					}
					if ((bool)_0024self__002421453.openEffectPrefab)
					{
						_0024eff_002421450 = (GameObject)UnityEngine.Object.Instantiate(_0024self__002421453.openEffectPrefab);
					}
					if ((bool)_0024eff_002421450)
					{
						_0024eff_002421450.transform.parent = _0024self__002421453.gameObject.transform;
						_0024eff_002421450.transform.localPosition = Vector3.zero;
						_0024eff_002421450.transform.localScale = Vector3.one;
						_0024openEffect_002421451 = _0024eff_002421450.GetComponent<ParticleSystem>();
					}
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
				case 3:
					if (!_0024openEffect_002421451.isStopped)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024self__002421453.DirectOpenIcon();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal bool _0024enableSe_002421454;

		internal RewardIconInfo _0024self__002421455;

		public _0024open_002421449(bool enableSe, RewardIconInfo self_)
		{
			_0024enableSe_002421454 = enableSe;
			_0024self__002421455 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024enableSe_002421454, _0024self__002421455);
		}
	}

	public WeaponInfo weaponInfo;

	public MuppetInfo petInfo;

	public TreasureInfo treasureInfo;

	private HUDSwitcher hudSwitcher;

	public GameObject openEffectPrefab;

	public GameObject normalEffectPrefab;

	public GameObject rareEffectPrefab;

	public GameObject supecialRareEffectPrefab;

	public string seFile;

	public Icon rewardIconType;

	protected RespReward curReward;

	private bool lastFavo;

	public bool isWeapon => rewardIconType == Icon.Weapon;

	public bool isPet => rewardIconType == Icon.Pet;

	public RespReward CurReward
	{
		get
		{
			return curReward;
		}
		set
		{
			curReward = value;
		}
	}

	public RewardIconInfo()
	{
		seFile = "se_map_treasure_get";
	}

	public void SetRespReward(RespReward reward)
	{
		curReward = reward;
		int num = 0;
		if (reward.TypeValue == 3)
		{
			RespWeapon respWeapon = reward.toRespWeapon();
			weaponInfo.IgnoreUnknown = true;
			weaponInfo.SetWeapon(respWeapon);
			petInfo.SetMuppet(null);
			rewardIconType = Icon.Weapon;
			num = respWeapon.Rare.Id;
		}
		else
		{
			if (reward.TypeValue != 4)
			{
				return;
			}
			weaponInfo.SetWeapon(null);
			RespPoppet respPoppet = reward.toRespPoppet();
			petInfo.IgnoreUnknown = true;
			petInfo.SetMuppet(respPoppet);
			rewardIconType = Icon.Pet;
			num = respPoppet.Rare.Id;
		}
		if ((bool)treasureInfo)
		{
			treasureInfo.SetState(num);
		}
		GameObject gameObject = normalEffectPrefab;
		if (5 <= num)
		{
			gameObject = supecialRareEffectPrefab;
		}
		else if (3 <= num)
		{
			gameObject = rareEffectPrefab;
		}
		if (gameObject != null)
		{
			GameObject gameObject2 = (GameObject)UnityEngine.Object.Instantiate(gameObject);
			gameObject2.transform.parent = this.gameObject.transform;
			gameObject2.transform.localPosition = new Vector3(0f, 0f, 0.1f);
			gameObject2.transform.localScale = Vector3.one;
			ParticleSystem component = gameObject2.GetComponent<ParticleSystem>();
			component.Play();
			UnityEngine.Object.Destroy(gameObject2, component.startLifetime);
		}
		if (!hudSwitcher)
		{
			hudSwitcher = this.gameObject.GetComponent<HUDSwitcher>();
		}
		hudSwitcher.SetActive(0, on: false);
		hudSwitcher.SetActive(1, on: false);
		hudSwitcher.SetActive(2, on: true);
	}

	public void OpenIcon(bool enableSe)
	{
		StartCoroutine(open(enableSe));
	}

	public void DirectOpenIcon()
	{
		hudSwitcher.SetActive(0, isWeapon);
		hudSwitcher.SetActive(1, isPet);
		hudSwitcher.SetActive(2, on: false);
	}

	private IEnumerator open(bool enableSe)
	{
		return new _0024open_002421449(enableSe, this).GetEnumerator();
	}

	public RespWeapon GetWeaponData()
	{
		return (!isWeapon) ? null : weaponInfo.LastWeapon;
	}

	public RespPoppet GetPetData()
	{
		return (!isPet) ? null : petInfo.LastMuppet;
	}

	public RespWeaponPoppet GetRespWeaponPoppet()
	{
		JsonBase jb = ((!isWeapon) ? ((JsonBase)GetPetData()) : ((JsonBase)GetWeaponData()));
		return new RespWeaponPoppet(jb);
	}

	private UIListItem GetIcon()
	{
		return isWeapon ? ((UIListItem)weaponInfo) : ((UIListItem)((!isPet) ? null : petInfo));
	}

	private void Update()
	{
		UIListItem icon = GetIcon();
		if (icon == null)
		{
			return;
		}
		RespWeaponPoppet respWeaponPoppet = GetRespWeaponPoppet();
		if (respWeaponPoppet != null)
		{
			RespPlayerBox respPlayerBox = RespPlayerBox.ConvertRespPlayerBox(respWeaponPoppet.data);
			if (respPlayerBox != null && UserData.Current.IsFavorite(respPlayerBox) != lastFavo)
			{
				lastFavo = !lastFavo;
				icon.SetFavorite(lastFavo);
			}
		}
	}
}
