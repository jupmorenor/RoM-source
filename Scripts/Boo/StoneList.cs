using System;
using System.Collections;
using System.Text.RegularExpressions;
using Boo.Lang.Runtime;
using CompilerGenerated;
using GameAsset;
using MerlinAPI;
using UnityEngine;

[Serializable]
public class StoneList : MonoBehaviour
{
	[Serializable]
	public class CacheButtonMessage
	{
		public GameObject target;

		public string functionName;

		[NonSerialized]
		internal static Regex _0024re_002424726 = new Regex("[^0-9]");
	}

	[Serializable]
	public enum Mode
	{
		None,
		Init,
		SetupList,
		SelectList,
		Purchase,
		PurchaseComplete,
		ErrorInit,
		Error,
		Repare,
		Suspend
	}

	[Serializable]
	public enum DIALOG_MODE
	{
		None,
		CureAp,
		CureRp,
		Buy,
		ApFix,
		RpFix,
		CureBp,
		BpFix
	}

	[Serializable]
	internal class _0024Initialize_0024locals_002414482
	{
		internal bool _0024ServerBusy;

		internal ApiPurchaseProductIdList _0024req;
	}

	[Serializable]
	internal class _0024Update_0024locals_002414483
	{
		internal bool _0024ServerBusy;
	}

	[Serializable]
	internal class _0024PurchaseVerify_0024locals_002414484
	{
		internal string _0024transactionId;

		internal bool _0024stealth;

		internal __MerlinServer_Request_0024callable86_0024160_56__ _0024successHandle;

		internal __MerlinServer_Request_0024callable86_0024160_56__ _0024errorHandle;
	}

	[Serializable]
	internal class _0024RequestCure_0024locals_002414485
	{
		internal DIALOG_MODE _0024fixMode;
	}

	[Serializable]
	internal class _0024IsDialogUpdating_0024locals_002414486
	{
		internal UISituation _0024curSitu;

		internal UIMain _0024uimain;
	}

	[Serializable]
	internal class _0024Initialize_0024closure_00242962
	{
		internal _0024Initialize_0024locals_002414482 _0024_0024locals_002415065;

		internal StoneList _0024this_002415066;

		public _0024Initialize_0024closure_00242962(_0024Initialize_0024locals_002414482 _0024_0024locals_002415065, StoneList _0024this_002415066)
		{
			this._0024_0024locals_002415065 = _0024_0024locals_002415065;
			this._0024this_002415066 = _0024this_002415066;
		}

		public void Invoke(PurchaseUtil purchaseUtil)
		{
			ApiPurchaseProductIdList.Resp response = _0024_0024locals_002415065._0024req.GetResponse();
			if (!PurchaseUtil.SetProductsList(response.ToString(), _0024this_002415066.InitializeList))
			{
				_0024this_002415066.mode = Mode.ErrorInit;
				_0024_0024locals_002415065._0024ServerBusy = false;
			}
		}
	}

	[Serializable]
	internal class _0024Update_0024closure_00242963
	{
		internal _0024Update_0024locals_002414483 _0024_0024locals_002415067;

		internal StoneList _0024this_002415068;

		public _0024Update_0024closure_00242963(_0024Update_0024locals_002414483 _0024_0024locals_002415067, StoneList _0024this_002415068)
		{
			this._0024_0024locals_002415067 = _0024_0024locals_002415067;
			this._0024this_002415068 = _0024this_002415068;
		}

		public void Invoke()
		{
			ModalCollider.SetActive(_0024this_002415068, active: false);
			_0024_0024locals_002415067._0024ServerBusy = false;
			if (_0024this_002415068.OnEnd != null)
			{
				_0024this_002415068.endFlag = true;
				bool arg = false;
				_0024this_002415068.OnEnd(arg);
			}
		}
	}

	[Serializable]
	internal class _0024PurchaseVerify_0024closure_00242969
	{
		internal _0024PurchaseVerify_0024locals_002414484 _0024_0024locals_002415069;

		public _0024PurchaseVerify_0024closure_00242969(_0024PurchaseVerify_0024locals_002414484 _0024_0024locals_002415069)
		{
			this._0024_0024locals_002415069 = _0024_0024locals_002415069;
		}

		public void Invoke(RequestBase r)
		{
			if (!_0024_0024locals_002415069._0024stealth)
			{
				DialogManager.Open(MTexts.Msg("$STONE_LIST_BUY_ERROR"), string.Empty);
			}
			if (r.ResponseObj is GameApiResponseBase gameApiResponseBase && gameApiResponseBase.StatusCode.StartsWith("PuRlt"))
			{
				PurchaseUtil.CompletePurchase(_0024_0024locals_002415069._0024transactionId);
			}
			if (null != _0024_0024locals_002415069._0024errorHandle)
			{
				_0024_0024locals_002415069._0024errorHandle(r);
			}
		}
	}

	[Serializable]
	internal class _0024PurchaseVerify_0024closure_00242970
	{
		internal _0024PurchaseVerify_0024locals_002414484 _0024_0024locals_002415070;

		public _0024PurchaseVerify_0024closure_00242970(_0024PurchaseVerify_0024locals_002414484 _0024_0024locals_002415070)
		{
			this._0024_0024locals_002415070 = _0024_0024locals_002415070;
		}

