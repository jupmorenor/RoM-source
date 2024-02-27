using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boo.Lang.Runtime;
using GameAsset;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class PresentList : UIListBase
{
	private DateTime now;

	private HashSet<int> olds;

	private List<RespPlayerPresentBox> original;

	private bool first;

	private GameObject callbackTarget;

	private GameObject weaponIconPrefab;

	private GameObject mapetIconPrefab;

	public UIMain uimain;

	private Dictionary<EnumMasterTypeValues, int> masterTypeCounts;

	public PresentList()
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

	public void SetResponse(RespPlayerPresentBox[] list, GameObject go)
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
		UserAlreadyReadData alreadyReadData = UserData.Current.userMiscInfo.alreadyReadData;
		olds = alreadyReadData.MarkPresents(list);
		now = MerlinDateTime.Now;
		original = list.ToList();
		callbackTarget = go;
		Initialize(list, gameObject, autoTween: true);
	}

	public void SetDetail(GiftListItem target, RespPlayerPresentBox presentData)
	{
		target.textTitleLabel.text = presentData.Title;
		DateTime dateTime = presentData.SendDate.ToLocalTime();
		MGameParameters mGameParameters = MGameParameters.findByGameParameterId(11);
		int num = default(int);
		num = mGameParameters?.Param ?? 3000;
		int b = checked((int)(dateTime.AddDays(num) - now).TotalDays);
		b = Mathf.Max(1, b);
		target.textDateLabel.text = dateTime.ToString("yyyy/MM/dd");
		target.textBodyLabel.text = (string.IsNullOrEmpty(presentData.Explain) ? string.Empty : presentData.GetMultiLineExplain());
		target.textDateLimitLabel.text = UIBasicUtility.SafeFormat("あと {0}日", b);
		target.newIcon.enabled = olds.Contains(presentData.Id);
		Hashtable hashtable = (target.hash = NGUIJson.jsonDecode(presentData.ItemData) as Hashtable);
		EnumMasterTypeValues enumMasterTypeValues = (EnumMasterTypeValues)RuntimeServices.UnboxInt32(hashtable["MasterTypeValue"]);
		int num2 = RuntimeServices.UnboxInt32(hashtable["Quantity"]);
		int num3 = RuntimeServices.UnboxInt32(hashtable["ItemId"]);
		int num4 = RuntimeServices.UnboxInt32(hashtable["Level"]);
		MMasterTypeValues mMasterTypeValues = MMasterTypeValues.Get((int)enumMasterTypeValues);
		int num5 = 0;
		if (masterTypeCounts.ContainsKey(enumMasterTypeValues))
		{
			num5 = masterTypeCounts[enumMasterTypeValues];
		}
		masterTypeCounts[enumMasterTypeValues] = checked(num5 + 1);
		GameObject go = target.gameObject;
		GameObject gameObject = ExtensionsModule.FindChild(go, "CommonIcon");
		GameObject gameObject2 = ExtensionsModule.FindChild(go, "Pet");
		GameObject gameObject3 = ExtensionsModule.FindChild(go, "Weapon");
		RespReward reward = presentData.GetReward();
		gameObject2.SetActive(value: false);
		gameObject3.SetActive(value: false);
		gameObject.SetActive(value: false);
		if (enumMasterTypeValues == EnumMasterTypeValues.None)
		{
			throw new AssertionFailedException("masterTypeValue != EnumMasterTypeValues.None");
		}
		UserData current = UserData.Current;
		switch (enumMasterTypeValues)
		{
		case EnumMasterTypeValues.Weapon:
		{
			gameObject3.SetActive(value: true);
			GameObject gameObject5 = (GameObject)UnityEngine.Object.Instantiate(weaponIconPrefab);
			gameObject5.transform.parent = gameObject3.transform;
			gameObject5.transform.localScale = Vector3.one;
			gameObject5.transform.localPosition = new Vector3(0f, 0f, -1f);
			RespWeapon respWeapon = reward.toRespWeapon();
			target.textItemLabel.text = new StringBuilder().Append(respWeapon.Master.Name).Append(" Lv ").Append((object)num4)
				.ToString();
			current.userMiscInfo.weaponBookData.look(respWeapon.Master);
			gameObject5.GetComponent<WeaponListItem>().SetWeapon(respWeapon);
			UIButtonMessage component2 = gameObject5.GetComponent<UIButtonMessage>();
			component2.target = uimain.gameObject;
			component2.functionName = "PushDetail";
			component2.waitTime = 0.8f;
			break;
		}
		case EnumMasterTypeValues.Poppet:
		{
			gameObject2.SetActive(value: true);
			GameObject gameObject4 = (GameObject)UnityEngine.Object.Instantiate(mapetIconPrefab);
			gameObject4.transform.parent = gameObject2.transform;
			gameObject4.transform.localScale = Vector3.one;
			gameObject4.transform.localPosition = new Vector3(0f, 0f, -1f);
			RespPoppet respPoppet = reward.toRespPoppet();
			target.textItemLabel.text = new StringBuilder().Append(respPoppet.Master.Name).Append(" Lv ").Append((object)num4)
				.ToString();
			current.userMiscInfo.poppetBookData.look(respPoppet.Master);
			gameObject4.GetComponent<MapetListItem>().SetMapet(respPoppet);
			UIButtonMessage component2 = gameObject4.GetComponent<UIButtonMessage>();
			component2.target = uimain.gameObject;
			component2.functionName = "PushDetail";
			component2.waitTime = 0.8f;
			break;
		}
		default:
			if (mMasterTypeValues != null)
			{
				if ((bool)gameObject)
				{
					UISprite component = gameObject.GetComponent<UISprite>();
					component.spriteName = mMasterTypeValues.Icon;
					gameObject.SetActive(value: true);
				}
				target.textItemLabel.text = UIBasicUtility.SafeFormat(new StringBuilder().Append(mMasterTypeValues.Name_DisplayFormat).ToString(), num2);
			}
			break;
		case EnumMasterTypeValues.None:
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
		SetDetail((GiftListItem)item, item.GetData<RespPlayerPresentBox>());
		return false;
	}
}
