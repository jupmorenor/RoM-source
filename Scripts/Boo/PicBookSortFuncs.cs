using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;

public static class PicBookSortFuncs
{
	private static string msg(string key)
	{
		MTexts mTexts = MTexts.Get(key);
		if (mTexts == null)
		{
			throw new AssertionFailedException(new StringBuilder().Append(key).Append(" というIDがテキストマスターに有りません.").ToString());
		}
		return mTexts.msg;
	}

	private static string[] GetNames()
	{
		return new string[6]
		{
			msg("sort_item_category"),
			msg("sort_item_atk"),
			msg("sort_item_hp"),
			msg("sort_item_element"),
			msg("sort_item_type"),
			msg("sort_item_rare")
		};
	}

	public static void SetPicBookListSortFuncs(UIListBase listBase)
	{
		int num = 0;
		int num2 = 0;
		string[] names = GetNames();
		listBase.ResetSortFunc();
		checked
		{
			listBase.SetSortFunc(names[RuntimeServices.NormalizeArrayIndex(names, num++)], SortItemNo);
			listBase.SetSortFunc(names[RuntimeServices.NormalizeArrayIndex(names, num++)], SortItemAttack);
			listBase.SetSortFunc(names[RuntimeServices.NormalizeArrayIndex(names, num++)], SortItemHp);
			listBase.SetSortFunc(names[RuntimeServices.NormalizeArrayIndex(names, num++)], SortItemElement);
			listBase.SetSortFunc(names[RuntimeServices.NormalizeArrayIndex(names, num++)], SortItemType);
			listBase.SetSortFunc(names[RuntimeServices.NormalizeArrayIndex(names, num++)], SortItemRare);
			listBase.SetSortTypeName(names, 0);
		}
	}

	public static List<UIListBase.Container> SortItemNo(List<UIListBase.Container> container)
	{
		return SortFuncs.sort(container, SortFuncs.UIListBaseContainerFuncArray(_0024adaptor_0024__WorldColosseumMain__0024InitColosseumEventList_0024closure_00243125_0024callable136_0024413_24___0024Comparison_0024180.Adapt(_midC)));
	}

	public static List<UIListBase.Container> SortItemElement(List<UIListBase.Container> container)
	{
		return SortFuncs.sort(container, SortFuncs.UIListBaseContainerFuncArray(_0024adaptor_0024__WorldColosseumMain__0024InitColosseumEventList_0024closure_00243125_0024callable136_0024413_24___0024Comparison_0024180.Adapt(_elemC), _0024adaptor_0024__WorldColosseumMain__0024InitColosseumEventList_0024closure_00243125_0024callable136_0024413_24___0024Comparison_0024180.Adapt(_rareC), _0024adaptor_0024__WorldColosseumMain__0024InitColosseumEventList_0024closure_00243125_0024callable136_0024413_24___0024Comparison_0024180.Adapt(_midC)));
	}

	public static List<UIListBase.Container> SortItemRare(List<UIListBase.Container> container)
	{
		return SortFuncs.sort(container, SortFuncs.UIListBaseContainerFuncArray(_0024adaptor_0024__WorldColosseumMain__0024InitColosseumEventList_0024closure_00243125_0024callable136_0024413_24___0024Comparison_0024180.Adapt(_rareC), _0024adaptor_0024__WorldColosseumMain__0024InitColosseumEventList_0024closure_00243125_0024callable136_0024413_24___0024Comparison_0024180.Adapt(_elemC), _0024adaptor_0024__WorldColosseumMain__0024InitColosseumEventList_0024closure_00243125_0024callable136_0024413_24___0024Comparison_0024180.Adapt(_midC)));
	}

	public static List<UIListBase.Container> SortItemType(List<UIListBase.Container> container)
	{
		return SortFuncs.sort(container, SortFuncs.UIListBaseContainerFuncArray(_0024adaptor_0024__WorldColosseumMain__0024InitColosseumEventList_0024closure_00243125_0024callable136_0024413_24___0024Comparison_0024180.Adapt(_typeC), _0024adaptor_0024__WorldColosseumMain__0024InitColosseumEventList_0024closure_00243125_0024callable136_0024413_24___0024Comparison_0024180.Adapt(_elemC), _0024adaptor_0024__WorldColosseumMain__0024InitColosseumEventList_0024closure_00243125_0024callable136_0024413_24___0024Comparison_0024180.Adapt(_rareC), _0024adaptor_0024__WorldColosseumMain__0024InitColosseumEventList_0024closure_00243125_0024callable136_0024413_24___0024Comparison_0024180.Adapt(_midC)));
	}

