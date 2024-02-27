using System;
using System.Collections;
using Boo.Lang.Runtime;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class BoxListItem : UIListItem
{
	public GameObject weaponIconPrefab;

	public GameObject petIconPrefab;

	private UILabelBase sumPlusLabel;

	private GameObject instance;

	private UIValidController validController;

	private bool lastFavo;

	public GameObject Instance
	{
		get
		{
			return instance;
		}
		private set
		{
			instance = value;
		}
	}

	public override void Init()
	{
		if ((bool)Instance)
		{
			return;
		}
		RespPlayerBox data = GetData<RespPlayerBox>();
		GameObject gameObject = Instance;
		if (gameObject == null)
		{
			GameObject prefabObject = null;
			if (data.IsWeapon)
			{
				prefabObject = weaponIconPrefab;
			}
			else if (data.IsPoppet)
			{
				prefabObject = petIconPrefab;
			}
			gameObject = (Instance = NGUITools.InstantiateWithoutUIPanel(prefabObject));
		}
		UIListItem component = gameObject.GetComponent<UIListItem>();
		if (!(component != null))
		{
			throw new AssertionFailedException("アイコンプレハブが UIListItem 継承したアイコンでは有りません!");
		}
		component.canShowNew = true;
		component.SetData(GetData());
		copyState.copyUsingFlag = false;
		copyState.copyDisableFlag = false;
		copyState.copyFavoriteFlag = false;
		copyState.copyCautionText = false;
		copyState.copyUsingText = false;
		copyState.copyIconFavoriteSprite = true;
		copyState.copyFavoObject = true;
		copyState.copyIconNewSprite = true;
		copyState.copyNewObject = true;
		copyState.copyIconCautionLabel = true;
		copyState.copyCautionObject = true;
		copyState.copyAlphaTarget = true;
		Copy(component);
		iconOption = component.iconOption;
		if (data.IsWeapon)
		{
			WeaponInfo weaponInfo = component as WeaponInfo;
			weaponInfo.SetWeapon(data.toRespWeapon(), ignoreUnknown: true);
			sumPlusLabel = weaponInfo.curSumPlusLabel;
		}
		else if (data.IsPoppet)
		{
			MuppetInfo muppetInfo = component as MuppetInfo;
			focusOffset = muppetInfo.focusOffset;
			muppetInfo.SetMuppet(data.toRespPoppet(), ignoreUnknown: true);
			sumPlusLabel = muppetInfo.curSumPlusLabel;
		}
		component.SendMessage("Update", SendMessageOptions.DontRequireReceiver);
		NGUITools.DestroyAllSameComponent<UIPanel>(Instance);
		component.enabled = false;
		gameObject.transform.parent = this.transform;
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.transform.localScale = Vector3.one;
		UIValidController uIValidController = this.gameObject.GetComponent<UIValidController>();
		if (!uIValidController)
		{
			uIValidController = this.gameObject.AddComponent<UIValidController>();
		}
		IEnumerator enumerator = gameObject.transform.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is Transform))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Transform));
			}
			Transform transform = (Transform)obj;
			if (transform != null && transform.name == "State")
			{
				uIValidController.validEffectTarget = transform.gameObject;
				break;
			}
		}
		validController = uIValidController;
		UIListItem.InitAlphaLoopCtrls(this);
		StartAlphaLoopCtrl();
		RespWeaponPoppet respWeaponPoppet = new RespWeaponPoppet(data);
		UIBasicUtility.SetSumPlusBonusLabel(sumPlusLabel, respWeaponPoppet.data);
		SetEnableAlphaTargets("PlusText", 0 < respWeaponPoppet.SumPlusBonus);
	}

	public void SetState(bool use, bool disable)
	{
		UserData current = UserData.Current;
		if (current == null)
		{
			throw new AssertionFailedException("ud");
		}
		if (!(Instance != null))
		{
			throw new AssertionFailedException("アイコンが何も有りません");
		}
		RespPlayerBox data = GetData<RespPlayerBox>();
		if (data != null)
		{
			UsingText = UIBasicUtility.GetUseItemString(current.IsUsing(data.Id), data.IsWeapon);
		}
		ShowUsingText(use, disable);
		validController.isValidColor = !disable;
	}

	public void Update()
	{
		UpdateAlphaLoopCtrl();
		if ((bool)Instance)
		{
			RespPlayerBox respPlayerBox = RespPlayerBox.ConvertRespPlayerBox(GetData<JsonBase>());
			if (respPlayerBox != null && UserData.Current.IsFavorite(respPlayerBox) != lastFavo)
			{
				UIListItem component = Instance.GetComponent<UIListItem>();
				lastFavo = !lastFavo;
				component.SetFavorite(lastFavo);
			}
		}
	}
}