		public void Invoke(RequestBase r)
		{
			if (r.IsOk)
			{
				PurchaseUtil.CompletePurchase(_0024_0024locals_002415070._0024transactionId);
			}
			if (null != _0024_0024locals_002415070._0024successHandle)
			{
				_0024_0024locals_002415070._0024successHandle(r);
			}
		}
	}

	[Serializable]
	internal class _0024RequestCure_0024closure_00242972
	{
		internal _0024RequestCure_0024locals_002414485 _0024_0024locals_002415071;

		internal StoneList _0024this_002415072;

		public _0024RequestCure_0024closure_00242972(_0024RequestCure_0024locals_002414485 _0024_0024locals_002415071, StoneList _0024this_002415072)
		{
			this._0024_0024locals_002415071 = _0024_0024locals_002415071;
			this._0024this_002415072 = _0024this_002415072;
		}

		public void Invoke()
		{
			_0024this_002415072.ShowDialog(_0024_0024locals_002415071._0024fixMode);
		}
	}

	[Serializable]
	internal class _0024IsDialogUpdating_0024closure_00242974
	{
		internal _0024IsDialogUpdating_0024locals_002414486 _0024_0024locals_002415073;

		public _0024IsDialogUpdating_0024closure_00242974(_0024IsDialogUpdating_0024locals_002414486 _0024_0024locals_002415073)
		{
			this._0024_0024locals_002415073 = _0024_0024locals_002415073;
		}

		public void Invoke(bool cancel)
		{
			_0024_0024locals_002415073._0024uimain.ChangeSituation(_0024_0024locals_002415073._0024curSitu, wait_currSituation: true);
		}
	}

	protected Mode mode;

	protected Mode lastMode;

	public GameObject webViewPanel;

	public WebView buyInformationWebView;

	[NonSerialized]
	private static string infoHtml;

	[NonSerialized]
	protected static string prefabPath = "Prefab/GUI/StoneShop/StoneList Panel";

	private RespInAppProduct[] inputStoneList;

	public bool error;

	private RespInAppProduct lastStone;

	private RespInAppProduct curStone;

	public UITable listParent;

	protected UIDraggablePanelEx dragPanel;

	protected GameObject curSelItem;

	protected bool serverBusy;

	public GameObject listItemPrefab;

	public UIDynamicFontLabel lastNameLabel;

	public UIDynamicFontLabel lastTypeLabel;

	public UISprite lastIconSprite;

	public UISprite lastIconElemSprite;

	public UIDynamicFontLabel curNameLabel;

	public UIDynamicFontLabel curTypeLabel;

	public UISprite curIconSprite;

	public UISprite curIconElemSprite;

	public GameObject decideTarget;

	public string decideFunction;

	public __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ OnEnd;

	protected bool endFlag;

	public GameObject backButtonHUDPrefab;

	private CacheButtonMessage btnBackup;

	private bool destoryBackButton;

	public GameObject purchaseModalCollider;

	protected string curProductId;

	protected bool donwLoad;

	protected float initSec;

	protected string initSelectName;

	public bool debugFlag;

	[NonSerialized]
	private static StoneList stoneList;

	private DIALOG_MODE dialogMode;

	private DialogManager m_dlgMan;

	public UISituation m_situation;

	private bool isClosing;

	private RespInAppProduct[] SetInputStoneList
	{
		set
		{
			inputStoneList = value;
		}
	}

	public bool canStarted => inputStoneList != null;

	private RespInAppProduct CurStoneInfo
	{
		get
		{
			return curStone;
		}
		set
		{
			curStone = value;
			SetCurStone(curStone);
		}
	}

	public GameObject GetCurSelItem => curSelItem;

	public bool IsBusy
	{
		get
		{
			bool num = mode == Mode.SelectList;
			if (!num)
			{
				num = mode == Mode.Error;
			}
			return !num;
		}
	}

	public bool SererBusy
	{
		get
		{
			return serverBusy;
		}
		set
		{
			serverBusy = value;
			MerlinServer.Busy = serverBusy;
		}
	}

	private DialogManager dlgMan
	{
		get
		{
			if (!m_dlgMan)
			{
				m_dlgMan = DialogManager.Instance;
			}
			return m_dlgMan;
		}
	}

	public UISituation Situation => m_situation;

	public StoneList()
	{
		mode = Mode.None;
		lastMode = Mode.None;
		btnBackup = new CacheButtonMessage();
		initSec = 30f;
		dialogMode = DIALOG_MODE.None;
	}

	public void InitList(string initSelect)
	{
		initSelectName = initSelect;
	}

	public static StoneList Create(Transform uiParent)
	{
		return Create(uiParent, null);
	}

	public static StoneList Create(Transform uiParent, __LotterySequence_S540_ExecuteStoneList_0024callable43_0024917_34__ onEnd)
	{
		if (!stoneList)
		{
			stoneList = GameAssetModule.InstantiatePrefab<StoneList>(prefabPath);
			InitTrans(stoneList.gameObject, uiParent);
			int num = -2000;
			Vector3 localPosition = stoneList.transform.localPosition;
			float num2 = (localPosition.z = num);
			Vector3 vector2 = (stoneList.transform.localPosition = localPosition);
		}
		if (onEnd == null)
		{
			onEnd = delegate
			{
				stoneList.gameObject.SetActive(value: false);
			};
		}
		stoneList.OnEnd = onEnd;
		return stoneList;
	}

