using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using GameAsset;
using MerlinAPI;
using ObjUtil;
using UnityEngine;

[Serializable]
public abstract class DamageCalc
{
	[Serializable]
	public struct Log
	{
		public string Name;

		public string Value;

		public override string ToString()
		{
			return new StringBuilder().Append(Name).Append(":").Append(Value)
				.ToString();
		}
	}

	[Serializable]
	public struct BonusValue
	{
		public int attack;

		public int hp;

		public object[] evoTrack;
	}

	private bool guardCancel;

	private MerlinActionControl attackerControl;

	private MerlinActionControl defenserControl;

	protected float outDamage;

	protected bool outCriticalOk;

	protected YarareTypes outYarareType;

	protected bool outGuardOk;

	protected bool outDodgeHealOk;

	protected bool outInvalidateSuperArmor;

	protected bool outAntiInvalidateSuperArmor;

	protected bool outIsSucceededDodgeAction;

	[NonSerialized]
	public static bool _DebugUseParams;

	[NonSerialized]
	public static float DebugTotalPlayerHP = 100f;

	[NonSerialized]
	public static float DebugTotalWeaponAttack = 100f;

	[NonSerialized]
	private static Boo.Lang.List<Log> logs = new Boo.Lang.List<Log>();

	[NonSerialized]
	private static Queue<string> logHistory = new Queue<string>();

	public float Damage => Mathf.Round(outDamage);

	public bool CriticalOk => outCriticalOk;

	public bool GuardOk => outGuardOk;

	public bool DodgeHealOk => outDodgeHealOk;

	public bool IsSucceededDodgeAction => outIsSucceededDodgeAction;

	public bool InvalidateSuperArmor => outInvalidateSuperArmor;

	public bool AntiInvalidateSuperArmor => outAntiInvalidateSuperArmor;

	public YarareTypes YarareType => outYarareType;

	protected PlayerAbnormalStateControl.StateParams AttackerAbsp => (!(attackerControl != null)) ? new PlayerAbnormalStateControl.StateParams() : attackerControl.AbnormalStateParams;

	protected PlayerAbnormalStateControl.StateParams DefenserAbsp => (!(defenserControl != null)) ? new PlayerAbnormalStateControl.StateParams() : defenserControl.AbnormalStateParams;

	public static bool DebugUseParams
	{
		get
		{
			return _DebugUseParams;
		}
		set
		{
			if (value && value != _DebugUseParams)
			{
				LoadDebugSettings();
			}
			_DebugUseParams = value;
		}
	}

	public bool GuardCancel
	{
		get
		{
			return guardCancel;
		}
		set
		{
			guardCancel = value;
		}
	}

	public MerlinActionControl AttackerControl
	{
		get
		{
			return attackerControl;
		}
		set
		{
			attackerControl = value;
		}
	}

	public MerlinActionControl DefenserControl
	{
		get
		{
			return defenserControl;
		}
		set
		{
			defenserControl = value;
		}
	}

	public static Queue<string> LogHistory => logHistory;

	public DamageCalc()
	{
		outYarareType = YarareTypes.None;
		logs.Clear();
	}

	public void calc()
	{
		if (!(AttackerControl == null) && !(DefenserControl == null))
		{
			doCalc();
		}
	}

	protected virtual void doCalc()
	{
	}

	public virtual void doHit(bool isKilled, bool isCorpse)
	{
	}

	public override string ToString()
	{
		return ObjUtilModule.DebugObjectInspectionFull(this);
	}

	private static void LoadDebugSettings()
	{
		string path = "Misc/PlayerAttackAndHpForDebug";
		TextAsset textAsset = GameAssetModule.LoadPrefab(path, typeof(TextAsset)) as TextAsset;
		if (textAsset != null && NGUIJson.jsonDecode(textAsset.text) is Hashtable hashtable)
		{
			DebugTotalPlayerHP = RuntimeServices.UnboxSingle(hashtable["hp"]);
			DebugTotalWeaponAttack = RuntimeServices.UnboxSingle(hashtable["attack"]);
		}
	}