	public static List<UIListBase.Container> SortItemAttack(List<UIListBase.Container> container)
	{
		return SortFuncs.sort(container, SortFuncs.UIListBaseContainerFuncArray(_0024adaptor_0024__WorldColosseumMain__0024InitColosseumEventList_0024closure_00243125_0024callable136_0024413_24___0024Comparison_0024180.Adapt(_atkC), _0024adaptor_0024__WorldColosseumMain__0024InitColosseumEventList_0024closure_00243125_0024callable136_0024413_24___0024Comparison_0024180.Adapt(_elemC), _0024adaptor_0024__WorldColosseumMain__0024InitColosseumEventList_0024closure_00243125_0024callable136_0024413_24___0024Comparison_0024180.Adapt(_rareC), _0024adaptor_0024__WorldColosseumMain__0024InitColosseumEventList_0024closure_00243125_0024callable136_0024413_24___0024Comparison_0024180.Adapt(_midC)));
	}

	public static List<UIListBase.Container> SortItemHp(List<UIListBase.Container> container)
	{
		return SortFuncs.sort(container, SortFuncs.UIListBaseContainerFuncArray(_0024adaptor_0024__WorldColosseumMain__0024InitColosseumEventList_0024closure_00243125_0024callable136_0024413_24___0024Comparison_0024180.Adapt(_hpC), _0024adaptor_0024__WorldColosseumMain__0024InitColosseumEventList_0024closure_00243125_0024callable136_0024413_24___0024Comparison_0024180.Adapt(_elemC), _0024adaptor_0024__WorldColosseumMain__0024InitColosseumEventList_0024closure_00243125_0024callable136_0024413_24___0024Comparison_0024180.Adapt(_rareC), _0024adaptor_0024__WorldColosseumMain__0024InitColosseumEventList_0024closure_00243125_0024callable136_0024413_24___0024Comparison_0024180.Adapt(_midC)));
	}

	private static int _mid(UIListBase.Container c)
	{
		PicBookData data = c.data.GetData<PicBookData>();
		return data.IsWeapon() ? data.weapon.Id : (data.IsPoppet() ? data.poppet.Id : 0);
	}

	private static int _elem(UIListBase.Container c)
	{
		PicBookData data = c.data.GetData<PicBookData>();
		return data.IsWeapon() ? data.weapon.MElementId.Id : (data.IsPoppet() ? data.poppet.MElementId.Id : 0);
	}

	private static int _type(UIListBase.Container c)
	{
		PicBookData data = c.data.GetData<PicBookData>();
		return data.IsWeapon() ? data.weapon.MStyleId.Id : (data.IsPoppet() ? data.poppet.MRaceId.Id : 0);
	}

	private static int _rare(UIListBase.Container c)
	{
		PicBookData data = c.data.GetData<PicBookData>();
		return data.IsWeapon() ? data.weapon.Rare.Id : (data.IsPoppet() ? data.poppet.Rare.Id : 0);
	}

	private static int _hp(UIListBase.Container c)
	{
		PicBookData data = c.data.GetData<PicBookData>();
		return checked(data.IsWeapon() ? (data.GetHp() + data.GetBonus().hp) : (data.IsPoppet() ? (data.GetHp() + data.GetBonus().hp) : 0));
	}

	private static int _atk(UIListBase.Container c)
	{
		PicBookData data = c.data.GetData<PicBookData>();
		return checked(data.IsWeapon() ? (data.GetAttack() + data.GetBonus().attack) : (data.IsPoppet() ? (data.GetAttack() + data.GetBonus().attack) : 0));
	}

	private static int _midC(UIListBase.Container a, UIListBase.Container b)
	{
		int num = _mid(a);
		int num2 = _mid(b);
		return checked(num - num2);
	}

	private static int _elemC(UIListBase.Container a, UIListBase.Container b)
	{
		int num = _elem(a);
		int num2 = _elem(b);
		return checked(num - num2);
	}

	private static int _typeC(UIListBase.Container a, UIListBase.Container b)
	{
		int num = _type(a);
		int num2 = _type(b);
		return checked(num - num2);
	}

	private static int _rareC(UIListBase.Container a, UIListBase.Container b)
	{
		int num = _rare(a);
		int num2 = _rare(b);
		return checked(num2 - num);
	}

	private static int _atkC(UIListBase.Container a, UIListBase.Container b)
	{
		int num = _atk(a);
		int num2 = _atk(b);
		return checked(num2 - num);
	}

	private static int _hpC(UIListBase.Container a, UIListBase.Container b)
	{
		int num = _hp(a);
		int num2 = _hp(b);
		return checked(num2 - num);
	}
}
