using System;
using System.Text;
using Boo.Lang.PatternMatching;
using Boo.Lang.Runtime;

[Serializable]
public class MyHomePicBookMain : MyhomeSubSceneTopMain
{
	public PIC_BOOK_LIST_TYPE listType;

	protected PIC_BOOK_MAIN mode;

	protected PIC_BOOK_MAIN lastMode;

	public PicBookListTypeSet weaponList;

	public PicBookListTypeSet poppetList;

	public override void StartCore()
	{
		mode = (lastMode = PIC_BOOK_MAIN.TopMenu);
		UISituation[] array = situations;
		ChangeSituation(array[RuntimeServices.NormalizeArrayIndex(array, (int)mode)]);
	}

	public void SetSituation(PIC_BOOK_MAIN setMode)
	{
		mode = setMode;
		SceneUpdate();
	}

	public override void SceneUpdate()
	{
		if (!IsChangingSituation && mode != lastMode)
		{
			lastMode = mode;
			ChangeSituation(GetSituation((int)mode));
		}
	}

	public void PushBack()
	{
		PIC_BOOK_MAIN pIC_BOOK_MAIN = mode;
		switch (pIC_BOOK_MAIN)
		{
		case PIC_BOOK_MAIN.TopMenu:
			BackMyhome();
			break;
		case PIC_BOOK_MAIN.List:
			mode = PIC_BOOK_MAIN.TopMenu;
			break;
		case PIC_BOOK_MAIN.Detail:
			mode = PIC_BOOK_MAIN.List;
			break;
		case PIC_BOOK_MAIN.Model:
			mode = PIC_BOOK_MAIN.List;
			break;
		default:
			throw new MatchError(new StringBuilder("`mode` failed to match `").Append(pIC_BOOK_MAIN).Append("`").ToString());
		}
	}

	public void SetListType(PIC_BOOK_LIST_TYPE setType)
	{
		listType = setType;
		PIC_BOOK_LIST_TYPE pIC_BOOK_LIST_TYPE = listType;
		switch (pIC_BOOK_LIST_TYPE)
		{
		case PIC_BOOK_LIST_TYPE.Weapon:
			weaponList.SendMessage("Show");
			poppetList.SendMessage("Hide");
			break;
		case PIC_BOOK_LIST_TYPE.Poppet:
			weaponList.SendMessage("Hide");
			poppetList.SendMessage("Show");
			break;
		default:
			throw new MatchError(new StringBuilder("`listType` failed to match `").Append(pIC_BOOK_LIST_TYPE).Append("`").ToString());
		}
	}

	public void PushWeapon()
	{
		SetListType(PIC_BOOK_LIST_TYPE.Weapon);
		SetSituation(PIC_BOOK_MAIN.List);
	}

	public void PushPoppet()
	{
		SetListType(PIC_BOOK_LIST_TYPE.Poppet);
		SetSituation(PIC_BOOK_MAIN.List);
	}
}