	public static string flushLog(string title)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(new StringBuilder().Append(title).Append(" 発生フレーム:").Append((object)Time.frameCount)
			.Append("\n")
			.ToString());
		IEnumerator<Log> enumerator = logs.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				stringBuilder.Append(enumerator.Current.ToString());
				stringBuilder.Append("\n");
			}
		}
		finally
		{
			enumerator.Dispose();
		}
		logs.Clear();
		string text = stringBuilder.ToString();
		logHistory.Enqueue(text);
		while (((ICollection)logHistory).Count > 100)
		{
			logHistory.Dequeue();
		}
		return text;
	}

	public static float val(string n, float v)
	{
		return v;
	}

	public static bool val(string n, bool b)
	{
		return b;
	}

	public static void val(string n, string b)
	{
	}

	public static float ElementalMult(EnumElements at, EnumElements df)
	{
		float rate = MElementCorrelations.GetRate(at, df);
		return val(new StringBuilder(" > 属性 <").Append(at).Append("> -> <").Append(df)
			.Append("> ")
			.ToString(), rate);
	}

	public static float TotalWeaponAttack(RespWeapon mainWeapon, RespWeapon[] subWeapons)
	{
		float result;
		if (DebugUseParams)
		{
			result = DebugTotalWeaponAttack;
		}
		else
		{
			float num = 0f;
			if (mainWeapon != null)
			{
				num = mainWeapon.TotalAttack;
			}
			if (subWeapons != null)
			{
				int i = 0;
				for (int length = subWeapons.Length; i < length; i = checked(i + 1))
				{
					if (subWeapons[i] != null)
					{
						num += SupportWeaponAttackRevise(subWeapons[i], mainWeapon);
					}
				}
			}
			result = num;
		}
		return result;
	}

	public static float TotalPlayerHP(RespWeapon[] weapons, RespPoppet[] poppets)
	{
		float result;
		if (IsEmpty(weapons))
		{
			result = 0f;
		}
		else
		{
			float num = TotalWeaponHP(weapons);
			num += TotalPoppetPlayerHpRevise(poppets, weapons[0]);
			result = Mathf.Max(1f, num);
		}
		return result;
	}

	public static float TotalPlayerHP(WeaponEquipments weq, RespPoppet[] poppets)
	{
		float result;
		if (weq == null)
		{
			result = 0f;
		}
		else
		{
			float num = weq.totalPlayerHP();
			float num2 = TotalPoppetPlayerHpRevise(poppets, weq.MainTenshiWeapon);
			float num3 = TotalPoppetPlayerHpRevise(poppets, weq.MainAkumaWeapon);
			num += num2 + num3;
			result = Mathf.Max(1f, num);
		}
		return result;
	}

	public static float TotalPlayerAttack(RespWeapon[] weapons, RespPoppet[] poppets)
	{
		float result;
		if (IsEmpty(weapons))
		{
			result = 0f;
		}
		else
		{
			float num = TotalWeaponAttack(weapons);
			float num2 = TotalPoppetPlayerAttackRevise(poppets, weapons[0]);
			float b = num + num2;
			result = Mathf.Max(1f, b);
		}
		return result;
	}

	public static float TotalPlayerAttack(WeaponEquipments weq, RespPoppet[] poppets)
	{
		float result;
		if (weq == null)
		{
			result = 0f;
		}
		else
		{
			float num = weq.totalPlayerAttack();
			float num2 = TotalPoppetPlayerAttackRevise(poppets, weq.MainTenshiWeapon);
			float num3 = TotalPoppetPlayerAttackRevise(poppets, weq.MainAkumaWeapon);
			float b = num + (num2 + num3);
			result = Mathf.Max(1f, b);
		}
		return result;
	}

	public static float TotalWeaponHP(RespWeapon[] weapons)
	{
		return DebugUseParams ? DebugTotalPlayerHP : ((!IsEmpty(weapons)) ? TotalWeaponHP(weapons[0], (RespWeapon[])RuntimeServices.GetRange1(weapons, 1)) : 0f);
	}

	public static float TotalWeaponHP(RespWeapon mainWeapon, RespWeapon[] subWeapons)
	{
		float result;
		if (DebugUseParams)
		{
			result = DebugTotalPlayerHP;
		}
		else
		{
			float num = 0f;
			if (mainWeapon != null)
			{
				num = mainWeapon.TotalHP;
			}
			if (subWeapons != null)
			{
				int i = 0;
				for (int length = subWeapons.Length; i < length; i = checked(i + 1))
				{
					if (subWeapons[i] != null)
					{
						num += SupportWeaponHpRevise(subWeapons[i], mainWeapon);
					}
				}
			}
			result = num;
		}
		return result;
	}

	public static float TotalWeaponAttack(RespWeapon[] weapons)
	{
		return DebugUseParams ? DebugTotalWeaponAttack : ((!IsEmpty(weapons)) ? TotalWeaponAttack(weapons[0], (RespWeapon[])RuntimeServices.GetRange1(weapons, 1)) : 0f);
	}

	public static float SupportWeaponAttackRevise(RespWeapon wpn, RespWeapon main)
	{
		return SupportWeaponRevise(wpn, wpn.TotalAttack, main);
	}

	public static float SupportWeaponHpRevise(RespWeapon wpn, RespWeapon main)
	{
		return SupportWeaponRevise(wpn, wpn.TotalHP, main);
	}

	public static float SupportWeaponRevise(RespWeapon wpn, float wpnValue, RespWeapon main)
	{
		float result;
		if (wpn != null)
		{
			int cost = wpn.Cost;
			bool num = main != null;
			if (num)
			{
				num = wpn.StyleId == main.StyleId;
			}
			bool num2 = main != null;
			if (num2)
			{
				num2 = wpn.ElementId == main.ElementId;
			}
			result = SupportWeaponReviseValue(wpnValue, cost, num, num2);
		}
		else
		{
			result = 1f;
		}
		return result;
	}

	public static float SupportWeaponReviseValue(float wpnValue, int wpnCost, bool styleCoincide, bool elementCoincide)
	{
		float num = 0.02f;
		if (styleCoincide)
		{
			num += 0.01f;
		}
		if (elementCoincide)
		{
			num += 0.01f;
		}
		return Clamp1AndFloor(wpnValue * (float)wpnCost * num);
	}

	public static float TotalPoppetPlayerHpRevise(RespPoppet[] poppets, RespWeapon main)
	{
		float result;
		if (main == null || poppets == null)
		{
			result = 0f;
		}
		else
		{
			float num = 0f;
			int i = 0;
			for (int length = poppets.Length; i < length; i = checked(i + 1))
			{
				num += PoppetHpRevice(poppets[i], main);
			}
			result = num;
		}
		return result;
	}

	public static float TotalPoppetPlayerAttackRevise(RespPoppet[] poppets, RespWeapon main)
	{
		float result;
		if (main == null || IsEmpty(poppets))
		{
			result = 0f;
		}
		else
		{
			float num = 0f;
			int i = 0;
			for (int length = poppets.Length; i < length; i = checked(i + 1))
			{
				float num2 = PoppetAttackRevice(poppets[i], main);
				num += num2;
			}
			result = num;
		}
		return result;
	}

	public static float PoppetHpRevice(RespPoppet ppt, RespWeapon main)
	{
		return PoppetRevice(ppt, ppt.TotalHP, main);
	}

	public static float PoppetAttackRevice(RespPoppet ppt, RespWeapon main)
	{
		return PoppetRevice(ppt, ppt.TotalAttack, main);
	}

	public static float PoppetRevice(RespPoppet ppt, float pptValue, RespWeapon main)
	{
		float result;
		if (ppt != null)
		{
			int cost = ppt.Cost;
			bool num = main != null;
			if (num)
			{
				num = ppt.ElementId == main.ElementId;
			}
			result = PoppetReviceValue(pptValue, cost, num);
		}
		else
		{
			result = 1f;
		}
		return result;
	}

	public static float AttackPlusValue(EnumRares rarity, int plusBonus)
	{
		return (rarity < EnumRares.ultra_rare) ? ((float)plusBonus * 2f) : ((float)plusBonus * 3f);
	}

	public static float HpPlusValue(EnumRares rarity, int plusBonus)
	{
		return (rarity < EnumRares.ultra_rare) ? ((float)plusBonus * 10f) : ((float)plusBonus * 15f);
	}

	public static float PoppetRevice(RespPoppet ppt, float pptValue, int elementId)
	{
		return (ppt == null) ? 1f : PoppetReviceValue(pptValue, ppt.Cost, ppt.ElementId == elementId);
	}

	public static float PoppetReviceValue(float pptValue, int pptCost, bool elementCoincide)
	{
		float num = 0.02f;
		if (elementCoincide)
		{
			num += 0.01f;
		}
		return Clamp1AndFloor(pptValue * (float)pptCost * num);
	}

	public static float PoppetAttackRevice(WeaponEquipments weq, RespPoppet poppet)
	{
		float result;
		if (weq == null)
		{
			result = 0f;
		}
		else
		{
			float num = PoppetAttackRevice(poppet, weq.MainTenshiWeapon);
			float num2 = PoppetAttackRevice(poppet, weq.MainAkumaWeapon);
			float b = num + num2;
			result = Mathf.Max(1f, b);
		}
		return result;
	}

	public static float PoppetHpRevice(WeaponEquipments weq, RespPoppet poppet)
	{
		float result;
		if (weq == null)
		{
			result = 0f;
		}
		else
		{
			float num = PoppetHpRevice(poppet, weq.MainTenshiWeapon);
			float num2 = PoppetHpRevice(poppet, weq.MainAkumaWeapon);
			float b = num + num2;
			result = Mathf.Max(1f, b);
		}
		return result;
	}

	public static BonusValue WeaponBonusMaximumValue(MWeapons data)
	{
		BonusValue result = default(BonusValue);
		MWeapons[] weaponEvoTrack = GetWeaponEvoTrack(data);
		float num = (float)MGameParameters.findByGameParameterId(10).Param / 100f;
		int num2 = 0;
		int length = weaponEvoTrack.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < length)
		{
			int num3 = num2;
			num2++;
			checked
			{
				MWeapons mWeapons = weaponEvoTrack[RuntimeServices.NormalizeArrayIndex(weaponEvoTrack, weaponEvoTrack.Length - (num3 + 1))];
				result.attack = (int)((mWeapons.attack(mWeapons.LevelLimitMax) + (float)result.attack) * num);
				result.hp = (int)((mWeapons.hp(mWeapons.LevelLimitMax) + (float)result.hp) * num);
			}
		}
		result.evoTrack = weaponEvoTrack as object[];
		return result;
	}

	private static MWeapons[] GetWeaponEvoTrack(MWeapons data)
	{
		MWeapons[] evoTrack = new MWeapons[0];
		RecursiveWeaponEvoTrack(data, ref evoTrack);
		return evoTrack;
	}

	private static void RecursiveWeaponEvoTrack(MWeapons data, ref MWeapons[] evoTrack)
	{
		MWeapons mWeapons = null;
		int num;
		MEvolutionInformations mEvolutionInformations = MEvolutionInformations.SearchToDestinationId(num = 1, data.Id);
		if (mEvolutionInformations != null)
		{
			mWeapons = MWeapons.Get(mEvolutionInformations.EvolutionSourceId);
		}
		if (mWeapons == null)
		{
			int i = 0;
			MWeapons[] all = MWeapons.All;
			for (int length = all.Length; i < length; i = checked(i + 1))
			{
				if (all[i].EvolutionWeaponId != null && all[i].EvolutionWeaponId.Id == data.Id)
				{
					mWeapons = all[i];
					break;
				}
			}
		}
		if (mWeapons != null)
		{
			evoTrack = (MWeapons[])RuntimeServices.AddArrays(typeof(MWeapons), evoTrack, new MWeapons[1] { mWeapons });
			RecursiveWeaponEvoTrack(mWeapons, ref evoTrack);
		}
	}

	public static BonusValue PoppetBonusMaximumValue(MPoppets data)
	{
		BonusValue result = default(BonusValue);
		MPoppets[] poppetEvoTrack = GetPoppetEvoTrack(data);
		float num = (float)MGameParameters.findByGameParameterId(10).Param / 100f;
		int num2 = 0;
		int length = poppetEvoTrack.Length;
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < length)
		{
			int num3 = num2;
			num2++;
			checked
			{
				MPoppets mPoppets = poppetEvoTrack[RuntimeServices.NormalizeArrayIndex(poppetEvoTrack, poppetEvoTrack.Length - (num3 + 1))];
				result.attack = (int)((float)(mPoppets.attack(mPoppets.LevelLimitMax) + result.attack) * num);
				result.hp = (int)((float)(mPoppets.hp(mPoppets.LevelLimitMax) + result.hp) * num);
			}
		}
		result.evoTrack = poppetEvoTrack as object[];
		return result;
	}

	private static MPoppets[] GetPoppetEvoTrack(MPoppets data)
	{
		MPoppets[] evoTrack = new MPoppets[0];
		RecursivePoppetEvoTrack(data, ref evoTrack);
		return evoTrack;
	}

	private static void RecursivePoppetEvoTrack(MPoppets data, ref MPoppets[] evoTrack)
	{
		MPoppets mPoppets = null;
		int num;
		MEvolutionInformations mEvolutionInformations = MEvolutionInformations.SearchToDestinationId(num = 2, data.Id);
		if (mEvolutionInformations != null)
		{
			mPoppets = MPoppets.Get(mEvolutionInformations.EvolutionSourceId);
		}
		if (mPoppets == null)
		{
			int i = 0;
			MPoppets[] all = MPoppets.All;
			for (int length = all.Length; i < length; i = checked(i + 1))
			{
				if (all[i].EvolutionPoppetId != null && all[i].EvolutionPoppetId.Id == data.Id)
				{
					mPoppets = all[i];
					break;
				}
			}
		}
		if (mPoppets != null)
		{
			evoTrack = (MPoppets[])RuntimeServices.AddArrays(typeof(MPoppets), evoTrack, new MPoppets[1] { mPoppets });
			RecursivePoppetEvoTrack(mPoppets, ref evoTrack);
		}
	}

	public static float WeakStyleAttackMult(EnumStyles weaponStyle, EnumStyles monsterWeak)
	{
		return (weaponStyle != 0 && monsterWeak != 0) ? ((weaponStyle != monsterWeak) ? 1f : 1.5f) : 1f;
	}

	public static float ColosseumPoppetAttack(RespPoppet poppet, RespWeapon weapon)
	{
		if (poppet == null)
		{
			throw new AssertionFailedException("poppet != null");
		}
		float num = poppet.TotalAttack;
		if (weapon != null)
		{
			num += ColosseumPoppetAttackRevise(poppet, weapon);
		}
		return Mathf.Floor(num);
	}

	public static float ColosseumPoppetHP(RespPoppet poppet, RespWeapon weapon)
	{
		if (poppet == null)
		{
			throw new AssertionFailedException("poppet != null");
		}
		float num = poppet.TotalHP;
		if (weapon != null)
		{
			num += ColosseumPoppetHPRevise(poppet, weapon);
		}
		return Mathf.Floor(num);
	}

	public static float ColosseumPoppetAttackRevise(RespPoppet poppet, RespWeapon weapon)
	{
		float num = _ColosseumPoppetAttackHpCoef(poppet, weapon, 0.2f, 0.1f);
		return num * weapon.TotalAttack;
	}

	public static float ColosseumPoppetHPRevise(RespPoppet poppet, RespWeapon weapon)
	{
		float num = _ColosseumPoppetAttackHpCoef(poppet, weapon, 0.2f, 0.1f);
		return num * weapon.TotalHP;
	}

	private static float _ColosseumPoppetAttackHpCoef(RespPoppet poppet, RespWeapon weapon, float match, float unmatch)
	{
		return (poppet != null && weapon != null) ? (RuntimeServices.EqualityOperator(poppet.Element, weapon.Element) ? match : unmatch) : unmatch;
	}

	protected static float ToRate(float v)
	{
		return v / 100f;
	}

	protected static bool IsEmpty(RespWeapon[] wpns)
	{
		bool num = wpns == null;
		if (!num)
		{
			num = wpns.Length <= 0;
		}
		return num;
	}

	protected static bool IsEmpty(RespPoppet[] ppts)
	{
		bool num = ppts == null;
		if (!num)
		{
			num = ppts.Length <= 0;
		}
		return num;
	}

	protected static float Clamp1AndFloor(float v)
	{
		return minClampAndFloor(v, 1f);
	}

	protected static float minClampAndFloor(float v, float min)
	{
		return Mathf.Floor(Mathf.Max(min, v));
	}
}
