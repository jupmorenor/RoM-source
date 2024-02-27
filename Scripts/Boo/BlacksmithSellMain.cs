using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class BlacksmithSellMain : UIMain
{
	[Serializable]
	public enum MODE_SELLITEM
	{
		Selectsellitem,
		Confsellitem,
		Max
	}

	[Serializable]
	internal class _0024PushYes_0024locals_002414496
	{
		internal UserData _0024ud;

		internal ApiSellBox _0024req;
	}

	[Serializable]
	internal class _0024PushYes_0024closure_00244261
	{
		internal _0024PushYes_0024locals_002414496 _0024_0024locals_002415087;

		internal BlacksmithSellMain _0024this_002415088;

		public _0024PushYes_0024closure_00244261(_0024PushYes_0024locals_002414496 _0024_0024locals_002415087, BlacksmithSellMain _0024this_002415088)
		{
			this._0024_0024locals_002415087 = _0024_0024locals_002415087;
			this._0024this_002415088 = _0024this_002415088;
		}

		public void Invoke()
		{
			_0024this_002415088.boxList.ClearSelectItems();
			_0024this_002415088.boxList.SetInputBoxList(_0024_0024locals_002415087._0024ud.userBoxData.AllItems);
			_0024this_002415088.mode = MODE_SELLITEM.Selectsellitem;
			StorageHUD.DoUpdateNow();
			__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = () => new _0024_0024_0024PushYes_0024closure_00244261_0024c_00244262_002421538(_0024this_002415088).GetEnumerator();
			_0024this_002415088.StartCoroutine(_GouseiSequense_S540_init_0024callable40_002410_5__());
		}
	}

	[Serializable]
	internal class _0024PushYes_0024coroutine_00244263
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024Invoke_002421541 : GenericGenerator<object>
		{
			[Serializable]
			[CompilerGenerated]
			internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
			{
				internal _0024PushYes_0024coroutine_00244263 _0024self__002421542;

				public _0024(_0024PushYes_0024coroutine_00244263 self_)
				{
					_0024self__002421542 = self_;
				}

				public override bool MoveNext()
				{
					int result;
					switch (_state)
					{
					default:
						if (!_0024self__002421542._0024_0024locals_002415090._0024req.IsEnd)
						{
							result = (YieldDefault(2) ? 1 : 0);
							break;
						}
						if (!_0024self__002421542._0024_0024locals_002415090._0024req.IsOk)
						{
							_0024self__002421542._0024this_002415089.LockTouch(on: false);
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

			internal _0024PushYes_0024coroutine_00244263 _0024self__002421543;

			public _0024Invoke_002421541(_0024PushYes_0024coroutine_00244263 self_)
			{
				_0024self__002421543 = self_;
			}

			public override IEnumerator<object> GetEnumerator()
			{
				return new _0024(_0024self__002421543);
			}
		}

		internal BlacksmithSellMain _0024this_002415089;

		internal _0024PushYes_0024locals_002414496 _0024_0024locals_002415090;

		public _0024PushYes_0024coroutine_00244263(BlacksmithSellMain _0024this_002415089, _0024PushYes_0024locals_002414496 _0024_0024locals_002415090)
		{
			this._0024this_002415089 = _0024this_002415089;
			this._0024_0024locals_002415090 = _0024_0024locals_002415090;
		}

		public IEnumerator Invoke()
		{
			return new _0024Invoke_002421541(this).GetEnumerator();
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024_0024_0024PushYes_0024closure_00244261_0024c_00244262_002421538 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal BlacksmithSellMain _0024self__002421539;

			public _0024(BlacksmithSellMain self_)
			{
				_0024self__002421539 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024self__002421539.IsChangingSituation)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					goto case 3;
				case 3:
					if (_0024self__002421539.IsChangingSituation)
					{
						result = (YieldDefault(3) ? 1 : 0);
						break;
					}
					_0024self__002421539.LockTouch(on: false);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal BlacksmithSellMain _0024self__002421540;

		public _0024_0024_0024PushYes_0024closure_00244261_0024c_00244262_002421538(BlacksmithSellMain self_)
		{
			_0024self__002421540 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__002421540);
		}
	}

	private MODE_SELLITEM mode;

	private MODE_SELLITEM lastMode;

	public BoxItemList boxList;

	public WeaponInfo weaponInfo;

	public MuppetInfo petInfo;

	public BoxListItem[] selectItemDisplay;

	public UILabelBase selectCountLabel;

	public UILabelBase topSumPriceLabel;

	public UILabelBase winSumPriceLabel;

	public UILabelBase manaSumPriceLabel;

	public UILabelBase warningRareLabel;

	private UIBasicUtility.ButtonSet dicideButtonSet;

	public UIButtonMessage sellButton;

	public UIButtonMessage clearButton;

	private bool isShowDetail;

	private int prevSelectCount;

	public BlacksmithSellMain()
	{
		prevSelectCount = -1;
	}

	private void SetSumPrice(int sum, int manaSum)
	{
		UIBasicUtility.SetLabel(topSumPriceLabel, sum.ToString("#,0"), show: true);
		UIBasicUtility.SetLabel(winSumPriceLabel, MTexts.Format("exp_ruku", sum.ToString("#,0")), show: true);
		UIBasicUtility.SetLabel(manaSumPriceLabel, manaSum.ToString("#,0"), show: true);
	}

	private void SetDicedeButtonValid(bool valid)
	{
		if (dicideButtonSet == null)
		{
			dicideButtonSet = UIBasicUtility.CreateButtonSet(sellButton);
		}
		UIBasicUtility.SetButtonValid(dicideButtonSet, valid);
	}

	public override void SceneStart()
	{
		mode = MODE_SELLITEM.Selectsellitem;
		SetDicedeButtonValid(valid: false);
		weaponInfo.DestroyLevel();
		petInfo.DestroyLevel();
		MerlinServer.EditorCommunicationInitialize((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			Initialize();
			ChangeSituation(GetSituation((int)mode));
		});
	}

	public override void LockTouch(bool on)
	{
		base.LockTouch(on);
	}

	private void immadiateFunc()
	{
		if (!IsChangingSituation)
		{
			LockTouch(on: true);
		}
	}

	private void Initialize()
	{
		UserData current = UserData.Current;
		sellButton.immadiateHandler = immadiateFunc;
		clearButton.immadiateHandler = immadiateFunc;
		ButtonBackHUD.GetButton().immadiateHandler = immadiateFunc;
		__Req_FailHandler_0024callable6_0024440_32__ handler = delegate
		{
			// Found self-referencing delegate construction. Abort transformation to avoid stack overflow.
			LockTouch(on: false);
			SceneChanger.ScenePreChangeEvent -= _0024Initialize_0024endScene_00244249;
			ButtonBackHUD.GetButton().immadiateHandler = null;
		};
		SceneChanger.ScenePreChangeEvent += handler;
		boxList.SetInputBoxList(current.userBoxData.AllItems);
		StorageHUD.DoUpdateNow();
	}

	public override void SceneUpdate()
	{
		if (mode != lastMode)
		{
			lastMode = mode;
			ChangeSituation(GetSituation((int)mode));
		}
		if (prevSelectCount != boxList.SelectItems.Count())
		{
			prevSelectCount = boxList.SelectItems.Count();
			SetSumPrice(GetSumPrice(), GetManaSumPrice());
			UIBasicUtility.SetLabel(selectCountLabel, prevSelectCount.ToString(), show: true);
			SetDicedeButtonValid(0 < prevSelectCount);
		}
	}

	public int GetSumPrice()
	{
		return GetSumPrice(boxList, isMana: false);
	}

	public int GetManaSumPrice()
	{
		return GetSumPrice(boxList, isMana: true);
	}

	public static int GetSumPrice(BoxItemList boxList, bool isMana)
	{
		int num = 0;
		RespWeaponPoppet[] array = ArrayMapMain.UIListItemsToRespWeaponPoppet(boxList.SelectItems);
		int i = 0;
		RespWeaponPoppet[] array2 = array;
		checked
		{
			for (int length = array2.Length; i < length; i++)
			{
				num = ((!isMana) ? (num + array2[i].SellPrice) : (num + array2[i].SellManaFragment));
			}
			return num;
		}
	}

	public void PushClear()
	{
		LockTouch(on: false);
		boxList.ClearSelectItems();
	}

	public void PushSell()
	{
		LockTouch(on: false);
		if (!IsChangingSituation && !isShowDetail)
		{
			RespPlayerBox[] array = ArrayMapMain.UIListItemsToRespPlayerBox(boxList.SelectItems);
			if (array.Count() > 0)
			{
				SellCheck(array);
			}
		}
	}

	private void SellCheck(RespPlayerBox[] selects)
	{
		string text = MTexts.Msg("$blk_sell_selection");
		if (PowupBase.IsCheckRareItem(selects))
		{
			text = MTexts.Msg("$blk_sell_rare");
		}
		UIBasicUtility.SetLabel(warningRareLabel, text, show: true);
		int i = 0;
		BoxListItem[] array = selectItemDisplay;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			UnityEngine.Object.DestroyImmediate(array[i].Instance);
		}
		int num = 0;
		int length2 = selectItemDisplay.Length;
		if (length2 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num < length2)
		{
			int num2 = num;
			num++;
			BoxListItem[] array2 = selectItemDisplay;
			BoxListItem boxListItem = array2[RuntimeServices.NormalizeArrayIndex(array2, num2)];
			if (num2 < selects.Length)
			{
				RespPlayerBox respPlayerBox = selects[RuntimeServices.NormalizeArrayIndex(selects, num2)];
				if (respPlayerBox != null && !RuntimeServices.EqualityOperator(boxListItem.ID, respPlayerBox.Id))
				{
					boxListItem.gameObject.SetActive(value: true);
					UIListItem.Data data = new UIListItem.Data();
					data.core = respPlayerBox;
					boxListItem.SetData(data);
					boxListItem.Init();
				}
			}
			else
			{
				boxListItem.gameObject.SetActive(value: false);
			}
		}
		mode = MODE_SELLITEM.Confsellitem;
	}

	public void PushYes()
	{
		_0024PushYes_0024locals_002414496 _0024PushYes_0024locals_0024 = new _0024PushYes_0024locals_002414496();
		_0024PushYes_0024locals_0024._0024ud = UserData.Current;
		_0024PushYes_0024locals_0024._0024req = new ApiSellBox();
		RespPlayerBox[] items = ArrayMapMain.UIListItemsToRespPlayerBox(boxList.SelectItems);
		BoxId[] ids = ArrayMapMain.NonNullIds(items);
		_0024PushYes_0024locals_0024._0024req.set(ids);
		MerlinServer.Request(_0024PushYes_0024locals_0024._0024req, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(new _0024PushYes_0024closure_00244261(_0024PushYes_0024locals_0024, this).Invoke));
		__GouseiSequense_S540_init_0024callable40_002410_5__ _GouseiSequense_S540_init_0024callable40_002410_5__ = new _0024PushYes_0024coroutine_00244263(this, _0024PushYes_0024locals_0024).Invoke;
		IEnumerator enumerator = _GouseiSequense_S540_init_0024callable40_002410_5__();
		if (enumerator != null)
		{
			StartCoroutine(enumerator);
		}
	}

	public void PushNo()
	{
		LockTouch(on: false);
		mode = MODE_SELLITEM.Selectsellitem;
	}

	public void PushDetail(GameObject obj)
	{
		if (!IsChangingSituation)
		{
			RespPlayerBox focusData = boxList.GetFocusData<RespPlayerBox>();
			if (focusData.IsWeapon)
			{
				UIAutoTweenerStandAloneEx.In(weaponInfo.gameObject);
				weaponInfo.SetWeapon(focusData.toRespWeapon());
			}
			else if (focusData.IsPoppet)
			{
				UIAutoTweenerStandAloneEx.In(petInfo.gameObject);
				petInfo.SetMuppet(focusData.toRespPoppet());
			}
			isShowDetail = true;
		}
	}

	public void PushBack(GameObject obj)
	{
		LockTouch(on: false);
		if (isShowDetail)
		{
			isShowDetail = false;
			RespPlayerBox focusData = boxList.GetFocusData<RespPlayerBox>();
			if (focusData.IsWeapon)
			{
				UIAutoTweenerStandAloneEx.Out(weaponInfo.gameObject);
			}
			else
			{
				UIAutoTweenerStandAloneEx.Out(petInfo.gameObject);
			}
		}
		else if (mode == MODE_SELLITEM.Selectsellitem)
		{
			SceneChanger.ChangeTo(SceneID.Ui_TownBlacksmith);
		}
		else if (mode == MODE_SELLITEM.Confsellitem)
		{
			mode = MODE_SELLITEM.Selectsellitem;
		}
	}

	internal void _0024SceneStart_0024closure_00244248()
	{
		Initialize();
		ChangeSituation(GetSituation((int)mode));
	}

	internal void _0024Initialize_0024endScene_00244249(string str)
	{
		// Found self-referencing delegate construction. Abort transformation to avoid stack overflow.
		LockTouch(on: false);
		SceneChanger.ScenePreChangeEvent -= _0024Initialize_0024endScene_00244249;
		ButtonBackHUD.GetButton().immadiateHandler = null;
	}

	internal IEnumerator _0024_0024PushYes_0024closure_00244261_0024c_00244262()
	{
		return new _0024_0024_0024PushYes_0024closure_00244261_0024c_00244262_002421538(this).GetEnumerator();
	}
}