	private static object InitTrans(GameObject obj, Transform parent)
	{
		object result;
		if (!obj)
		{
			result = null;
		}
		else
		{
			obj.transform.parent = parent;
			obj.transform.localScale = Vector3.one;
			obj.transform.localPosition = Vector3.zero;
			result = null;
		}
		return result;
	}

	public UIButtonMessage CreateBackButton(GameObject target)
	{
		return CreateBackButton(target, null);
	}

	public UIButtonMessage CreateBackButton(GameObject target, Transform parent)
	{
		if (ButtonBackHUD.Instance == null)
		{
			destoryBackButton = true;
			InitTrans((GameObject)UnityEngine.Object.Instantiate(backButtonHUDPrefab), (!parent) ? transform : parent);
		}
		UIButtonMessage button = ButtonBackHUD.GetButton();
		if (!(button != null))
		{
			throw new AssertionFailedException("BackButtonHUD がありません!!!");
		}
		btnBackup.target = button.target;
		btnBackup.functionName = button.functionName;
		button.target = target;
		button.functionName = "PushBack";
		return button;
	}

	public void Close()
	{
		bool flag = false;
		ModalCollider.SetActive(this, active: false);
		if ((bool)ButtonBackHUD.Instance)
		{
			if (destoryBackButton)
			{
				UnityEngine.Object.Destroy(ButtonBackHUD.Instance.gameObject);
				return;
			}
			UIButtonMessage button = ButtonBackHUD.GetButton();
			button.target = btnBackup.target;
			button.functionName = btnBackup.functionName;
		}
	}

	public void SetLastStone(RespInAppProduct stone)
	{
		SetStone(stone, lastNameLabel, lastTypeLabel, lastIconSprite, lastIconElemSprite);
	}

	public void SetCurStone(RespInAppProduct stone)
	{
		SetStone(stone, curNameLabel, curTypeLabel, curIconSprite, curIconElemSprite);
	}

	private void SetStone(RespInAppProduct stone, UILabelBase nameLabel, UILabelBase typeLabel, UISprite icon, UISprite elem)
	{
		if (stone != null)
		{
			UIBasicUtility.SetLabel(nameLabel, stone.Name, show: true);
			UIBasicUtility.SetLabel(typeLabel, stone.Quantity.ToString(), show: true);
			UIBasicUtility.SetSprite(icon, stone.Icon, null, !string.IsNullOrEmpty(stone.Icon));
			UIBasicUtility.SetSprite(elem, stone.ElementIcon, null, !string.IsNullOrEmpty(stone.ElementIcon));
		}
	}

	private RespInAppProduct GetRespInAppProduct(string productId)
	{
		int num = 0;
		RespInAppProduct[] array = inputStoneList;
		int length = array.Length;
		object result;
		while (true)
		{
			if (num < length)
			{
				if (array[num] != null && array[num].ProductIdCode == productId)
				{
					result = array[num];
					break;
				}
				num = checked(num + 1);
				continue;
			}
			result = null;
			break;
		}
		return (RespInAppProduct)result;
	}

