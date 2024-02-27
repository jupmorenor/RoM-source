using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;

[Serializable]
public class PowupRecommender
{
	[Serializable]
	private class ExpCompares : IComparer
	{
		private RespWeaponPoppet @base;

		private SortFuncs.MultiComparison<RespWeaponPoppet> comparer;

		private bool _0024initialized__PowupRecommender_ExpCompares_0024;

		private ExpCompares()
		{
			if (!_0024initialized__PowupRecommender_ExpCompares_0024)
			{
				_0024initialized__PowupRecommender_ExpCompares_0024 = true;
			}
			InitComparer();
		}

		public ExpCompares(RespWeaponPoppet b)
		{
			if (!_0024initialized__PowupRecommender_ExpCompares_0024)
			{
				_0024initialized__PowupRecommender_ExpCompares_0024 = true;
			}
			if (b == null)
			{
				throw new AssertionFailedException("b != null");
			}
			@base = b;
			InitComparer();
		}

		public int Calc(RespWeaponPoppet[] r)
		{
			int dstNewExp = 0;
			int dstNeedCost = 0;
			@base.LevelUpSimulate(r, ref dstNewExp, ref dstNeedCost);
			checked
			{
				dstNewExp -= @base.Exp;
				CampaignsController.CampaignsRate campaignsRate = CampaignsController.GetCampaignsRate(isPowup: true);
				dstNewExp = (int)((float)dstNewExp * campaignsRate.exp);
				dstNeedCost = (int)((float)dstNeedCost / campaignsRate.cost);
				return dstNewExp;
			}
		}

		public int Calc(Boo.Lang.List<RespWeaponPoppet> list)
		{
			return Calc(list.ToArray());
		}

		public int Calc(RespWeaponPoppet r)
		{
			return Calc(new RespWeaponPoppet[1] { r });
		}

		public int Elem(RespWeaponPoppet r)
		{
			return r.Element.Id;
		}

		public long Id(RespWeaponPoppet r)
		{
			return r.Id.Value;
		}

		public int Type(RespWeaponPoppet r)
		{
			return r.StyleOrRace;
		}

		private int _exp(RespWeaponPoppet a, RespWeaponPoppet b)
		{
			int num = Calc(a);
			int num2 = Calc(b);
			return checked(num2 - num);
		}

		private int _elem(RespWeaponPoppet a, RespWeaponPoppet b)
		{
			int num = Elem(a);
			int num2 = Elem(b);
			return checked(num - num2);
		}

		private int _type(RespWeaponPoppet a, RespWeaponPoppet b)
		{
			int num = Type(a);
			int num2 = Type(b);
			return checked(num - num2);
		}

		private int _id(RespWeaponPoppet a, RespWeaponPoppet b)
		{
			long num = Id(a);
			long num2 = Id(b);
			return (num != num2) ? ((num2 >= num) ? 1 : (-1)) : 0;
		}

		private void InitComparer()
		{
			Boo.Lang.List<Comparison<RespWeaponPoppet>> list = new Boo.Lang.List<Comparison<RespWeaponPoppet>>();
			list.Add(_0024adaptor_0024__PowupRecommender_PickOne_0024callable601_0024100_32___0024Comparison_0024206.Adapt(_exp));
			list.Add(_0024adaptor_0024__PowupRecommender_PickOne_0024callable601_0024100_32___0024Comparison_0024206.Adapt(_elem));
			list.Add(_0024adaptor_0024__PowupRecommender_PickOne_0024callable601_0024100_32___0024Comparison_0024206.Adapt(_type));
			list.Add(_0024adaptor_0024__PowupRecommender_PickOne_0024callable601_0024100_32___0024Comparison_0024206.Adapt(_id));
			Comparison<RespWeaponPoppet>[] comps = list.ToArray();
			comparer = new SortFuncs.MultiComparison<RespWeaponPoppet>(comps);
		}

		public int Compire(RespWeaponPoppet a, RespWeaponPoppet b)
		{
			return comparer.Compare(a, b);
		}

		public virtual int Compare(object x, object y)
		{
			throw new NotImplementedException();
		}
	}

	private RespWeaponPoppet @base;

	private RespWeaponPoppet[] materials;

	private ExpCompares expComp;

	private int selectMax;

	private bool _0024initialized__PowupRecommender_0024;

	public PowupRecommender()
	{
		if (!_0024initialized__PowupRecommender_0024)
		{
			selectMax = 5;
			_0024initialized__PowupRecommender_0024 = true;
		}
	}

