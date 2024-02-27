using System;
using UnityEngine;

[Serializable]
public class PicBookListItem : UIListItem
{
	[Serializable]
	internal class _0024SetBoxItem_0024locals_002414531
	{
		internal bool _0024isHave;
	}

	[Serializable]
	internal class _0024SetBoxItem_0024closure_00245085
	{
		internal PicBookListItem _0024this_002415185;

		internal _0024SetBoxItem_0024locals_002414531 _0024_0024locals_002415186;

		public _0024SetBoxItem_0024closure_00245085(PicBookListItem _0024this_002415185, _0024SetBoxItem_0024locals_002414531 _0024_0024locals_002415186)
		{
			this._0024this_002415185 = _0024this_002415185;
			this._0024_0024locals_002415186 = _0024_0024locals_002415186;
		}

		public void Invoke(UIAtlas atlas)
		{
			_0024this_002415185.itemSprite.gameObject.SetActive(atlas != null);
			if (!_0024_0024locals_002415186._0024isHave)
			{
				_0024this_002415185.itemSprite.color = _0024this_002415185.notHaveItemSpriteColor;
			}
		}
	}

	public UILabel numberLabel;

	public UISprite itemSprite;

	public Color notHaveItemSpriteColor;

	public GameObject notHaveObject;

	public PicBookListItem()
	{
		notHaveItemSpriteColor = Color.gray;
	}

	public void SetPicBookItem(PIC_BOOK_LIST_MODE mode)
	{
		PicBookData data = GetData().GetData<PicBookData>();
		if (data.IsWeapon())
		{
			MWeapons weapon = data.weapon;
			switch (mode)
			{
			case PIC_BOOK_LIST_MODE.ALL:
				SetBoxItem(weapon.Id, weapon.Icon, isHave: true);
				break;
			case PIC_BOOK_LIST_MODE.HAVE_ONLY:
				SetBoxItem(weapon.Id, weapon.Icon, isHave: true);
				break;
			case PIC_BOOK_LIST_MODE.HAVE_OR_LOOK:
				SetBoxItem(weapon.Id, weapon.Icon, data.IsHave());
				break;
			case PIC_BOOK_LIST_MODE.NOHAVE_IS_NONEICON:
				if (!data.IsHave())
				{
					SetNoItem();
				}
				else
				{
					SetBoxItem(weapon.Id, weapon.Icon, isHave: true);
				}
				break;
			default:
				SetNoItem();
				break;
			}
		}
		else if (data.IsPoppet())
		{
			MPoppets poppet = data.poppet;
			switch (mode)
			{
			case PIC_BOOK_LIST_MODE.ALL:
				SetBoxItem(poppet.Id, poppet.Icon, isHave: true);
				break;
			case PIC_BOOK_LIST_MODE.HAVE_ONLY:
				SetBoxItem(poppet.Id, poppet.Icon, isHave: true);
				break;
			case PIC_BOOK_LIST_MODE.HAVE_OR_LOOK:
				SetBoxItem(poppet.Id, poppet.Icon, data.IsHave());
				break;
			case PIC_BOOK_LIST_MODE.NOHAVE_IS_NONEICON:
				if (!data.IsHave())
				{
					SetNoItem();
				}
				else
				{
					SetBoxItem(poppet.Id, poppet.Icon, isHave: true);
				}
				break;
			default:
				SetNoItem();
				break;
			}
		}
		else
		{
			SetNoItem();
		}
	}

	public void SetBoxItem(int bookNumber, string iconName, bool isHave)
	{
		_0024SetBoxItem_0024locals_002414531 _0024SetBoxItem_0024locals_0024 = new _0024SetBoxItem_0024locals_002414531();
		_0024SetBoxItem_0024locals_0024._0024isHave = isHave;
		numberLabel.text = bookNumber.ToString();
		IconAtlasPool.SetSprite(itemSprite, iconName, new _0024SetBoxItem_0024closure_00245085(this, _0024SetBoxItem_0024locals_0024).Invoke);
		if (!_0024SetBoxItem_0024locals_0024._0024isHave && notHaveObject != null)
		{
			NGUITools.AddChild(gameObject, notHaveObject);
		}
	}

	public void SetNoItem()
	{
		numberLabel.text = string.Empty;
		IconAtlasPool.SetSprite(itemSprite, "P_none", delegate(UIAtlas atlas)
		{
			itemSprite.gameObject.SetActive(atlas != null);
		});
		GetData().core = null;
		UnityEngine.Object.Destroy(iconOption);
	}

	internal void _0024SetNoItem_0024closure_00245086(UIAtlas atlas)
	{
		itemSprite.gameObject.SetActive(atlas != null);
	}
}
