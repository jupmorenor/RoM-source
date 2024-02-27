using System;
using Boo.Lang.Runtime;
using CompilerGenerated;
using UnityEngine;

[Serializable]
public class LoginBonusDialog : CustomDialogBase
{
	[NonSerialized]
	private static LoginBonusDialog m_instance;

	private bool isOpened;

	public static LoginBonusDialog Instance
	{
		get
		{
			if (!m_instance)
			{
				m_instance = (LoginBonusDialog)UnityEngine.Object.FindObjectOfType(typeof(LoginBonusDialog));
			}
			return m_instance;
		}
	}

	public static bool IsOpened => (bool)Instance && Instance.isOpened;

	protected override void EnterModalMode()
	{
		base.EnterModalMode();
		UIAutoTweenerStandAloneEx.In(gameObject);
	}

	protected override void ExitModalMode()
	{
		ModalCollider.SetActive(this, active: false);
	}

	public void Open(EnumMasterTypeValues itemType, string titile, string message, __RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ weaponCreate, __RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61__ mapetCreate)
	{
		string text = null;
		GameObject gameObject = ExtensionsModule.FindChild(this.gameObject, "WeaponIcon");
		gameObject.SetActive(value: false);
		int i = 0;
		GameObject[] array = ExtensionsModule.Children(gameObject);
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			UnityEngine.Object.Destroy(array[i]);
		}
		switch (itemType)
		{
		case EnumMasterTypeValues.FayStone:
			text = "icon_faystone";
			break;
		case EnumMasterTypeValues.Coin:
			text = "icon_money";
			break;
		case EnumMasterTypeValues.FriendPoint:
			text = "icon_friend";
			break;
		case EnumMasterTypeValues.Weapon:
			text = string.Empty;
			weaponCreate(gameObject);
			break;
		case EnumMasterTypeValues.Poppet:
			text = string.Empty;
			mapetCreate(gameObject);
			break;
		default:
			if (0 == 0)
			{
				throw new AssertionFailedException("表示非対応な種類のログインボーナス.配ってはいけないものを配っている？ itemType = " + itemType);
			}
			break;
		}
		GameObject gameObject2 = ExtensionsModule.FindChild(this.gameObject, "Icon");
		bool flag = !string.IsNullOrEmpty(text);
		if (flag)
		{
			gameObject2.GetComponent<UISprite>().spriteName = text;
		}
		gameObject2.GetComponent<UISprite>().enabled = flag;
		ExtensionsModule.FindChild(this.gameObject, "Message").GetComponent<UILabelBase>().text = message;
		ExtensionsModule.FindChild(this.gameObject, "Title").GetComponent<UILabelBase>().text = titile;
		EnterModalMode();
		isOpened = true;
	}

	private void PushYes()
	{
		UIAutoTweenerStandAloneEx.Out(gameObject, delegate
		{
			isOpened = false;
			ExitModalMode();
		});
	}

	public static void PushOK()
	{
		if ((bool)Instance)
		{
			Instance.PushYes();
		}
	}

	internal void _0024PushYes_0024closure_00244241(GameObject go)
	{
		isOpened = false;
		ExitModalMode();
	}
}