	public PowupRecommender(RespWeaponPoppet item, RespWeaponPoppet[] mats, int max)
	{
		if (!_0024initialized__PowupRecommender_0024)
		{
			selectMax = 5;
			_0024initialized__PowupRecommender_0024 = true;
		}
		Initialize(item, mats, max);
	}

	public static RespWeaponPoppet[] Recommend(RespWeaponPoppet item, RespWeaponPoppet[] mats, int max, bool useElem)
	{
		PowupRecommender powupRecommender = new PowupRecommender(item, mats, max);
		return powupRecommender.Recommend(useElem);
	}

	public void Initialize(RespWeaponPoppet item, RespWeaponPoppet[] mats, int max)
	{
		if (item == null)
		{
		}
		if (mats == null)
		{
		}
		@base = item;
		materials = mats;
		expComp = new ExpCompares(item);
		selectMax = max;
	}

	public RespWeaponPoppet[] Recommend(bool useElem)
	{
		object result;
		if (0 < materials.Length)
		{
			Boo.Lang.List<RespWeaponPoppet> list = Choice(GetMatList(), useElem);
			if (useElem && ((ICollection)list).Count <= 0)
			{
				list = Choice(GetMatList(), useElem: false);
			}
			result = list.ToArray();
		}
		else
		{
			result = null;
		}
		return (RespWeaponPoppet[])result;
	}

	private Boo.Lang.List<RespWeaponPoppet> GetMatList()
	{
		return new Boo.Lang.List<RespWeaponPoppet>(materials);
	}

	private Boo.Lang.List<RespWeaponPoppet> Filtering(Boo.Lang.List<RespWeaponPoppet> list, int rare, bool useElem)
	{
		Boo.Lang.List<RespWeaponPoppet> list2 = new Boo.Lang.List<RespWeaponPoppet>();
		IEnumerator<RespWeaponPoppet> enumerator = list.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				RespWeaponPoppet current = enumerator.Current;
				if (current.LevelUpType == 4 && !current.IsLimitBreak && !current.IsSkillLvUp && !current.IsFavorite && !UserData.Current.IsUsing(current.Id) && (!useElem || RuntimeServices.EqualityOperator(current.Element, @base.Element) || (!@base.IsPoppet && current.StyleOrRace == @base.StyleOrRace)) && (1 > rare || current.Rare == rare))
				{
					list2.Add(current);
				}
			}
			return list2;
		}
		finally
		{
			enumerator.Dispose();
		}
	}

	private Boo.Lang.List<RespWeaponPoppet> GetTopRange(Boo.Lang.List<RespWeaponPoppet> list)
	{
		if (selectMax < ((ICollection)list).Count)
		{
			list = list.GetRange(0, selectMax);
		}
		return list;
	}

	private Boo.Lang.List<RespWeaponPoppet> Choice(Boo.Lang.List<RespWeaponPoppet> mats, bool useElem)
	{
		Boo.Lang.List<RespWeaponPoppet> list = new Boo.Lang.List<RespWeaponPoppet>();
		mats = Filtering(mats, 0, useElem);
		int num = 0;
		int num2 = selectMax;
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < num2)
		{
			int index = num;
			num++;
			RespWeaponPoppet respWeaponPoppet = PickOne(list, mats, index);
			if (respWeaponPoppet == null)
			{
				break;
			}
			list.Add(respWeaponPoppet);
			mats.Remove(respWeaponPoppet);
		}
		return GetTopRange(list);
	}

	private RespWeaponPoppet PickOne(Boo.Lang.List<RespWeaponPoppet> list, Boo.Lang.List<RespWeaponPoppet> mats, int index)
	{
		int num = expComp.Calc(list);
		int num2 = checked(@base.LevelMaxExp - @base.Exp);
		RespWeaponPoppet result = null;
		int count = ((ICollection)mats).Count;
		if (num < num2 && 0 < count)
		{
			mats.Sort(_0024adaptor_0024__PowupRecommender_PickOne_0024callable601_0024100_32___0024Comparison_0024206.Adapt(expComp.Compire));
			result = mats[0];
			int num3 = 0;
			int num4 = count;
			if (num4 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num3 < num4)
			{
				int index2 = num3;
				num3++;
				RespWeaponPoppet respWeaponPoppet = mats[index2];
				int num5 = expComp.Calc(respWeaponPoppet);
				if (num2 < checked(num + num5))
				{
					result = respWeaponPoppet;
					continue;
				}
				break;
			}
		}
		return result;
	}
}
