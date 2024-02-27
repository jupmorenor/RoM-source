using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boo.Lang.PatternMatching;
using Boo.Lang.Runtime;
using GameAsset;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class ManaPieceList : UIListBase
{
	private List<RespShopItem> original;

	private bool first;

	private GameObject callbackTarget;

	private GameObject weaponIconPrefab;

	private GameObject mapetIconPrefab;

	public UIMain uimain;

	private Dictionary<EnumMasterTypeValues, int> masterTypeCounts;

	public ManaPieceList()
	{
		first = true;
		masterTypeCounts = new Dictionary<EnumMasterTypeValues, int>();
	}

	public int GetMasterTypeCount(EnumMasterTypeValues masterTypeValue)
	{
		int result = 0;
		if (masterTypeCounts.ContainsKey(masterTypeValue))
		{
			result = masterTypeCounts[masterTypeValue];
		}
		return result;
	}

	public void SetResponse(RespShopItem[] list, GameObject go)
	{
		masterTypeCounts.Clear();
		if (!weaponIconPrefab)
		{
			weaponIconPrefab = GameAssetModule.LoadPrefab("Prefab/UI_Sequence/WeaponListItem") as GameObject;
		}
		if (!mapetIconPrefab)
		{
			mapetIconPrefab = GameAssetModule.LoadPrefab("Prefab/UI_Sequence/MuppetListItem") as GameObject;
		}
		if (list != null)
		{
			original = list.ToList();
			callbackTarget = go;
			Initialize(list, gameObject, autoTween: true);
		}
	}

	public void SetDetail(ManaPieceListItem target, RespShopItem listItemData)
	{
		if (!target || listItemData == null)
		{
			return;
		}
		target.textTitleLabel.text = listItemData.Name;
		if ((bool)target.textCostLabel)
		{
			target.textCostLabel.text = UIBasicUtility.SafeFormat("{0}", listItemData.Price.ToString("#,#,#,#,0"));
		}
		if ((bool)target.textBodyLabel)
		{
			target.textBodyLabel.text = listItemData.Explain;
		}
		if ((bool)target.textDateLimitLabel)
		{
			if (!((listItemData.EndDate - MerlinDateTime.UtcNow).TotalDays > 365.0))
			{
				DateTime dateTime = listItemData.EndDate.ToLocalTime();
				target.textDateLimitLabel.text = dateTime.ToString("yyyy/MM/dd");
			}
			else
			{
				target.textDateLimitLabel.text = "なし";
			}
		}
		RespShopItem.Item[] items = listItemData.Items;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int i = 0;
		RespShopItem.Item[] array = items;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (num3 == 0)
			{
				num = (int)array[i].TypeValue;
				num2 = array[i].Quantity;
				num3 = array[i].ItemId;
				num4 = array[i].Level;
				break;
			}
		}
		int num5 = 0;
		if (masterTypeCounts.ContainsKey((EnumMasterTypeValues)num))
		{
			num5 = masterTypeCounts[(EnumMasterTypeValues)num];
		}
		masterTypeCounts[(EnumMasterTypeValues)num] = checked(num5 + 1);
		GameObject go = target.gameObject;
		GameObject gameObject = ExtensionsModule.FindChild(go, "Faystone");
		GameObject gameObject2 = ExtensionsModule.FindChild(go, "Money");
		GameObject gameObject3 = ExtensionsModule.FindChild(go, "FriendPoint");
		GameObject gameObject4 = ExtensionsModule.FindChild(go, "Pet");
		GameObject gameObject5 = ExtensionsModule.FindChild(go, "Weapon");
		gameObject.SetActive(value: false);
		gameObject2.SetActive(value: false);
		gameObject4.SetActive(value: false);
		gameObject5.SetActive(value: false);
		gameObject3.SetActive(value: false);
		if (num == 0)
		{
			throw new AssertionFailedException("masterTypeValue != EnumMasterTypeValues.None");
		}
		UserData current = UserData.Current;
		int num6 = num;
		switch (num6)
		{
		case 2:
			gameObject2.SetActive(value: true);
			if ((bool)target.textItemLabel)
			{
				target.textItemLabel.text = UIBasicUtility.SafeFormat("{0}ルク", num2.ToString("#,#,#,#,0"));
			}
			break;
		case 3:
		{
			gameObject5.SetActive(value: true);
			GameObject gameObject6 = (GameObject)UnityEngine.Object.Instantiate(weaponIconPrefab);
			gameObject6.transform.parent = gameObject5.transform;
			gameObject6.transform.localScale = Vector3.one;
			gameObject6.transform.localPosition = new Vector3(0f, 0f, -1f);
			RespWeapon respWeapon = new RespWeapon(num3);
			respWeapon.Level = num4;
			if ((bool)target.textItemLabel)
			{
				target.textItemLabel.text = new StringBuilder().Append(respWeapon.Master.Name).Append(" Lv ").Append((object)num4)
					.ToString();
			}
			current.userMiscInfo.weaponBookData.look(respWeapon.Master);
			gameObject6.GetComponent<WeaponListItem>().SetWeapon(respWeapon);
			UIButtonMessage component = gameObject6.GetComponent<UIButtonMessage>();
			if ((bool)component && (bool)uimain)
			{
				component.target = uimain.gameObject;
				component.functionName = "PushDetail";
				component.waitTime = 0.8f;
			}
			break;
		}
		case 4:
		{
			gameObject4.SetActive(value: true);
			GameObject gameObject7 = (GameObject)UnityEngine.Object.Instantiate(mapetIconPrefab);
			gameObject7.transform.parent = gameObject4.transform;
			gameObject7.transform.localScale = Vector3.one;
			gameObject7.transform.localPosition = new Vector3(0f, 0f, -1f);
			RespPoppet respPoppet = new RespPoppet(num3);
			respPoppet.Level = num4;
			if ((bool)target.textItemLabel)
			{
				target.textItemLabel.text = new StringBuilder().Append(respPoppet.Master.Name).Append(" Lv ").Append((object)num4)
					.ToString();
			}
			current.userMiscInfo.poppetBookData.look(respPoppet.Master);
			gameObject7.GetComponent<MapetListItem>().SetMapet(respPoppet);
			UIButtonMessage component = gameObject7.GetComponent<UIButtonMessage>();
			if ((bool)component && (bool)uimain)
			{
				component.target = uimain.gameObject;
				component.functionName = "PushDetail";
				component.waitTime = 0.8f;
			}
			break;
		}
		case 5:
			if (0 == 0)
			{
				throw new AssertionFailedException("Candyが配布されている");
			}
			break;
		case 6:
			gameObject.SetActive(value: true);
			if ((bool)target.textItemLabel)
			{
				target.textItemLabel.text = UIBasicUtility.SafeFormat("精霊石 {0}個", num2.ToString("#,#,#,#,0"));
			}
			break;
		case 7:
			if (0 == 0)
			{
				throw new AssertionFailedException("KeyItemが配布されている");
			}
			break;
		case 8:
			gameObject3.SetActive(value: true);
			if ((bool)target.textItemLabel)
			{
				target.textItemLabel.text = UIBasicUtility.SafeFormat("フレンドポイント {0}", num2.ToString("#,#,#,#,0"));
			}
			break;
		default:
			throw new MatchError(new StringBuilder("`masterTypeValue` failed to match `").Append((object)num6).Append("`").ToString());
		case 1:
			break;
		}
		ExtensionsModule.FindChild(target.gameObject, "CollectBotton").GetComponent<UIButtonMessage>().target = callbackTarget;
		NGUITools.DestroyAllSameComponent<UIPanel>(target.gameObject);
	}

	public void Awake()
	{
		base.HookSettingListItem = hookPresentSettingListItem;
	}

	private bool hookPresentSettingListItem(UIListItem item)
	{
		if ((bool)item)
		{
			SetDetail((ManaPieceListItem)item, item.GetData<RespShopItem>());
		}
		return false;
	}
}
