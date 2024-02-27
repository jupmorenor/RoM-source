using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Boo.Lang;
using Boo.Lang.Runtime;
using CompilerGenerated;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class DebugSubGacha : RuntimeDebugModeGuiMixin
{
	[Serializable]
	public class ActionBase
	{
		public ActionEnum _0024act_0024t_0024206;

		public string _0024act_0024t_0024207;

		public __ActionBase__0024act_0024t_0024208_0024callable7_002426_5__ _0024act_0024t_0024208;

		public __ActionBase__0024act_0024t_0024208_0024callable7_002426_5__ _0024act_0024t_0024209;

		public __ActionBase__0024act_0024t_0024208_0024callable7_002426_5__ _0024act_0024t_0024210;

		public __ActionBase__0024act_0024t_0024208_0024callable7_002426_5__ _0024act_0024t_0024211;

		public __ActionBase__0024act_0024t_0024208_0024callable7_002426_5__ _0024act_0024t_0024212;

		public __ActionBase__0024act_0024t_0024208_0024callable7_002426_5__ _0024act_0024t_0024213;

		public __ActionBase__0024act_0024t_0024214_0024callable8_002426_5__ _0024act_0024t_0024214;

		public IEnumerator _0024act_0024t_0024218;

		public float actionTime;

		public float preActionTime;

		public float realActionTimeInit;

		public float actionFrame;

		public string myName => _0024act_0024t_0024206.ToString();

		public float realActionTime => Time.time - realActionTimeInit;
	}

	[Serializable]
	public class ActionClassmainMode : ActionBase
	{
	}

	[Serializable]
	public class ActionClasstutorialItemMode : ActionBase
	{
		public int mode;
	}

	[Serializable]
	public enum ActionEnum
	{
		tutorialItemMode,
		mainMode,
		NUM,
		_noaction_
	}

	protected int typeIdx;

	protected int turnIdx;

	protected int product;

	protected int restore;

	protected RespInAppProduct[] inputStoneList;

	protected int[] turnList;

	protected string[] turnLabelList;

	private Dictionary<string, ActionBase> _0024act_0024t_0024215;

	private Dictionary<string, ActionEnum> _0024act_0024t_0024217;

	private ActionBase[] tmpActBuf;

	private int _0024act_0024t_0024216;

	public bool actionDebugFlag;

	public bool IsmainMode => currActionID("$default$") == ActionEnum.mainMode;

	public float actionTime => currActionTime("$default$");

	public ActionClassmainMode mainModeData => currAction("$default$") as ActionClassmainMode;

	public bool IstutorialItemMode => currActionID("$default$") == ActionEnum.tutorialItemMode;

	public ActionClasstutorialItemMode tutorialItemModeData => currAction("$default$") as ActionClasstutorialItemMode;

	public DebugSubGacha()
	{
		turnList = new int[8] { 1, 2, 3, 5, 10, 20, 30, 50 };
		turnLabelList = new string[8] { "1回", "2回", "3回", "5回", "10回", "20回", "30回", "50回" };
		_0024act_0024t_0024215 = new Dictionary<string, ActionBase>();
		_0024act_0024t_0024217 = new Dictionary<string, ActionEnum>();
		tmpActBuf = new ActionBase[32];
	}

	public override void Init()
	{
		MerlinServer.Request(new ApiPurchaseProductIdList(), _0024adaptor_0024__DebugSubGacha_Init_0024callable381_002416_59___0024__MerlinServer_Request_0024callable86_0024160_56___00245.Adapt(ProductIdListInitialize));
		mainMode();
	}

	public override void OnGUI()
	{
		actOnGUI();
	}

	public override void Update()
	{
		actUpdate();
	}

	public void setActionDebugMode(bool b)
	{
		actionDebugFlag = b;
	}

	public ActionBase currAction()
	{
		return currAction("$default$");
	}

	public ActionEnum currActionID()
	{
		return currActionID("$default$");
	}

	public ActionBase currAction(string grp)
	{
		return (string.IsNullOrEmpty(grp) || !_0024act_0024t_0024215.ContainsKey(grp)) ? null : _0024act_0024t_0024215[grp];
	}

	public ActionEnum currActionID(string grp)
	{
		return (!_0024act_0024t_0024217.ContainsKey(grp)) ? ActionEnum._noaction_ : _0024act_0024t_0024217[grp];
	}

	public float currActionTime(string grp)
	{
		return (!_0024act_0024t_0024215.ContainsKey(grp)) ? 0f : _0024act_0024t_0024215[grp].actionTime;
	}

	public float currPreActionTime(string grp)
	{
		return (!_0024act_0024t_0024215.ContainsKey(grp)) ? 0f : _0024act_0024t_0024215[grp].preActionTime;
	}

	public float currActionFrame(string grp)
	{
		return (!_0024act_0024t_0024215.ContainsKey(grp)) ? 0f : _0024act_0024t_0024215[grp].actionFrame;
	}

	public bool isExecuting(ActionEnum aid)
	{
		bool flag;
		foreach (ActionEnum value in _0024act_0024t_0024217.Values)
		{
			if (value != aid)
			{
				continue;
			}
			flag = true;
			goto IL_004c;
		}
		int result = 0;
		goto IL_004d;
		IL_004c:
		result = (flag ? 1 : 0);
		goto IL_004d;
		IL_004d:
		return (byte)result != 0;
	}

	public bool isExecuting(ActionBase act)
	{
		return act != null && !string.IsNullOrEmpty(act._0024act_0024t_0024207) && _0024act_0024t_0024215.ContainsKey(act._0024act_0024t_0024207) && RuntimeServices.EqualityOperator(act, _0024act_0024t_0024215[act._0024act_0024t_0024207]);
	}

	public static bool IsValidActionID(ActionEnum aid)
	{
		bool num = ActionEnum.tutorialItemMode <= aid;
		if (num)
		{
			num = aid < ActionEnum.NUM;
		}
		return num;
	}

	protected void setCurrAction(ActionBase act)
	{
		if (act != null)
		{
			if (string.IsNullOrEmpty(act._0024act_0024t_0024207))
			{
				throw new AssertionFailedException("not string.IsNullOrEmpty(act.$act$t$207)");
			}
			_0024act_0024t_0024215[act._0024act_0024t_0024207] = act;
			_0024act_0024t_0024217[act._0024act_0024t_0024207] = act._0024act_0024t_0024206;
			act.realActionTimeInit = Time.time;
		}
	}

	protected void changeAction(ActionBase act)
	{
		if (checked(++_0024act_0024t_0024216) > 100)
		{
			throw new Exception("update無しに" + 100 + "回以上action遷移しました");
		}
		ActionBase actionBase = currAction(act._0024act_0024t_0024207);
		if (act == null || RuntimeServices.EqualityOperator(actionBase, act))
		{
			return;
		}
		if (actionDebugFlag)
		{
			if (actionBase == null)
			{
				Builtins.print(new StringBuilder("act_method: change <no action> -> ").Append(act.myName).Append(" (group: ").Append(act._0024act_0024t_0024207)
					.Append(")")
					.ToString());
			}
			else
			{
				Builtins.print(new StringBuilder("act_method: change ").Append(actionBase.myName).Append(" -> ").Append(act.myName)
					.Append(" (group: ")
					.Append(act._0024act_0024t_0024207)
					.Append(")")
					.ToString());
			}
		}
		if (actionBase != null && actionBase._0024act_0024t_0024209 != null)
		{
			actionBase._0024act_0024t_0024209(actionBase);
		}
		if (actionBase == null || isExecuting(actionBase))
		{
			setCurrAction(act);
			if (act._0024act_0024t_0024208 != null)
			{
				act._0024act_0024t_0024208(act);
			}
			if (isExecuting(act) && act._0024act_0024t_0024214 != null)
			{
				act._0024act_0024t_0024218 = act._0024act_0024t_0024214(act);
			}
		}
	}

	public void changeAction(ActionEnum actID)
	{
		ActionBase actionBase = createActionData(actID);
		if (actionBase != null)
		{
			changeAction(actionBase);
		}
	}

	private int copyActsToTmpActBuf()
	{
		int result = 0;
		foreach (ActionBase value in _0024act_0024t_0024215.Values)
		{
			ActionBase[] array = tmpActBuf;
			array[RuntimeServices.NormalizeArrayIndex(array, checked(result++))] = value;
		}
		return result;
	}

	public void actUpdate()
	{
		int num = copyActsToTmpActBuf();
		_0024act_0024t_0024216 = 0;
		int num2 = 0;
		int num3 = num;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int index = num2;
			num2++;
			ActionBase[] array = tmpActBuf;
			ActionBase actionBase = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			if (actionBase._0024act_0024t_0024210 != null)
			{
				actionBase._0024act_0024t_0024210(actionBase);
			}
			if (isExecuting(actionBase) && actionBase._0024act_0024t_0024218 != null && !actionBase._0024act_0024t_0024218.MoveNext())
			{
				actionBase._0024act_0024t_0024218 = null;
			}
		}
		foreach (ActionBase value in _0024act_0024t_0024215.Values)
		{
			value.preActionTime = value.actionTime;
			if (value != null)
			{
				value.actionTime += Time.deltaTime;
			}
			value.actionFrame += 1f;
		}
	}

	public void actFixedUpdate()
	{
		int num = copyActsToTmpActBuf();
		_0024act_0024t_0024216 = 0;
		int num2 = 0;
		int num3 = num;
		if (num3 < 0)
		{
			throw new ArgumentOutOfRangeException("max");
		}
		while (num2 < num3)
		{
			int index = num2;
			num2++;
			ActionBase[] array = tmpActBuf;
			ActionBase actionBase = array[RuntimeServices.NormalizeArrayIndex(array, index)];
			if (actionBase._0024act_0024t_0024211 != null)
			{
				actionBase._0024act_0024t_0024211(actionBase);
			}
		}
	}

	public void actOnGUI()
	{
		_0024act_0024t_0024216 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_0024215.Keys);
		int i = 0;
		string[] array2 = array;
		checked
		{
			for (int length = array2.Length; i < length; i++)
			{
				ActionBase actionBase = _0024act_0024t_0024215[array2[i]];
				if (actionBase._0024act_0024t_0024212 != null)
				{
					actionBase._0024act_0024t_0024212(actionBase);
				}
			}
			if (!actionDebugFlag)
			{
				return;
			}
			int num = 100;
			foreach (ActionBase value in _0024act_0024t_0024215.Values)
			{
				GUI.Label(new Rect(200f, num, 400f, 20f), "act:" + value._0024act_0024t_0024207 + " - " + value._0024act_0024t_0024206 + " tm:" + value.actionTime + " fr:" + value.actionFrame);
				num += 20;
			}
		}
	}

	public void actLateUpdate()
	{
		_0024act_0024t_0024216 = 0;
		string[] array = (string[])Builtins.array(typeof(string), _0024act_0024t_0024215.Keys);
		int i = 0;
		string[] array2 = array;
		for (int length = array2.Length; i < length; i = checked(i + 1))
		{
			ActionBase actionBase = _0024act_0024t_0024215[array2[i]];
			if (actionBase._0024act_0024t_0024213 != null)
			{
				actionBase._0024act_0024t_0024213(actionBase);
			}
		}
	}

	protected ActionBase createActionData(ActionEnum actID)
	{
		if (!IsValidActionID(actID))
		{
			throw new Exception("invalid " + "DebugSubGacha" + " enum: " + actID);
		}
		return actID switch
		{
			ActionEnum.mainMode => createDatamainMode(), 
			ActionEnum.tutorialItemMode => createDatatutorialItemMode(), 
			_ => null, 
		};
	}

	public ActionClassmainMode mainMode()
	{
		ActionClassmainMode actionClassmainMode = createmainMode();
		changeAction(actionClassmainMode);
		return actionClassmainMode;
	}

	public ActionClassmainMode createDatamainMode()
	{
		ActionClassmainMode actionClassmainMode = new ActionClassmainMode();
		actionClassmainMode._0024act_0024t_0024206 = ActionEnum.mainMode;
		actionClassmainMode._0024act_0024t_0024207 = "$default$";
		actionClassmainMode._0024act_0024t_0024212 = _0024adaptor_0024__DebugSubGacha_0024callable194_002426_5___0024__ActionBase__0024act_0024t_0024208_0024callable7_002426_5___00246.Adapt(delegate
		{
			GUILayoutOption gUILayoutOption = RuntimeDebugModeGuiMixin.optWidth(400);
			RuntimeDebugModeGuiMixin.space(10);
			if (typeIdx < 0)
			{
				typeIdx = 0;
			}
			DateTime utcNow = MerlinDateTime.UtcNow;
			Boo.Lang.List<MSaleGachas> list = new Boo.Lang.List<MSaleGachas>();
			Boo.Lang.List<string> list2 = new Boo.Lang.List<string>();
			IEnumerator enumerator = MSaleGachas.All.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is MSaleGachas))
				{
					obj = RuntimeServices.Coerce(obj, typeof(MSaleGachas));
				}
				MSaleGachas mSaleGachas = (MSaleGachas)obj;
				if (mSaleGachas.StartDate <= utcNow && utcNow <= mSaleGachas.EndDate)
				{
					list.Add(mSaleGachas);
					list2.Add(new StringBuilder().Append((object)mSaleGachas.Id).Append(":").Append(mSaleGachas.Name)
						.Append("/step=")
						.Append((object)mSaleGachas.Step)
						.ToString());
				}
			}
			RuntimeDebugModeGuiMixin.label("Gacha Type:");
			typeIdx = RuntimeDebugModeGuiMixin.grid(typeIdx, (string[])Builtins.array(typeof(string), list2), 1);
			RuntimeDebugModeGuiMixin.space(10);
			RuntimeDebugModeGuiMixin.label("Gacha Turn:");
			turnIdx = RuntimeDebugModeGuiMixin.grid(turnIdx, turnLabelList, 5);
			RuntimeDebugModeGuiMixin.space(10);
			if (RuntimeDebugModeGuiMixin.button("ガチャ引く！", gUILayoutOption) && 0 <= turnIdx)
			{
				MSaleGachas mSaleGachas2 = list[typeIdx];
				int num = 0;
				int[] array = turnList;
				int num2 = array[RuntimeServices.NormalizeArrayIndex(array, turnIdx)];
				if (num2 < 0)
				{
					throw new ArgumentOutOfRangeException("max");
				}
				while (num < num2)
				{
					int num3 = num;
					num++;
					ApiGachaExec apiGachaExec = new ApiGachaExec();
					int num4 = (apiGachaExec.GachaId = mSaleGachas2.Id);
					int num5 = (apiGachaExec.Turn = 1);
					MerlinServer.ExRequest(apiGachaExec);
				}
			}
			RuntimeDebugModeGuiMixin.space(30);
			if (RuntimeDebugModeGuiMixin.button("APいま回復する！"))
			{
				MerlinServer.ExRequest(new ApiUpdateActionPoint());
			}
			RuntimeDebugModeGuiMixin.space(30);
			if (RuntimeDebugModeGuiMixin.button("RPいま回復する！"))
			{
				MerlinServer.ExRequest(new ApiUpdateRaidPoint());
			}
			RuntimeDebugModeGuiMixin.space(30);
			if (RuntimeDebugModeGuiMixin.button("BPいま回復する！"))
			{
				MerlinServer.ExRequest(new ApiPlayerUpdateBattlePoint());
			}
			RuntimeDebugModeGuiMixin.space(30);
			if (RuntimeDebugModeGuiMixin.button("箱拡張x5"))
			{
				MerlinServer.ExRequest(new ApiBoxExtension());
				MerlinServer.ExRequest(new ApiBoxExtension());
				MerlinServer.ExRequest(new ApiBoxExtension());
				MerlinServer.ExRequest(new ApiBoxExtension());
				MerlinServer.ExRequest(new ApiBoxExtension());
			}
			RuntimeDebugModeGuiMixin.space(30);
			if (RuntimeDebugModeGuiMixin.button("TutorialItem付与機能テスト"))
			{
				tutorialItemMode();
			}
			__DebugSubUserData__0024createDataFlagMode_0024closure_00242825_0024callable129_0024479_23__ _DebugSubUserData__0024createDataFlagMode_0024closure_00242825_0024callable129_0024479_23__ = checked(delegate(string btnName, bool sellFavo)
			{
				RuntimeDebugModeGuiMixin.space(30);
				if (RuntimeDebugModeGuiMixin.button(btnName))
				{
					ApiSellBox apiSellBox = new ApiSellBox();
					Boo.Lang.List<BoxId> list3 = new Boo.Lang.List<BoxId>();
					int i = 0;
					RespPlayerBox[] allItems = UserData.Current.userBoxData.AllItems;
					for (int length = allItems.Length; i < length; i++)
					{
						if (allItems[i] != null && (sellFavo || !UserData.Current.IsFavorite(allItems[i])))
						{
							BoxId id = allItems[i].Id;
							if (!UserData.Current.IsUsing(id))
							{
								list3.Add(id);
							}
						}
					}
					string lhs = "{ ";
					int j = 0;
					BoxId[] array2 = list3.ToArray();
					for (int length2 = array2.Length; j < length2; j++)
					{
						lhs += array2[j].ToString() + ", ";
					}
					lhs += "}";
					apiSellBox.set(list3.ToArray());
					MerlinServer.ExRequest(apiSellBox);
				}
			});
			_DebugSubUserData__0024createDataFlagMode_0024closure_00242825_0024callable129_0024479_23__("全部売る", doFade: false);
			_DebugSubUserData__0024createDataFlagMode_0024closure_00242825_0024callable129_0024479_23__("全部売る(お気に入りも)", doFade: true);
		});
		actionClassmainMode._0024act_0024t_0024210 = _0024adaptor_0024__DebugSubGacha_0024callable194_002426_5___0024__ActionBase__0024act_0024t_0024208_0024callable7_002426_5___00246.Adapt(delegate
		{
			title = "Gacha";
		});
		return actionClassmainMode;
	}

	public ActionClassmainMode createmainMode()
	{
		return createDatamainMode();
	}

	public bool IsAtTime(float t)
	{
		int num2;
		if (_0024act_0024t_0024215.ContainsKey("$default$"))
		{
			ActionBase actionBase = _0024act_0024t_0024215["$default$"];
			float realActionTime = actionBase.realActionTime;
			float num = actionBase.realActionTime - t;
			num2 = ((num > 0f) ? 1 : 0);
			if (num2 != 0)
			{
				num2 = ((!(num > Time.deltaTime)) ? 1 : 0);
			}
		}
		else
		{
			num2 = 0;
		}
		return (byte)num2 != 0;
	}

	public ActionClasstutorialItemMode tutorialItemMode()
	{
		ActionClasstutorialItemMode actionClasstutorialItemMode = createtutorialItemMode();
		changeAction(actionClasstutorialItemMode);
		return actionClasstutorialItemMode;
	}

	public ActionClasstutorialItemMode createDatatutorialItemMode()
	{
		ActionClasstutorialItemMode actionClasstutorialItemMode = new ActionClasstutorialItemMode();
		actionClasstutorialItemMode._0024act_0024t_0024206 = ActionEnum.tutorialItemMode;
		actionClasstutorialItemMode._0024act_0024t_0024207 = "$default$";
		actionClasstutorialItemMode._0024act_0024t_0024208 = _0024adaptor_0024__DebugSubGacha_0024callable195_0024111_5___0024__ActionBase__0024act_0024t_0024208_0024callable7_002426_5___00247.Adapt(delegate(ActionClasstutorialItemMode _0024act_0024t_0024221)
		{
			_0024act_0024t_0024221.mode = 0;
		});
		actionClasstutorialItemMode._0024act_0024t_0024212 = _0024adaptor_0024__DebugSubGacha_0024callable195_0024111_5___0024__ActionBase__0024act_0024t_0024208_0024callable7_002426_5___00247.Adapt(delegate(ActionClasstutorialItemMode _0024act_0024t_0024221)
		{
			_0024act_0024t_0024221.mode = RuntimeDebugModeGuiMixin.grid(_0024act_0024t_0024221.mode, new string[2] { "確定", "ランダム" }, 2);
			int i = 0;
			MTutorialItems[] all = MTutorialItems.All;
			for (int length = all.Length; i < length; i = checked(i + 1))
			{
				if (RuntimeDebugModeGuiMixin.button(all[i].Progname))
				{
					ApiTutorialPutInBox apiTutorialPutInBox = new ApiTutorialPutInBox(all[i].Id);
					apiTutorialPutInBox.IsRandom = _0024act_0024t_0024221.mode == 0;
					MerlinServer.ExRequest(apiTutorialPutInBox);
				}
			}
		});
		return actionClasstutorialItemMode;
	}

	public ActionClasstutorialItemMode createtutorialItemMode()
	{
		return createDatatutorialItemMode();
	}

	private void requestPurchase(int id)
	{
		if (!(inputStoneList == null))
		{
			ApiPurchaseVerify apiPurchaseVerify = new ApiPurchaseVerify();
			RespInAppProduct[] array = inputStoneList;
			string text = (apiPurchaseVerify.ProductId = array[RuntimeServices.NormalizeArrayIndex(array, id)].ProductIdCode.ToString());
			string text2 = (apiPurchaseVerify.TransactionId = StoneList.GetTransactionId(random: true));
			MerlinServer.ExRequest(apiPurchaseVerify);
		}
	}

	private void ProductIdListInitialize(ApiPurchaseProductIdList req)
	{
		if (req == null)
		{
			throw new AssertionFailedException("req != null");
		}
		inputStoneList = req.GetResponse().ProductInfo;
		int i = 0;
		RespInAppProduct[] array = inputStoneList;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
		}
	}

	internal void _0024createDatamainMode_0024closure_00243383(ActionClassmainMode _0024act_0024t_0024205)
	{
		GUILayoutOption gUILayoutOption = RuntimeDebugModeGuiMixin.optWidth(400);
		RuntimeDebugModeGuiMixin.space(10);
		if (typeIdx < 0)
		{
			typeIdx = 0;
		}
		DateTime utcNow = MerlinDateTime.UtcNow;
		Boo.Lang.List<MSaleGachas> list = new Boo.Lang.List<MSaleGachas>();
		Boo.Lang.List<string> list2 = new Boo.Lang.List<string>();
		IEnumerator enumerator = MSaleGachas.All.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is MSaleGachas))
			{
				obj = RuntimeServices.Coerce(obj, typeof(MSaleGachas));
			}
			MSaleGachas mSaleGachas = (MSaleGachas)obj;
			if (mSaleGachas.StartDate <= utcNow && utcNow <= mSaleGachas.EndDate)
			{
				list.Add(mSaleGachas);
				list2.Add(new StringBuilder().Append((object)mSaleGachas.Id).Append(":").Append(mSaleGachas.Name)
					.Append("/step=")
					.Append((object)mSaleGachas.Step)
					.ToString());
			}
		}
		RuntimeDebugModeGuiMixin.label("Gacha Type:");
		typeIdx = RuntimeDebugModeGuiMixin.grid(typeIdx, (string[])Builtins.array(typeof(string), list2), 1);
		RuntimeDebugModeGuiMixin.space(10);
		RuntimeDebugModeGuiMixin.label("Gacha Turn:");
		turnIdx = RuntimeDebugModeGuiMixin.grid(turnIdx, turnLabelList, 5);
		RuntimeDebugModeGuiMixin.space(10);
		if (RuntimeDebugModeGuiMixin.button("ガチャ引く！", gUILayoutOption) && 0 <= turnIdx)
		{
			MSaleGachas mSaleGachas2 = list[typeIdx];
			int num = 0;
			int[] array = turnList;
			int num2 = array[RuntimeServices.NormalizeArrayIndex(array, turnIdx)];
			if (num2 < 0)
			{
				throw new ArgumentOutOfRangeException("max");
			}
			while (num < num2)
			{
				int num3 = num;
				num++;
				ApiGachaExec apiGachaExec = new ApiGachaExec();
				int num4 = (apiGachaExec.GachaId = mSaleGachas2.Id);
				int num5 = (apiGachaExec.Turn = 1);
				MerlinServer.ExRequest(apiGachaExec);
			}
		}
		RuntimeDebugModeGuiMixin.space(30);
		if (RuntimeDebugModeGuiMixin.button("APいま回復する！"))
		{
			MerlinServer.ExRequest(new ApiUpdateActionPoint());
		}
		RuntimeDebugModeGuiMixin.space(30);
		if (RuntimeDebugModeGuiMixin.button("RPいま回復する！"))
		{
			MerlinServer.ExRequest(new ApiUpdateRaidPoint());
		}
		RuntimeDebugModeGuiMixin.space(30);
		if (RuntimeDebugModeGuiMixin.button("BPいま回復する！"))
		{
			MerlinServer.ExRequest(new ApiPlayerUpdateBattlePoint());
		}
		RuntimeDebugModeGuiMixin.space(30);
		if (RuntimeDebugModeGuiMixin.button("箱拡張x5"))
		{
			MerlinServer.ExRequest(new ApiBoxExtension());
			MerlinServer.ExRequest(new ApiBoxExtension());
			MerlinServer.ExRequest(new ApiBoxExtension());
			MerlinServer.ExRequest(new ApiBoxExtension());
			MerlinServer.ExRequest(new ApiBoxExtension());
		}
		RuntimeDebugModeGuiMixin.space(30);
		if (RuntimeDebugModeGuiMixin.button("TutorialItem付与機能テスト"))
		{
			tutorialItemMode();
		}
		__DebugSubUserData__0024createDataFlagMode_0024closure_00242825_0024callable129_0024479_23__ _DebugSubUserData__0024createDataFlagMode_0024closure_00242825_0024callable129_0024479_23__ = checked(delegate(string btnName, bool sellFavo)
		{
			RuntimeDebugModeGuiMixin.space(30);
			if (RuntimeDebugModeGuiMixin.button(btnName))
			{
				ApiSellBox apiSellBox = new ApiSellBox();
				Boo.Lang.List<BoxId> list3 = new Boo.Lang.List<BoxId>();
				int i = 0;
				RespPlayerBox[] allItems = UserData.Current.userBoxData.AllItems;
				for (int length = allItems.Length; i < length; i++)
				{
					if (allItems[i] != null && (sellFavo || !UserData.Current.IsFavorite(allItems[i])))
					{
						BoxId id = allItems[i].Id;
						if (!UserData.Current.IsUsing(id))
						{
							list3.Add(id);
						}
					}
				}
				string lhs = "{ ";
				int j = 0;
				BoxId[] array2 = list3.ToArray();
				for (int length2 = array2.Length; j < length2; j++)
				{
					lhs += array2[j].ToString() + ", ";
				}
				lhs += "}";
				apiSellBox.set(list3.ToArray());
				MerlinServer.ExRequest(apiSellBox);
			}
		});
		_DebugSubUserData__0024createDataFlagMode_0024closure_00242825_0024callable129_0024479_23__("全部売る", doFade: false);
		_DebugSubUserData__0024createDataFlagMode_0024closure_00242825_0024callable129_0024479_23__("全部売る(お気に入りも)", doFade: true);
	}

	internal void _0024_0024createDatamainMode_0024closure_00243383_0024SellButton_00243385(string btnName, bool sellFavo)
	{
		RuntimeDebugModeGuiMixin.space(30);
		if (!RuntimeDebugModeGuiMixin.button(btnName))
		{
			return;
		}
		ApiSellBox apiSellBox = new ApiSellBox();
		Boo.Lang.List<BoxId> list = new Boo.Lang.List<BoxId>();
		int i = 0;
		RespPlayerBox[] allItems = UserData.Current.userBoxData.AllItems;
		checked
		{
			for (int length = allItems.Length; i < length; i++)
			{
				if (allItems[i] != null && (sellFavo || !UserData.Current.IsFavorite(allItems[i])))
				{
					BoxId id = allItems[i].Id;
					if (!UserData.Current.IsUsing(id))
					{
						list.Add(id);
					}
				}
			}
			string lhs = "{ ";
			int j = 0;
			BoxId[] array = list.ToArray();
			for (int length2 = array.Length; j < length2; j++)
			{
				lhs += array[j].ToString() + ", ";
			}
			lhs += "}";
			apiSellBox.set(list.ToArray());
			MerlinServer.ExRequest(apiSellBox);
		}
	}

	internal void _0024createDatamainMode_0024closure_00243388(ActionClassmainMode _0024act_0024t_0024205)
	{
		title = "Gacha";
	}

	internal void _0024createDatatutorialItemMode_0024closure_00243389(ActionClasstutorialItemMode _0024act_0024t_0024221)
	{
		_0024act_0024t_0024221.mode = 0;
	}

	internal void _0024createDatatutorialItemMode_0024closure_00243390(ActionClasstutorialItemMode _0024act_0024t_0024221)
	{
		_0024act_0024t_0024221.mode = RuntimeDebugModeGuiMixin.grid(_0024act_0024t_0024221.mode, new string[2] { "確定", "ランダム" }, 2);
		int i = 0;
		MTutorialItems[] all = MTutorialItems.All;
		for (int length = all.Length; i < length; i = checked(i + 1))
		{
			if (RuntimeDebugModeGuiMixin.button(all[i].Progname))
			{
				ApiTutorialPutInBox apiTutorialPutInBox = new ApiTutorialPutInBox(all[i].Id);
				apiTutorialPutInBox.IsRandom = _0024act_0024t_0024221.mode == 0;
				MerlinServer.ExRequest(apiTutorialPutInBox);
			}
		}
	}
}
