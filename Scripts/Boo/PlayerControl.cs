using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using GameAsset;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class PlayerControl : MerlinActionControl
{
	[Serializable]
	public class SpawnParam
	{
		public string gameObjectName;

		public Vector3 pos;

		public Quaternion rot;

		public EnumGenders reservedTenshiGender;

		public EnumGenders reservedAkumaGender;

		public bool useReservedGender;

		public RACE_TYPE initialRace;

		public bool initWithSkillPacks;

		public BATTLE_MODE reservedBattleMode;

		public bool useReservedBattleMode;

		public bool reqLoadAssetsInMotPack;

		public WeaponEquipments weaponEquipments;

		public bool withAutoBattle;

		private bool _0024initialized__PlayerControl_SpawnParam_0024;

		public SpawnParam()
		{
			if (!_0024initialized__PlayerControl_SpawnParam_0024)
			{
				gameObjectName = "C0000_000_MA_ROOT";
				pos = Vector3.zero;
				rot = Quaternion.identity;
				reservedTenshiGender = EnumGenders.male;
				reservedAkumaGender = EnumGenders.male;
				initialRace = RACE_TYPE.Tensi;
				initWithSkillPacks = true;
				reservedBattleMode = BATTLE_MODE.Battle;
				reqLoadAssetsInMotPack = true;
				_0024initialized__PlayerControl_SpawnParam_0024 = true;
			}
			initAsDefault();
		}

		public SpawnParam(Vector3 _pos, Quaternion _rot)
		{
			if (!_0024initialized__PlayerControl_SpawnParam_0024)
			{
				gameObjectName = "C0000_000_MA_ROOT";
				pos = Vector3.zero;
				rot = Quaternion.identity;
				reservedTenshiGender = EnumGenders.male;
				reservedAkumaGender = EnumGenders.male;
				initialRace = RACE_TYPE.Tensi;
				initWithSkillPacks = true;
				reservedBattleMode = BATTLE_MODE.Battle;
				reqLoadAssetsInMotPack = true;
				_0024initialized__PlayerControl_SpawnParam_0024 = true;
			}
			initAsDefault();
			pos = _pos;
			rot = _rot;
		}

		public SpawnParam(Vector3 _pos, Quaternion _rot, BATTLE_MODE _bmode)
		{
			if (!_0024initialized__PlayerControl_SpawnParam_0024)
			{
				gameObjectName = "C0000_000_MA_ROOT";
				pos = Vector3.zero;
				rot = Quaternion.identity;
				reservedTenshiGender = EnumGenders.male;
				reservedAkumaGender = EnumGenders.male;
				initialRace = RACE_TYPE.Tensi;
				initWithSkillPacks = true;
				reservedBattleMode = BATTLE_MODE.Battle;
				reqLoadAssetsInMotPack = true;
				_0024initialized__PlayerControl_SpawnParam_0024 = true;
			}
			initAsDefault();
			pos = _pos;
			rot = _rot;
			setBattleMode(_bmode);
		}

		public SpawnParam(Vector3 _pos, Quaternion _rot, EnumGenders tenshiGender, EnumGenders akumaGender)
		{
			if (!_0024initialized__PlayerControl_SpawnParam_0024)
			{
				gameObjectName = "C0000_000_MA_ROOT";
				pos = Vector3.zero;
				rot = Quaternion.identity;
				reservedTenshiGender = EnumGenders.male;
				reservedAkumaGender = EnumGenders.male;
				initialRace = RACE_TYPE.Tensi;
				initWithSkillPacks = true;
				reservedBattleMode = BATTLE_MODE.Battle;
				reqLoadAssetsInMotPack = true;
				_0024initialized__PlayerControl_SpawnParam_0024 = true;
			}
			initAsDefault();
			pos = _pos;
			rot = _rot;
			reservedTenshiGender = tenshiGender;
			reservedAkumaGender = akumaGender;
			useReservedGender = true;
		}

		public SpawnParam(Vector3 _pos, Quaternion _rot, EnumGenders tenshiGender, EnumGenders akumaGender, BATTLE_MODE bmode, bool withSkillPack)
		{
			if (!_0024initialized__PlayerControl_SpawnParam_0024)
			{
				gameObjectName = "C0000_000_MA_ROOT";
				pos = Vector3.zero;
				rot = Quaternion.identity;
				reservedTenshiGender = EnumGenders.male;
				reservedAkumaGender = EnumGenders.male;
				initialRace = RACE_TYPE.Tensi;
				initWithSkillPacks = true;
				reservedBattleMode = BATTLE_MODE.Battle;
				reqLoadAssetsInMotPack = true;
				_0024initialized__PlayerControl_SpawnParam_0024 = true;
			}
			initAsDefault();
			pos = _pos;
			rot = _rot;
			reservedTenshiGender = tenshiGender;
			reservedAkumaGender = akumaGender;
			useReservedGender = true;
			setBattleMode(bmode);
			initWithSkillPacks = withSkillPack;
		}

		private void initAsDefault()
		{
			UserData current = UserData.Current;
			gameObjectName = "C0000_000_MA_ROOT";
			pos = Vector3.zero;
			rot = Quaternion.identity;
			reservedTenshiGender = (EnumGenders)current.AngelGender;
			reservedAkumaGender = (EnumGenders)current.DemonGender;
			initialRace = current.PlayerRace;
			initWithSkillPacks = true;
			reservedBattleMode = BATTLE_MODE.Battle;
			useReservedBattleMode = false;
			reqLoadAssetsInMotPack = true;
			weaponEquipments = WeaponEquipments.FromUserData();
			withAutoBattle = false;
		}

		public void setBattleMode(BATTLE_MODE _bmode)
		{
			reservedBattleMode = _bmode;
			useReservedBattleMode = true;
		}

		public void setNonBattleMode()
		{
			setBattleMode(BATTLE_MODE.Non_Battle);
		}
	}

	[Serializable]
	public class KaihiTimeInfo
	{
		public bool enabled;

		public float start;

		public float end;

		public bool Disabled => !enabled;

		public void enable(float _start, float _end)
		{
			enabled = true;
			start = _start;
			end = _end;
		}

		public void disable()
		{
			enabled = false;
		}

		public bool inTime(float motionTime)
		{
			bool num = enabled;
			if (num)
			{
				num = !(start > motionTime);
			}
			if (num)
			{
				num = motionTime < end;
			}
			return num;
		}

		public bool notInTime(float motionTime)
		{
			return !inTime(motionTime);
		}
	}

	[Serializable]
	public enum SKILL_SLOT
	{
		WeaponSkill1,
		WeaponSkill2,
		Change,
		Max
	}

	[Serializable]
	public enum STATE
	{
		Battle,
		Wait,
		Max
	}

	[Serializable]
	public enum BATTLE_MODE
	{
		Battle,
		Non_Battle
	}

	[Serializable]
	public enum SceneMode
	{
		Normal,
		Town,
		Raid
	}

	[Serializable]
	internal class _0024initializeCooldowns_0024locals_002414354
	{
		internal __PlayerControl_initializeCooldowns_0024callable168_0024553_13__ _0024endCooldown;

		internal __PlayerControl_initializeCooldowns_0024callable169_0024569_13__ _0024enableSkillHUD;
	}

	[Serializable]
	internal class _0024loadMotionPack_0024locals_002414355
	{
		internal MerlinMotionPack _0024loadedPack;
	}

	[Serializable]
	internal class _0024loadRaceModels_0024locals_002414356
	{
		internal PlayerModelSettings _0024settingsTensi;

		internal PlayerModelSettings _0024settingsAkuma;
	}

	[Serializable]
	internal class _0024setupMotionPackInfo_0024locals_002414357
	{
		internal string _0024packName;
	}

	[Serializable]
	internal class _0024PVOICE_0024locals_002414358
	{
		internal string _0024seName;
	}

	[Serializable]
	internal class _0024JUST_DODGE_0024locals_002414359
	{
		internal float _0024time;
	}

	[Serializable]
	internal class _0024initializeCooldowns_0024closure_00243871
	{
		internal _0024initializeCooldowns_0024locals_002414354 _0024_0024locals_002414821;

		public _0024initializeCooldowns_0024closure_00243871(_0024initializeCooldowns_0024locals_002414354 _0024_0024locals_002414821)
		{
			this._0024_0024locals_002414821 = _0024_0024locals_002414821;
		}

		public void Invoke()
		{
			_0024_0024locals_002414821._0024endCooldown(0, SQEX_SoundPlayerData.SE.weapon_ready);
		}
	}

	[Serializable]
	internal class _0024initializeCooldowns_0024closure_00243872
	{
		internal _0024initializeCooldowns_0024locals_002414354 _0024_0024locals_002414822;

		public _0024initializeCooldowns_0024closure_00243872(_0024initializeCooldowns_0024locals_002414354 _0024_0024locals_002414822)
		{
			this._0024_0024locals_002414822 = _0024_0024locals_002414822;
		}

		public void Invoke()
		{
			_0024_0024locals_002414822._0024endCooldown(1, SQEX_SoundPlayerData.SE.weapon_ready);
		}
	}

	[Serializable]
	internal class _0024initializeCooldowns_0024closure_00243873
	{
		internal _0024initializeCooldowns_0024locals_002414354 _0024_0024locals_002414823;

		public _0024initializeCooldowns_0024closure_00243873(_0024initializeCooldowns_0024locals_002414354 _0024_0024locals_002414823)
		{
			this._0024_0024locals_002414823 = _0024_0024locals_002414823;
		}

		public void Invoke()
		{
			_0024_0024locals_002414823._0024endCooldown(2, SQEX_SoundPlayerData.SE.change_ready);
		}
	}

	[Serializable]
	internal class _0024initializeCooldowns_0024closure_00243875
	{
		internal _0024initializeCooldowns_0024locals_002414354 _0024_0024locals_002414824;

		public _0024initializeCooldowns_0024closure_00243875(_0024initializeCooldowns_0024locals_002414354 _0024_0024locals_002414824)
		{
			this._0024_0024locals_002414824 = _0024_0024locals_002414824;
		}

		public void Invoke(float v)
		{
			_0024_0024locals_002414824._0024enableSkillHUD(0, v);
		}
	}

	[Serializable]
	internal class _0024initializeCooldowns_0024closure_00243876
	{
		internal _0024initializeCooldowns_0024locals_002414354 _0024_0024locals_002414825;

		public _0024initializeCooldowns_0024closure_00243876(_0024initializeCooldowns_0024locals_002414354 _0024_0024locals_002414825)
		{
			this._0024_0024locals_002414825 = _0024_0024locals_002414825;
		}

		public void Invoke(float v)
		{
			_0024_0024locals_002414825._0024enableSkillHUD(1, v);
		}
	}

	[Serializable]
	internal class _0024initializeCooldowns_0024closure_00243877
	{
		internal _0024initializeCooldowns_0024locals_002414354 _0024_0024locals_002414826;

		public _0024initializeCooldowns_0024closure_00243877(_0024initializeCooldowns_0024locals_002414354 _0024_0024locals_002414826)
		{
			this._0024_0024locals_002414826 = _0024_0024locals_002414826;
		}

		public void Invoke(float v)
		{
			_0024_0024locals_002414826._0024enableSkillHUD(2, v);
		}
	}

	[Serializable]
	internal class _0024loadMotionPack_0024_loadPackSub_00243883
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002417154 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal RuntimeAssetBundleDB.Req _0024r_002417155;

				internal string _0024_0024dialog_assert1_00241323_002417156;

				internal string _0024_0024dialog_assert1_00241324_002417157;

				internal string _0024_0024dialog_assert1_00241325_002417158;

				internal string _0024packName_002417159;

				internal _0024loadMotionPack_0024_loadPackSub_00243883 _0024self__002417160;

				public _0024(string packName, _0024loadMotionPack_0024_loadPackSub_00243883 self_)
				{
					_0024packName_002417159 = packName;
					_0024self__002417160 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					switch (_state)
					{
					default:
						_0024r_002417155 = RuntimeAssetBundleDB.Instance.loadPrefab(_0024packName_002417159);
						goto case 2;
					case 2:
						if (!_0024r_002417155.IsEnd)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						if (!_0024r_002417155.IsOk)
						{
							_0024_0024dialog_assert1_00241323_002417156 = new StringBuilder("ロードエラー: ").Append(_0024r_002417155.AssetPath).Append(" - ").Append(_0024r_002417155.Error)
								.ToString();
							MerlinServer.FatalErrorDialog(_0024_0024dialog_assert1_00241323_002417156, "Assets/Scripts/Character/PlayerControl.boo(1240)", string.Empty);
							Debug.LogError(_0024_0024dialog_assert1_00241323_002417156);
							TestFlightUnity.PassCheckpoint(_0024_0024dialog_assert1_00241323_002417156);
							throw new Exception(_0024_0024dialog_assert1_00241323_002417156);
						}
						if (!(_0024r_002417155.Prefab != null))
						{
							_0024_0024dialog_assert1_00241324_002417157 = new StringBuilder("ロードエラー: ").Append(_0024r_002417155.AssetPath).Append(" - ").Append(_0024r_002417155.Error)
								.ToString();
							MerlinServer.FatalErrorDialog(_0024_0024dialog_assert1_00241324_002417157, "Assets/Scripts/Character/PlayerControl.boo(1241)", string.Empty);
							Debug.LogError(_0024_0024dialog_assert1_00241324_002417157);
							TestFlightUnity.PassCheckpoint(_0024_0024dialog_assert1_00241324_002417157);
							throw new Exception(_0024_0024dialog_assert1_00241324_002417157);
						}
						_0024self__002417160._0024_0024locals_002414827._0024loadedPack = _0024r_002417155.Prefab.GetComponent<MerlinMotionPack>();
						if (!(_0024self__002417160._0024_0024locals_002414827._0024loadedPack != null))
						{
							_0024_0024dialog_assert1_00241325_002417158 = new StringBuilder().Append(_0024packName_002417159).Append("はMerlinMotionPackではない").ToString();
							MerlinServer.FatalErrorDialog(_0024_0024dialog_assert1_00241325_002417158, "Assets/Scripts/Character/PlayerControl.boo(1243)", string.Empty);
							Debug.LogError(_0024_0024dialog_assert1_00241325_002417158);
							TestFlightUnity.PassCheckpoint(_0024_0024dialog_assert1_00241325_002417158);
							throw new Exception(_0024_0024dialog_assert1_00241325_002417158);
						}
						_0024self__002417160._0024this_002414828.Mmpc.addMotionPack(_0024self__002417160._0024_0024locals_002414827._0024loadedPack);
						YieldDefault(1);
						goto case 1;
					case 1:
						result = 0;
						break;
					}
					return (byte)result != 0;
				}
			}

			internal string _0024packName_002417161;

			internal _0024loadMotionPack_0024_loadPackSub_00243883 _0024self__002417162;

			public _0024Invoke_002417154(string packName, _0024loadMotionPack_0024_loadPackSub_00243883 self_)
			{
				_0024packName_002417161 = packName;
				_0024self__002417162 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024packName_002417161, _0024self__002417162);
			}
		}

		internal _0024loadMotionPack_0024locals_002414355 _0024_0024locals_002414827;

		internal PlayerControl _0024this_002414828;

		public _0024loadMotionPack_0024_loadPackSub_00243883(_0024loadMotionPack_0024locals_002414355 _0024_0024locals_002414827, PlayerControl _0024this_002414828)
		{
			this._0024_0024locals_002414827 = _0024_0024locals_002414827;
			this._0024this_002414828 = _0024this_002414828;
		}

		public IEnumerator Invoke(string packName)
		{
			return new _0024Invoke_002417154(packName, this).GetEnumerator();
		}
	}

	[Serializable]
	internal class _0024loadRaceModels_0024closure_00243892
	{
		internal _0024loadRaceModels_0024locals_002414356 _0024_0024locals_002414829;

		public _0024loadRaceModels_0024closure_00243892(_0024loadRaceModels_0024locals_002414356 _0024_0024locals_002414829)
		{
			this._0024_0024locals_002414829 = _0024_0024locals_002414829;
		}

		public PlayerModelSettings Invoke(PlayerModelSettings s)
		{
			return _0024_0024locals_002414829._0024settingsTensi = s;
		}
	}

	[Serializable]
	internal class _0024loadRaceModels_0024closure_00243893
	{
		internal _0024loadRaceModels_0024locals_002414356 _0024_0024locals_002414830;

		public _0024loadRaceModels_0024closure_00243893(_0024loadRaceModels_0024locals_002414356 _0024_0024locals_002414830)
		{
			this._0024_0024locals_002414830 = _0024_0024locals_002414830;
		}

		public PlayerModelSettings Invoke(PlayerModelSettings s)
		{
			return _0024_0024locals_002414830._0024settingsAkuma = s;
		}
	}

	[Serializable]
	internal class _0024setupMotionPackInfo_0024singleInfo_00243894
	{
		internal PlayerControl _0024this_002414831;

		internal _0024setupMotionPackInfo_0024locals_002414357 _0024_0024locals_002414832;

		public _0024setupMotionPackInfo_0024singleInfo_00243894(PlayerControl _0024this_002414831, _0024setupMotionPackInfo_0024locals_002414357 _0024_0024locals_002414832)
		{
			this._0024this_002414831 = _0024this_002414831;
			this._0024_0024locals_002414832 = _0024_0024locals_002414832;
		}

		public float Invoke(string n, float defval)
		{
			return _0024this_002414831.Mmpc.getPackMiscInfoAsSingle(_0024_0024locals_002414832._0024packName, n, defval);
		}
	}

	[Serializable]
	internal class _0024setupMotionPackInfo_0024boolInfo_00243895
	{
		internal _0024setupMotionPackInfo_0024locals_002414357 _0024_0024locals_002414833;

		internal PlayerControl _0024this_002414834;

		public _0024setupMotionPackInfo_0024boolInfo_00243895(_0024setupMotionPackInfo_0024locals_002414357 _0024_0024locals_002414833, PlayerControl _0024this_002414834)
		{
			this._0024_0024locals_002414833 = _0024_0024locals_002414833;
			this._0024this_002414834 = _0024this_002414834;
		}

		public bool Invoke(string n, bool defval)
		{
			return _0024this_002414834.Mmpc.getPackMiscInfoAsBool(_0024_0024locals_002414833._0024packName, n, defval);
		}
	}

	[Serializable]
	internal class _0024PVOICE_0024closure_00243916
	{
		internal PlayerControl _0024this_002414835;

		internal _0024PVOICE_0024locals_002414358 _0024_0024locals_002414836;

		public _0024PVOICE_0024closure_00243916(PlayerControl _0024this_002414835, _0024PVOICE_0024locals_002414358 _0024_0024locals_002414836)
		{
			this._0024this_002414835 = _0024this_002414835;
			this._0024_0024locals_002414836 = _0024_0024locals_002414836;
		}

		public void Invoke()
		{
			_0024this_002414835.PlayerVoice(_0024_0024locals_002414836._0024seName, 0);
		}
	}

	[Serializable]
	internal class _0024JUST_DODGE_0024closure_00243918
	{
		internal PlayerControl _0024this_002414837;

		internal _0024JUST_DODGE_0024locals_002414359 _0024_0024locals_002414838;

		public _0024JUST_DODGE_0024closure_00243918(PlayerControl _0024this_002414837, _0024JUST_DODGE_0024locals_002414359 _0024_0024locals_002414838)
		{
			this._0024this_002414837 = _0024this_002414837;
			this._0024_0024locals_002414838 = _0024_0024locals_002414838;
		}

		public void Invoke()
		{
			_0024this_002414837.justDodge.start(_0024_0024locals_002414838._0024time);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ChangeTensiAkuma_002416944 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal IEnumerator _0024_0024sco_0024temp_00241303_002416945;

			internal PlayerControl _0024self__002416946;

			public _0024(PlayerControl self_)
			{
				_0024self__002416946 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024sco_0024temp_00241303_002416945 = _0024self__002416946.ChangeTensiAkuma(withSe: true, withEffect: true);
					if (_0024_0024sco_0024temp_00241303_002416945 != null)
					{
						result = (Yield(2, _0024self__002416946.StartCoroutine(_0024_0024sco_0024temp_00241303_002416945)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PlayerControl _0024self__002416947;

		public _0024ChangeTensiAkuma_002416944(PlayerControl self_)
		{
			_0024self__002416947 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002416947);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ChangeTensiAkuma_002416948 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal IEnumerator _0024_0024sco_0024temp_00241304_002416949;

			internal IEnumerator _0024_0024sco_0024temp_00241305_002416950;

			internal bool _0024withSe_002416951;

			internal bool _0024withEffect_002416952;

			internal PlayerControl _0024self__002416953;

			public _0024(bool withSe, bool withEffect, PlayerControl self_)
			{
				_0024withSe_002416951 = withSe;
				_0024withEffect_002416952 = withEffect;
				_0024self__002416953 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__002416953.IsTensi)
					{
						_0024_0024sco_0024temp_00241304_002416949 = _0024self__002416953.ChangeTensiAkuma(RACE_TYPE.Akuma, _0024withSe_002416951, _0024withEffect_002416952);
						if (_0024_0024sco_0024temp_00241304_002416949 != null)
						{
							result = (Yield(2, _0024self__002416953.StartCoroutine(_0024_0024sco_0024temp_00241304_002416949)) ? 1 : 0);
							break;
						}
					}
					else
					{
						_0024_0024sco_0024temp_00241305_002416950 = _0024self__002416953.ChangeTensiAkuma(RACE_TYPE.Tensi, _0024withSe_002416951, _0024withEffect_002416952);
						if (_0024_0024sco_0024temp_00241305_002416950 != null)
						{
							result = (Yield(3, _0024self__002416953.StartCoroutine(_0024_0024sco_0024temp_00241305_002416950)) ? 1 : 0);
							break;
						}
					}
					goto case 2;
				case 2:
				case 3:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal bool _0024withSe_002416954;

		internal bool _0024withEffect_002416955;

		internal PlayerControl _0024self__002416956;

		public _0024ChangeTensiAkuma_002416948(bool withSe, bool withEffect, PlayerControl self_)
		{
			_0024withSe_002416954 = withSe;
			_0024withEffect_002416955 = withEffect;
			_0024self__002416956 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024withSe_002416954, _0024withEffect_002416955, _0024self__002416956);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ChangeTensiAkuma_002416957 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal IEnumerator _0024_0024sco_0024temp_00241306_002416958;

			internal RACE_TYPE _0024rtype_002416959;

			internal PlayerControl _0024self__002416960;

			public _0024(RACE_TYPE rtype, PlayerControl self_)
			{
				_0024rtype_002416959 = rtype;
				_0024self__002416960 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024sco_0024temp_00241306_002416958 = _0024self__002416960.ChangeTensiAkuma(_0024rtype_002416959, withSe: true, withEffect: true);
					if (_0024_0024sco_0024temp_00241306_002416958 != null)
					{
						result = (Yield(2, _0024self__002416960.StartCoroutine(_0024_0024sco_0024temp_00241306_002416958)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal RACE_TYPE _0024rtype_002416961;

		internal PlayerControl _0024self__002416962;

		public _0024ChangeTensiAkuma_002416957(RACE_TYPE rtype, PlayerControl self_)
		{
			_0024rtype_002416961 = rtype;
			_0024self__002416962 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024rtype_002416961, _0024self__002416962);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ChangeTensiAkuma_002416963 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal IEnumerator _0024_0024sco_0024temp_00241307_002416964;

			internal RACE_TYPE _0024rtype_002416965;

			internal bool _0024withSe_002416966;

			internal PlayerControl _0024self__002416967;

			public _0024(RACE_TYPE rtype, bool withSe, PlayerControl self_)
			{
				_0024rtype_002416965 = rtype;
				_0024withSe_002416966 = withSe;
				_0024self__002416967 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						if (DebugKillBeforeChangeMethod)
						{
							_0024self__002416967.HitAttack(99999999, YarareTypes.Down, null);
						}
						if (_0024rtype_002416965 == _0024self__002416967.raceType || _0024self__002416967.IsDead)
						{
							goto case 1;
						}
						_0024self__002416967.initializingCounter++;
						if (_0024withSe_002416966)
						{
							_0024self__002416967.playSE(_0024self__002416967.raceChange_4SQEX_SE);
						}
						_0024self__002416967.raceType = _0024rtype_002416965;
						UserData.Current.PlayerRace = _0024self__002416967.raceType;
						_0024self__002416967.activateRaceObjects(_0024self__002416967.raceType);
						_0024_0024sco_0024temp_00241307_002416964 = _0024self__002416967.activateMotionPacks();
						if (_0024_0024sco_0024temp_00241307_002416964 != null)
						{
							result = (Yield(2, _0024self__002416967.StartCoroutine(_0024_0024sco_0024temp_00241307_002416964)) ? 1 : 0);
							break;
						}
						goto case 2;
					case 2:
						_0024self__002416967.showOrHideWeapon();
						_0024self__002416967.setSkillIcon();
						_0024self__002416967.setWeaponElementIcon();
						_0024self__002416967.reInitWeaponCooldownTime();
						if (DebugKillInChangeMethod)
						{
							_0024self__002416967.HitAttack(99999999, YarareTypes.Down, null);
						}
						if (!_0024self__002416967.IsDead)
						{
							_0024self__002416967.finalizeChangeIfAlive();
							_0024self__002416967.reqSkillAfterChange = _0024self__002416967.IsBattleMode;
						}
						ShadowSelector.Setup(_0024self__002416967.gameObject);
						if (DebugKillAfterChangeMethod)
						{
							_0024self__002416967.HitAttack(99999999, YarareTypes.Down, null);
						}
						_0024self__002416967.initializingCounter--;
						YieldDefault(1);
						goto case 1;
					case 1:
						result = 0;
						break;
					}
				}
				return (byte)result != 0;
			}
		}

		internal RACE_TYPE _0024rtype_002416968;

		internal bool _0024withSe_002416969;

		internal PlayerControl _0024self__002416970;

		public _0024ChangeTensiAkuma_002416963(RACE_TYPE rtype, bool withSe, PlayerControl self_)
		{
			_0024rtype_002416968 = rtype;
			_0024withSe_002416969 = withSe;
			_0024self__002416970 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024rtype_002416968, _0024withSe_002416969, _0024self__002416970);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ChangeToTensi_002416971 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal IEnumerator _0024_0024sco_0024temp_00241308_002416972;

			internal PlayerControl _0024self__002416973;

			public _0024(PlayerControl self_)
			{
				_0024self__002416973 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024sco_0024temp_00241308_002416972 = _0024self__002416973.ChangeToTensi(withSe: true, withEffect: true);
					if (_0024_0024sco_0024temp_00241308_002416972 != null)
					{
						result = (Yield(2, _0024self__002416973.StartCoroutine(_0024_0024sco_0024temp_00241308_002416972)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PlayerControl _0024self__002416974;

		public _0024ChangeToTensi_002416971(PlayerControl self_)
		{
			_0024self__002416974 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002416974);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ChangeToTensi_002416975 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal IEnumerator _0024_0024sco_0024temp_00241309_002416976;

			internal bool _0024withSe_002416977;

			internal bool _0024withEffect_002416978;

			internal PlayerControl _0024self__002416979;

			public _0024(bool withSe, bool withEffect, PlayerControl self_)
			{
				_0024withSe_002416977 = withSe;
				_0024withEffect_002416978 = withEffect;
				_0024self__002416979 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__002416979.raceType == RACE_TYPE.Tensi)
					{
						goto case 1;
					}
					_0024_0024sco_0024temp_00241309_002416976 = _0024self__002416979.ChangeTensiAkuma(RACE_TYPE.Tensi, _0024withSe_002416977, _0024withEffect_002416978);
					if (_0024_0024sco_0024temp_00241309_002416976 != null)
					{
						result = (Yield(2, _0024self__002416979.StartCoroutine(_0024_0024sco_0024temp_00241309_002416976)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal bool _0024withSe_002416980;

		internal bool _0024withEffect_002416981;

		internal PlayerControl _0024self__002416982;

		public _0024ChangeToTensi_002416975(bool withSe, bool withEffect, PlayerControl self_)
		{
			_0024withSe_002416980 = withSe;
			_0024withEffect_002416981 = withEffect;
			_0024self__002416982 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024withSe_002416980, _0024withEffect_002416981, _0024self__002416982);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ChangeToAkuma_002416983 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal IEnumerator _0024_0024sco_0024temp_00241310_002416984;

			internal PlayerControl _0024self__002416985;

			public _0024(PlayerControl self_)
			{
				_0024self__002416985 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024_0024sco_0024temp_00241310_002416984 = _0024self__002416985.ChangeToAkuma(withSe: true, withEffect: true);
					if (_0024_0024sco_0024temp_00241310_002416984 != null)
					{
						result = (Yield(2, _0024self__002416985.StartCoroutine(_0024_0024sco_0024temp_00241310_002416984)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PlayerControl _0024self__002416986;

		public _0024ChangeToAkuma_002416983(PlayerControl self_)
		{
			_0024self__002416986 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002416986);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ChangeToAkuma_002416987 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal IEnumerator _0024_0024sco_0024temp_00241311_002416988;

			internal bool _0024withSe_002416989;

			internal bool _0024withEffect_002416990;

			internal PlayerControl _0024self__002416991;

			public _0024(bool withSe, bool withEffect, PlayerControl self_)
			{
				_0024withSe_002416989 = withSe;
				_0024withEffect_002416990 = withEffect;
				_0024self__002416991 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__002416991.raceType == RACE_TYPE.Akuma)
					{
						goto case 1;
					}
					_0024_0024sco_0024temp_00241311_002416988 = _0024self__002416991.ChangeTensiAkuma(RACE_TYPE.Akuma, _0024withSe_002416989, _0024withEffect_002416990);
					if (_0024_0024sco_0024temp_00241311_002416988 != null)
					{
						result = (Yield(2, _0024self__002416991.StartCoroutine(_0024_0024sco_0024temp_00241311_002416988)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal bool _0024withSe_002416992;

		internal bool _0024withEffect_002416993;

		internal PlayerControl _0024self__002416994;

		public _0024ChangeToAkuma_002416987(bool withSe, bool withEffect, PlayerControl self_)
		{
			_0024withSe_002416992 = withSe;
			_0024withEffect_002416993 = withEffect;
			_0024self__002416994 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024withSe_002416992, _0024withEffect_002416993, _0024self__002416994);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024loadMotionPack_002416995 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal RespWeapon[] _0024mainWpns_002416996;

			internal Boo.Lang.List<string> _0024stylePackNames_002416997;

			internal RespWeapon _0024w_002416998;

			internal string _0024_0024dialog_assert1_00241322_002416999;

			internal string _0024pname_002417000;

			internal __PlayerControl_loadMotionPack_0024callable170_00241237_13__ _0024_loadPackSub_002417001;

			internal string _0024spkName_002417002;

			internal IEnumerator _0024_0024sco_0024temp_00241326_002417003;

			internal IEnumerator _0024_0024sco_0024temp_00241327_002417004;

			internal string _0024_0024dialog_assert1_00241328_002417005;

			internal string _0024stylePackNames_002417006;

			internal int _0024_00248731_002417007;

			internal RespWeapon[] _0024_00248732_002417008;

			internal int _0024_00248733_002417009;

			internal IEnumerator<string> _0024_0024iterator_002413509_002417010;

			internal IEnumerator<string> _0024_0024iterator_002413510_002417011;

			internal _0024loadMotionPack_0024locals_002414355 _0024_0024locals_002417012;

			internal WeaponEquipments _0024wpns_002417013;

			internal PlayerControl _0024self__002417014;

			public _0024(WeaponEquipments wpns, PlayerControl self_)
			{
				_0024wpns_002417013 = wpns;
				_0024self__002417014 = self_;
			}

			public override bool MoveNext()
			{
				bool flag;
				int result;
				checked
				{
					try
					{
						switch (_state)
						{
						default:
							_0024_0024locals_002417012 = new _0024loadMotionPack_0024locals_002414355();
							_0024mainWpns_002416996 = new RespWeapon[2] { _0024wpns_002417013.MainTenshiWeapon, _0024wpns_002417013.MainAkumaWeapon };
							_0024stylePackNames_002416997 = new Boo.Lang.List<string>();
							_0024_00248731_002417007 = 0;
							_0024_00248732_002417008 = _0024mainWpns_002416996;
							for (_0024_00248733_002417009 = _0024_00248732_002417008.Length; _0024_00248731_002417007 < _0024_00248733_002417009; _0024_00248731_002417007++)
							{
								if (_0024_00248732_002417008[_0024_00248731_002417007] == null || _0024_00248732_002417008[_0024_00248731_002417007].Style == null)
								{
									_0024_0024dialog_assert1_00241322_002416999 = new StringBuilder("weapon error: w=").Append(_0024_00248732_002417008[_0024_00248731_002417007]).ToString();
									MerlinServer.FatalErrorDialog(_0024_0024dialog_assert1_00241322_002416999, "Assets/Scripts/Character/PlayerControl.boo(1231)", string.Empty);
									Debug.LogError(_0024_0024dialog_assert1_00241322_002416999);
									TestFlightUnity.PassCheckpoint(_0024_0024dialog_assert1_00241322_002416999);
									throw new Exception(_0024_0024dialog_assert1_00241322_002416999);
								}
								_0024pname_002417000 = PackName(unchecked((EnumStyles)_0024_00248732_002417008[_0024_00248731_002417007].Style.Id));
								if (!_0024stylePackNames_002416997.Contains(_0024pname_002417000))
								{
									_0024stylePackNames_002416997.Add(_0024pname_002417000);
								}
							}
							_0024_0024locals_002417012._0024loadedPack = null;
							_0024_loadPackSub_002417001 = new _0024loadMotionPack_0024_loadPackSub_00243883(_0024_0024locals_002417012, _0024self__002417014).Invoke;
							_0024_0024iterator_002413509_002417010 = _0024stylePackNames_002416997.GetEnumerator();
							_state = 2;
							goto case 3;
						case 3:
							while (_0024_0024iterator_002413509_002417010.MoveNext())
							{
								_0024spkName_002417002 = _0024_0024iterator_002413509_002417010.Current;
								if (!(_0024self__002417014.Mmpc.getPack(_0024spkName_002417002) == null))
								{
									continue;
								}
								_0024_0024sco_0024temp_00241326_002417003 = _0024_loadPackSub_002417001(_0024spkName_002417002);
								if (_0024_0024sco_0024temp_00241326_002417003 == null)
								{
									continue;
								}
								flag = Yield(3, _0024self__002417014.StartCoroutine(_0024_0024sco_0024temp_00241326_002417003));
								goto IL_03b3;
							}
							_state = 1;
							_0024ensure2();
							if (!(_0024self__002417014.eventMotionPack == null))
							{
								goto IL_0317;
							}
							_0024_0024sco_0024temp_00241327_002417004 = _0024_loadPackSub_002417001("mp_player_000_event");
							if (_0024_0024sco_0024temp_00241327_002417004 == null)
							{
								goto case 4;
							}
							flag = Yield(4, _0024self__002417014.StartCoroutine(_0024_0024sco_0024temp_00241327_002417004));
							goto IL_03b3;
						case 4:
							if (!(_0024_0024locals_002417012._0024loadedPack != null))
							{
								_0024_0024dialog_assert1_00241328_002417005 = "loadedPack of mp_player_000_event is null";
								MerlinServer.FatalErrorDialog(_0024_0024dialog_assert1_00241328_002417005, "Assets/Scripts/Character/PlayerControl.boo(1255)", string.Empty);
								Debug.LogError(_0024_0024dialog_assert1_00241328_002417005);
								TestFlightUnity.PassCheckpoint(_0024_0024dialog_assert1_00241328_002417005);
								throw new Exception(_0024_0024dialog_assert1_00241328_002417005);
							}
							_0024self__002417014.eventMotionPack = _0024_0024locals_002417012._0024loadedPack;
							goto IL_0317;
						case 5:
							break;
						case 1:
						case 2:
							goto end_IL_0000;
							IL_0317:
							_0024_0024iterator_002413510_002417011 = _0024stylePackNames_002416997.GetEnumerator();
							try
							{
								while (_0024_0024iterator_002413510_002417011.MoveNext())
								{
									_0024stylePackNames_002417006 = _0024_0024iterator_002413510_002417011.Current;
									_0024self__002417014.Mmpc.setPackHighPrio(_0024stylePackNames_002417006);
								}
							}
							finally
							{
								_0024_0024iterator_002413510_002417011.Dispose();
							}
							break;
						}
						if (_0024self__002417014.Mmpc.HasAnyCommands)
						{
							flag = YieldDefault(5);
							goto IL_03b3;
						}
						YieldDefault(1);
						end_IL_0000:;
					}
					catch
					{
						//try-fault
						Dispose();
						throw;
					}
					result = 0;
					goto IL_03b4;
				}
				IL_03b4:
				return (byte)result != 0;
				IL_03b3:
				result = (flag ? 1 : 0);
				goto IL_03b4;
			}

			private void _0024ensure2()
			{
				_0024_0024iterator_002413509_002417010.Dispose();
			}

			public override void Dispose()
			{
				switch (_state)
				{
				default:
					_state = 1;
					break;
				case 2:
				case 3:
					_state = 1;
					_0024ensure2();
					break;
				}
			}
		}

		internal WeaponEquipments _0024wpns_002417015;

		internal PlayerControl _0024self__002417016;

		public _0024loadMotionPack_002416995(WeaponEquipments wpns, PlayerControl self_)
		{
			_0024wpns_002417015 = wpns;
			_0024self__002417016 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024wpns_002417015, _0024self__002417016);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Initialize_002417017 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal string _0024_0024dialog_assert1_00241329_002417018;

			internal UserData _0024ud_002417019;

			internal IEnumerator _0024_0024sco_0024temp_00241330_002417020;

			internal IEnumerator _0024_0024sco_0024temp_00241331_002417021;

			internal IEnumerator _0024_0024sco_0024temp_00241332_002417022;

			internal PlayerControl _0024self__002417023;

			public _0024(PlayerControl self_)
			{
				_0024self__002417023 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						_0024self__002417023.initializingCounter++;
						_0024self__002417023.activateFingerGestures(b: false);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					case 2:
						if (!(_0024self__002417023.CharControl != null))
						{
							_0024_0024dialog_assert1_00241329_002417018 = new StringBuilder("CharControl ないの？ ").Append(_0024self__002417023.gameObject).ToString();
							MerlinServer.FatalErrorDialog(_0024_0024dialog_assert1_00241329_002417018, "Assets/Scripts/Character/PlayerControl.boo(1274)", string.Empty);
							Debug.LogError(_0024_0024dialog_assert1_00241329_002417018);
							TestFlightUnity.PassCheckpoint(_0024_0024dialog_assert1_00241329_002417018);
							throw new Exception(_0024_0024dialog_assert1_00241329_002417018);
						}
						if (_0024self__002417023.spawnParam == null)
						{
							_0024self__002417023.spawnParam = new SpawnParam();
						}
						if (_0024self__002417023.spawnParam.useReservedBattleMode)
						{
							_0024self__002417023.battleMode = _0024self__002417023.spawnParam.reservedBattleMode;
						}
						_0024self__002417023.raceType = _0024self__002417023.spawnParam.initialRace;
						_0024self__002417023.weaponEquipments = _0024self__002417023.spawnParam.weaponEquipments;
						ExtensionsModule.SetComponent<PoppetSpeakEventHandler>(_0024self__002417023.gameObject);
						_0024self__002417023.initializeAutoRunBattle(_0024self__002417023.spawnParam.withAutoBattle);
						_0024ud_002417019 = UserData.Current;
						if (_0024self__002417023.spawnParam.useReservedGender)
						{
							_0024_0024sco_0024temp_00241330_002417020 = _0024self__002417023.loadRaceModels(_0024self__002417023.spawnParam.reservedTenshiGender, _0024self__002417023.spawnParam.reservedAkumaGender);
							if (_0024_0024sco_0024temp_00241330_002417020 != null)
							{
								result = (Yield(3, _0024self__002417023.StartCoroutine(_0024_0024sco_0024temp_00241330_002417020)) ? 1 : 0);
								break;
							}
						}
						else
						{
							_0024_0024sco_0024temp_00241331_002417021 = unchecked(_0024self__002417023.loadRaceModels((EnumGenders)_0024ud_002417019.AngelGender, (EnumGenders)_0024ud_002417019.DemonGender));
							if (_0024_0024sco_0024temp_00241331_002417021 != null)
							{
								result = (Yield(4, _0024self__002417023.StartCoroutine(_0024_0024sco_0024temp_00241331_002417021)) ? 1 : 0);
								break;
							}
						}
						goto case 3;
					case 3:
					case 4:
						_0024self__002417023.coliCenterInit = _0024self__002417023.CharControl.center;
						_0024self__002417023.sndmgr = SQEX_SoundPlayer.Instance;
						_0024self__002417023.nextSkill = -1;
						_0024self__002417023.myTransform = _0024self__002417023.transform;
						_0024self__002417023.initializeCooldowns();
						_0024_0024sco_0024temp_00241332_002417022 = _0024self__002417023.coEquipMainWeaponRoutine(_0024self__002417023.weaponEquipments);
						if (_0024_0024sco_0024temp_00241332_002417022 != null)
						{
							result = (Yield(5, _0024self__002417023.StartCoroutine(_0024_0024sco_0024temp_00241332_002417022)) ? 1 : 0);
							break;
						}
						goto case 5;
					case 5:
					{
						_0024self__002417023.activateRaceObjects(_0024self__002417023.raceType);
						_0024self__002417023.showOrHideWeapon();
						_0024self__002417023.setSkillIcon();
						__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__[] updateFunctions = _0024self__002417023.updateFunctions;
						updateFunctions[RuntimeServices.NormalizeArrayIndex(updateFunctions, 0)] = _0024self__002417023.UpdateBattle;
						__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__[] updateFunctions2 = _0024self__002417023.updateFunctions;
						updateFunctions2[RuntimeServices.NormalizeArrayIndex(updateFunctions2, 1)] = _0024self__002417023.UpdateWait;
						_0024self__002417023.setupSkillEffectControl();
						_0024self__002417023.recalcParametersFromWeaponsAndPoppets();
						if (_0024self__002417023.useHUD)
						{
							BattleHUDPlayerInfo.SetHitPointNum((int)_0024self__002417023.HitPoint);
						}
						_0024self__002417023.autoFlowController = PlayerAutoFlowController.Create(_0024self__002417023);
						result = (YieldDefault(6) ? 1 : 0);
						break;
					}
					case 6:
						_0024self__002417023.PlayAnimationIdle();
						_0024self__002417023.activateFingerGestures(b: true);
						_0024self__002417023.initializingCounter--;
						CurrentPlayerList.Add(_0024self__002417023);
						YieldDefault(1);
						goto case 1;
					case 1:
						result = 0;
						break;
					}
				}
				return (byte)result != 0;
			}
		}

		internal PlayerControl _0024self__002417024;

		public _0024Initialize_002417017(PlayerControl self_)
		{
			_0024self__002417024 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024self__002417024);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024loadRaceModels_002417025 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal GameObject[] _0024_0024sfor_00241333_002417026;

			internal int _0024_0024sfor_00241335_002417027;

			internal int _0024_0024sfor_00241334_002417028;

			internal int _0024_00243891_002417029;

			internal GameObject _0024child_002417030;

			internal string[] _0024tensiModels_002417031;

			internal string[] _0024akumaModels_002417032;

			internal IEnumerator _0024_0024sco_0024temp_00241336_002417033;

			internal IEnumerator _0024_0024sco_0024temp_00241337_002417034;

			internal string _0024_0024dialog_assert1_00241338_002417035;

			internal _0024loadRaceModels_0024locals_002414356 _0024_0024locals_002417036;

			internal EnumGenders _0024tensiGender_002417037;

			internal EnumGenders _0024akumaGender_002417038;

			internal PlayerControl _0024self__002417039;

			public _0024(EnumGenders tensiGender, EnumGenders akumaGender, PlayerControl self_)
			{
				_0024tensiGender_002417037 = tensiGender;
				_0024akumaGender_002417038 = akumaGender;
				_0024self__002417039 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					_0024_0024locals_002417036 = new _0024loadRaceModels_0024locals_002414356();
					_0024_0024sfor_00241333_002417026 = ExtensionsModule.Children(_0024self__002417039.gameObject);
					_0024_0024sfor_00241335_002417027 = _0024_0024sfor_00241333_002417026.Length;
					_0024_0024sfor_00241334_002417028 = 0;
					while (_0024_0024sfor_00241334_002417028 < _0024_0024sfor_00241335_002417027)
					{
						GameObject[] array = _0024_0024sfor_00241333_002417026;
						int num = (_0024_0024sfor_00241334_002417028 = checked((_0024_00243891_002417029 = _0024_0024sfor_00241334_002417028) + 1));
						_0024child_002417030 = array[RuntimeServices.NormalizeArrayIndex(array, _0024_00243891_002417029)];
						UnityEngine.Object.Destroy(_0024child_002417030);
					}
					_0024_0024locals_002417036._0024settingsTensi = null;
					_0024_0024locals_002417036._0024settingsAkuma = null;
					_0024tensiGender_002417037 = (EnumGenders)Mathf.Clamp((int)_0024tensiGender_002417037, 1, 2);
					_0024akumaGender_002417038 = (EnumGenders)Mathf.Clamp((int)_0024akumaGender_002417038, 1, 2);
					_0024tensiModels_002417031 = new string[3]
					{
						string.Empty,
						"C0002_000_MA_PART",
						"C0000_000_MA_PART"
					};
					_0024akumaModels_002417032 = new string[3]
					{
						string.Empty,
						"C0003_000_MA_PART",
						"C0001_000_MA_PART"
					};
					PlayerControl playerControl = _0024self__002417039;
					string[] array2 = _0024tensiModels_002417031;
					_0024_0024sco_0024temp_00241336_002417033 = playerControl.instantiateRaceModel(array2[RuntimeServices.NormalizeArrayIndex(array2, (int)_0024tensiGender_002417037)], _0024adaptor_0024___0024_MoveNext_0024callable521_00241372_51___0024__PlayerControl_instantiateRaceModel_0024callable61_00241397_65___0024135.Adapt(new _0024loadRaceModels_0024closure_00243892(_0024_0024locals_002417036).Invoke));
					if (_0024_0024sco_0024temp_00241336_002417033 != null)
					{
						result = (Yield(2, _0024self__002417039.StartCoroutine(_0024_0024sco_0024temp_00241336_002417033)) ? 1 : 0);
						break;
					}
					goto case 2;
				}
				case 2:
				{
					PlayerControl playerControl2 = _0024self__002417039;
					string[] array3 = _0024akumaModels_002417032;
					_0024_0024sco_0024temp_00241337_002417034 = playerControl2.instantiateRaceModel(array3[RuntimeServices.NormalizeArrayIndex(array3, (int)_0024akumaGender_002417038)], _0024adaptor_0024___0024_MoveNext_0024callable521_00241372_51___0024__PlayerControl_instantiateRaceModel_0024callable61_00241397_65___0024135.Adapt(new _0024loadRaceModels_0024closure_00243893(_0024_0024locals_002417036).Invoke));
					if (_0024_0024sco_0024temp_00241337_002417034 != null)
					{
						result = (Yield(3, _0024self__002417039.StartCoroutine(_0024_0024sco_0024temp_00241337_002417034)) ? 1 : 0);
						break;
					}
					goto case 3;
				}
				case 3:
					if (!(_0024_0024locals_002417036._0024settingsTensi != null) || !(_0024_0024locals_002417036._0024settingsAkuma != null))
					{
						_0024_0024dialog_assert1_00241338_002417035 = new StringBuilder("settingsTensi:").Append(_0024_0024locals_002417036._0024settingsTensi).Append(" settingsAkuma:").Append(_0024_0024locals_002417036._0024settingsAkuma)
							.ToString();
						MerlinServer.FatalErrorDialog(_0024_0024dialog_assert1_00241338_002417035, "Assets/Scripts/Character/PlayerControl.boo(1376)", string.Empty);
						Debug.LogError(_0024_0024dialog_assert1_00241338_002417035);
						TestFlightUnity.PassCheckpoint(_0024_0024dialog_assert1_00241338_002417035);
						throw new Exception(_0024_0024dialog_assert1_00241338_002417035);
					}
					_0024self__002417039.tensiModel = _0024_0024locals_002417036._0024settingsTensi.Body;
					_0024self__002417039.coliYarareTensi = _0024_0024locals_002417036._0024settingsTensi.YarareCollider;
					_0024self__002417039.weaponRBaseTensi = _0024_0024locals_002417036._0024settingsTensi.WeaponRightBase;
					_0024self__002417039.weaponLBaseTensi = _0024_0024locals_002417036._0024settingsTensi.WeaponLeftBase;
					_0024self__002417039.attackCollidersTensi = _0024_0024locals_002417036._0024settingsTensi.attackColliders;
					_0024self__002417039.akumaModel = _0024_0024locals_002417036._0024settingsAkuma.Body;
					_0024self__002417039.coliYarareAkuma = _0024_0024locals_002417036._0024settingsAkuma.YarareCollider;
					_0024self__002417039.weaponRBaseAkuma = _0024_0024locals_002417036._0024settingsAkuma.WeaponRightBase;
					_0024self__002417039.weaponLBaseAkuma = _0024_0024locals_002417036._0024settingsAkuma.WeaponLeftBase;
					_0024self__002417039.attackCollidersAkuma = _0024_0024locals_002417036._0024settingsAkuma.attackColliders;
					result = (YieldDefault(4) ? 1 : 0);
					break;
				case 4:
					UnityEngine.Object.Destroy(_0024_0024locals_002417036._0024settingsTensi.gameObject);
					UnityEngine.Object.Destroy(_0024_0024locals_002417036._0024settingsAkuma.gameObject);
					ShadowSelector.Setup(_0024self__002417039.gameObject);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal EnumGenders _0024tensiGender_002417040;

		internal EnumGenders _0024akumaGender_002417041;

		internal PlayerControl _0024self__002417042;

		public _0024loadRaceModels_002417025(EnumGenders tensiGender, EnumGenders akumaGender, PlayerControl self_)
		{
			_0024tensiGender_002417040 = tensiGender;
			_0024akumaGender_002417041 = akumaGender;
			_0024self__002417042 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024tensiGender_002417040, _0024akumaGender_002417041, _0024self__002417042);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024instantiateRaceModel_002417043 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal RuntimeAssetBundleDB _0024abdb_002417044;

			internal RuntimeAssetBundleDB.Req _0024r_002417045;

			internal string _0024_0024dialog_assert1_00241339_002417046;

			internal PlayerModelSettings _0024c_002417047;

			internal string _0024modelName_002417048;

			internal __PlayerControl_instantiateRaceModel_0024callable61_00241397_65__ _0024h_002417049;

			internal PlayerControl _0024self__002417050;

			public _0024(string modelName, __PlayerControl_instantiateRaceModel_0024callable61_00241397_65__ h, PlayerControl self_)
			{
				_0024modelName_002417048 = modelName;
				_0024h_002417049 = h;
				_0024self__002417050 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024abdb_002417044 = RuntimeAssetBundleDB.Instance;
					_0024r_002417045 = _0024abdb_002417044.instantiatePrefab(_0024modelName_002417048);
					goto case 2;
				case 2:
					if (!_0024r_002417045.IsEnd)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (!_0024r_002417045.IsOk)
					{
						_0024_0024dialog_assert1_00241339_002417046 = new StringBuilder("could not load ").Append(_0024modelName_002417048).ToString();
						MerlinServer.FatalErrorDialog(_0024_0024dialog_assert1_00241339_002417046, "Assets/Scripts/Character/PlayerControl.boo(1401)", string.Empty);
						Debug.LogError(_0024_0024dialog_assert1_00241339_002417046);
						TestFlightUnity.PassCheckpoint(_0024_0024dialog_assert1_00241339_002417046);
						throw new Exception(_0024_0024dialog_assert1_00241339_002417046);
					}
					_0024c_002417047 = _0024r_002417045.Prefab.GetComponent<PlayerModelSettings>();
					_0024c_002417047.init(_0024self__002417050.gameObject);
					if (_0024h_002417049 != null)
					{
						_0024h_002417049(_0024c_002417047);
					}
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024modelName_002417051;

		internal __PlayerControl_instantiateRaceModel_0024callable61_00241397_65__ _0024h_002417052;

		internal PlayerControl _0024self__002417053;

		public _0024instantiateRaceModel_002417043(string modelName, __PlayerControl_instantiateRaceModel_0024callable61_00241397_65__ h, PlayerControl self_)
		{
			_0024modelName_002417051 = modelName;
			_0024h_002417052 = h;
			_0024self__002417053 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024modelName_002417051, _0024h_002417052, _0024self__002417053);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024coEquipMainWeaponRoutine_002417054 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal WeaponEquipments _0024weq_002417055;

			internal IEnumerator _0024_0024sco_0024temp_00241343_002417056;

			internal RespWeapon[] _0024weapons_002417057;

			internal PlayerControl _0024self__002417058;

			public _0024(RespWeapon[] weapons, PlayerControl self_)
			{
				_0024weapons_002417057 = weapons;
				_0024self__002417058 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024weq_002417055 = WeaponEquipments.FromOldWeaponArray(_0024weapons_002417057);
					_0024_0024sco_0024temp_00241343_002417056 = _0024self__002417058.coEquipMainWeaponRoutine(_0024weq_002417055);
					if (_0024_0024sco_0024temp_00241343_002417056 != null)
					{
						result = (Yield(2, _0024self__002417058.StartCoroutine(_0024_0024sco_0024temp_00241343_002417056)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal RespWeapon[] _0024weapons_002417059;

		internal PlayerControl _0024self__002417060;

		public _0024coEquipMainWeaponRoutine_002417054(RespWeapon[] weapons, PlayerControl self_)
		{
			_0024weapons_002417059 = weapons;
			_0024self__002417060 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024weapons_002417059, _0024self__002417060);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024coEquipMainWeaponRoutine_002417061 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal string _0024_0024dialog_assert1_00241344_002417062;

			internal string _0024_0024dialog_assert1_00241345_002417063;

			internal IEnumerator _0024_0024sco_0024temp_00241346_002417064;

			internal RespWeapon _0024tenshiWpn_002417065;

			internal RespWeapon _0024akumaWpn_002417066;

			internal MWeapons _0024tenshiMst_002417067;

			internal MWeapons _0024akumaMst_002417068;

			internal MStyles _0024tenshiStyle_002417069;

			internal MStyles _0024akumaStyle_002417070;

			internal __PlayerControl_coEquipMainWeaponRoutine_0024callable174_00241515_13__ _0024_equip_002417071;

			internal __PlayerControl_coEquipMainWeaponRoutine_0024callable62_00241518_36__ _0024_initTenshiAfterLoad_002417072;

			internal __PlayerControl_coEquipMainWeaponRoutine_0024callable62_00241518_36__ _0024_initAkumaAfterLoad_002417073;

			internal GameObject[] _0024tensiHands_002417074;

			internal IEnumerator _0024_0024sco_0024temp_00241350_002417075;

			internal GameObject[] _0024akumaHands_002417076;

			internal IEnumerator _0024_0024sco_0024temp_00241351_002417077;

			internal Collider[] _0024_0024sfor_00241352_002417078;

			internal int _0024_0024sfor_00241354_002417079;

			internal int _0024_0024sfor_00241353_002417080;

			internal int _0024_00243899_002417081;

			internal Collider _0024ac_002417082;

			internal Collider[] _0024_0024sfor_00241355_002417083;

			internal int _0024_0024sfor_00241357_002417084;

			internal int _0024_0024sfor_00241356_002417085;

			internal int _0024_00243900_002417086;

			internal MWeaponSkills _0024skill_002417087;

			internal string _0024mot_002417088;

			internal float _0024_0024wait_until_0024temp_00241358_002417089;

			internal float _0024_0024wait_until_0024temp_00241359_002417090;

			internal string _0024_0024dialog_assert1_00241360_002417091;

			internal MerlinMotionPackEffectLoader[] _0024efLoaders_002417092;

			internal IEnumerator _0024_0024sco_0024temp_00241361_002417093;

			internal MerlinMotionPackEffectLoader _0024eld_002417094;

			internal float _0024_0024wait_until_0024temp_00241362_002417095;

			internal float _0024_0024wait_until_0024temp_00241363_002417096;

			internal int _0024_00248735_002417097;

			internal MWeaponSkills[] _0024_00248736_002417098;

			internal int _0024_00248737_002417099;

			internal int _0024_00248739_002417100;

			internal MerlinMotionPackEffectLoader[] _0024_00248740_002417101;

			internal int _0024_00248741_002417102;

			internal WeaponEquipments _0024weapons_002417103;

			internal PlayerControl _0024self__002417104;

			public _0024(WeaponEquipments weapons, PlayerControl self_)
			{
				_0024weapons_002417103 = weapons;
				_0024self__002417104 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				checked
				{
					switch (_state)
					{
					default:
						if (_0024weapons_002417103 == null)
						{
							_0024_0024dialog_assert1_00241344_002417062 = "weapons == null";
							MerlinServer.FatalErrorDialog(_0024_0024dialog_assert1_00241344_002417062, "Assets/Scripts/Character/PlayerControl.boo(1482)", string.Empty);
							Debug.LogError(_0024_0024dialog_assert1_00241344_002417062);
							TestFlightUnity.PassCheckpoint(_0024_0024dialog_assert1_00241344_002417062);
							throw new Exception(_0024_0024dialog_assert1_00241344_002417062);
						}
						if (!_0024weapons_002417103.IsValid)
						{
							_0024_0024dialog_assert1_00241345_002417063 = "weapons is not valid";
							MerlinServer.FatalErrorDialog(_0024_0024dialog_assert1_00241345_002417063, "Assets/Scripts/Character/PlayerControl.boo(1483)", string.Empty);
							Debug.LogError(_0024_0024dialog_assert1_00241345_002417063);
							TestFlightUnity.PassCheckpoint(_0024_0024dialog_assert1_00241345_002417063);
							throw new Exception(_0024_0024dialog_assert1_00241345_002417063);
						}
						_0024self__002417104.initializingCounter++;
						_0024self__002417104.Mmpc.eraseMotionPackExceptWith(_0024self__002417104.eventMotionPack);
						_0024_0024sco_0024temp_00241346_002417064 = _0024self__002417104.loadMotionPack(_0024weapons_002417103);
						if (_0024_0024sco_0024temp_00241346_002417064 != null)
						{
							result = (Yield(2, _0024self__002417104.StartCoroutine(_0024_0024sco_0024temp_00241346_002417064)) ? 1 : 0);
							break;
						}
						goto case 2;
					case 2:
						_0024self__002417104.destroyAllCommands();
						result = (YieldDefault(3) ? 1 : 0);
						break;
					case 3:
						_0024self__002417104.disposeWeapons();
						_0024self__002417104.weaponEquipments = _0024weapons_002417103;
						_0024tenshiWpn_002417065 = _0024weapons_002417103.getMainWeapon(RACE_TYPE.Tensi);
						_0024akumaWpn_002417066 = _0024weapons_002417103.getMainWeapon(RACE_TYPE.Akuma);
						_0024tenshiMst_002417067 = _0024tenshiWpn_002417065.Master;
						_0024akumaMst_002417068 = _0024akumaWpn_002417066.Master;
						_0024tenshiStyle_002417069 = _0024tenshiMst_002417067.StyleId;
						_0024akumaStyle_002417070 = _0024akumaMst_002417068.StyleId;
						_0024_equip_002417071 = (GameObject[] hands, MWeapons wpnMst, GameObject[] outLoadedObjes, __PlayerControl_coEquipMainWeaponRoutine_0024callable62_00241518_36__ handler) => new _0024_0024coEquipMainWeaponRoutine_0024_equip_00243896_002417125(hands, wpnMst, outLoadedObjes, handler, _0024self__002417104).GetEnumerator();
						_0024_initTenshiAfterLoad_002417072 = delegate(Collider[] colis)
						{
							_0024self__002417104.attackColisTensi = colis;
						};
						_0024_initAkumaAfterLoad_002417073 = delegate(Collider[] colis)
						{
							_0024self__002417104.attackColisAkuma = colis;
						};
						_0024tensiHands_002417074 = new GameObject[2] { _0024self__002417104.weaponRBaseTensi, _0024self__002417104.weaponLBaseTensi };
						_0024_0024sco_0024temp_00241350_002417075 = _0024_equip_002417071(_0024tensiHands_002417074, _0024tenshiMst_002417067, _0024self__002417104.weaponTensi, _0024_initTenshiAfterLoad_002417072);
						if (_0024_0024sco_0024temp_00241350_002417075 != null)
						{
							result = (Yield(4, _0024self__002417104.StartCoroutine(_0024_0024sco_0024temp_00241350_002417075)) ? 1 : 0);
							break;
						}
						goto case 4;
					case 4:
						_0024akumaHands_002417076 = new GameObject[2] { _0024self__002417104.weaponRBaseAkuma, _0024self__002417104.weaponLBaseAkuma };
						_0024_0024sco_0024temp_00241351_002417077 = _0024_equip_002417071(_0024akumaHands_002417076, _0024akumaMst_002417068, _0024self__002417104.weaponAkuma, _0024_initAkumaAfterLoad_002417073);
						if (_0024_0024sco_0024temp_00241351_002417077 != null)
						{
							result = (Yield(5, _0024self__002417104.StartCoroutine(_0024_0024sco_0024temp_00241351_002417077)) ? 1 : 0);
							break;
						}
						goto case 5;
					case 5:
						_0024self__002417104.extAttackColisTensiCache.Clear();
						_0024self__002417104.extAttackColisAkumaCache.Clear();
						_0024_0024sfor_00241352_002417078 = _0024self__002417104.attackColisTensi;
						_0024_0024sfor_00241354_002417079 = _0024_0024sfor_00241352_002417078.Length;
						_0024_0024sfor_00241353_002417080 = 0;
						while (_0024_0024sfor_00241353_002417080 < _0024_0024sfor_00241354_002417079)
						{
							Collider[] array = _0024_0024sfor_00241352_002417078;
							int num = (_0024_0024sfor_00241353_002417080 = (_0024_00243899_002417081 = _0024_0024sfor_00241353_002417080) + 1);
							_0024ac_002417082 = array[RuntimeServices.NormalizeArrayIndex(array, _0024_00243899_002417081)];
							_0024self__002417104.extAttackColisTensiCache[_0024ac_002417082.name] = new Collider[1] { _0024ac_002417082 };
						}
						_0024_0024sfor_00241355_002417083 = _0024self__002417104.attackColisAkuma;
						_0024_0024sfor_00241357_002417084 = _0024_0024sfor_00241355_002417083.Length;
						_0024_0024sfor_00241356_002417085 = 0;
						while (_0024_0024sfor_00241356_002417085 < _0024_0024sfor_00241357_002417084)
						{
							Collider[] array2 = _0024_0024sfor_00241355_002417083;
							int num2 = (_0024_0024sfor_00241356_002417085 = (_0024_00243900_002417086 = _0024_0024sfor_00241356_002417085) + 1);
							_0024ac_002417082 = array2[RuntimeServices.NormalizeArrayIndex(array2, _0024_00243900_002417086)];
							_0024self__002417104.extAttackColisAkumaCache[_0024ac_002417082.name] = new Collider[1] { _0024ac_002417082 };
						}
						_0024_00248735_002417097 = 0;
						_0024_00248736_002417098 = new MWeaponSkills[2] { _0024tenshiMst_002417067.AngelSkillId, _0024akumaMst_002417068.DemonSkillId };
						_0024_00248737_002417099 = _0024_00248736_002417098.Length;
						goto IL_060a;
					case 6:
						if (!_0024self__002417104.Mmpc.isLoaded(_0024mot_002417088) && Time.realtimeSinceStartup - _0024_0024wait_until_0024temp_00241359_002417090 < _0024_0024wait_until_0024temp_00241358_002417089)
						{
							result = (YieldDefault(6) ? 1 : 0);
							break;
						}
						if (!_0024self__002417104.Mmpc.isLoaded(_0024mot_002417088))
						{
							_0024_0024dialog_assert1_00241360_002417091 = new StringBuilder().Append(_0024mot_002417088).Append(" could not loaded").ToString();
							MerlinServer.FatalErrorDialog(_0024_0024dialog_assert1_00241360_002417091, "Assets/Scripts/Character/PlayerControl.boo(1558)", string.Empty);
							Debug.LogError(_0024_0024dialog_assert1_00241360_002417091);
							TestFlightUnity.PassCheckpoint(_0024_0024dialog_assert1_00241360_002417091);
							throw new Exception(_0024_0024dialog_assert1_00241360_002417091);
						}
						goto IL_05fc;
					case 7:
						_0024_0024sco_0024temp_00241361_002417093 = _0024self__002417104.activateMotionPacks();
						if (_0024_0024sco_0024temp_00241361_002417093 != null)
						{
							result = (Yield(8, _0024self__002417104.StartCoroutine(_0024_0024sco_0024temp_00241361_002417093)) ? 1 : 0);
							break;
						}
						goto case 8;
					case 8:
						_0024self__002417104.PlayAnimationIdle();
						_0024self__002417104.showOrHideWeapon();
						_0024self__002417104.SkillEffectControl.setWeapons(new RespWeapon[2] { _0024tenshiWpn_002417065, _0024akumaWpn_002417066 });
						_0024self__002417104.reInitWeaponCooldownTime();
						_0024self__002417104.setSkillIcon();
						_0024_00248739_002417100 = 0;
						_0024_00248740_002417101 = _0024efLoaders_002417092;
						_0024_00248741_002417102 = _0024_00248740_002417101.Length;
						goto IL_0792;
					case 9:
						if (!_0024_00248740_002417101[_0024_00248739_002417100].IsLoaded && Time.realtimeSinceStartup - _0024_0024wait_until_0024temp_00241363_002417096 < _0024_0024wait_until_0024temp_00241362_002417095)
						{
							result = (YieldDefault(9) ? 1 : 0);
							break;
						}
						if (!_0024_00248740_002417101[_0024_00248739_002417100].IsLoaded)
						{
						}
						_0024_00248739_002417100++;
						goto IL_0792;
					case 1:
						{
							result = 0;
							break;
						}
						IL_0792:
						if (_0024_00248739_002417100 < _0024_00248741_002417102)
						{
							_0024_0024wait_until_0024temp_00241362_002417095 = 20f;
							_0024_0024wait_until_0024temp_00241363_002417096 = Time.realtimeSinceStartup;
							goto case 9;
						}
						_0024self__002417104.setWeaponElementIcon();
						_0024self__002417104.initializingCounter--;
						YieldDefault(1);
						goto case 1;
						IL_060a:
						if (_0024_00248735_002417097 < _0024_00248737_002417099)
						{
							if (_0024_00248736_002417098[_0024_00248735_002417097] != null && !string.IsNullOrEmpty(_0024_00248736_002417098[_0024_00248735_002417097].Motion))
							{
								_0024mot_002417088 = _0024_00248736_002417098[_0024_00248735_002417097].Motion;
								if (_0024self__002417104.Mmpc.loadClip(_0024mot_002417088))
								{
									_0024_0024wait_until_0024temp_00241358_002417089 = 30f;
									_0024_0024wait_until_0024temp_00241359_002417090 = Time.realtimeSinceStartup;
									goto case 6;
								}
							}
							goto IL_05fc;
						}
						_0024efLoaders_002417092 = _0024self__002417104.Mmpc.loadEffects();
						if (_0024self__002417104.spawnParam.reqLoadAssetsInMotPack)
						{
							_0024self__002417104.Mmpc.loadActivatedMotionAssets();
						}
						result = (YieldDefault(7) ? 1 : 0);
						break;
						IL_05fc:
						_0024_00248735_002417097++;
						goto IL_060a;
					}
				}
				return (byte)result != 0;
			}
		}

		internal WeaponEquipments _0024weapons_002417105;

		internal PlayerControl _0024self__002417106;

		public _0024coEquipMainWeaponRoutine_002417061(WeaponEquipments weapons, PlayerControl self_)
		{
			_0024weapons_002417105 = weapons;
			_0024self__002417106 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024weapons_002417105, _0024self__002417106);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024loadWeapons_002417107 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal string _0024_0024dialog_assert1_00241365_002417108;

			internal int _0024i_002417109;

			internal string _0024path_002417110;

			internal RuntimeAssetBundleDB.Req _0024r_002417111;

			internal string _0024_0024dialog_assert1_00241366_002417112;

			internal int _0024_00248743_002417113;

			internal int _0024_00248744_002417114;

			internal string[] _0024wpnPaths_002417115;

			internal GameObject[] _0024outObjArray_002417116;

			public _0024(string[] wpnPaths, GameObject[] outObjArray)
			{
				_0024wpnPaths_002417115 = wpnPaths;
				_0024outObjArray_002417116 = outObjArray;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024wpnPaths_002417115.Length != _0024outObjArray_002417116.Length)
					{
						_0024_0024dialog_assert1_00241365_002417108 = "len(wpnPaths) == len(outObjArray)";
						MerlinServer.FatalErrorDialog(_0024_0024dialog_assert1_00241365_002417108, "Assets/Scripts/Character/PlayerControl.boo(1621)", string.Empty);
						Debug.LogError(_0024_0024dialog_assert1_00241365_002417108);
						TestFlightUnity.PassCheckpoint(_0024_0024dialog_assert1_00241365_002417108);
						throw new Exception(_0024_0024dialog_assert1_00241365_002417108);
					}
					_0024_00248743_002417113 = 0;
					_0024_00248744_002417114 = _0024wpnPaths_002417115.Length;
					if (_0024_00248744_002417114 < 0)
					{
						throw new ArgumentOutOfRangeException("max");
					}
					goto IL_01ac;
				case 2:
				{
					if (!_0024r_002417111.IsEnd)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (!_0024r_002417111.IsOk)
					{
						_0024_0024dialog_assert1_00241366_002417112 = new StringBuilder("could not load weapon ").Append(_0024path_002417110).ToString();
						MerlinServer.FatalErrorDialog(_0024_0024dialog_assert1_00241366_002417112, "Assets/Scripts/Character/PlayerControl.boo(1627)", string.Empty);
						Debug.LogError(_0024_0024dialog_assert1_00241366_002417112);
						TestFlightUnity.PassCheckpoint(_0024_0024dialog_assert1_00241366_002417112);
						throw new Exception(_0024_0024dialog_assert1_00241366_002417112);
					}
					GameObject[] array = _0024outObjArray_002417116;
					array[RuntimeServices.NormalizeArrayIndex(array, _0024i_002417109)] = _0024r_002417111.Prefab;
					goto IL_01ac;
				}
				case 1:
					{
						result = 0;
						break;
					}
					IL_00f0:
					_0024r_002417111 = RuntimeAssetBundleDB.Instance.instantiatePrefab(_0024path_002417110);
					goto case 2;
					IL_01ac:
					while (_0024_00248743_002417113 < _0024_00248744_002417114)
					{
						_0024i_002417109 = _0024_00248743_002417113;
						_0024_00248743_002417113++;
						string[] array2 = _0024wpnPaths_002417115;
						_0024path_002417110 = array2[RuntimeServices.NormalizeArrayIndex(array2, _0024i_002417109)];
						if (string.IsNullOrEmpty(_0024path_002417110))
						{
							continue;
						}
						goto IL_00f0;
					}
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal string[] _0024wpnPaths_002417117;

		internal GameObject[] _0024outObjArray_002417118;

		public _0024loadWeapons_002417107(string[] wpnPaths, GameObject[] outObjArray)
		{
			_0024wpnPaths_002417117 = wpnPaths;
			_0024outObjArray_002417118 = outObjArray;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024wpnPaths_002417117, _0024outObjArray_002417118);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024activateMotionPacks_002417119 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal RespWeapon _0024wpn_002417120;

			internal EnumStyles _0024etype_002417121;

			internal EnumElements _0024element_002417122;

			internal PlayerControl _0024self__002417123;

			public _0024(PlayerControl self_)
			{
				_0024self__002417123 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024wpn_002417120 = _0024self__002417123.weaponEquipments.getMainWeapon(_0024self__002417123.raceType);
					_0024etype_002417121 = (EnumStyles)_0024wpn_002417120.Style.Id;
					_0024element_002417122 = (EnumElements)_0024wpn_002417120.Element.Id;
					_0024self__002417123.equipType = _0024etype_002417121;
					_0024self__002417123.enableMotionPack(_0024etype_002417121);
					goto case 2;
				case 2:
					if (!_0024self__002417123.isEventPackEnabled())
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (_0024self__002417123.spawnParam.initWithSkillPacks)
					{
						goto case 3;
					}
					goto IL_00e7;
				case 3:
					if (!_0024self__002417123.isStylePackEnabled(_0024etype_002417121))
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					goto IL_00e7;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00e7:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal PlayerControl _0024self__002417124;

		public _0024activateMotionPacks_002417119(PlayerControl self_)
		{
			_0024self__002417124 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002417124);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024coEquipMainWeaponRoutine_0024_equip_00243896_002417125 : GenericGenerator<Coroutine>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<Coroutine>, IEnumerator
		{
			internal string _0024_0024dialog_assert1_00241347_002417126;

			internal string _0024_0024dialog_assert1_00241348_002417127;

			internal MStyles _0024style_002417128;

			internal int _0024mainIdx_002417129;

			internal int _0024altIdx_002417130;

			internal string[] _0024wpnPaths_002417131;

			internal IEnumerator _0024_0024sco_0024temp_00241349_002417132;

			internal Collider[] _0024colis_002417133;

			internal GameObject[] _0024hands_002417134;

			internal MWeapons _0024wpnMst_002417135;

			internal GameObject[] _0024outLoadedObjes_002417136;

			internal __PlayerControl_coEquipMainWeaponRoutine_0024callable62_00241518_36__ _0024handler_002417137;

			internal PlayerControl _0024self__002417138;

			public _0024(GameObject[] hands, MWeapons wpnMst, GameObject[] outLoadedObjes, __PlayerControl_coEquipMainWeaponRoutine_0024callable62_00241518_36__ handler, PlayerControl self_)
			{
				_0024hands_002417134 = hands;
				_0024wpnMst_002417135 = wpnMst;
				_0024outLoadedObjes_002417136 = outLoadedObjes;
				_0024handler_002417137 = handler;
				_0024self__002417138 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024hands_002417134 == null || _0024hands_002417134.Length != 2)
					{
						_0024_0024dialog_assert1_00241347_002417126 = "invalid hands";
						MerlinServer.FatalErrorDialog(_0024_0024dialog_assert1_00241347_002417126, "Assets/Scripts/Character/PlayerControl.boo(1519)", string.Empty);
						Debug.LogError(_0024_0024dialog_assert1_00241347_002417126);
						TestFlightUnity.PassCheckpoint(_0024_0024dialog_assert1_00241347_002417126);
						throw new Exception(_0024_0024dialog_assert1_00241347_002417126);
					}
					if (_0024wpnMst_002417135 == null)
					{
						_0024_0024dialog_assert1_00241348_002417127 = "wpnMst==null";
						MerlinServer.FatalErrorDialog(_0024_0024dialog_assert1_00241348_002417127, "Assets/Scripts/Character/PlayerControl.boo(1520)", string.Empty);
						Debug.LogError(_0024_0024dialog_assert1_00241348_002417127);
						TestFlightUnity.PassCheckpoint(_0024_0024dialog_assert1_00241348_002417127);
						throw new Exception(_0024_0024dialog_assert1_00241348_002417127);
					}
					_0024style_002417128 = _0024wpnMst_002417135.StyleId;
					_0024mainIdx_002417129 = (_0024style_002417128.IsLefty ? 1 : 0);
					_0024altIdx_002417130 = checked(1 - _0024mainIdx_002417129);
					_0024wpnPaths_002417131 = _0024self__002417138.weaponPrefabPaths(_0024wpnMst_002417135);
					_0024_0024sco_0024temp_00241349_002417132 = _0024self__002417138.loadWeapons(_0024wpnPaths_002417131, _0024outLoadedObjes_002417136);
					if (_0024_0024sco_0024temp_00241349_002417132 != null)
					{
						result = (Yield(2, _0024self__002417138.StartCoroutine(_0024_0024sco_0024temp_00241349_002417132)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
				{
					PlayerControl playerControl = _0024self__002417138;
					GameObject[] array = _0024hands_002417134;
					GameObject mainHand = array[RuntimeServices.NormalizeArrayIndex(array, _0024mainIdx_002417129)];
					GameObject[] array2 = _0024hands_002417134;
					_0024colis_002417133 = playerControl.holdWeapons(mainHand, array2[RuntimeServices.NormalizeArrayIndex(array2, _0024altIdx_002417130)], _0024outLoadedObjes_002417136);
					if (_0024handler_002417137 != null)
					{
						_0024handler_002417137(_0024colis_002417133);
					}
					YieldDefault(1);
					goto case 1;
				}
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal GameObject[] _0024hands_002417139;

		internal MWeapons _0024wpnMst_002417140;

		internal GameObject[] _0024outLoadedObjes_002417141;

		internal __PlayerControl_coEquipMainWeaponRoutine_0024callable62_00241518_36__ _0024handler_002417142;

		internal PlayerControl _0024self__002417143;

		public _0024_0024coEquipMainWeaponRoutine_0024_equip_00243896_002417125(GameObject[] hands, MWeapons wpnMst, GameObject[] outLoadedObjes, __PlayerControl_coEquipMainWeaponRoutine_0024callable62_00241518_36__ handler, PlayerControl self_)
		{
			_0024hands_002417139 = hands;
			_0024wpnMst_002417140 = wpnMst;
			_0024outLoadedObjes_002417141 = outLoadedObjes;
			_0024handler_002417142 = handler;
			_0024self__002417143 = self_;
		}

		public override IEnumerator<Coroutine> GetEnumerator()
		{
			return new _0024(_0024hands_002417139, _0024wpnMst_002417140, _0024outLoadedObjes_002417141, _0024handler_002417142, _0024self__002417143);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024startHUDSkillTimerMode_0024routine_00243922_002417144 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal MagicGauge _0024hud_002417145;

			internal float _0024itm_002417146;

			internal float _0024etm_002417147;

			internal int _0024pidx_002417148;

			internal SkillEffector _0024skeff_002417149;

			internal PlayerControl _0024self__002417150;

			public _0024(int pidx, SkillEffector skeff, PlayerControl self_)
			{
				_0024pidx_002417148 = pidx;
				_0024skeff_002417149 = skeff;
				_0024self__002417150 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024hud_002417145 = BattleHUD.GetMagicGauge(_0024pidx_002417148);
					if (_0024hud_002417145 == null)
					{
						goto case 1;
					}
					_0024hud_002417145.RemainingTimeDisplayMode();
					goto case 2;
				case 2:
					if (_0024skeff_002417149 != null && !_0024skeff_002417149.IsExpired)
					{
						_0024itm_002417146 = _0024skeff_002417149.InitialExpirationTime;
						_0024etm_002417147 = _0024skeff_002417149.ExpirationTime;
						_0024hud_002417145.setRemainingTime(_0024etm_002417147, _0024itm_002417146);
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__002417150.playSE(SQEX_SoundPlayerData.SE.combination_end);
					_0024hud_002417145.MagicPointDisplayMode();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024pidx_002417151;

		internal SkillEffector _0024skeff_002417152;

		internal PlayerControl _0024self__002417153;

		public _0024_0024startHUDSkillTimerMode_0024routine_00243922_002417144(int pidx, SkillEffector skeff, PlayerControl self_)
		{
			_0024pidx_002417151 = pidx;
			_0024skeff_002417152 = skeff;
			_0024self__002417153 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024pidx_002417151, _0024skeff_002417152, _0024self__002417153);
		}
	}

	[NonSerialized]
	private const string EVENT_MOTPACK = "mp_player_000_event";

	[NonSerialized]
	private static Boo.Lang.List<PlayerControl> CurrentPlayerList = new Boo.Lang.List<PlayerControl>();

	private bool inputActive;

	private bool disableAttackColli;

	private SpawnParam spawnParam;

	private WeaponEquipments _weaponEquipments;

	private int initializingCounter;

	private bool started;

	[NonSerialized]
	public static bool KabeYoke;

	[NonSerialized]
	public static bool DispPlayerInputControlInfo;

	public EnumStyles equipType;

	private float attackLengthOffset;

	private float defineMoveSpeed;

	private float defineNonBattleMoveSpeed;

	private Vector3 targetLocation;

	private Transform enemyTransform;

	private AIControl enemyAIControl;

	private PlayerModelSettings settingsTensi;

	private PlayerModelSettings settingsAkuma;

	public GameObject weaponRBaseTensi;

	public GameObject weaponLBaseTensi;

	public GameObject weaponRBaseAkuma;

	public GameObject weaponLBaseAkuma;

	private GameObject mainWeaponHoldingHand;

	private GameObject altWeaponHoldingHand;

	private Collider[] attackColis;

	private Collider[] attackColisTensi;

	private Collider[] attackColisAkuma;

	public Dictionary<string, Collider[]> extAttackColisCache;

	private Dictionary<string, Collider[]> extAttackColisTensiCache;

	private Dictionary<string, Collider[]> extAttackColisAkumaCache;

	private Collider[] attackCollidersTensi;

	private Collider[] attackCollidersAkuma;

	public GameObject[] weaponTensi;

	public GameObject[] weaponAkuma;

	public Collider coliYarare;

	public Collider coliYarareTensi;

	public Collider coliYarareAkuma;

	private Vector3 coliCenterInit;

	private float tapRunAttackDistance;

	private float tapNormalAttackDistance;

	private bool isLefty;

	private float tapRunAttackDistanceDefault;

	private float tapNormalAttackDistanceDefault;

	private bool isLeftyDefault;

	private bool noFaceMovement;

	private bool disableFaceMovement;

	private Camera mainCamera;

	private KaihiTimeInfo kaihiTimeInfo;

	private TimerFlag justDodge;

	[NonSerialized]
	private const float STOP_LENGTH = 0.1f;

	[NonSerialized]
	private const float RUN_ATTACK_LENGTH_MIN = 2.5f;

	[NonSerialized]
	private const float RUN_ATTACK_LENGTH_MAX = 500f;

	[NonSerialized]
	private const float MIN_SWIPE_VELOCITY = 400f;

	[NonSerialized]
	private const float CAN_SHIFT_TIME_DOWN_YARARE = 0.7f;

	[NonSerialized]
	private const float CAN_SHIFT_TIME_ZUZAA_YARARE = 0.7f;

	[NonSerialized]
	private const float CAN_SHIFT_TIME_WEAK_YARARE = 0.2f;

	[NonSerialized]
	private const float REVIVE_LENGTH = 100f;

	[NonSerialized]
	private const float NEAR_DEATH_HITPOINT_RATE = 0.333f;

	public GameObject helixHealing;

	public GameObject continueEffect;

	public GameObject hitCancelEffect;

	private HitCancelEffectController hitCancelEffectController;

	public SQEX_SoundPlayerData.SE healing_4SQEX_SE;

	public SQEX_SoundPlayerData.SE skill_4SQEX_SE;

	public SQEX_SoundPlayerData.SE raceChange_4SQEX_SE;

	private SQEX_SoundPlayer sndmgr;

	private Vector3 previouslyPos;

	private DisplacementMeasure displacementMeasure;

	private int recoveryDamage;

	private int nextSkill;

	private bool reqSkillAfterChange;

	private string equipInitial;

	public GameObject targetRingObj;

	private GameObject targetRing;

	private bool enabledContinue;

	private bool playBt2Ev;

	private bool playEv2Bt;

	private PassiveSkillPlayerEventHandlers passiveSkillPlayerEventHandlers;

	private PlayerMoveControl moveControl;

	private PlayerInputControl _inputControl;

	private PlayerInputControlByTouch touchControl;

	private bool enableControllerDeviceChecking;

	private PlayerLockOnControl lockOnControl;

	private CooldownValue[] skillCoolDowns;

	private RACE_TYPE _raceType;

	public GameObject tensiModel;

	public GameObject akumaModel;

	public TextAsset GraphTextAsset;

	private Transform _myTransform;

	private AIControl[] _poppets;

	private RespPoppet[] _raidPoppetData;

	protected readonly string SHADER_DEFAULT;

	protected readonly string SHADER_TARGET;

	private STATE _state;

	private __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__[] updateFunctions;

	public BATTLE_MODE _battleMode;

	public bool useHUD;

	public bool noMappetButtons;

	private PlayerAutoBattle autoBattle;

	private bool enableAuto;

	private bool activeDebugActionCommad;

	private Queue<string> debugActionCommadQueue;

	private Queue<string> debugAutoBattleActionCommadQueue;

	private PlayerAutoFlowController autoFlowController;

	private NavigationArrow navigationArrow;

	private MerlinMotionPack eventMotionPack;

	private float mousePressTime;

	private Vector3 prePosition;

	private float moveLengthMinTime;

	[NonSerialized]
	public static PlayerInputControlType ForceToSetInputType = PlayerInputControlType.Default;

	private PlayerAnimationTypes reqAnimaiton;

	private int hudUpdateCounter;

	[NonSerialized]
	public static int HudUpdateStep = 1;

	private SceneMode sceneMode;

	private MasterEffectPack masterEffect;

	[NonSerialized]
	public static bool DebugKillBeforeChangeMethod;

	[NonSerialized]
	public static bool DebugKillInChangeMethod;

	[NonSerialized]
	public static bool DebugKillAfterChangeMethod;

	public static PlayerControl CurrentPlayer => (CurrentPlayerList.Count <= 0) ? null : CurrentPlayerList[0];

	public static GameObject CurrentPlayerGO => (!(CurrentPlayer != null)) ? null : CurrentPlayer.gameObject;

	public bool InputActive
	{
		get
		{
			return inputActive;
		}
		set
		{
			inputActive = value;
		}
	}

	public bool IsReady
	{
		get
		{
			int num;
			if (!weaponEquipments.IsValid)
			{
				num = 0;
			}
			else
			{
				num = (started ? 1 : 0);
				if (num != 0)
				{
					num = ((initializingCounter <= 0) ? 1 : 0);
				}
			}
			return (byte)num != 0;
		}
	}

	public WeaponEquipments weaponEquipments
	{
		get
		{
			if (_weaponEquipments == null)
			{
				_weaponEquipments = WeaponEquipments.Default();
			}
			return _weaponEquipments;
		}
		set
		{
			_weaponEquipments = value;
			if (value != null)
			{
				value.Race = raceType;
			}
		}
	}

	public override PlayerAnimationTypes AnimationTypeIdle => (battleMode != 0) ? PlayerAnimationTypes.EvIdle : PlayerAnimationTypes.Idle;

	public override PlayerAnimationTypes AnimationTypeRun => (battleMode == BATTLE_MODE.Battle) ? PlayerAnimationTypes.Run : PlayerAnimationTypes.EvRun;

	public override GameObject TargetChar => lockOnControl.TargetGameObject;

	public RespWeapon AltWeapon => weaponEquipments.AltWeapon;

	public RespWeapon[] MainWeaponList => weaponEquipments.MainWeaponList;

	public RespWeapon[] SubWeapons => weaponEquipments.SubWeapons;

	public RespWeapon[] AllWeapons => weaponEquipments.AllWeapons;

	public int CurrentWeaponSkillLevel => weaponEquipments.MainWeaponSkillLevel;

	public MWeaponSkills CurrentWeaponSkill => weaponEquipments.MainWeaponSkill;

	public MWeaponSkills AltWeaponSkill => weaponEquipments.AltWeaponSkill;

	public float CurrentMoveSpeed
	{
		get
		{
			float num = currentMoveScale();
			if (battleMode == BATTLE_MODE.Battle)
			{
				return defineMoveSpeed * num;
			}
			return defineNonBattleMoveSpeed * num;
		}
	}

	public float CurrentMotionTimeScale
	{
		get
		{
			PlayerAbnormalStateControl.StateParams @params = abnormalStateControl.Params;
			return @params.motionSpeed;
		}
	}

	public bool IsJustDodge => justDodge.IsOn;

	public PlayerInputControl InputControl
	{
		get
		{
			return _inputControl;
		}
		set
		{
			if (_inputControl != null)
			{
				_inputControl.onDisable();
			}
			_inputControl = value;
			if (_inputControl != null)
			{
				_inputControl.onEnable();
			}
		}
	}

	public CooldownValue WeaponSkillCooldown
	{
		get
		{
			CooldownValue[] array = skillCoolDowns;
			return array[RuntimeServices.NormalizeArrayIndex(array, 0)];
		}
	}

	public CooldownValue ChangeCooldown
	{
		get
		{
			CooldownValue[] array = skillCoolDowns;
			return array[RuntimeServices.NormalizeArrayIndex(array, 2)];
		}
	}

	public override bool IsPlayer => false;

	public override bool IsTensi => raceType == RACE_TYPE.Tensi;

	public override bool IsAkuma => raceType == RACE_TYPE.Akuma;

	protected RACE_TYPE raceType
	{
		get
		{
			return _raceType;
		}
		set
		{
			_raceType = value;
			_weaponEquipments.Race = value;
		}
	}

	protected Transform myTransform
	{
		get
		{
			return (!(_myTransform == null)) ? _myTransform : transform;
		}
		set
		{
			_myTransform = value;
		}
	}

	public int PoppetNum => _poppets.Length;

	public AIControl[] Poppets => _poppets;

	public RespPoppet[] PoppetsData
	{
		get
		{
			RespPoppet[] result;
			if (_raidPoppetData == null)
			{
				int length = _poppets.Length;
				RespPoppet[] array = new RespPoppet[length];
				int num = 0;
				int num2 = length;
				if (num2 < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num < num2)
				{
					int index = num;
					num++;
					AIControl[] poppets = _poppets;
					AIControl aIControl = poppets[RuntimeServices.NormalizeArrayIndex(poppets, index)];
					if (aIControl != null && aIControl.HasPoppetData)
					{
						array[RuntimeServices.NormalizeArrayIndex(array, index)] = aIControl.PoppetData;
					}
				}
				result = array;
			}
			else
			{
				result = _raidPoppetData;
			}
			return result;
		}
	}

	public RespPoppet[] CurrentPoppetData
	{
		get
		{
			RespPoppet[] result;
			if (_raidPoppetData == null)
			{
				RespPoppet[] array = Gen_array_macrosModule.GenArray<RespPoppet, AIControl>(_poppets, (__PlayerControl_0024callable334_0024733_26__)((AIControl _0024genarray_00241299) => _0024genarray_00241299.PoppetData));
				result = array;
			}
			else
			{
				result = _raidPoppetData;
			}
			return result;
		}
	}

	public STATE state
	{
		get
		{
			return _state;
		}
		set
		{
			_state = value;
		}
	}

	public BATTLE_MODE battleMode
	{
		get
		{
			return _battleMode;
		}
		set
		{
			_battleMode = value;
		}
	}

	public bool IsBattleMode => _battleMode == BATTLE_MODE.Battle;

	public bool IsNonBattleMode => _battleMode == BATTLE_MODE.Non_Battle;

	public bool IsAutoBattleMode
	{
		get
		{
			bool isBattleMode = IsBattleMode;
			if (isBattleMode)
			{
				isBattleMode = EnableAuto;
			}
			return isBattleMode;
		}
	}

	public bool EnableAuto
	{
		get
		{
			return enableAuto;
		}
		set
		{
			enableAuto = value;
		}
	}

	public static bool NeedControllerInput
	{
		get
		{
			bool num = DeviceController.Instance.IsPlugged;
			if (!num)
			{
				num = ForceToSetInputType == PlayerInputControlType.ByController;
			}
			return num;
		}
	}

	public static bool NeedVirtualPadInput
	{
		get
		{
			UserData current = UserData.Current;
			bool num = current.Config.VirtualPad;
			if (!num)
			{
				num = ForceToSetInputType == PlayerInputControlType.ByVirtualPad;
			}
			return num;
		}
	}

	public bool DisableAttackColli
	{
		get
		{
			return disableAttackColli;
		}
		set
		{
			disableAttackColli = value;
		}
	}

	public float AttackLengthOffset => attackLengthOffset;

	public float TapRunAttackDistance => tapRunAttackDistance;

	public float TapNormalAttackDistance => tapNormalAttackDistance;

	public bool DisableFaceMovement
	{
		get
		{
			return disableFaceMovement;
		}
		set
		{
			disableFaceMovement = value;
		}
	}

	public Camera MainCamera => mainCamera;

	public KaihiTimeInfo KaihiTime => kaihiTimeInfo;

	public TimerFlag JustDodgeFlag => justDodge;

	public int RecoveryDamage => recoveryDamage;

	public bool EnableControllerDeviceChecking
	{
		get
		{
			return enableControllerDeviceChecking;
		}
		set
		{
			enableControllerDeviceChecking = value;
		}
	}

	public PlayerLockOnControl LockOnControl => lockOnControl;

	public CooldownValue[] Cooldowns => skillCoolDowns;

	public PlayerAutoBattle AutoBattle => autoBattle;

	public bool ActiveDebugActionCommad
	{
		get
		{
			return activeDebugActionCommad;
		}
		set
		{
			activeDebugActionCommad = value;
		}
	}

	public Queue<string> DebugActionCommadQueue
	{
		get
		{
			return debugActionCommadQueue;
		}
		set
		{
			debugActionCommadQueue = value;
		}
	}

	public Queue<string> DebugAutoBattleActionCommadQueue
	{
		get
		{
			return debugAutoBattleActionCommadQueue;
		}
		set
		{
			debugAutoBattleActionCommadQueue = value;
		}
	}

	public PlayerAutoFlowController AutoFlowController => autoFlowController;

	public NavigationArrow NavigationArrowObj => navigationArrow;

	public PlayerControl()
	{
		inputActive = true;
		attackLengthOffset = 0.7f;
		defineMoveSpeed = 7.1f;
		defineNonBattleMoveSpeed = 9f;
		extAttackColisTensiCache = new Dictionary<string, Collider[]>();
		extAttackColisAkumaCache = new Dictionary<string, Collider[]>();
		weaponTensi = new GameObject[2];
		weaponAkuma = new GameObject[2];
		tapRunAttackDistance = 9999f;
		tapNormalAttackDistance = 10f;
		tapRunAttackDistanceDefault = 9999f;
		tapNormalAttackDistanceDefault = 10f;
		kaihiTimeInfo = new KaihiTimeInfo();
		justDodge = new TimerFlag();
		healing_4SQEX_SE = SQEX_SoundPlayerData.SE.drop_get;
		skill_4SQEX_SE = SQEX_SoundPlayerData.SE.skill_motion;
		raceChange_4SQEX_SE = SQEX_SoundPlayerData.SE.change;
		displacementMeasure = new DisplacementMeasure();
		enabledContinue = true;
		playBt2Ev = true;
		playEv2Bt = true;
		enableControllerDeviceChecking = true;
		skillCoolDowns = new CooldownValue[3];
		_poppets = new AIControl[0];
		SHADER_DEFAULT = "Mobile/Unlit (Supports Lightmap)";
		SHADER_TARGET = "Outlined/Silhouetted Unlit";
		_state = STATE.Battle;
		updateFunctions = new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__[2];
		_battleMode = BATTLE_MODE.Battle;
		useHUD = true;
		debugActionCommadQueue = new Queue<string>();
		debugAutoBattleActionCommadQueue = new Queue<string>();
		sceneMode = SceneMode.Normal;
	}

	protected override bool ignoreNODEF()
	{
		return true;
	}

	public static PlayerControl Spawn()
	{
		return Spawn(new SpawnParam(Vector3.zero, Quaternion.identity));
	}

	public static PlayerControl Spawn(Vector3 pos, Quaternion rot)
	{
		UserData current = UserData.Current;
		return Spawn(new SpawnParam(pos, rot, (EnumGenders)current.AngelGender, (EnumGenders)current.DemonGender));
	}

	public static PlayerControl Spawn(Vector3 pos, Quaternion rot, BATTLE_MODE bmode)
	{
		UserData current = UserData.Current;
		return Spawn(new SpawnParam(pos, rot, (EnumGenders)current.AngelGender, (EnumGenders)current.DemonGender, bmode, withSkillPack: true));
	}

	public static PlayerControl SpawnForTown(Vector3 pos, Quaternion rot)
	{
		UserData current = UserData.Current;
		SpawnParam spawnParam = new SpawnParam(pos, rot, (EnumGenders)current.AngelGender, (EnumGenders)current.DemonGender);
		spawnParam.setNonBattleMode();
		return Spawn(spawnParam);
	}

	public static PlayerControl Spawn(Vector3 pos, Quaternion rot, EnumGenders tenshiGender, EnumGenders akumaGender)
	{
		return Spawn(new SpawnParam(pos, rot, tenshiGender, akumaGender, BATTLE_MODE.Battle, withSkillPack: true));
	}

	public static PlayerControl Spawn(SpawnParam param)
	{
		if (param == null)
		{
			string text = "param != null";
			MerlinServer.FatalErrorDialog(text, "Assets/Scripts/Character/PlayerControl.boo(121)", string.Empty);
			Debug.LogError(text);
			TestFlightUnity.PassCheckpoint(text);
			throw new Exception(text);
		}
		string path = "Prefab/Character/Player/C0000_000_MA_ROOT";
		PlayerControl playerControl = GameAssetModule.InstantiatePrefab<PlayerControl>(path);
		if (!(playerControl != null))
		{
			string text2 = "c != null";
			MerlinServer.FatalErrorDialog(text2, "Assets/Scripts/Character/PlayerControl.boo(124)", string.Empty);
			Debug.LogError(text2);
			TestFlightUnity.PassCheckpoint(text2);
			throw new Exception(text2);
		}
		playerControl.spawnParam = param;
		playerControl.gameObject.name = param.gameObjectName;
		playerControl.transform.position = param.pos;
		playerControl.transform.rotation = param.rot;
		return playerControl;
	}

	public static void UpdateCurentPlayerList(PlayerControl highPrioPlayer)
	{
		if (!(highPrioPlayer == null))
		{
			CurrentPlayerList.Remove(highPrioPlayer);
			CurrentPlayerList.Insert(0, highPrioPlayer);
		}
	}

	public override Collider[] getAttackCollision(string partName)
	{
		if (Application.isEditor && extAttackColisCache != null)
		{
			foreach (Collider[] value2 in extAttackColisCache.Values)
			{
				if (!(value2 == null))
				{
				}
			}
		}
		object result;
		if (extAttackColisCache == null)
		{
			result = null;
		}
		else
		{
			Collider[] value = null;
			result = ((!extAttackColisCache.TryGetValue(partName, out value)) ? null : value);
		}
		return (Collider[])result;
	}

	public override RespWeapon getMainWeapon()
	{
		return weaponEquipments.MainWeapon;
	}

	public override void effectEmitHandler(GameObject effectObject)
	{
		if (!(effectObject == null))
		{
			MWeaponSkills currentWeaponSkill = CurrentWeaponSkill;
			if (currentWeaponSkill != null)
			{
				effectObject.SendMessage("setRank", currentWeaponSkill.Rank, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	public override bool isAStyle(MStyles s)
	{
		return s != null && getMainWeapon() != null && RuntimeServices.EqualityOperator(s, getMainWeapon().Style);
	}

	public override bool isAnElement(MElements e)
	{
		return e != null && getMainWeapon() != null && RuntimeServices.EqualityOperator(e, getMainWeapon().Element);
	}

	private void checkWeaponArrayForDebug(RespWeapon[] wpns)
	{
		if (wpns == null)
		{
			throw new AssertionFailedException("装備武器配列=null");
		}
		if (wpns.Length <= 0)
		{
			throw new AssertionFailedException(new StringBuilder("装備武器配列長＝").Append((object)wpns.Length).ToString());
		}
		if (wpns[0] == null)
		{
			throw new AssertionFailedException("メイン武器＝null");
		}
		if (!wpns[0].IsValidMaster)
		{
			throw new AssertionFailedException("メイン武器マスターエラー");
		}
	}

	public float currentMoveScale()
	{
		float num = ((!GameParameter.tooFast) ? 1f : 2.5f);
		float num2 = 1f;
		num2 = ((battleMode != 0) ? num : (num * getMovementSpeedScaleByAreaDamage()));
		return num2 * SkillEffect.speedMult;
	}

	protected override float getMovementSpeedScaleByAreaDamage()
	{
		return (battleMode != 0) ? 1f : base.getMovementSpeedScaleByAreaDamage();
	}

	protected override void doMotionChanged()
	{
		kaihiTimeInfo.disable();
		noFaceMovement = false;
		notifyMotionChangedToAutoBattle();
	}

	private void notifyMotionChangedToAutoBattle()
	{
		if (EnableAuto && autoBattle != null)
		{
			MerlinMotionPack.Entry executedEntryInThisFrame = Mmpc.executedEntryInThisFrame;
			if (executedEntryInThisFrame != null)
			{
				autoBattle.actIfMotionChanged(executedEntryInThisFrame.name);
			}
		}
	}

	public void setPlayBt2Ev(bool b)
	{
		playBt2Ev = b;
	}

	public void setPlayEv2Bt(bool b)
	{
		playEv2Bt = b;
	}

	public void resetInputControl()
	{
		if (InputControl != null)
		{
			InputControl.clear();
		}
	}

	public void resetCooldowns()
	{
		int i = 0;
		CooldownValue[] array = skillCoolDowns;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (array[i] != null)
			{
				array[i].resetAndSetDefaultSpeed();
			}
		}
	}

	public void resetWeaponCooldowns()
	{
		WeaponSkillCooldown?.reset();
	}

	public void coolDownWeaponSkill(float tm)
	{
		WeaponSkillCooldown?.update(tm);
	}

	public void initializeCooldowns()
	{
		_0024initializeCooldowns_0024locals_002414354 _0024initializeCooldowns_0024locals_0024 = new _0024initializeCooldowns_0024locals_002414354();
		skillCoolDowns = new CooldownValue[3];
		int num = 0;
		int length = skillCoolDowns.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index2 = num;
			num++;
			CooldownValue[] array = skillCoolDowns;
			array[RuntimeServices.NormalizeArrayIndex(array, index2)] = new CooldownValue();
		}
		CooldownValue[] array2 = skillCoolDowns;
		CooldownValue cooldownValue = array2[RuntimeServices.NormalizeArrayIndex(array2, 0)];
		CooldownValue[] array3 = skillCoolDowns;
		CooldownValue cooldownValue2 = array3[RuntimeServices.NormalizeArrayIndex(array3, 1)];
		CooldownValue[] array4 = skillCoolDowns;
		CooldownValue cooldownValue3 = array4[RuntimeServices.NormalizeArrayIndex(array4, 2)];
		_0024initializeCooldowns_0024locals_0024._0024endCooldown = delegate(int index, SQEX_SoundPlayerData.SE se)
		{
			BattleHUDSkill.SetButtonAttr(index, string.Empty, Color.white);
			BattleHUDSkill.RechargeSkillAnimation(index);
			playSE(se);
		};
		cooldownValue.EndHandler = new _0024initializeCooldowns_0024closure_00243871(_0024initializeCooldowns_0024locals_0024).Invoke;
		cooldownValue2.EndHandler = new _0024initializeCooldowns_0024closure_00243872(_0024initializeCooldowns_0024locals_0024).Invoke;
		cooldownValue3.EndHandler = new _0024initializeCooldowns_0024closure_00243873(_0024initializeCooldowns_0024locals_0024).Invoke;
		setWeaponCooldownTime(null, 1, null, 1);
		cooldownValue3.HeatTime = 12f;
		_0024initializeCooldowns_0024locals_0024._0024enableSkillHUD = delegate(int i, float val)
		{
			Color col = new Color(0.4f, 0.4f, 0.4f, 1f);
			int num2 = Mathf.CeilToInt(val);
			if (useHUD)
			{
				BattleHUDSkill.SetButtonAttr(i, new StringBuilder().Append((object)num2).ToString(), col);
			}
		};
		cooldownValue.UpdateHandler = new _0024initializeCooldowns_0024closure_00243875(_0024initializeCooldowns_0024locals_0024).Invoke;
		cooldownValue2.UpdateHandler = new _0024initializeCooldowns_0024closure_00243876(_0024initializeCooldowns_0024locals_0024).Invoke;
		cooldownValue3.UpdateHandler = new _0024initializeCooldowns_0024closure_00243877(_0024initializeCooldowns_0024locals_0024).Invoke;
	}

	public void reInitWeaponCooldownTime()
	{
		setWeaponCooldownTime(CurrentWeaponSkill, CurrentWeaponSkillLevel, null, 1);
	}

	public void setWeaponCooldownTime(MWeaponSkills wpnSkill1, int level1, MWeaponSkills wpnSkill2, int level2)
	{
		CooldownValue[] array = skillCoolDowns;
		CooldownValue cooldownValue = array[RuntimeServices.NormalizeArrayIndex(array, 0)];
		CooldownValue[] array2 = skillCoolDowns;
		CooldownValue cooldownValue2 = array2[RuntimeServices.NormalizeArrayIndex(array2, 1)];
		if (wpnSkill1 != null)
		{
			cooldownValue.HeatTime = wpnSkill1.CurrentCoolDown(level1);
		}
		else
		{
			cooldownValue.HeatTime = 6f;
		}
		if (wpnSkill2 != null)
		{
			cooldownValue2.HeatTime = wpnSkill2.CurrentCoolDown(level2);
		}
		else
		{
			cooldownValue2.HeatTime = 6f;
		}
	}

	public void UpdateSkillCoolDown(float dt)
	{
		int i = 0;
		CooldownValue[] array = skillCoolDowns;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			array[i].update(dt);
		}
	}

	public void endAllSkillCoolDown()
	{
		int i = 0;
		CooldownValue[] array = skillCoolDowns;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			array[i].reset();
		}
	}

	public AIControl getPoppet(int index)
	{
		object result;
		if (0 <= index && index < _poppets.Length)
		{
			AIControl[] poppets = _poppets;
			result = poppets[RuntimeServices.NormalizeArrayIndex(poppets, index)];
		}
		else
		{
			result = null;
		}
		return (AIControl)result;
	}

	public void setPoppets(AIControl[] ps)
	{
		if (ps == null)
		{
			return;
		}
		Boo.Lang.List<AIControl> list = new Boo.Lang.List<AIControl>();
		int num = 0;
		int i = 0;
		MerlinActionControl[] array;
		int num2;
		int length2;
		checked
		{
			for (int length = ps.Length; i < length; i++)
			{
				if (ps[i] != null)
				{
					list.Add(ps[i]);
					ps[i].cacheChainEffect();
					if (ps[i].MagicSkillComponent != null)
					{
						ps[i].MagicSkillComponent.setPoppetIndexOfPlayer(num);
					}
					num++;
				}
			}
			_poppets = (AIControl[])Builtins.array(typeof(AIControl), list);
			SkillEffectControl.setPoppets(_poppets);
			recalcParametersFromWeaponsAndPoppets();
			initPoppetHUD();
			array = new MerlinActionControl[_poppets.Length];
			num2 = 0;
			length2 = _poppets.Length;
			if (length2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
		}
		while (num2 < length2)
		{
			int index = num2;
			num2++;
			int num3 = RuntimeServices.NormalizeArrayIndex(array, index);
			AIControl[] poppets = _poppets;
			array[num3] = poppets[RuntimeServices.NormalizeArrayIndex(poppets, index)];
		}
		PlayerEventDispatcher.InvokePoppetSet(this, array);
	}

	public void addPoppet(AIControl p)
	{
		if (!(p == null))
		{
			setPoppets((AIControl[])RuntimeServices.AddArrays(typeof(AIControl), _poppets, new AIControl[1] { p }));
		}
	}

	public void deletePoppet(AIControl p)
	{
		if (p == null)
		{
			return;
		}
		int num = 0;
		int length = _poppets.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			if (RuntimeServices.EqualityOperator(_poppets, p))
			{
				AIControl[] poppets = _poppets;
				poppets[RuntimeServices.NormalizeArrayIndex(poppets, index)] = null;
				setPoppets(_poppets);
				break;
			}
		}
	}

	public bool hasPoppet(AIControl p)
	{
		int result;
		if (p == null)
		{
			result = 0;
		}
		else
		{
			int num = 0;
			AIControl[] poppets = _poppets;
			int length = poppets.Length;
			while (true)
			{
				if (num < length)
				{
					if (poppets[num] == p)
					{
						result = 1;
						break;
					}
					num = checked(num + 1);
					continue;
				}
				result = 0;
				break;
			}
		}
		return (byte)result != 0;
	}

	public void initPlayerParametersForRaid(RespPoppet[] ppts)
	{
		if (ppts == null)
		{
			throw new AssertionFailedException("ppts != null");
		}
		SkillEffectControl.setPoppets(ppts);
		recalcAndChargeHP(ppts);
		_raidPoppetData = ppts;
	}

	public void resetRaidPoppetData()
	{
		_raidPoppetData = null;
	}

	public int getPoppetIndex(AIControl p)
	{
		int num = 0;
		int length = _poppets.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		int result;
		while (true)
		{
			if (num < length)
			{
				int num2 = num;
				num++;
				AIControl[] poppets = _poppets;
				if (p == poppets[RuntimeServices.NormalizeArrayIndex(poppets, num2)])
				{
					result = num2;
					break;
				}
				continue;
			}
			result = -1;
			break;
		}
		return result;
	}

	public void clearPoppets()
	{
		_poppets = new AIControl[0];
	}

	public MagicSkill getPoppetMagicSkill(int idx)
	{
		object result;
		if (idx < 0 || idx > _poppets.Length)
		{
			result = null;
		}
		else
		{
			AIControl[] poppets = _poppets;
			AIControl aIControl = poppets[RuntimeServices.NormalizeArrayIndex(poppets, idx)];
			result = ((!(aIControl != null)) ? null : aIControl.MagicSkillComponent);
		}
		return (MagicSkill)result;
	}

	public void emitChangeEffect()
	{
		emitChangeEffect(myTransform.position, Quaternion.identity);
	}

	public void emitChangeEffect(Vector3 pos, Quaternion rot)
	{
		if (helixHealing != null)
		{
			UnityEngine.Object.Instantiate(helixHealing, pos, rot);
		}
	}

	public void emitContinueAttackEffect()
	{
		if (continueEffect != null)
		{
			UnityEngine.Object.Instantiate(continueEffect, myTransform.position, Quaternion.identity);
		}
	}

	private void finalizeChangeIfAlive()
	{
		changeRestoration();
		updateLockOnAndTargetAtChange();
		playIdlingAtChange();
		resetAbnormalStatesAtRaceChanging();
		SkillEffectControl.effectChangingRace(this);
		sendChangeEvents();
		emitChangeEffect();
	}

	private void updateLockOnAndTargetAtChange()
	{
		setMoveDir(Vector3.zero);
		targetLocation = transform.position;
		lockOnControl.refreshLockOnInfo();
	}

	private void playIdlingAtChange()
	{
		if (battleMode != 0)
		{
			PlayAnimationIdleNoCrossfade();
		}
	}

	private void sendChangeEvents()
	{
		if (IsAkuma)
		{
			PlayerEventDispatcher.InvokeToDemon();
		}
		else
		{
			PlayerEventDispatcher.InvokeToAngel();
		}
	}

	private static void activate(GameObject[] gos, bool b)
	{
		if (gos == null)
		{
			return;
		}
		int length = gos.Length;
		int num = 0;
		while (num < length)
		{
			GameObject gameObject = gos[RuntimeServices.NormalizeArrayIndex(gos, checked(num++))];
			if (gameObject != null)
			{
				gameObject.SetActive(b);
			}
		}
	}

	public void setSkillIcon()
	{
		if (useHUD)
		{
			MWeaponSkills mWeaponSkills = null;
			string text = null;
			string text2 = null;
			UserData current = UserData.Current;
			int num = current.AngelGender;
			int num2 = current.DemonGender;
			if (spawnParam.useReservedGender)
			{
				num = (int)spawnParam.reservedTenshiGender;
				num2 = (int)spawnParam.reservedAkumaGender;
			}
			if (IsTensi)
			{
				mWeaponSkills = getMainWeapon().AngelSkill;
				text2 = ((num2 != 2) ? "icon_change4" : "icon_change2");
			}
			else
			{
				mWeaponSkills = getMainWeapon().DemonSkill;
				text2 = ((num != 2) ? "icon_change3" : "icon_change1");
			}
			text = mWeaponSkills.Icon;
			BattleHUDSkill.SetButtonSprite(0, text);
			BattleHUDSkill.SetButtonSpriteKeepAtlas(2, text2);
		}
	}

	public IEnumerator ChangeTensiAkuma()
	{
		return new _0024ChangeTensiAkuma_002416944(this).GetEnumerator();
	}

	public IEnumerator ChangeTensiAkuma(bool withSe, bool withEffect)
	{
		return new _0024ChangeTensiAkuma_002416948(withSe, withEffect, this).GetEnumerator();
	}

	public IEnumerator ChangeTensiAkuma(RACE_TYPE rtype)
	{
		return new _0024ChangeTensiAkuma_002416957(rtype, this).GetEnumerator();
	}

	private IEnumerator ChangeTensiAkuma(RACE_TYPE rtype, bool withSe, bool withEffect)
	{
		return new _0024ChangeTensiAkuma_002416963(rtype, withSe, this).GetEnumerator();
	}

	private void changeRestoration()
	{
		HitPointRecovery(recoveryDamage);
		recoveryDamage = 0;
		if (useHUD)
		{
			BattleHUDPlayerInfo.SetHitPointNum(checked((int)HitPoint));
		}
	}

	private void setRaceType(RACE_TYPE rt)
	{
		raceType = rt;
		if (weaponEquipments != null)
		{
			weaponEquipments.Race = rt;
		}
	}

	public IEnumerator ChangeToTensi()
	{
		return new _0024ChangeToTensi_002416971(this).GetEnumerator();
	}

	public IEnumerator ChangeToTensi(bool withSe, bool withEffect)
	{
		return new _0024ChangeToTensi_002416975(withSe, withEffect, this).GetEnumerator();
	}

	public IEnumerator ChangeToAkuma()
	{
		return new _0024ChangeToAkuma_002416983(this).GetEnumerator();
	}

	public IEnumerator ChangeToAkuma(bool withSe, bool withEffect)
	{
		return new _0024ChangeToAkuma_002416987(withSe, withEffect, this).GetEnumerator();
	}

	private void activateRaceObjects(RACE_TYPE r)
	{
		checked
		{
			initializingCounter++;
			GameObject gameObject = null;
			GameObject gameObject2 = null;
			PlayerModelSettings playerModelSettings = null;
			Collider[] array = null;
			switch (r)
			{
			case RACE_TYPE.Tensi:
				attackColis = attackColisTensi;
				extAttackColisCache = extAttackColisTensiCache;
				array = attackCollidersTensi;
				coliYarare = coliYarareTensi;
				gameObject = tensiModel;
				gameObject2 = akumaModel;
				break;
			case RACE_TYPE.Akuma:
				attackColis = attackColisAkuma;
				extAttackColisCache = extAttackColisAkumaCache;
				array = attackCollidersAkuma;
				coliYarare = coliYarareAkuma;
				gameObject = akumaModel;
				gameObject2 = tensiModel;
				break;
			default:
				throw new Exception(new StringBuilder("unknown player race type=").Append(r).ToString());
			}
			Array.Copy(array, attackColliders, Mathf.Min(array.Length, attackColliders.Length));
			setAttackLayer("PlayerAttackColi");
			Mmpc.setMotionTargetWithActivation(gameObject, deactivateOld: true);
			Mmpc.resetBasePos();
			gameObject2.SetActive(value: false);
			Collider[] array2 = attackColis;
			int length = array2.Length;
			int num = 0;
			while (num < length)
			{
				Collider collider = array2[RuntimeServices.NormalizeArrayIndex(array2, num++)];
				setMyAttackLayer(collider);
				collider.enabled = false;
			}
			foreach (Collider[] value in extAttackColisCache.Values)
			{
				if (!(value == null))
				{
					Collider[] array3 = value;
					int length2 = array3.Length;
					int num2 = 0;
					while (num2 < length2)
					{
						Collider collider = array3[RuntimeServices.NormalizeArrayIndex(array3, num2++)];
						setMyAttackLayer(collider);
						collider.enabled = false;
					}
				}
			}
			initializingCounter--;
		}
	}

	private void initializeAutoRunBattle(bool autoBattleOn)
	{
		autoBattle = ExtensionsModule.SetComponent<PlayerAutoBattle>(gameObject);
		if (!(autoBattle != null))
		{
			throw new AssertionFailedException("autoBattle != null");
		}
		CharPathFinder = ExtensionsModule.SetComponent<CharacterPathFinder>(gameObject);
		if (!(CharPathFinder != null))
		{
			throw new AssertionFailedException("CharPathFinder != null");
		}
		autoBattle.Init(this);
		autoBattle.enabled = autoBattleOn;
		enableAuto = autoBattleOn;
	}

	public void forceSetAutoBattle(bool active)
	{
		autoBattle.enabled = active;
		enableAuto = active;
	}

	public void QueuingAutoChainSkill(int petIndex)
	{
		if (!(autoBattle == null) && petIndex >= 0 && petIndex <= 2)
		{
			autoBattle.SetQueuingChainSkill(petIndex);
		}
	}

	public void QueuingAutoWeaponSkill()
	{
		if (autoBattle != null)
		{
			autoBattle.QueuingWeaponSkill = true;
		}
	}

	public void QueuingAutoChange()
	{
		if (autoBattle != null)
		{
			autoBattle.QueuingChange = true;
		}
	}

	private void updateAutoBattle(float dt)
	{
		if (autoBattle != null)
		{
			autoBattle.doUpdate(dt);
		}
	}

	private void changeAutoBattleModeByButton(bool b)
	{
		if (useHUD)
		{
			EnableAuto = b;
		}
	}

	public void resetAutoFlow()
	{
		if (autoFlowController != null)
		{
			autoFlowController.clearFlow();
		}
		if (CharPathFinder != null)
		{
			CharPathFinder.Reset();
		}
	}

	private void initNavigationArrow()
	{
		UnityEngine.Object @object = GameAssetModule.LoadPrefab("Prefab/GUI/NavigationArrow");
		if (@object != null)
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(@object);
			NavigationArrow component = default(NavigationArrow);
			if (gameObject != null)
			{
				component = gameObject.GetComponent<NavigationArrow>();
			}
			if (component != null)
			{
				component.StartLockOn(this.gameObject);
			}
			navigationArrow = component;
		}
	}

	private void destroyNavigationArrow()
	{
		if (navigationArrow != null)
		{
			UnityEngine.Object.Destroy(navigationArrow.gameObject);
			navigationArrow = null;
		}
	}

	private void activateNavigationArrow(bool b)
	{
		if (navigationArrow != null)
		{
			navigationArrow.gameObject.SetActive(b);
		}
	}

	public void hideNavigationArrow()
	{
		if (navigationArrow != null)
		{
			navigationArrow.HidArrow();
		}
	}

	public void showNavigationArrow()
	{
		if (navigationArrow != null)
		{
			navigationArrow.ShowArrow();
		}
	}

	public void setNavigationArrowTarget(Transform tobj, Vector3 targetPos)
	{
		if (navigationArrow != null)
		{
			navigationArrow.targetTransform = tobj;
			navigationArrow.targetTransform.position = targetPos;
		}
	}

	public float DistanceTo()
	{
		float result;
		if (_inputControl is PlayerInputControlByTouch)
		{
			touchControl = _inputControl as PlayerInputControlByTouch;
			if (touchControl.Marker.IsMarked)
			{
				result = (touchControl.Marker.MarkedPos - transform.position).magnitude;
				goto IL_0066;
			}
		}
		result = 0f;
		goto IL_0066;
		IL_0066:
		return result;
	}

	public void UpdateMakerPos(Vector3 vPos)
	{
		if (touchControl != null)
		{
			touchControl.Marker.updateMark(vPos);
		}
	}

	private void SetTouchEvent()
	{
		if (!(_inputControl is PlayerInputControlByTouch))
		{
			return;
		}
		touchControl = _inputControl as PlayerInputControlByTouch;
		touchControl.OnTouchEvent += _0024adaptor_0024__PlayerControl_0024callable335_00241160_42___0024__PlayerInputControlByTouch_OnTouchEvent_0024callable64_002410_27___0024134.Adapt(delegate(object me, Vector3 vTargetPos)
		{
			if (CharPathFinder != null)
			{
				CharPathFinder.Goto(vTargetPos);
			}
		});
	}

	public override void Awake()
	{
		base.Awake();
		setSetupTypePlayer();
		moveControl = new PlayerMoveControl(transform);
		lockOnControl = new PlayerLockOnControl(this);
		checkControllerDevice();
		passiveSkillPlayerEventHandlers = ExtensionsModule.SetComponent<PassiveSkillPlayerEventHandlers>(gameObject);
		passiveSkillPlayerEventHandlers.Player = this;
		EnableDefalutInputClearEveryFrame = false;
		resetTrajectory();
		hitCancelEffectController = new HitCancelEffectController(this, hitCancelEffect);
		EnableIkariMode = false;
		DamageCalcCharData = new DamageCalcCharDataPlayer(this);
	}

	public override void Start()
	{
		base.Start();
		IEnumerator enumerator = Initialize();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
		started = true;
	}

	public void resetTrajectory()
	{
		TrajectoryInterval = 0f;
		TrajectoryDistThreshold = 0f;
	}

	private void activateFingerGestures(bool b)
	{
		GestureRecognizer[] components = GetComponents<GestureRecognizer>();
		int length = components.Length;
		int num = 0;
		while (num < length)
		{
			GestureRecognizer gestureRecognizer = components[RuntimeServices.NormalizeArrayIndex(components, checked(num++))];
			gestureRecognizer.enabled = b;
		}
	}

	private IEnumerator loadMotionPack(WeaponEquipments wpns)
	{
		return new _0024loadMotionPack_002416995(wpns, this).GetEnumerator();
	}

	private IEnumerator Initialize()
	{
		return new _0024Initialize_002417017(this).GetEnumerator();
	}

	private IEnumerator loadRaceModels(EnumGenders tensiGender, EnumGenders akumaGender)
	{
		return new _0024loadRaceModels_002417025(tensiGender, akumaGender, this).GetEnumerator();
	}

	private IEnumerator instantiateRaceModel(string modelName, __PlayerControl_instantiateRaceModel_0024callable61_00241397_65__ h)
	{
		return new _0024instantiateRaceModel_002417043(modelName, h, this).GetEnumerator();
	}

	private void enableMotionPack(EnumStyles etype)
	{
		if (spawnParam.initWithSkillPacks)
		{
			string text = PackName(etype);
			if (!string.IsNullOrEmpty(text))
			{
				Mmpc.activateMotionPackOnly("mp_player_000_event", text);
				setupMotionPackInfo(text);
			}
		}
		else
		{
			Mmpc.activateMotionPackOnly("mp_player_000_event");
			setupMotionPackInfo("mp_player_000_event");
		}
	}

	private void setupMotionPackInfo(string packName)
	{
		_0024setupMotionPackInfo_0024locals_002414357 _0024setupMotionPackInfo_0024locals_0024 = new _0024setupMotionPackInfo_0024locals_002414357();
		_0024setupMotionPackInfo_0024locals_0024._0024packName = packName;
		if (!string.IsNullOrEmpty(_0024setupMotionPackInfo_0024locals_0024._0024packName))
		{
			__PlayerControl_setupMotionPackInfo_0024callable172_00241423_13__ _PlayerControl_setupMotionPackInfo_0024callable172_00241423_13__ = new _0024setupMotionPackInfo_0024singleInfo_00243894(this, _0024setupMotionPackInfo_0024locals_0024).Invoke;
			__PlayerControl_setupMotionPackInfo_0024callable173_00241426_13__ _PlayerControl_setupMotionPackInfo_0024callable173_00241426_13__ = new _0024setupMotionPackInfo_0024boolInfo_00243895(_0024setupMotionPackInfo_0024locals_0024, this).Invoke;
			tapRunAttackDistance = _PlayerControl_setupMotionPackInfo_0024callable172_00241423_13__("I_RUNATK_DIST", tapRunAttackDistanceDefault);
			tapNormalAttackDistance = _PlayerControl_setupMotionPackInfo_0024callable172_00241423_13__("I_ATK_DIST", tapNormalAttackDistanceDefault);
			isLefty = _PlayerControl_setupMotionPackInfo_0024callable173_00241426_13__("I_LEFTY", isLeftyDefault);
			defineMoveSpeed = _PlayerControl_setupMotionPackInfo_0024callable172_00241423_13__("I_BATTLE_SPEED", defineMoveSpeed);
			defineNonBattleMoveSpeed = _PlayerControl_setupMotionPackInfo_0024callable172_00241423_13__("I_NONBATTLE_SPEED", defineMoveSpeed);
			attackLengthOffset = _PlayerControl_setupMotionPackInfo_0024callable172_00241423_13__("I_ATTACK_LENGTH_OFFSET", 0.7f);
		}
	}

	private static string PackName(EnumStyles etype)
	{
		return MStyles.Get((int)etype)?.MotPackName;
	}

	private bool isStylePackEnabled(EnumStyles etype)
	{
		MStyles mStyles = MStyles.Get((int)etype);
		return mStyles != null && !string.IsNullOrEmpty(mStyles.MotPackName) && Mmpc.isActivatedMotionPacks(mStyles.MotPackName);
	}

	private bool isEventPackEnabled()
	{
		return Mmpc.isActivatedMotionPacks("mp_player_000_event");
	}

	public void equipMainWeapon(int weaponMasterId)
	{
		Array array = new RespWeapon[1]
		{
			new RespWeapon(weaponMasterId)
		} * 3;
		IEnumerator enumerator = coEquipMainWeaponRoutine((RespWeapon[])array);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public void equipWeapons(RespWeapon[] weapons)
	{
		IEnumerator enumerator = coEquipMainWeaponRoutine(weapons);
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public void equipWeapons(WeaponEquipments weq)
	{
		if (weq != null)
		{
			IEnumerator enumerator = coEquipMainWeaponRoutine(weq);
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
		}
	}

	private IEnumerator coEquipMainWeaponRoutine(RespWeapon[] weapons)
	{
		return new _0024coEquipMainWeaponRoutine_002417054(weapons, this).GetEnumerator();
	}

	public void refreshWeaponsCoverSkill()
	{
		weaponEquipments = WeaponEquipments.FromUserData();
		RespWeapon mainWeapon = weaponEquipments.getMainWeapon(RACE_TYPE.Tensi);
		RespWeapon mainWeapon2 = weaponEquipments.getMainWeapon(RACE_TYPE.Akuma);
		SkillEffectControl.setWeapons(new RespWeapon[2] { mainWeapon, mainWeapon2 });
	}

	private IEnumerator coEquipMainWeaponRoutine(WeaponEquipments weapons)
	{
		return new _0024coEquipMainWeaponRoutine_002417061(weapons, this).GetEnumerator();
	}

	private void setWeaponElementIcon()
	{
		setWeaponElementIcon(getMainWeapon());
	}

	private void setWeaponElementIcon(RespWeapon wpn)
	{
		if (wpn != null && useHUD)
		{
			BattleHUDPlayerInfo.SetZokuseiIcon(wpn.ElementMainIcon);
		}
	}

	public void loadAssetsInMotPack()
	{
		Mmpc.loadActivatedMotionAssets();
	}

	private Collider[] holdWeapons(GameObject mainHand, GameObject altHand, GameObject[] objArray)
	{
		if (objArray.Length != 2)
		{
			string text = "len(objArray) != 2";
			MerlinServer.FatalErrorDialog(text, "Assets/Scripts/Character/PlayerControl.boo(1613)", string.Empty);
			Debug.LogError(text);
			TestFlightUnity.PassCheckpoint(text);
			throw new Exception(text);
		}
		Collider[] weaponAttackColliders = getWeaponAttackColliders(objArray);
		holdWeapon(objArray[0], mainHand);
		holdWeapon(objArray[1], altHand);
		return weaponAttackColliders;
	}

	private IEnumerator loadWeapons(string[] wpnPaths, GameObject[] outObjArray)
	{
		return new _0024loadWeapons_002417107(wpnPaths, outObjArray).GetEnumerator();
	}

	private void showOrHideWeapon()
	{
		showWeapons(battleMode == BATTLE_MODE.Battle);
	}

	public void showWeapons(bool show)
	{
		bool num = show;
		if (num)
		{
			num = IsTensi;
		}
		bool b = num;
		bool num2 = show;
		if (num2)
		{
			num2 = IsAkuma;
		}
		bool b2 = num2;
		activate(weaponTensi, b);
		activate(weaponAkuma, b2);
		if (IsTensi)
		{
			attackColis = attackColisTensi;
			Dictionary<string, Collider[]> dictionary = extAttackColisTensiCache;
		}
		else
		{
			attackColis = attackColisAkuma;
			Dictionary<string, Collider[]> dictionary = extAttackColisAkumaCache;
		}
	}

	private string[] weaponPrefabPaths(MWeapons wmst)
	{
		if (wmst == null)
		{
			string text = "wmst != null";
			MerlinServer.FatalErrorDialog(text, "Assets/Scripts/Character/PlayerControl.boo(1653)", string.Empty);
			Debug.LogError(text);
			TestFlightUnity.PassCheckpoint(text);
			throw new Exception(text);
		}
		if (string.IsNullOrEmpty(wmst.PrefabName))
		{
			string text2 = "not string.IsNullOrEmpty(wmst.PrefabName)";
			MerlinServer.FatalErrorDialog(text2, "Assets/Scripts/Character/PlayerControl.boo(1654)", string.Empty);
			Debug.LogError(text2);
			TestFlightUnity.PassCheckpoint(text2);
			throw new Exception(text2);
		}
		string text3 = wmst.PrefabName;
		string text4 = wmst.AltPrefabName;
		if (string.IsNullOrEmpty(text4))
		{
			string text5 = text3;
			if (text5.Substring(RuntimeServices.NormalizeStringIndex(text5, -2)) == "_l")
			{
				text4 = text3;
				text3 = RuntimeServices.Mid(text3, 0, -2) + "_r";
			}
			else
			{
				string text6 = text3;
				if (text6.Substring(RuntimeServices.NormalizeStringIndex(text6, -2)) == "_r")
				{
					text4 = RuntimeServices.Mid(text3, 0, -2) + "_l";
				}
			}
		}
		string text7 = new StringBuilder("Prefab/Weapons/").Append(RuntimeServices.Mid(text3, 0, 3)).Append("/").Append(text3)
			.ToString();
		string text8 = (string.IsNullOrEmpty(text4) ? null : new StringBuilder("Prefab/Weapons/").Append(RuntimeServices.Mid(text4, 0, 3)).Append("/").Append(text4)
			.ToString());
		return new string[2] { text7, text8 };
	}

	private IEnumerator activateMotionPacks()
	{
		return new _0024activateMotionPacks_002417119(this).GetEnumerator();
	}

	protected override void doForceToIdle()
	{
		unsetRejectMode();
		PlayAnimationIdle();
		MoveSpeed = 0f;
		targetLocation = transform.position;
		if (InputControl != null)
		{
			InputControl.clear();
		}
	}

	public void disposeWeapons()
	{
		GameObject[] array = weaponTensi;
		int length = array.Length;
		int num = 0;
		checked
		{
			while (num < length)
			{
				GameObject gameObject = array[RuntimeServices.NormalizeArrayIndex(array, num++)];
				if (gameObject != null)
				{
					UnityEngine.Object.Destroy(gameObject);
				}
			}
			GameObject[] array2 = weaponAkuma;
			int length2 = array2.Length;
			int num2 = 0;
			while (num2 < length2)
			{
				GameObject gameObject = array2[RuntimeServices.NormalizeArrayIndex(array2, num2++)];
				if (gameObject != null)
				{
					UnityEngine.Object.Destroy(gameObject);
				}
			}
			object obj = null;
			extAttackColisTensiCache.Clear();
			extAttackColisAkumaCache.Clear();
		}
	}

	public void holdWeapon(GameObject weapon, GameObject bone)
	{
		if (!(weapon == null))
		{
			ExtensionsModule.SetParent(weapon, bone);
			weapon.transform.localPosition = Vector3.zero;
			weapon.transform.localRotation = Quaternion.identity;
		}
	}

	public Collider[] getWeaponAttackColliders(GameObject[] weapons)
	{
		checked
		{
			Collider[] result;
			if (weapons == null)
			{
				result = new Collider[0];
			}
			else
			{
				Collider[] array = new Collider[0];
				int length = weapons.Length;
				int num = 0;
				while (num < length)
				{
					GameObject gameObject = weapons[RuntimeServices.NormalizeArrayIndex(weapons, num++)];
					if (!(gameObject == null))
					{
						Collider[] componentsInChildren = gameObject.GetComponentsInChildren<Collider>();
						int length2 = array.Length;
						array = (Collider[])RuntimeServices.AddArrays(typeof(Collider), array, new Collider[componentsInChildren.Length]);
						int num2 = 0;
						int length3 = componentsInChildren.Length;
						if (length3 < 0)
						{
							throw new ArgumentOutOfRangeException("max");
						}
						while (num2 < length3)
						{
							int num3 = num2;
							num2 = unchecked(num2 + 1);
							Collider[] array2 = array;
							array2[RuntimeServices.NormalizeArrayIndex(array2, num3 + length2)] = componentsInChildren[RuntimeServices.NormalizeArrayIndex(componentsInChildren, num3)];
						}
					}
				}
				Collider[] array3 = array;
				int length4 = array3.Length;
				int num4 = 0;
				while (num4 < length4)
				{
					Collider collider = array3[RuntimeServices.NormalizeArrayIndex(array3, num4++)];
					if (collider != null)
					{
						collider.enabled = false;
						setMyAttackLayer(collider);
					}
				}
				result = array;
			}
			return result;
		}
	}

	public override void OnDestroy()
	{
		base.OnDestroy();
		if (tensiModel != null)
		{
			UnityEngine.Object.Destroy(tensiModel);
		}
		if (akumaModel != null)
		{
			UnityEngine.Object.Destroy(akumaModel);
		}
		destroyNavigationArrow();
		CurrentPlayerList.Remove(this);
	}

	public override void OnEnable()
	{
		base.OnEnable();
		if (!sndmgr)
		{
			sndmgr = SQEX_SoundPlayer.Instance;
		}
		RuntimeFingerGestures instance = RuntimeFingerGestures.Instance;
		ShadowSelector.Setup(gameObject);
		PlayerEventDispatcher.InvokePlayerEnabled(this);
		if (InputControl != null)
		{
			InputControl.onEnable();
		}
		if (passiveSkillPlayerEventHandlers != null)
		{
			passiveSkillPlayerEventHandlers.enabled = true;
		}
		SceneChanger.SceneChangeEvent += sceneChangeEvent;
		updateSceneMode(SceneChanger.CurrentSceneName);
		BattleHUDAutoBattle.AddHandler(changeAutoBattleModeByButton);
		activateNavigationArrow(b: true);
	}

	private void sceneChangeEvent(SceneID sceneId, string sceneName)
	{
		updateSceneMode(sceneName);
	}

	private void updateSceneMode(string sceneName)
	{
		if (sceneName == "Town" || sceneName == "Myhome")
		{
			sceneMode = SceneMode.Town;
		}
		else if (sceneName.StartsWith("Raid"))
		{
			sceneMode = SceneMode.Raid;
		}
		else
		{
			sceneMode = SceneMode.Normal;
		}
	}

	public override void OnDisable()
	{
		base.OnDisable();
		if (passiveSkillPlayerEventHandlers != null)
		{
			passiveSkillPlayerEventHandlers.enabled = false;
		}
		PlayerEventDispatcher.InvokePlayerDisabled(this);
		if (InputControl != null)
		{
			InputControl.onDisable();
		}
		SceneChanger.SceneChangeEvent -= sceneChangeEvent;
		hitCancelEffectController.kill();
		BattleHUDAutoBattle.RemoveHandler(changeAutoBattleModeByButton);
		activateNavigationArrow(b: true);
	}

	public override void startHitCancel(int n)
	{
		base.startHitCancel(n);
		if (hitCancelEffectController != null)
		{
			hitCancelEffectController.start(n);
		}
	}

	public override void stopHitCancel()
	{
		base.stopHitCancel();
		if (hitCancelEffectController != null)
		{
			hitCancelEffectController.kill();
		}
	}

	public override void decHitCancelCount()
	{
		base.decHitCancelCount();
		if (hitCancelEffectController != null)
		{
			hitCancelEffectController.setCount(ActionParameters.HitCancelCount);
		}
	}

	public void OnTap(TapGesture gesture)
	{
		if (IsReady && InputActive && InputControl != null)
		{
			InputControl.onTap();
		}
	}

	public void OnTapTwoFingers(TapGesture gesture)
	{
		if (IsReady && InputActive && InputControl != null)
		{
			InputControl.onDoubleTap();
		}
	}

	public void OnSwipe(SwipeGesture gesture)
	{
		if (IsReady && InputActive && gesture.Velocity >= 400f)
		{
			float dir = FingerGestureDirToAngle((int)gesture.Direction);
			int fingerId = ((gesture.Fingers.Count > 0) ? gesture.Fingers[0].Index : 0);
			if (InputControl != null)
			{
				InputControl.onSwipe(dir, fingerId);
			}
		}
	}

	public static float FingerGestureDirToAngle(int dir)
	{
		float result = 0f;
		switch (dir)
		{
		case 1:
			result = 270f;
			break;
		case 2:
			result = 90f;
			break;
		case 4:
			result = 180f;
			break;
		case 8:
			result = 0f;
			break;
		case 16:
			result = 135f;
			break;
		case 32:
			result = 225f;
			break;
		case 64:
			result = 315f;
			break;
		case 128:
			result = 45f;
			break;
		}
		return result;
	}

	public void OnGUI_()
	{
		if (KabeYoke)
		{
			moveControl.actOnGUI();
		}
		if (DispPlayerInputControlInfo && InputControl != null)
		{
			InputControl.onGUI();
		}
	}

	public override void Update()
	{
		if (RuntimeDebugMode.Instance.IsInDebugMode)
		{
			return;
		}
		if (Pause)
		{
			if (InputControl != null)
			{
				InputControl.pause();
			}
		}
		else
		{
			if (!IsReady)
			{
				return;
			}
			float deltaTime = Time.deltaTime;
			stateDependLockOnControl();
			checkControllerDevice();
			if (autoBattle.enabled)
			{
				autoBattle.doUpdate(deltaTime);
			}
			if (InputControl != null)
			{
				if (FaderCore.Instance.isInCompleted)
				{
					InputControl.clear();
					ActionInput.clearAll();
				}
				else if (InputActive)
				{
					InputControl.update(deltaTime);
				}
				else
				{
					InputControl.clear();
				}
			}
			if (!ActionInput.HasMove)
			{
				CharPathFinder.updateActionInput();
			}
			forbidInputCheck();
			base.Update();
			if (reqSkillAfterChange)
			{
				DoSkillMain(0, ignoreCoolDown: true);
				reqSkillAfterChange = false;
			}
			else
			{
				PlayerAnimationTypes req = (PlayerAnimationTypes)(-1);
				interpretStrongInputs(ref req);
				if (req >= PlayerAnimationTypes.Idle)
				{
					PlayAnimation(req);
				}
			}
			abnormalStateControl.update(deltaTime);
			updateSkillEffectControl(deltaTime);
			justDodge.update(deltaTime);
			updateInAreaState(deltaTime);
			lockOnControl.update(deltaTime);
			reflectAbnormalStateParameters();
			__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__[] array = updateFunctions;
			if (array[RuntimeServices.NormalizeArrayIndex(array, (int)state)] != null)
			{
				__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__[] array2 = updateFunctions;
				array2[RuntimeServices.NormalizeArrayIndex(array2, (int)state)]();
			}
			FaceMovementDirection();
			ActionInput.clearEveryFrame();
			UpdateHUD();
			hitCancelEffectController.update(deltaTime);
			checkDeadAndContinue();
		}
	}

	private int getChainSkillIndexFromActionInput()
	{
		int result = -1;
		if (ActionInput.HasChainMySkill)
		{
			result = 0;
		}
		if (ActionInput.HasChainFriendSkill)
		{
			result = 1;
		}
		return result;
	}

	private bool execChainSkill(int useIdx)
	{
		if (useIdx >= 0)
		{
			MagicSkill poppetMagicSkill = getPoppetMagicSkill(useIdx);
			if (!ChainSkillRoutine.IsPlaying && poppetMagicSkill != null && poppetMagicSkill.canUseSkill())
			{
				ActionInput.clearAll();
				ChainSkillRoutine.Instance.execSkill(this, useIdx);
			}
		}
		return false;
	}

	public GameObject searchTargetEnemy()
	{
		return lockOnControl.searchTargetEnemy();
	}

	private void checkDeadAndContinue()
	{
		if (IsDead && !NageManager.Instance.isEntried(this))
		{
			resetAbnormalState();
		}
	}

	private void checkControllerDevice()
	{
		if (!enableControllerDeviceChecking)
		{
			return;
		}
		if (NeedControllerInput)
		{
			if (!(InputControl is PlayerInputControlByController))
			{
				InputControl = new PlayerInputControlByController(this);
			}
		}
		else if (NeedVirtualPadInput)
		{
			if (!(InputControl is PlayerInputControlByVirtualPad))
			{
				InputControl = new PlayerInputControlByVirtualPad(this);
			}
		}
		else if (!(InputControl is PlayerInputControlByTouch))
		{
			InputControl = new PlayerInputControlByTouch(this);
		}
	}

	private void stateDependLockOnControl()
	{
	}

	private void forbidInputCheck()
	{
		MerlinActionInput merlinActionInput = ActionInput;
		if (IsDead || !IsReady)
		{
			merlinActionInput.clearAll();
		}
		if (AbnormalStateParams.disableMove)
		{
			merlinActionInput.clearMove();
			merlinActionInput.clearKaihi();
		}
		if (AbnormalStateParams.disableAttack)
		{
			merlinActionInput.clearAttack();
		}
		if (isKaihi())
		{
			merlinActionInput.clearKaihi();
		}
		if (isKaihi() || isActionType(ActionTypes.Down) || isYarareZuzaa())
		{
			merlinActionInput.clearAttack();
		}
		if (IsNonBattleMode)
		{
			merlinActionInput.clearSkills();
			merlinActionInput.clearAttack();
		}
	}

	public void UpdateWait()
	{
	}

	public void UpdateBattle()
	{
	}

	protected override void doAddDefaultCommands()
	{
		base.doAddDefaultCommands();
	}

	protected override ActCommand doCreateCancel(float startTime)
	{
		ActionTimerJob actionTimerJob = new ActionTimerJob(startTime, float.MaxValue);
		actionTimerJob.inTimeJob = delegate
		{
			interpretInputsAtIdling();
		};
		actionTimerJob.myName = "PLAYER_DEF_RUN_SHIFT";
		return actionTimerJob;
	}

	protected override ActCommand doCreateMovingControl()
	{
		ActCommandWithHandler actCommandWithHandler = new ActCommandWithHandler();
		actCommandWithHandler.doUpdateHandler = interpretRunInputAtRunning;
		return actCommandWithHandler;
	}

	protected override void doAddDefaultCommandMove()
	{
		base.doAddDefaultCommandMove();
	}

	protected override void doAddDefaultCommandRunningShift()
	{
		base.doAddDefaultCommandRunningShift();
	}

	protected override void doAddDefaultCommandDefaultNEXT()
	{
		if (Mmpc.CurrentAnimType != 23)
		{
			base.doAddDefaultCommandDefaultNEXT();
		}
	}

	protected override void doAddDefaultCommandTargettingCommands()
	{
		base.doAddDefaultCommandTargettingCommands();
	}

	public void interpretInputsAtIdling()
	{
		executeAnimation(delegate(ref PlayerAnimationTypes req)
		{
			PlayerAnimationTypes playerAnimationTypes = interpretCancelInputs();
			MerlinActionInput merlinActionInput = ActionInput;
			if (MerlinActionEnumsModule.IsValidAnimationType(playerAnimationTypes))
			{
				req = playerAnimationTypes;
			}
			else if (merlinActionInput.HasMove)
			{
				req = AnimationTypeRun;
			}
		});
	}

	public void interpretRunInputAtRunning(float dt)
	{
		executeAnimation(delegate(ref PlayerAnimationTypes req)
		{
			MerlinActionInput merlinActionInput = ActionInput;
			PlayerAnimationTypes playerAnimationTypes = interpretCancelInputs();
			if (MerlinActionEnumsModule.IsValidAnimationType(playerAnimationTypes))
			{
				req = playerAnimationTypes;
			}
			else if (merlinActionInput.HasMove)
			{
				setMoveDir(merlinActionInput.moveToDir(MYPOS));
				MoveSpeed = CurrentMoveSpeed;
			}
			else if (raidData.isRaid)
			{
				if (InputActive)
				{
					req = AnimationTypeIdle;
				}
			}
			else
			{
				req = AnimationTypeIdle;
			}
		});
	}

	public PlayerAnimationTypes interpretCancelInputs()
	{
		MerlinActionInput merlinActionInput = ActionInput;
		int result;
		if (!merlinActionInput.HasKaihi)
		{
			result = (merlinActionInput.HasRunAttack ? 12 : ((!merlinActionInput.hasAttack(1)) ? (-1) : 3));
		}
		else
		{
			Mmpc.setYangle(kaihiYAngleFromInput());
			result = 11;
		}
		return (PlayerAnimationTypes)result;
	}

	public void interpretStrongInputs(ref PlayerAnimationTypes req)
	{
		MerlinActionInput merlinActionInput = ActionInput;
		if (merlinActionInput.HasNoutou && !isAnimType(PlayerAnimationTypes.Ev2Bt))
		{
			req = PlayerAnimationTypes.Ev2Bt;
		}
		else if (merlinActionInput.HasBattou && !isAnimType(PlayerAnimationTypes.Bt2Ev))
		{
			req = PlayerAnimationTypes.Bt2Ev;
		}
		int chainSkillIndexFromActionInput = getChainSkillIndexFromActionInput();
		if (chainSkillIndexFromActionInput >= 0)
		{
			execChainSkill(chainSkillIndexFromActionInput);
			merlinActionInput.clearSkillAndChange();
		}
		else if (merlinActionInput.HasChange)
		{
			if (canDoSkill(2))
			{
				DoSkillMain(2, IsNonBattleMode);
			}
			merlinActionInput.clearSkillAndChange();
		}
		else if (merlinActionInput.HasSkill1)
		{
			if (canDoSkill(0))
			{
				DoSkillMain(0);
			}
			merlinActionInput.clearSkillAndChange();
		}
	}

	public void executeAnimation(__PlayerControl_executeAnimation_0024callable63_00242176_32__ c)
	{
		if (!(c == null))
		{
			PlayerAnimationTypes arg = (PlayerAnimationTypes)(-1);
			c(ref arg);
			if (arg >= PlayerAnimationTypes.Idle && arg < PlayerAnimationTypes.Max)
			{
				PlayAnimation(arg);
			}
		}
	}

	private bool isAnimNoutouBattou()
	{
		bool num = isAnimType(PlayerAnimationTypes.Bt2Ev);
		if (!num)
		{
			num = isAnimType(PlayerAnimationTypes.Ev2Bt);
		}
		return num;
	}

	public override void LateUpdate()
	{
		if (!RuntimeDebugMode.Instance.IsInDebugMode && !Pause && IsReady)
		{
			base.LateUpdate();
			UpdateSkillCoolDown(Time.deltaTime);
			DrawHitPointGauge();
		}
	}

	public override void FixedUpdate()
	{
		if (!RuntimeDebugMode.Instance.IsInDebugMode && !Pause && IsReady)
		{
			base.FixedUpdate();
			Vector3 knockBack = KnockBack;
			inAreaStateFixedUpdate();
			knockBack += InAreaStateExtraMovementOfFixedUpdate;
			setExtraMovement(knockBack);
			if (!(myTransform.position.y >= -40f))
			{
				standGround(myTransform);
			}
			KnockBack *= 0.5f;
			previouslyPos = myTransform.position;
		}
	}

	public object[] GetTerrainHeight(Vector3 pos)
	{
		Terrain activeTerrain = Terrain.activeTerrain;
		object result;
		if (!activeTerrain || !activeTerrain.terrainData)
		{
			pos.y = 0f;
			result = new object[3]
			{
				false,
				0f,
				Vector3.up
			};
		}
		else
		{
			Vector3 vector = pos - activeTerrain.transform.position;
			Vector2 vector2 = new Vector2(Mathf.InverseLerp(0f, activeTerrain.terrainData.size.x, vector.x), Mathf.InverseLerp(0f, activeTerrain.terrainData.size.z, vector.z));
			Vector3 interpolatedNormal = activeTerrain.terrainData.GetInterpolatedNormal(vector2.x, vector2.y);
			float num = activeTerrain.terrainData.GetInterpolatedHeight(vector2.x, vector2.y) + activeTerrain.transform.position.y;
			result = new object[3] { true, num, interpolatedNormal };
		}
		return (object[])result;
	}

	public void FaceMovementDirection()
	{
		if (noFaceMovement || disableFaceMovement)
		{
			return;
		}
		Vector3 velocity = CharControl.velocity;
		velocity.y = 0f;
		if (!((double)velocity.magnitude <= 0.1) && isRun())
		{
			myTransform.forward = velocity.normalized;
		}
		else if (lockOnControl.IsLockedOn)
		{
			Transform targetTransform = lockOnControl.TargetTransform;
			if ((equipType != EnumStyles.Sword || !Mmpc.isAnimType(28) || Mmpc.MotionTime <= 0.3f) && (equipType != EnumStyles.Knuckle || !Mmpc.isAnimType(29) || Mmpc.MotionTime <= 0.8f) && (isIdle() || isActionType(ActionTypes.Attack) || isActionType(ActionTypes.Skill)))
			{
				Vector3 vector = targetTransform.position - MYPOS;
				vector.y = 0f;
				myTransform.forward = vector.normalized;
			}
		}
	}

	public MerlinMotionPackControl.Command PlayAnimationIdle()
	{
		return PlayAnimation(AnimationTypeIdle, crossFadeIfNeed: true);
	}

	public MerlinMotionPackControl.Command PlayAnimationIdleNoCrossfade()
	{
		return PlayAnimation(AnimationTypeIdle, crossFadeIfNeed: false);
	}

	public MerlinMotionPackControl.Command PlayAnimationRun()
	{
		return PlayAnimation(AnimationTypeRun);
	}

	public MerlinMotionPackControl.Command PlayAnimation(PlayerAnimationTypes _animationState)
	{
		return PlayAnimation(_animationState, crossFadeIfNeed: true);
	}

	public MerlinMotionPackControl.Command PlayAnimation(PlayerAnimationTypes _animationState, bool crossFadeIfNeed)
	{
		object result;
		if (_animationState < PlayerAnimationTypes.Idle || _animationState >= PlayerAnimationTypes.Max)
		{
			result = null;
		}
		else
		{
			bool flag = isIdle(_animationState);
			bool flag2 = isRun(_animationState);
			result = ((Mmpc.CurrentAnimType == (int)_animationState && flag2) ? null : (flag ? playAnimationByType(_animationState, crossFadeIfNeed) : ((!flag2) ? playAnimationByType(_animationState, crossFadeIfNeed) : playAnimationByType(_animationState, crossFadeIfNeed))));
		}
		return (MerlinMotionPackControl.Command)result;
	}

	public MerlinMotionPackControl.Command PlayAnimation(string animName, string[] keywords)
	{
		return (!string.IsNullOrEmpty(animName)) ? playAnimationByName(animName) : null;
	}

	public void UpdateHUD()
	{
		if (useHUD && checked(++hudUpdateCounter) >= HudUpdateStep)
		{
			hudUpdateCounter = 0;
			if (IsDead || CutSceneManager.Instance.isBusy)
			{
				BattleHUD.Hide();
			}
			else if (sceneMode == SceneMode.Town)
			{
				BattleHUD.ShowForTown();
			}
			else if (sceneMode == SceneMode.Raid)
			{
				BattleHUD.ShowNonMappetHUD();
			}
			else if (battleMode == BATTLE_MODE.Battle)
			{
				BattleHUD.Show();
			}
			else if (battleMode == BATTLE_MODE.Non_Battle)
			{
				BattleHUD.ShowNonBattle();
			}
			else
			{
				BattleHUD.Hide();
			}
			BattleHUDSkill.SetTargetChar(gameObject);
			TargetHitPointBar.SetPlayer(gameObject);
			initPoppetHUD();
		}
	}

	public void initPoppetHUD()
	{
		if (!useHUD)
		{
			return;
		}
		int num = 0;
		while (num < 2)
		{
			int num2 = num;
			num++;
			object obj;
			if (num2 < _poppets.Length)
			{
				AIControl[] poppets = _poppets;
				obj = poppets[RuntimeServices.NormalizeArrayIndex(poppets, num2)];
			}
			else
			{
				obj = null;
			}
			AIControl aIControl = (AIControl)obj;
			if (aIControl != null && aIControl.gameObject.activeSelf)
			{
				BattleHUDMappet.SetTargetMappet(num2, aIControl.gameObject);
				BattleHUDMappetIdentifier.EnableIdentifier(num2, aIControl.gameObject);
				RespPoppet respPoppet = aIControl.PoppetData;
				BattleHUD.SetMagicGaugeFaceIcon(num2, respPoppet);
				BattleHUD.SetMagicGaugeName(num2, respPoppet.Name);
			}
			else
			{
				BattleHUDMappet.ResetTargetMappet(num2);
				BattleHUDMappetIdentifier.DisableIdentifier(num2);
			}
		}
	}

	public override void resetAbnormalState()
	{
		base.resetAbnormalState();
	}

	public bool CanRun()
	{
		bool num = isActionType(ActionTypes.Idle);
		if (!num)
		{
			num = isActionType(ActionTypes.Moving);
		}
		return num;
	}

	public bool canAttack()
	{
		bool num = isActionType(ActionTypes.Idle);
		if (!num)
		{
			num = isActionType(ActionTypes.Moving);
		}
		if (!num)
		{
			num = isActionType(ActionTypes.Cancel);
		}
		return num;
	}

	public bool CanRunAttack(float enemyRange)
	{
		bool num = !(2.5f > enemyRange);
		if (num)
		{
			num = !(enemyRange > 500f);
		}
		return num;
	}

	public bool CheckCaracterFront(Vector3 targetPosition)
	{
		Vector3 rhs = targetPosition - myTransform.position;
		Vector3 lhs = myTransform.TransformDirection(Vector3.forward);
		float num = Vector3.Dot(lhs, rhs);
		return (double)num > 0.0;
	}

	public void OnSkill1Button()
	{
		if (IsAutoBattleMode)
		{
			QueuingAutoWeaponSkill();
		}
		else
		{
			ActionInput.skill1();
		}
	}

	public void OnSkill2Button()
	{
	}

	public void OnSkill3Button()
	{
		if (IsAutoBattleMode)
		{
			QueuingAutoChange();
		}
		else
		{
			ActionInput.change();
		}
	}

	private bool canDoSkill(int skillID)
	{
		int result;
		if (AbnormalStateParams.disableSkill)
		{
			result = 0;
		}
		else if (skillID < 0 || skillID >= skillCoolDowns.Length)
		{
			result = 0;
		}
		else
		{
			CooldownValue[] array = skillCoolDowns;
			result = ((array[RuntimeServices.NormalizeArrayIndex(array, skillID)].IsReady && state == STATE.Battle && !IsDead && !NageManager.Instance.isEntried(this)) ? 1 : 0);
		}
		return (byte)result != 0;
	}

	public bool DoSkillMain(int skillID)
	{
		return DoSkillMain(skillID, ignoreCoolDown: false);
	}

	private bool DoSkillMain(int skillID, bool ignoreCoolDown)
	{
		int result;
		if (skillID >= 3)
		{
			result = 0;
		}
		else if (IsDead)
		{
			result = 0;
		}
		else
		{
			if (InputControl != null)
			{
				InputControl.clear();
			}
			lockOnControl.searchAndStartIfNotLockedOn();
			if (!ignoreCoolDown)
			{
				CooldownValue[] array = skillCoolDowns;
				array[RuntimeServices.NormalizeArrayIndex(array, skillID)].heatUp();
				if (useHUD)
				{
					BattleHUDSkill.UseSkillAnimation(skillID);
				}
			}
			if (!IsDead)
			{
				if (skillID != 2)
				{
					MWeaponSkills mWeaponSkills = null;
					mWeaponSkills = ((!IsTensi) ? getMainWeapon().DemonSkill : getMainWeapon().AngelSkill);
					if (mWeaponSkills == null)
					{
						result = 0;
						goto IL_0101;
					}
					playWeaponSkillMotion(mWeaponSkills);
				}
				else
				{
					IEnumerator enumerator = ChangeTensiAkuma();
					if (enumerator != null)
					{
						StartCoroutine(enumerator);
					}
				}
				playSE(skill_4SQEX_SE);
				gameObject.SendMessage("raidSkill", skillID, SendMessageOptions.DontRequireReceiver);
				result = 1;
			}
			else
			{
				result = 0;
			}
		}
		goto IL_0101;
		IL_0101:
		return (byte)result != 0;
	}

	private void playWeaponSkillMotion(MWeaponSkills skmst)
	{
		if (skmst != null)
		{
			string[] keywords = null;
			if (skmst.Rank >= 2)
			{
				keywords = new string[1] { new StringBuilder("rank").Append((object)skmst.Rank).ToString() };
			}
			MerlinMotionPackControl.PlayReq req = new MerlinMotionPackControl.PlayReq(skmst.Motion, keywords, 0f);
			playAnimationByReq(req);
		}
	}

	public override void HitAttack(int damage, YarareTypes yarare, GameObject attackChar)
	{
		gameObject.SendMessage("raidGetDamage", yarare, SendMessageOptions.DontRequireReceiver);
		checked
		{
			if (GameParameter.jisatu)
			{
				damage = (int)HitPoint;
			}
			decHP(damage);
			if (HitPoint > 0f)
			{
				recoveryDamage = (int)((float)recoveryDamage + (float)damage * 0.666f);
				switch (yarare)
				{
				case YarareTypes.None:
					break;
				case YarareTypes.Weak:
					PlayAnimation(PlayerAnimationTypes.YarareWeak);
					break;
				case YarareTypes.Down:
					PlayAnimation(PlayerAnimationTypes.YarareDown);
					break;
				case YarareTypes.Zuzaa:
					PlayAnimation(PlayerAnimationTypes.YarareZuzaa);
					break;
				default:
					PlayAnimation(PlayerAnimationTypes.YarareDown);
					break;
				}
			}
		}
	}

	public void playDead()
	{
		PlayAnimation(PlayerAnimationTypes.YarareDead);
	}

	public float execDrainSkill(float rate)
	{
		checked
		{
			int num = (int)Mathf.Max(rate * MaxHitPoint, 1f);
			HitPointRecovery(num);
			recoveryDamage = Mathf.Max(recoveryDamage - num, 0);
			return num;
		}
	}

	public void addRecoveryDamage(float rate)
	{
		recoveryDamage = checked((int)((float)recoveryDamage + rate * MaxHitPoint));
	}

	public void setRecoveryDamage(float rd)
	{
		recoveryDamage = checked((int)rd);
	}

	private void recalcHPMax()
	{
		recalcHPMax(PoppetsData);
	}

	private void recalcHPMax(RespPoppet[] ppts)
	{
		SkillEffectControl.recalcAllSkillEffection();
		SkillEffectData currentData = SkillEffectControl.CurrentData;
		float @base = Mathf.Round(totalPlayerHP(ppts));
		float hitPointAndHitPointMax = currentData.calcHpMax(@base);
		setHitPointAndHitPointMax(hitPointAndHitPointMax);
		recoveryDamage = 0;
	}

	public float totalPlayerAttack()
	{
		return Mathf.Floor(DamageCalc.TotalPlayerAttack(weaponEquipments, CurrentPoppetData));
	}

	public float totalPlayerHP()
	{
		return totalPlayerHP(PoppetsData);
	}

	private float totalPlayerHP(RespPoppet[] ppts)
	{
		return Mathf.Floor(DamageCalc.TotalPlayerHP(weaponEquipments, ppts));
	}

	private void recalcAndChargeHP()
	{
		recalcHPMax();
		if (useHUD)
		{
			BattleHUDPlayerInfo.SetHitPointNum(checked((int)HitPoint));
		}
	}

	private void recalcAndChargeHP(RespPoppet[] ppts)
	{
		recalcHPMax(ppts);
		if (useHUD)
		{
			BattleHUDPlayerInfo.SetHitPointNum(checked((int)HitPoint));
		}
	}

	public void recalcParametersFromWeaponsAndPoppets()
	{
		recalcAndChargeHP();
	}

	public override void addHP(float hp)
	{
		if (!(hp >= 0f))
		{
			string text = "hp >= 0.0F";
			MerlinServer.FatalErrorDialog(text, "Assets/Scripts/Character/PlayerControl.boo(2540)", string.Empty);
			Debug.LogError(text);
			TestFlightUnity.PassCheckpoint(text);
			throw new Exception(text);
		}
		addHitPoint(hp);
		if (useHUD)
		{
			BattleHUDPlayerInfo.SetHitPointNum(checked((int)HitPoint));
		}
	}

	public void setHP(float hp)
	{
		if (!(hp >= 0f))
		{
			string text = "hp >= 0.0F";
			MerlinServer.FatalErrorDialog(text, "Assets/Scripts/Character/PlayerControl.boo(2545)", string.Empty);
			Debug.LogError(text);
			TestFlightUnity.PassCheckpoint(text);
			throw new Exception(text);
		}
		HitPoint = hp;
		if (useHUD)
		{
			BattleHUDPlayerInfo.SetHitPointNum(checked((int)HitPoint));
		}
	}

	public override void decHP(float damage)
	{
		if (!(HitPoint <= MaxHitPoint * 0.333f) && !(HitPoint - damage > MaxHitPoint * 0.333f))
		{
			playSE(SQEX_SoundPlayerData.SE.dying_alert);
		}
		HitPoint -= damage;
		if (GameParameter.notDead)
		{
			HitPoint = Mathf.Max(1f, HitPoint);
		}
		if (useHUD)
		{
			BattleHUDPlayerInfo.SetHitPointNum(checked((int)HitPoint));
			if (!(HitPoint > MaxHitPoint * 0.333f))
			{
				BattleHUDPlayerInfo.EnableNearDeathTween();
			}
		}
		if (!(HitPoint > 0f))
		{
			HitPoint = 0f;
			PlayAnimation(PlayerAnimationTypes.YarareDead);
		}
		else
		{
			MagicPointCalc.DamageToPlayer(damage, this);
		}
	}

	public void addMagicPoint(int point)
	{
		AIControl[] poppets = _poppets;
		int length = poppets.Length;
		int num = 0;
		while (num < length)
		{
			AIControl aIControl = poppets[RuntimeServices.NormalizeArrayIndex(poppets, checked(num++))];
			if (!(aIControl == null))
			{
				MagicSkill magicSkillComponent = aIControl.MagicSkillComponent;
				if (!(magicSkillComponent == null) && !SkillEffectControl.hasNonInfinityEffectorOriginedBy(aIControl.PoppetData))
				{
					magicSkillComponent.addMagicPoint(point);
				}
			}
		}
	}

	public float[] getMagicPointList()
	{
		Boo.Lang.List<float> list = new Boo.Lang.List<float>();
		AIControl[] poppets = _poppets;
		int length = poppets.Length;
		int num = 0;
		while (num < length)
		{
			AIControl aIControl = poppets[RuntimeServices.NormalizeArrayIndex(poppets, checked(num++))];
			if (!(aIControl == null))
			{
				MagicSkill magicSkillComponent = aIControl.MagicSkillComponent;
				if (magicSkillComponent != null)
				{
					list.Add(magicSkillComponent.MagicPoint);
				}
			}
		}
		return (float[])Builtins.array(typeof(float), list);
	}

	public void setMagicPoints(float[] points)
	{
		if (points == null)
		{
			return;
		}
		int num = Mathf.Min(points.Length, _poppets.Length);
		int num2 = 0;
		int num3 = num;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int index = num2;
			num2++;
			AIControl[] poppets = _poppets;
			AIControl aIControl = poppets[RuntimeServices.NormalizeArrayIndex(poppets, index)];
			if (!(aIControl == null))
			{
				MagicSkill magicSkillComponent = aIControl.MagicSkillComponent;
				if (magicSkillComponent != null)
				{
					magicSkillComponent.setMagicPoint(points[RuntimeServices.NormalizeArrayIndex(points, index)]);
				}
			}
		}
	}

	public int[] addMagicPointRate(float rate)
	{
		int[] array = new int[_poppets.Length];
		int num = 0;
		int length = _poppets.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length)
		{
			int index = num;
			num++;
			AIControl[] poppets = _poppets;
			if (!(poppets[RuntimeServices.NormalizeArrayIndex(poppets, index)] == null))
			{
				AIControl[] poppets2 = _poppets;
				MagicSkill magicSkillComponent = poppets2[RuntimeServices.NormalizeArrayIndex(poppets2, index)].MagicSkillComponent;
				if (magicSkillComponent != null)
				{
					array[RuntimeServices.NormalizeArrayIndex(array, index)] = magicSkillComponent.addMagicPointRate(rate);
				}
			}
		}
		return array;
	}

	private bool inDeltaTime(float time)
	{
		return Mmpc.isAtTime(time);
	}

	private bool inDeltaTime(float time, float preTime, float nowTime)
	{
		bool num = !(preTime > time);
		if (num)
		{
			num = time < nowTime;
		}
		return num;
	}

	private void DrawHitPointGauge()
	{
		if (useHUD)
		{
			BattleHUDPlayerInfo.SetRecoverDamageBar(HitPoint, MaxHitPoint, recoveryDamage);
			BattleHUDPlayerInfo.SetHitPointBarValue(HitPoint, MaxHitPoint);
		}
	}

	public float RecoverByCandy()
	{
		float result = HitPointRecoveryRate(SkillEffect.candyRecoveryRate);
		float candyMagicRecoveryValue = SkillEffect.candyMagicRecoveryValue;
		if (!(candyMagicRecoveryValue <= 0f))
		{
			addMagicPoint(checked((int)candyMagicRecoveryValue));
		}
		return result;
	}

	public override float HitPointRecovery(float recovery)
	{
		HitPoint = Mathf.Min(HitPoint + recovery, MaxHitPoint);
		checked
		{
			if (!(HitPoint + (float)recoveryDamage <= MaxHitPoint))
			{
				recoveryDamage = (int)(MaxHitPoint - HitPoint);
			}
			if (useHUD)
			{
				BattleHUDPlayerInfo.SetHitPointNum((int)HitPoint);
				if (!(HitPoint <= MaxHitPoint * 0.333f))
				{
					BattleHUDPlayerInfo.DisableNearDeathTween();
				}
			}
			return recovery;
		}
	}

	public void OnTriggerEnter(Collider other)
	{
		DropBase component = other.GetComponent<DropBase>();
		if (component != null)
		{
			component.OnTriggerEnter(coliYarare);
		}
	}

	public void ToggleBattleMode()
	{
		if (battleMode == BATTLE_MODE.Battle)
		{
			ChangeBattleMode(BATTLE_MODE.Non_Battle);
		}
		else
		{
			ChangeBattleMode(BATTLE_MODE.Battle);
		}
	}

	public void setBattleMode()
	{
		ChangeBattleMode(BATTLE_MODE.Battle);
	}

	public void setNonBattleMode()
	{
		ChangeBattleMode(BATTLE_MODE.Non_Battle);
	}

	public void ChangeBattleMode(BATTLE_MODE _battleMode)
	{
		if (battleMode == _battleMode || IsDead)
		{
			return;
		}
		battleMode = _battleMode;
		resetAbnormalState();
		if (battleMode == BATTLE_MODE.Battle)
		{
			if (playEv2Bt)
			{
				destroyAllCommands();
			}
			playAnimationByType(PlayerAnimationTypes.Ev2Bt);
			if ((bool)Camera.main)
			{
				CameraControl component = Camera.main.GetComponent<CameraControl>();
				if ((bool)component)
				{
					component.battleCameraUpdate();
				}
			}
			autoBattle.enabled = enableAuto;
			CharPathFinder.Stop();
		}
		else
		{
			if (playBt2Ev)
			{
				destroyAllCommands();
			}
			playAnimationByType(PlayerAnimationTypes.Bt2Ev);
			if ((bool)Camera.main)
			{
				CameraControl component = Camera.main.GetComponent<CameraControl>();
				if ((bool)component)
				{
					component.fieldCameraUpdate();
				}
			}
			autoBattle.enabled = false;
		}
		if (InputControl != null)
		{
			InputControl.clear();
		}
	}

	public MerlinMotionPackControl.Command playChainSkillAction(PlayerAnimationTypes anim, MChainSkills cskmst)
	{
		if (cskmst == null)
		{
			string text = "cskmst != null";
			MerlinServer.FatalErrorDialog(text, "Assets/Scripts/Character/PlayerControl.boo(2703)", string.Empty);
			Debug.LogError(text);
			TestFlightUnity.PassCheckpoint(text);
			throw new Exception(text);
		}
		string[] keywords = new string[1] { cskmst.Progname };
		MerlinMotionPackControl.PlayReq req = new MerlinMotionPackControl.PlayReq((int)anim, keywords, 0f);
		return playAnimationByReq(req);
	}

	public void enableColiYarare(bool b)
	{
		if (coliYarare != null)
		{
			coliYarare.gameObject.SetActive(b);
		}
	}

	public void enableContinuePanel(bool b)
	{
		enabledContinue = b;
	}

	public bool isLockOn()
	{
		return enemyTransform != null;
	}

	public GameObject getLockOnEnemy()
	{
		return enemyTransform.gameObject;
	}

	public void kill()
	{
		HitPoint = 0f;
		PlayAnimation(PlayerAnimationTypes.YarareDead);
	}

	public bool isIdle()
	{
		return isActionType(ActionTypes.Idle);
	}

	public bool isRun()
	{
		return isActionType(ActionTypes.Moving);
	}

	public bool isRunAttack()
	{
		return Mmpc.isAnimType(12);
	}

	public bool isAttack1()
	{
		return Mmpc.isAnimType(3);
	}

	public bool isAttack2()
	{
		return Mmpc.isAnimType(4);
	}

	public bool isAttack3()
	{
		return Mmpc.isAnimType(5);
	}

	public bool isAttack4()
	{
		return Mmpc.isAnimType(6);
	}

	public bool isAttack5()
	{
		return Mmpc.isAnimType(7);
	}

	public bool isAttack6()
	{
		return Mmpc.isAnimType(8);
	}

	public bool isYarareDown()
	{
		return Mmpc.isAnimType(14);
	}

	public bool isYarareZuzaa()
	{
		return Mmpc.isAnimType(16);
	}

	public bool isYarareWeak()
	{
		return Mmpc.isAnimType(15);
	}

	public bool isYarareDead()
	{
		return Mmpc.isAnimType(13);
	}

	public bool isKaihi()
	{
		return Mmpc.isAnimType(11);
	}

	public bool isSpAtk1()
	{
		return Mmpc.isAnimType(24);
	}

	public override void cleanUpAnimations()
	{
		MerlinActionControl.CleanUpAnimations(tensiModel);
		MerlinActionControl.CleanUpAnimations(akumaModel);
	}

	public void reviveTutorial()
	{
		HitPointRecoveryRate(1f);
		emitChangeEffect(transform.position, Quaternion.identity);
		abnormalStateControl.clearAll();
		unsetRejectMode();
		PlayAnimationIdle();
		Mmpc.TimeScale = CurrentMotionTimeScale;
	}

	public void TOUCH_HOLD_COMB()
	{
		__CooldownValue_UpdateHandler_0024callable50_002433_30__ job = delegate
		{
		};
		__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ dispose = delegate
		{
		};
		ActionUpdateJob cmd = new ActionUpdateJob(job, dispose);
		addCommand(cmd);
	}

	public void reviveForContinue()
	{
		recalcAndChargeHP();
		HitPointRecoveryRate(1f);
		abnormalStateControl.clearAll();
		emitChangeEffect(transform.position, Quaternion.identity);
		forceToIdle();
		enableAuto = UserData.Current.Config.IsAutoBattleEnabled;
		autoBattle.enabled = enableAuto;
	}

	public void revivePoppetsForContinue()
	{
		AIControl[] poppets = _poppets;
		int length = poppets.Length;
		int num = 0;
		while (num < length)
		{
			AIControl aIControl = poppets[RuntimeServices.NormalizeArrayIndex(poppets, checked(num++))];
			if (aIControl == null)
			{
				continue;
			}
			AIControl component = aIControl.GetComponent<AIControl>();
			if ((bool)component)
			{
				if (!(component.HitPoint > 0f))
				{
					component.Revive();
					UnityEngine.Object.Instantiate(helixHealing, aIControl.transform.position, Quaternion.identity);
					emitChangeEffect(aIControl.transform.position, Quaternion.identity);
				}
				else
				{
					component.HitPoint = component.MaxHitPoint;
				}
			}
		}
	}

	public void revivePoppetsIfDead()
	{
		AIControl[] poppets = _poppets;
		int length = poppets.Length;
		int num = 0;
		while (num < length)
		{
			AIControl aIControl = poppets[RuntimeServices.NormalizeArrayIndex(poppets, checked(num++))];
			if (!(aIControl == null))
			{
				AIControl component = aIControl.GetComponent<AIControl>();
				if (component != null && component.IsDead)
				{
					component.Revive();
					UnityEngine.Object.Instantiate(helixHealing, aIControl.transform.position, Quaternion.identity);
					emitChangeEffect(aIControl.transform.position, Quaternion.identity);
				}
			}
		}
	}

	public void CHAINEFF(float emitTime, string boneName, ActionCommandEffect.TransformMode emitMode, ActionCommandEffect.TransformMode constraintMode, float offset_x, float offset_y, float offset_z, float rot_x, float rot_y, float rot_z)
	{
	}

	public void EFF_USE_POPPET_ATTACK(float rate)
	{
	}

	public void PVOICE(float time, string seName)
	{
		_0024PVOICE_0024locals_002414358 _0024PVOICE_0024locals_0024 = new _0024PVOICE_0024locals_002414358();
		_0024PVOICE_0024locals_0024._0024seName = seName;
		ActionTimerJob cmd = new ActionTimerJob(time, new __ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__(new _0024PVOICE_0024closure_00243916(this, _0024PVOICE_0024locals_0024).Invoke));
		addCommand(cmd);
	}

	public int PlayerVoice(string seName, int fadeInMSec)
	{
		int num = seName.IndexOf("c000");
		if (num >= 0)
		{
			UserData current = UserData.Current;
			int num2 = current.AngelGender;
			int num3 = current.DemonGender;
			if (spawnParam.useReservedGender)
			{
				num2 = (int)spawnParam.reservedTenshiGender;
				num3 = (int)spawnParam.reservedAkumaGender;
			}
			string rhs = "0";
			if (IsTensi)
			{
				if (num2 == 1)
				{
					rhs = "2";
				}
			}
			else
			{
				if (num3 == 2)
				{
					rhs = "1";
				}
				if (num3 == 1)
				{
					rhs = "3";
				}
			}
			seName = checked(seName.Substring(0, num + 4) + rhs + seName.Substring(num + 5));
		}
		playSE(seName);
		return 0;
	}

	public void KAIHI(float start, float end)
	{
		ActionTimerJob actionTimerJob = new ActionTimerJob(start, end);
		actionTimerJob.inTimeJob = delegate
		{
			if (ActionInput.HasKaihi)
			{
				Mmpc.setYangle(kaihiYAngleFromInput());
				PlayAnimation(PlayerAnimationTypes.Kaihi);
			}
		};
		actionTimerJob.myName = "KAIHI";
		addCommand(actionTimerJob);
	}

	private float kaihiYAngleFromInput()
	{
		return kaihiYAngle(ActionInput.KaihiAngle);
	}

	private float kaihiYAngle(float inpAngle)
	{
		float num = Camera.main.transform.eulerAngles.y - 180f;
		return inpAngle + num;
	}

	public void JUST_DODGE(float start, float end)
	{
		_0024JUST_DODGE_0024locals_002414359 _0024JUST_DODGE_0024locals_0024 = new _0024JUST_DODGE_0024locals_002414359();
		ActionTimerJob actionTimerJob = new ActionTimerJob(start, end);
		_0024JUST_DODGE_0024locals_0024._0024time = end - start + SkillEffect.justDodgeTimeBonus;
		actionTimerJob.startJob = new _0024JUST_DODGE_0024closure_00243918(this, _0024JUST_DODGE_0024locals_0024).Invoke;
		actionTimerJob.endJob = delegate
		{
			justDodge.reset();
		};
		actionTimerJob.myName = "JUST_DODGE";
		addCommand(actionTimerJob);
	}

	public void NOUTOU(float startTime)
	{
		__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ = delegate
		{
			showWeapons(show: false);
		};
		ActionTimerJob actionTimerJob = new ActionTimerJob(startTime, _ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__);
		actionTimerJob.disposeJob = _ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__;
		actionTimerJob.myName = "NOUTOU";
		addCommand(actionTimerJob);
	}

	public void BATTOU(float startTime)
	{
		__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ _ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__ = delegate
		{
			showWeapons(show: true);
		};
		ActionTimerJob actionTimerJob = new ActionTimerJob(startTime, _ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__);
		actionTimerJob.disposeJob = _ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__;
		actionTimerJob.myName = "BATTOU";
		addCommand(actionTimerJob);
	}

	public override void NO_TARGET()
	{
		noFaceMovement = true;
	}

	public override void MOVE(ActionDirections dir, float start, float end, float spd)
	{
		float num = currentMoveScale();
		ActionCommandTranslate cmd = new ActionCommandTranslate(start, end, dir, spd * num);
		addCommand(cmd);
	}

	public void startHUDSkillTimerMode(int poppetIndex, SkillEffector skeff)
	{
		if (skeff == null || poppetIndex < 0 || poppetIndex >= Poppets.Length)
		{
			return;
		}
		AIControl[] poppets = Poppets;
		AIControl aIControl = poppets[RuntimeServices.NormalizeArrayIndex(poppets, poppetIndex)];
		if (!(aIControl == null) && !skeff.IsExpired && skeff.InitialExpirationTime > 0f)
		{
			__PlayerControl_startHUDSkillTimerMode_0024callable175_00242938_13__ _PlayerControl_startHUDSkillTimerMode_0024callable175_00242938_13__ = (int pidx, SkillEffector skeff) => new _0024_0024startHUDSkillTimerMode_0024routine_00243922_002417144(pidx, skeff, this).GetEnumerator();
			IEnumerator enumerator = _PlayerControl_startHUDSkillTimerMode_0024callable175_00242938_13__(poppetIndex, skeff);
			if (enumerator != null)
			{
				StartCoroutine(enumerator);
			}
		}
	}

	public override bool isEnemy(MerlinActionControl other)
	{
		return !hasPoppet(other as AIControl);
	}

	internal RespPoppet _0024get_CurrentPoppetData_0024closure_00243101(AIControl _0024genarray_00241299)
	{
		return _0024genarray_00241299.PoppetData;
	}

	internal void _0024initializeCooldowns_0024endCooldown_00243870(int index, SQEX_SoundPlayerData.SE se)
	{
		BattleHUDSkill.SetButtonAttr(index, string.Empty, Color.white);
		BattleHUDSkill.RechargeSkillAnimation(index);
		playSE(se);
	}

	internal void _0024initializeCooldowns_0024enableSkillHUD_00243874(int i, float val)
	{
		Color col = new Color(0.4f, 0.4f, 0.4f, 1f);
		int num = Mathf.CeilToInt(val);
		if (useHUD)
		{
			BattleHUDSkill.SetButtonAttr(i, new StringBuilder().Append((object)num).ToString(), col);
		}
	}

	internal void _0024SetTouchEvent_0024closure_00243881(object me, Vector3 vTargetPos)
	{
		if (CharPathFinder != null)
		{
			CharPathFinder.Goto(vTargetPos);
		}
	}

	internal IEnumerator _0024coEquipMainWeaponRoutine_0024_equip_00243896(GameObject[] hands, MWeapons wpnMst, GameObject[] outLoadedObjes, __PlayerControl_coEquipMainWeaponRoutine_0024callable62_00241518_36__ handler)
	{
		return new _0024_0024coEquipMainWeaponRoutine_0024_equip_00243896_002417125(hands, wpnMst, outLoadedObjes, handler, this).GetEnumerator();
	}

	internal void _0024coEquipMainWeaponRoutine_0024_initTenshiAfterLoad_00243897(Collider[] colis)
	{
		attackColisTensi = colis;
	}

	internal void _0024coEquipMainWeaponRoutine_0024_initAkumaAfterLoad_00243898(Collider[] colis)
	{
		attackColisAkuma = colis;
	}

	internal void _0024doCreateCancel_0024closure_00243907()
	{
		interpretInputsAtIdling();
	}

	internal void _0024interpretInputsAtIdling_0024closure_00243908(ref PlayerAnimationTypes req)
	{
		PlayerAnimationTypes playerAnimationTypes = interpretCancelInputs();
		MerlinActionInput merlinActionInput = ActionInput;
		if (MerlinActionEnumsModule.IsValidAnimationType(playerAnimationTypes))
		{
			req = playerAnimationTypes;
		}
		else if (merlinActionInput.HasMove)
		{
			req = AnimationTypeRun;
		}
	}

	internal void _0024interpretRunInputAtRunning_0024closure_00243909(ref PlayerAnimationTypes req)
	{
		MerlinActionInput merlinActionInput = ActionInput;
		PlayerAnimationTypes playerAnimationTypes = interpretCancelInputs();
		if (MerlinActionEnumsModule.IsValidAnimationType(playerAnimationTypes))
		{
			req = playerAnimationTypes;
		}
		else if (merlinActionInput.HasMove)
		{
			setMoveDir(merlinActionInput.moveToDir(MYPOS));
			MoveSpeed = CurrentMoveSpeed;
		}
		else if (raidData.isRaid)
		{
			if (InputActive)
			{
				req = AnimationTypeIdle;
			}
		}
		else
		{
			req = AnimationTypeIdle;
		}
	}

	internal void _0024TOUCH_HOLD_COMB_0024closure_00243912(float motionTime)
	{
	}

	internal void _0024TOUCH_HOLD_COMB_0024closure_00243913()
	{
	}

	internal void _0024KAIHI_0024closure_00243917()
	{
		if (ActionInput.HasKaihi)
		{
			Mmpc.setYangle(kaihiYAngleFromInput());
			PlayAnimation(PlayerAnimationTypes.Kaihi);
		}
	}

	internal void _0024JUST_DODGE_0024closure_00243919()
	{
		justDodge.reset();
	}

	internal void _0024NOUTOU_0024closure_00243920()
	{
		showWeapons(show: false);
	}

	internal void _0024BATTOU_0024closure_00243921()
	{
		showWeapons(show: true);
	}

	internal IEnumerator _0024startHUDSkillTimerMode_0024routine_00243922(int pidx, SkillEffector skeff)
	{
		return new _0024_0024startHUDSkillTimerMode_0024routine_00243922_002417144(pidx, skeff, this).GetEnumerator();
	}
}