	public void InitSelectStone()
	{
		if (!listParent)
		{
			return;
		}
		IEnumerator enumerator = listParent.transform.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is Transform))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Transform));
			}
			Transform transform = (Transform)obj;
			bool flag = false;
			StoneListItem component = transform.gameObject.GetComponent<StoneListItem>();
			if ((bool)component && component.StoneInfo != null && component.StoneInfo.Name == initSelectName)
			{
				flag = true;
			}
			if (flag)
			{
				SelectItem(transform.gameObject);
				lastStone = component.StoneInfo;
				if ((bool)dragPanel)
				{
					dragPanel.SelectObject = transform.gameObject;
				}
				break;
			}
		}
	}

	public void AddList(RespInAppProduct stone, RespInAppProduct baseStone, string extraPrice, bool updateList)
	{
		if (!listItemPrefab || stone == null)
		{
			return;
		}
		GameObject gameObject = NGUITools.InstantiateWithoutUIPanel(listItemPrefab) as GameObject;
		if (!gameObject)
		{
			return;
		}
		gameObject.transform.parent = listParent.transform;
		float x = 0f;
		Vector3 localPosition = gameObject.transform.localPosition;
		float num = (localPosition.x = x);
		Vector3 vector2 = (gameObject.transform.localPosition = localPosition);
		float y = 0f;
		Vector3 localPosition2 = gameObject.transform.localPosition;
		float num2 = (localPosition2.y = y);
		Vector3 vector4 = (gameObject.transform.localPosition = localPosition2);
		float z = -2f;
		Vector3 localPosition3 = gameObject.transform.localPosition;
		float num3 = (localPosition3.z = z);
		Vector3 vector6 = (gameObject.transform.localPosition = localPosition3);
		float x2 = 1f;
		Vector3 localScale = gameObject.transform.localScale;
		float num4 = (localScale.x = x2);
		Vector3 vector8 = (gameObject.transform.localScale = localScale);
		float y2 = 1f;
		Vector3 localScale2 = gameObject.transform.localScale;
		float num5 = (localScale2.y = y2);
		Vector3 vector10 = (gameObject.transform.localScale = localScale2);
		float z2 = 1f;
		Vector3 localScale3 = gameObject.transform.localScale;
		float num6 = (localScale3.z = z2);
		Vector3 vector12 = (gameObject.transform.localScale = localScale3);
		StoneListItem component = gameObject.GetComponent<StoneListItem>();
		if (!component)
		{
			UnityEngine.Object.DestroyObject(gameObject);
			return;
		}
		component.SetStone(stone, baseStone, extraPrice);
		UIButtonMessage[] componentsInChildren = gameObject.GetComponentsInChildren<UIButtonMessage>(includeInactive: true);
		int i = 0;
		UIButtonMessage[] array = componentsInChildren;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (!array[i])
			{
				UnityEngine.Object.DestroyObject(gameObject);
				return;
			}
			array[i].target = this.gameObject;
			array[i].mode = UIButtonMessage.SendMode.Message;
			array[i].message = stone.ProductIdCode;
			array[i].functionName = "PushBuy";
		}
		if (updateList)
		{
			if ((bool)dragPanel)
			{
				dragPanel.InitListItem();
			}
			listParent.Reposition();
		}
	}

	public void ClearList()
	{
		if (!listParent)
		{
			return;
		}
		IEnumerator enumerator = listParent.transform.GetEnumerator();
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is Transform))
			{
				obj = RuntimeServices.Coerce(obj, typeof(Transform));
			}
			Transform transform = (Transform)obj;
			if ((bool)transform)
			{
				UnityEngine.Object.DestroyObject(transform.gameObject);
			}
		}
		curSelItem = null;
	}

	public void SelectItem(GameObject obj)
	{
		if ((bool)obj && !(curSelItem == obj))
		{
			StoneListItem component = obj.GetComponent<StoneListItem>();
			if ((bool)component)
			{
				CurStoneInfo = component.StoneInfo;
			}
			curSelItem = obj;
		}
	}

	public void DecideItem(GameObject obj)
	{
		if (!(curSelItem != obj) && (bool)decideTarget)
		{
			decideTarget.SendMessage(decideFunction, obj, SendMessageOptions.DontRequireReceiver);
		}
	}

	public void Start()
	{
		if ((bool)listParent)
		{
			listParent.gameObject.SetActive(value: false);
		}
		if ((bool)purchaseModalCollider)
		{
			purchaseModalCollider.SetActive(value: false);
		}
		MerlinServer.EditorCommunicationInitialize((__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63__)delegate
		{
			Download();
		});
	}

	public void Download()
	{
		UIAutoTweenerStandAloneEx.Hide(webViewPanel);
		if ((bool)listParent)
		{
			listParent.gameObject.SetActive(value: false);
		}
		endFlag = false;
		if (donwLoad)
		{
			listParent.Reposition();
			if ((bool)listParent)
			{
				listParent.gameObject.SetActive(value: true);
			}
			InitializeList(null);
			return;
		}
		buyInformationWebView.Clear();
		SetInputStoneList = null;
		ClearList();
		bool flag = true;
		MerlinServer.Request(new ApiPurchaseProductIdList(), delegate(RequestBase req2)
		{
			Initialize((ApiPurchaseProductIdList)req2);
		});
	}

	private void Initialize(ApiPurchaseProductIdList req)
	{
		_0024Initialize_0024locals_002414482 _0024Initialize_0024locals_0024 = new _0024Initialize_0024locals_002414482();
		_0024Initialize_0024locals_0024._0024req = req;
		if (_0024Initialize_0024locals_0024._0024req == null)
		{
			error = true;
			dlgMan.OpenDialog(MTexts.Msg("$STONE_LIST_NO_LIST_ERROR"), string.Empty, DialogManager.MB_FLAG.MB_NONE, new string[1] { MTexts.Msg("exp_ok") });
			Close();
			_0024Initialize_0024locals_0024._0024ServerBusy = false;
			mode = Mode.ErrorInit;
			return;
		}
		SetInputStoneList = _0024Initialize_0024locals_0024._0024req.GetResponse().ProductInfo;
		if (inputStoneList == null)
		{
			error = true;
			dlgMan.OpenDialog(MTexts.Msg("$STONE_LIST_NO_LIST_ERROR"), string.Empty, DialogManager.MB_FLAG.MB_NONE, new string[1] { MTexts.Msg("exp_ok") });
			Close();
			_0024Initialize_0024locals_0024._0024ServerBusy = false;
			mode = Mode.ErrorInit;
		}
		else if ((bool)listParent)
		{
			mode = Mode.Init;
			dragPanel = listParent.transform.parent.GetComponent<UIDraggablePanelEx>();
			PurchaseUtil.StartPurchase(new _0024Initialize_0024closure_00242962(_0024Initialize_0024locals_0024, this).Invoke);
		}
	}

	public void InitializeList(PurchaseUtil purchaseUtil)
	{
		mode = Mode.SetupList;
		bool flag = false;
		donwLoad = true;
		ClearList();
		if (!listParent || !listItemPrefab || inputStoneList == null)
		{
			throw new AssertionFailedException("(listParent and listItemPrefab) and inputStoneList");
		}
		int i = 0;
		RespInAppProduct[] array = inputStoneList;
		for (int length = array.Length; i < length; i = checked(i + 1))
		{
			if (array[i] != null)
			{
				string dstPrice = string.Empty;
				if (PurchaseUtil.IsEanbleProdcutEx(array[i].ProductIdCode, ref dstPrice))
				{
					AddList(array[i], inputStoneList[0], dstPrice, updateList: false);
				}
			}
		}
		if ((bool)dragPanel)
		{
			dragPanel.InitListItem();
		}
		listParent.Reposition();
		if ((bool)listParent)
		{
			listParent.gameObject.SetActive(value: true);
		}
	}

	public void OnDestroy()
	{
		bool flag = false;
		ModalCollider.SetActive(this, active: false);
		PurchaseUtil.EndPurchase();
	}

	public void OnEnable()
	{
		if (mode == Mode.SetupList || mode == Mode.SelectList || mode == Mode.Purchase)
		{
			listParent.Reposition();
		}
	}

	public void Update()
	{
		_0024Update_0024locals_002414483 _0024Update_0024locals_0024 = new _0024Update_0024locals_002414483();
		bool flag = false;
		if (mode != lastMode)
		{
			lastMode = mode;
			flag = true;
		}
		if (mode == Mode.Init)
		{
			if (flag)
			{
				initSec = 30f;
			}
			initSec -= Time.deltaTime;
			if (!(initSec > 0f))
			{
				mode = Mode.ErrorInit;
			}
		}
		else if (mode == Mode.SetupList)
		{
			if (canStarted)
			{
				mode = Mode.SelectList;
			}
		}
		else if (mode == Mode.SelectList)
		{
			if (flag)
			{
				endFlag = false;
				if ((bool)listParent)
				{
					listParent.gameObject.SetActive(value: true);
					listParent.Reposition();
				}
				_0024Update_0024locals_0024._0024ServerBusy = false;
				ModalCollider.SetActive(this, active: false);
				listParent.Reposition();
			}
			if (DialogManager.DialogCount > 0)
			{
				if ((bool)purchaseModalCollider)
				{
					purchaseModalCollider.SetActive(value: true);
				}
			}
			else if ((bool)purchaseModalCollider)
			{
				purchaseModalCollider.SetActive(value: false);
			}
			if (!string.IsNullOrEmpty(initSelectName))
			{
				InitSelectStone();
				SetLastStone(lastStone);
				SetCurStone(curStone);
				initSelectName = null;
			}
			if ((bool)dragPanel && curSelItem != dragPanel.SelectObject)
			{
				SelectItem(dragPanel.SelectObject);
			}
		}
		else if (mode == Mode.Purchase)
		{
			if (flag)
			{
				ModalCollider.SetActive(this, active: true);
				if ((bool)purchaseModalCollider)
				{
					purchaseModalCollider.SetActive(value: true);
				}
			}
		}
		else if (mode == Mode.PurchaseComplete)
		{
			bool flag2 = false;
			if (PurchaseUtil.IsCompleteFinish())
			{
				MerlinServer.Request(new ApiPlayer(), _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(new _0024Update_0024closure_00242963(_0024Update_0024locals_0024, this).Invoke));
				mode = Mode.SelectList;
				RespInAppProduct respInAppProduct = GetRespInAppProduct(curProductId);
				if (respInAppProduct == null || (respInAppProduct != null && respInAppProduct.ProductSalesTypeValue == 1))
				{
					donwLoad = false;
					Download();
				}
			}
		}
		else if (mode == Mode.ErrorInit)
		{
			DialogManager.Open(MTexts.Msg("$STONE_LIST_NO_LIST_ERROR"), string.Empty);
			mode = Mode.Error;
			_0024Update_0024locals_0024._0024ServerBusy = false;
			bool flag3 = false;
			ModalCollider.SetActive(this, active: false);
		}
		else if (mode != Mode.Error)
		{
		}
	}

	private static void NotifyToPyxis(string productId, string price, string currency)
	{
		double num = 0.0;
		try
		{
			num = double.Parse(CacheButtonMessage._0024re_002424726.Replace(price, string.Empty));
		}
		catch (Exception)
		{
		}
		PyxisBridge.SendPaymentInfoToFuckPyxisService(num, 1);
		FacebookBridge.PurchaseByJPY((float)num);
	}

	public static string GetTransactionId(bool random)
	{
		return (!random) ? "hoge" : ("hoge" + UnityEngine.Random.Range(0f, 4E+09f));
	}

	public void PurchaseFinish(PurchaseUtil purchaseUtil)
	{
		PurchaseUtil.State state = default(PurchaseUtil.State);
		bool flag = default(bool);
		string transactionId = string.Empty;
		string receipt = string.Empty;
		string signature = string.Empty;
		DateTime purchaseDate = default(DateTime);
		switch (GetPurchaseResult(curProductId, ref transactionId, ref receipt, ref signature, ref purchaseDate))
		{
		case PurchaseUtil.State.Ok:
		{
			mode = Mode.SelectList;
			__MerlinServer_Request_0024callable86_0024160_56__ errorHandle = delegate
			{
				mode = Mode.SelectList;
				bool flag4 = false;
				ModalCollider.SetActive(this, active: false);
			};
			__MerlinServer_Request_0024callable86_0024160_56__ successHandle = delegate(RequestBase r)
			{
				if (r.IsOk)
				{
					mode = Mode.PurchaseComplete;
					bool flag3 = false;
					ModalCollider.SetActive(this, active: false);
				}
			};
			PurchaseVerify(curProductId, transactionId, receipt, signature, purchaseDate, stealth: false, successHandle, errorHandle);
			break;
		}
		case PurchaseUtil.State.Error:
		{
			DialogManager.Open(MTexts.Msg("$STONE_LIST_BUY_ERROR"), string.Empty);
			mode = Mode.SelectList;
			bool flag2 = false;
			ModalCollider.SetActive(this, active: false);
			break;
		}
		case PurchaseUtil.State.Suspend:
		{
			DialogManager.Open(MTexts.Msg("$STONE_LIST_BUY_SUSPEND"), string.Empty);
			mode = Mode.SelectList;
			bool flag2 = false;
			ModalCollider.SetActive(this, active: false);
			break;
		}
		}
	}

	public static void PurchaseSuspendFinish(PurchaseUtil purchaseUtil)
	{
		PurchaseUtil.State state = default(PurchaseUtil.State);
		bool flag = default(bool);
		string transactionId = string.Empty;
		string receipt = string.Empty;
		string signature = string.Empty;
		DateTime purchaseDate = default(DateTime);
		string productIdentifier = PurchaseUtil.purchaseResult.productIdentifier;
		state = GetPurchaseResult(productIdentifier, ref transactionId, ref receipt, ref signature, ref purchaseDate);
		if (state == PurchaseUtil.State.Ok)
		{
			__MerlinServer_Request_0024callable86_0024160_56__ errorHandle = delegate
			{
			};
			__MerlinServer_Request_0024callable86_0024160_56__ successHandle = delegate
			{
			};
			PurchaseVerify(productIdentifier, transactionId, receipt, signature, purchaseDate, stealth: true, successHandle, errorHandle);
		}
	}

	public static PurchaseUtil.State GetPurchaseResult(string productId, ref string transactionId, ref string receipt, ref string signature, ref DateTime purchaseDate)
	{
		PurchaseUtil.State state = default(PurchaseUtil.State);
		return PurchaseUtil.GetPurchaseResult(productId, ref transactionId, ref receipt, ref signature, ref purchaseDate);
	}

	public static void PurchaseVerify(string productId, string transactionId, string receipt, string signature, DateTime purchaseDate, bool stealth, __MerlinServer_Request_0024callable86_0024160_56__ successHandle, __MerlinServer_Request_0024callable86_0024160_56__ errorHandle)
	{
		_0024PurchaseVerify_0024locals_002414484 _0024PurchaseVerify_0024locals_0024 = new _0024PurchaseVerify_0024locals_002414484();
		_0024PurchaseVerify_0024locals_0024._0024transactionId = transactionId;
		_0024PurchaseVerify_0024locals_0024._0024stealth = stealth;
		_0024PurchaseVerify_0024locals_0024._0024successHandle = successHandle;
		_0024PurchaseVerify_0024locals_0024._0024errorHandle = errorHandle;
		string dstPrice = null;
		string currency = null;
		if (PurchaseUtil.IsEanbleProdcutEx(productId, ref dstPrice))
		{
			NotifyToPyxis(productId, dstPrice, currency);
		}
		__MerlinServer_Request_0024callable86_0024160_56__ errorHandler = new _0024PurchaseVerify_0024closure_00242969(_0024PurchaseVerify_0024locals_0024).Invoke;
		__MerlinServer_Request_0024callable86_0024160_56__ handler = new _0024PurchaseVerify_0024closure_00242970(_0024PurchaseVerify_0024locals_0024).Invoke;
		ApiPurchaseVerify apiPurchaseVerify = new ApiPurchaseVerify();
		apiPurchaseVerify.ProductId = productId;
		apiPurchaseVerify.Receipt = receipt;
		apiPurchaseVerify.Signature = signature;
		apiPurchaseVerify.TransactionId = _0024PurchaseVerify_0024locals_0024._0024transactionId;
		apiPurchaseVerify.PurchaseDate = purchaseDate;
		apiPurchaseVerify.ErrorHandler = errorHandler;
		if (_0024PurchaseVerify_0024locals_0024._0024stealth)
		{
			MerlinServer.StealthRequest(apiPurchaseVerify, handler);
		}
		else
		{
			MerlinServer.Request(apiPurchaseVerify, handler);
		}
	}

	public void PushBuy(string productId)
	{
		if (endFlag || mode != Mode.SelectList)
		{
			return;
		}
		ModalCollider.SetActive(this, active: true);
		curProductId = productId;
		if (true)
		{
			PurchaseUtil.Purchase(productId, PurchaseFinish);
			bool flag;
			if (PurchaseUtil.isPurchase)
			{
				flag = true;
				mode = Mode.Purchase;
				return;
			}
			DialogManager.Open(MTexts.Msg("$STONE_LIST_BUY_ERROR"), string.Empty);
			flag = false;
			mode = Mode.SelectList;
			ModalCollider.SetActive(this, active: false);
		}
	}

	public void PushCancel()
	{
		endFlag = true;
		if (OnEnd != null)
		{
			OnEnd(arg0: true);
		}
	}

	public void PushWeb()
	{
		if (MerlinServer.Busy)
		{
			return;
		}
		if (string.IsNullOrEmpty(infoHtml))
		{
			MerlinServer.Request(new ApiWebSpecificTrade(), delegate(RequestBase req)
			{
				infoHtml = req.Result;
				buyInformationWebView.OpenHtml(infoHtml, ServerURL.GameServerUrl("/"));
				if (!webViewPanel.active)
				{
					UIAutoTweenerStandAloneEx.In(webViewPanel);
				}
			});
		}
		else
		{
			buyInformationWebView.OpenHtml(infoHtml, ServerURL.GameServerUrl("/"));
			if (!webViewPanel.active)
			{
				UIAutoTweenerStandAloneEx.In(webViewPanel);
			}
		}
	}

	public void ShowCureApDialog()
	{
		ShowDialog(DIALOG_MODE.CureAp);
	}

	public void ShowCureRpDialog()
	{
		ShowDialog(DIALOG_MODE.CureRp);
	}

	public void ShowBuyStoneDialog()
	{
		ShowDialog(DIALOG_MODE.Buy);
	}

	public void ShowCureBpDialog()
	{
		ShowDialog(DIALOG_MODE.CureBp);
	}

	public void ShowDialog(DIALOG_MODE mode)
	{
		Download();
		if (mode == DIALOG_MODE.CureAp)
		{
			dlgMan.OpenDialog(MTexts.Msg("$STONE_LIST_AP_FULL"), MTexts.Msg("$STONE_LIST_NO_AP_TITLE"), DialogManager.MB_FLAG.MB_NONE, new string[2]
			{
				MTexts.Msg("exp_no"),
				MTexts.Msg("exp_yes")
			});
		}
		switch (mode)
		{
		case DIALOG_MODE.CureRp:
			dlgMan.OpenDialog(MTexts.Msg("$STONE_LIST_RP_FULL"), MTexts.Msg("$STONE_LIST_NO_RP_TITLE"), DialogManager.MB_FLAG.MB_NONE, new string[2]
			{
				MTexts.Msg("exp_no"),
				MTexts.Msg("exp_yes")
			});
			break;
		case DIALOG_MODE.Buy:
			dlgMan.OpenDialog(MTexts.Msg("$STONE_LSIT_BUY_STONE"), MTexts.Msg("$SS_RP_NO_STONE_TITLE"), DialogManager.MB_FLAG.MB_NONE, new string[2]
			{
				MTexts.Msg("exp_no"),
				MTexts.Msg("exp_yes")
			});
			break;
		case DIALOG_MODE.ApFix:
			dlgMan.OpenDialog(MTexts.Msg("$STONE_LIST_AP_FULL_RESULT"), string.Empty, DialogManager.MB_FLAG.MB_NONE, new string[1] { MTexts.Msg("exp_ok") });
			ApRpExp.CureApRp();
			break;
		case DIALOG_MODE.RpFix:
			dlgMan.OpenDialog(MTexts.Msg("$STONE_LIST_RP_FULL_RESULT"), string.Empty, DialogManager.MB_FLAG.MB_NONE, new string[1] { MTexts.Msg("exp_ok") });
			ApRpExp.CureApRp();
			break;
		case DIALOG_MODE.CureBp:
			dlgMan.OpenDialog(MTexts.Msg("$STONE_LIST_BP_FULL"), MTexts.Msg("$STONE_LIST_NO_BP_TITLE"), DialogManager.MB_FLAG.MB_NONE, new string[2]
			{
				MTexts.Msg("exp_no"),
				MTexts.Msg("exp_yes")
			});
			break;
		case DIALOG_MODE.BpFix:
			dlgMan.OpenDialog(MTexts.Msg("$STONE_LIST_BP_FULL_RESULT"), string.Empty, DialogManager.MB_FLAG.MB_NONE, new string[1] { MTexts.Msg("exp_ok") });
			ApRpExp.CureApRp();
			break;
		}
		DialogManager.InitLastResult = 0;
		dialogMode = mode;
	}

	private void RequestCure(RequestBase api, DIALOG_MODE fixMode)
	{
		_0024RequestCure_0024locals_002414485 _0024RequestCure_0024locals_0024 = new _0024RequestCure_0024locals_002414485();
		_0024RequestCure_0024locals_0024._0024fixMode = fixMode;
		if (DialogManager.LastResult == 2)
		{
			dlgMan.OnButton(0);
			UserData current = UserData.Current;
			if (0 < current.FayStone)
			{
				MerlinServer.Request(api, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__MerlinServer_Request_0024callable86_0024160_56___00244.Adapt(new _0024RequestCure_0024closure_00242972(_0024RequestCure_0024locals_0024, this).Invoke));
			}
			else
			{
				ShowDialog(DIALOG_MODE.Buy);
			}
		}
	}

	public bool IsDialogUpdating(UIMain uimain)
	{
		_0024IsDialogUpdating_0024locals_002414486 _0024IsDialogUpdating_0024locals_0024 = new _0024IsDialogUpdating_0024locals_002414486();
		_0024IsDialogUpdating_0024locals_0024._0024uimain = uimain;
		int result;
		if ((bool)_0024IsDialogUpdating_0024locals_0024._0024uimain && _0024IsDialogUpdating_0024locals_0024._0024uimain.IsChangingSituation)
		{
			result = 1;
		}
		else
		{
			if (dialogMode != 0)
			{
				if (dialogMode == DIALOG_MODE.CureAp)
				{
					RequestCure(new ApiUpdateActionPoint(), DIALOG_MODE.ApFix);
				}
				else if (dialogMode == DIALOG_MODE.CureRp)
				{
					RequestCure(new ApiUpdateRaidPoint(), DIALOG_MODE.RpFix);
				}
				else if (dialogMode == DIALOG_MODE.CureBp)
				{
					RequestCure(new ApiPlayerUpdateBattlePoint(), DIALOG_MODE.BpFix);
				}
				else if (dialogMode == DIALOG_MODE.Buy && DialogManager.LastResult == 2)
				{
					dlgMan.OnButton(0);
					if ((bool)_0024IsDialogUpdating_0024locals_0024._0024uimain)
					{
						_0024IsDialogUpdating_0024locals_0024._0024curSitu = _0024IsDialogUpdating_0024locals_0024._0024uimain.CurrentSituation;
						_0024IsDialogUpdating_0024locals_0024._0024uimain.ChangeSituation(Situation, wait_currSituation: true);
						if (OnEnd == null)
						{
							OnEnd = new _0024IsDialogUpdating_0024closure_00242974(_0024IsDialogUpdating_0024locals_0024).Invoke;
						}
					}
					else
					{
						gameObject.SetActive(value: true);
						if (destoryBackButton)
						{
							ButtonBackHUD.SetActive(setActive: true);
						}
						if (OnEnd == null)
						{
							OnEnd = delegate
							{
								Close();
								gameObject.SetActive(value: false);
								dialogMode = DIALOG_MODE.None;
							};
						}
					}
				}
				if (DialogManager.LastResult != 1 && !endFlag)
				{
					result = 1;
					goto IL_018f;
				}
				dlgMan.OnButton(0);
				endFlag = false;
				dialogMode = DIALOG_MODE.None;
				PushCancel();
			}
			result = 0;
		}
		goto IL_018f;
		IL_018f:
		return (byte)result != 0;
	}

	private void PushBack()
	{
		if (mode == Mode.Purchase || MerlinServer.Instance.IsBusy)
		{
			return;
		}
		if (webViewPanel.active)
		{
			if (!isClosing)
			{
				isClosing = true;
				UIAutoTweenerStandAloneEx.Out(webViewPanel, _0024adaptor_0024__ActionClassclearSuccMode_backMethod_0024callable19_0024384_63___0024__RuntimeAssetBundleDB_loadPrefab_0024callable4_0024227_61___0024172.Adapt(delegate
				{
					buyInformationWebView.Clear();
					WebViewBase.Visible(flag: false);
					isClosing = false;
				}));
			}
		}
		else
		{
			endFlag = true;
			if (OnEnd != null)
			{
				OnEnd(arg0: true);
			}
			dialogMode = DIALOG_MODE.None;
		}
	}

	public void OnGUI()
	{
	}

	internal static void _0024Create_0024closure_00242959(bool cancel)
	{
		stoneList.gameObject.SetActive(value: false);
	}

	internal void _0024Start_0024closure_00242960()
	{
		Download();
	}

	internal void _0024Download_0024closure_00242961(RequestBase req2)
	{
		Initialize((ApiPurchaseProductIdList)req2);
	}

	internal void _0024PurchaseFinish_0024closure_00242965(RequestBase r)
	{
		mode = Mode.SelectList;
		bool flag = false;
		ModalCollider.SetActive(this, active: false);
	}

	internal void _0024PurchaseFinish_0024closure_00242966(RequestBase r)
	{
		if (r.IsOk)
		{
			mode = Mode.PurchaseComplete;
			bool flag = false;
			ModalCollider.SetActive(this, active: false);
		}
	}

	internal static void _0024PurchaseSuspendFinish_0024closure_00242967(RequestBase r)
	{
	}

	internal static void _0024PurchaseSuspendFinish_0024closure_00242968(RequestBase r)
	{
	}

	internal void _0024PushWeb_0024closure_00242971(RequestBase req)
	{
		infoHtml = req.Result;
		buyInformationWebView.OpenHtml(infoHtml, ServerURL.GameServerUrl("/"));
		if (!webViewPanel.active)
		{
			UIAutoTweenerStandAloneEx.In(webViewPanel);
		}
	}

	internal void _0024IsDialogUpdating_0024closure_00242975(bool cancel)
	{
		Close();
		gameObject.SetActive(value: false);
		dialogMode = DIALOG_MODE.None;
	}

	internal void _0024PushBack_0024closure_00242976()
	{
		buyInformationWebView.Clear();
		WebViewBase.Visible(flag: false);
		isClosing = false;
	}
}
