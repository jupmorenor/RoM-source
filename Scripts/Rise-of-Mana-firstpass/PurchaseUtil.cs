using System;
using System.Collections;
using UnityEngine;

public class PurchaseUtil : MonoBehaviour
{
	public struct StoreGetItemListStr
	{
		public string cProcutsJson;
	}

	public struct StoreGetItemResultStr
	{
		public string productIdentifier;

		public string transactionIdentifier;

		public string transactionReceipt;

		public string transactionDate;

		public string signature;

		public int iState;

		public override string ToString()
		{
			string text = "{";
			text = text + "\"productIdentifier\" : \"" + productIdentifier + "\", ";
			text = text + "\"transactionIdentifier\" : \"" + transactionIdentifier + "\", ";
			text = text + "\"transactionReceipt\" : \"" + transactionReceipt + "\", ";
			text = text + "\"transactionDate\": \"" + transactionDate + "\", ";
			text = text + "\"signature\" : \"" + signature + "\", ";
			string text2 = text;
			text = text2 + "\"iState\" : \"" + iState + "\", ";
			return text + "}";
		}
	}

	public enum State
	{
		Suspend = -2,
		Error,
		None,
		Ok
	}

	public enum Mode
	{
		None,
		GetProducts,
		PrepareProducts,
		NowPurchase,
		NowRepare,
		Suspend
	}

	public delegate void PurchaseHandler(PurchaseUtil sender);

	private static AndroidJavaClass billingPlugin = null;

	private static PurchaseUtil _instance;

	private static bool startPurchase = false;

	private static bool enablePurchase = false;

	private static bool endPurchase = false;

	public static Mode mode = Mode.None;

	public static State purchaseState = State.None;

	public static PurchaseHandler PrepareEvent;

	public static PurchaseHandler IsProductsEvent;

	public static PurchaseHandler EndPurchaseEvent;

	public static PurchaseHandler EndSuspendPurchaseEvent;

	public static StoreGetItemResultStr purchaseResult = default(StoreGetItemResultStr);

	public static StoreGetItemListStr prodcutsList = default(StoreGetItemListStr);

	public static string productsListString;

	public static Hashtable productsListTable;

	public static string log;

	public bool debugFlag;

	public State debugPurchaseState = State.Ok;

	public State debugSuspendState;

	private static bool init = false;

	public static PurchaseUtil Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = UnityEngine.Object.FindObjectOfType(typeof(PurchaseUtil)) as PurchaseUtil;
				if (_instance == null)
				{
					GameObject gameObject = new GameObject("__PurchaseUtil__");
					_instance = gameObject.AddComponent<PurchaseUtil>();
				}
				UnityEngine.Object.DontDestroyOnLoad(_instance);
			}
			return _instance;
		}
	}

	public static bool isProducts => mode > Mode.PrepareProducts;

	public static bool isPurchase => mode == Mode.NowPurchase;

	private static bool DROID_StoreStartPurchase()
	{
		if (billingPlugin == null)
		{
			billingPlugin = new AndroidJavaClass("jp.co.goshow.merlin.billing.InAppBillingPlugin");
		}
		if (billingPlugin != null)
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject @static = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
			DebugLog("billingPlugin:" + billingPlugin);
			DebugLog("unityPlayer:" + androidJavaClass);
			DebugLog("activity:" + @static);
			return billingPlugin.CallStatic<bool>("StartInAppBilling", new object[1] { @static });
		}
		return false;
	}

	private static bool DROID_StoreIsEnablePurchase()
	{
		if (billingPlugin != null)
		{
			return billingPlugin.CallStatic<bool>("IsEnableInAppBilling", new object[0]);
		}
		return false;
	}

	private static bool DROID_StoreEndPurchase()
	{
		if (billingPlugin != null)
		{
			billingPlugin.CallStatic("EndInAppBilling");
			billingPlugin = null;
			return true;
		}
		return false;
	}

	private static bool DROID_StoreRequestItemList(string strProductsJson)
	{
		if (billingPlugin != null)
		{
			Hashtable hashtable = (Hashtable)NGUIJson.jsonDecode(strProductsJson);
			if (hashtable != null)
			{
				int count = hashtable.Count;
				string text = "{ products: [";
				int num = 0;
				foreach (Hashtable value in hashtable.Values)
				{
					if (value != null && value.ContainsKey("ProductIdCode"))
					{
						text = text + "\"" + value["ProductIdCode"].ToString() + "\",";
					}
				}
				text += "]}";
				billingPlugin.CallStatic("RequestPurchaseProductList", text);
				return true;
			}
		}
		return false;
	}

	private static int DROID_StoreGetItemList(ref StoreGetItemListStr data)
	{
		if (billingPlugin != null)
		{
			int num = billingPlugin.CallStatic<int>("GetLastResult", new object[0]);
			if (num != 0)
			{
				DebugLog(" DROID_StoreGetItemList res = " + num);
				if (billingPlugin.CallStatic<bool>("IsPurchaseProductList", new object[0]))
				{
					data.cProcutsJson = billingPlugin.CallStatic<string>("GetPurchaseProductList", new object[0]);
					return 1;
				}
				data.cProcutsJson = string.Empty;
			}
			return num;
		}
		return 0;
	}

	private static int DROID_StoreGetResult()
	{
		if (billingPlugin != null)
		{
			return billingPlugin.CallStatic<int>("GetLastResult", new object[0]);
		}
		return -1;
	}

	private static bool DROID_StorePurchaseProduct(string productId)
	{
		if (billingPlugin != null)
		{
			return billingPlugin.CallStatic<bool>("PurchaseProduct", new object[1] { productId });
		}
		return false;
	}

	private static int DROID_StoreGetPurchaseResult(ref StoreGetItemResultStr data)
	{
		if (billingPlugin != null)
		{
			int num = billingPlugin.CallStatic<int>("GetLastResult", new object[0]);
			if (num != 0 && billingPlugin.CallStatic<bool>("IsPurchaseProduct", new object[0]))
			{
				DebugLog(" DROID_StoreGetPurchaseResult res = " + num);
				string text = billingPlugin.CallStatic<string>("GetPurchaseProductJson", new object[0]);
				DebugLog(" json = " + text);
				string text2 = billingPlugin.CallStatic<string>("GetPurchaseProductSignature", new object[0]);
				DebugLog(" signature = " + text2);
				if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(text2))
				{
					Hashtable hashtable = (Hashtable)NGUIJson.jsonDecode(text);
					if (hashtable != null)
					{
						if (hashtable.ContainsKey("orderId"))
						{
							object obj = hashtable["orderId"];
							DebugLog(" tab[orderId] = " + obj);
							data.transactionIdentifier = obj.ToString();
						}
						data.transactionReceipt = text;
						if (hashtable.ContainsKey("purchaseTime"))
						{
							object obj2 = hashtable["purchaseTime"];
							DebugLog(" tab[purchaseTime] = " + obj2);
							long num2 = long.Parse(obj2.ToString());
							data.transactionDate = new DateTime(1970, 1, 1).AddMilliseconds(num2).ToString();
						}
						data.signature = text2;
						data.iState = num;
					}
				}
			}
			return num;
		}
		return -1;
	}

	private static int DROID_StoreCompletePurchase(string transactionId)
	{
		if (billingPlugin != null && billingPlugin.CallStatic<bool>("CompletePurchaseProduct", new object[1] { transactionId }))
		{
			return 0;
		}
		return -1;
	}

	private static bool DROID_StoreIsCompleteFinish()
	{
		if (billingPlugin != null)
		{
			return billingPlugin.CallStatic<bool>("IsCompleteFinish", new object[0]);
		}
		return false;
	}

	private static bool DROID_StoreIsRepairePurchase()
	{
		if (billingPlugin != null)
		{
			return billingPlugin.CallStatic<bool>("IsRepairePurchase", new object[0]);
		}
		return false;
	}

	private static int DROID_StoreGetRepaireItemResult(ref StoreGetItemResultStr data)
	{
		if (billingPlugin != null)
		{
			int num = -1;
			string text = billingPlugin.CallStatic<string>("GetRepaireItemResult", new object[0]);
			if (!string.IsNullOrEmpty(text))
			{
				Hashtable hashtable = (Hashtable)NGUIJson.jsonDecode(text);
				if (hashtable != null)
				{
					Hashtable hashtable2 = null;
					if (hashtable.ContainsKey("purchaseData"))
					{
						hashtable2 = (Hashtable)hashtable["purchaseData"];
					}
					if (hashtable2 != null && hashtable.ContainsKey("dataSignature"))
					{
						num = 1;
						string text2 = "{";
						if (hashtable2.ContainsKey("orderId"))
						{
							text2 = text2 + "\"orderId\":\"" + hashtable2["orderId"].ToString() + "\",";
						}
						if (hashtable2.ContainsKey("packageName"))
						{
							text2 = text2 + "\"packageName\":\"" + hashtable2["packageName"].ToString() + "\",";
						}
						if (hashtable2.ContainsKey("productId"))
						{
							text2 = text2 + "\"productId\":\"" + hashtable2["productId"].ToString() + "\",";
						}
						if (hashtable2.ContainsKey("purchaseTime"))
						{
							text2 = text2 + "\"purchaseTime\":" + hashtable2["purchaseTime"].ToString() + ",";
						}
						if (hashtable2.ContainsKey("purchaseState"))
						{
							text2 = text2 + "\"purchaseState\":" + hashtable2["purchaseState"].ToString() + ",";
						}
						if (hashtable2.ContainsKey("purchaseToken"))
						{
							text2 = text2 + "\"purchaseToken\":\"" + hashtable2["purchaseToken"].ToString() + "\"";
						}
						text2 += "}";
						data.transactionReceipt = text2;
						object obj = hashtable["dataSignature"];
						DebugLog(" tab[dataSignature] = " + obj);
						data.signature = obj.ToString();
						if (hashtable2.ContainsKey("productId"))
						{
							object obj2 = hashtable2["productId"];
							DebugLog(" tab[productId] = " + obj2);
							data.productIdentifier = obj2.ToString();
						}
						if (hashtable2.ContainsKey("orderId"))
						{
							object obj3 = hashtable2["orderId"];
							DebugLog(" tab[orderId] = " + obj3);
							data.transactionIdentifier = obj3.ToString();
						}
						if (hashtable2.ContainsKey("purchaseTime"))
						{
							object obj4 = hashtable2["purchaseTime"];
							DebugLog(" tab2[purchaseTime] = " + obj4);
							long num2 = long.Parse(obj4.ToString());
							data.transactionDate = new DateTime(1970, 1, 1).AddMilliseconds(num2).ToString();
						}
						data.iState = num;
					}
				}
			}
			return num;
		}
		return -1;
	}

	private static int DROID_StoreCompleteRepaireItemResult(int nResItemId)
	{
		if (billingPlugin != null && billingPlugin.CallStatic<bool>("CompletePurchaseProduct", new object[1] { nResItemId }))
		{
			return 0;
		}
		return -1;
	}

	private static void DebugLog(string s)
	{
		s += "\n";
		Debug.Log(s);
		log += s;
	}

	public static State GetState()
	{
		return (State)DROID_StoreGetResult();
	}

	public static bool StartPurchase(PurchaseHandler prepareFunc)
	{
		if (startPurchase)
		{
			prepareFunc?.Invoke(Instance);
			return true;
		}
		PurchaseUtil instance = Instance;
		startPurchase = false;
		enablePurchase = false;
		endPurchase = false;
		PrepareEvent = prepareFunc;
		mode = Mode.None;
		purchaseState = State.None;
		startPurchase = DROID_StoreStartPurchase();
		return startPurchase;
	}

	public static bool IsEnablePurchase()
	{
		enablePurchase = false;
		enablePurchase = DROID_StoreIsEnablePurchase();
		return enablePurchase;
	}

	public static void CheckPreparePurchase()
	{
		if (startPurchase && !enablePurchase)
		{
			IsEnablePurchase();
			if (enablePurchase && PrepareEvent != null)
			{
				PrepareEvent(Instance);
				PrepareEvent = null;
			}
		}
	}

	public static bool SetProductsList(string strProducts, PurchaseHandler callback)
	{
		DebugLog("SetProductsList");
		bool flag = false;
		IsProductsEvent = callback;
		mode = Mode.GetProducts;
		purchaseState = State.None;
		flag = DROID_StoreRequestItemList(strProducts);
		init = true;
		return flag;
	}

	public static bool CheckProductsList()
	{
		if (mode > Mode.GetProducts)
		{
			return true;
		}
		if (mode < Mode.GetProducts)
		{
			return false;
		}
		productsListTable = null;
		productsListString = string.Empty;
		bool flag = false;
		switch ((State)DROID_StoreGetItemList(ref prodcutsList))
		{
		case State.Ok:
			DebugLog("GetItemList OK");
			flag = true;
			if (!string.IsNullOrEmpty(prodcutsList.cProcutsJson))
			{
				DebugLog("prodcutsList.cProcutsJson = " + prodcutsList.cProcutsJson);
				productsListString = prodcutsList.cProcutsJson;
				productsListTable = (Hashtable)NGUIJson.jsonDecode(productsListString);
			}
			break;
		default:
			DebugLog("GetItemList NG");
			flag = true;
			break;
		case State.None:
			break;
		}
		if (productsListTable != null)
		{
			DebugLog("productsListTable =");
			foreach (string key in productsListTable.Keys)
			{
				DebugLog(" key = " + key);
				Hashtable hashtable = (Hashtable)productsListTable[key];
				if (hashtable != null)
				{
					foreach (string key2 in hashtable.Keys)
					{
						DebugLog("    [" + key2 + "] = " + hashtable[key2]);
					}
				}
				else
				{
					DebugLog("    vallue = " + (Hashtable)productsListTable[key]);
				}
			}
		}
		if (flag)
		{
			mode = Mode.PrepareProducts;
			if (IsProductsEvent != null)
			{
				DebugLog("IsProductsEvent = " + IsProductsEvent);
				IsProductsEvent(_instance);
				IsProductsEvent = null;
			}
		}
		return flag;
	}

	public static bool EndPurchase()
	{
		endPurchase = true;
		if (mode == Mode.Suspend)
		{
			return false;
		}
		DROID_StoreEndPurchase();
		init = false;
		mode = Mode.None;
		startPurchase = false;
		enablePurchase = false;
		endPurchase = false;
		return true;
	}

	public static bool IsEanbleProdcut(string strProductId)
	{
		if (mode < Mode.PrepareProducts)
		{
			return false;
		}
		if (productsListTable == null)
		{
			return false;
		}
		return productsListTable.ContainsKey(strProductId);
	}

	public static bool IsEanbleProdcutEx(string strProductId, ref string dstPrice)
	{
		bool flag = false;
		dstPrice = string.Empty;
		if (mode < Mode.PrepareProducts)
		{
			return false;
		}
		if (productsListTable == null)
		{
			return false;
		}
		if (productsListTable.ContainsKey(strProductId))
		{
			Hashtable hashtable = (Hashtable)productsListTable[strProductId];
			if (hashtable.ContainsKey("Price"))
			{
				dstPrice = (string)hashtable["Price"];
				DebugLog("IsEanbleProdcutEx new price " + dstPrice);
			}
			else if (hashtable.ContainsKey("price"))
			{
				dstPrice = (string)hashtable["price"];
				DebugLog("IsEanbleProdcutEx new price " + dstPrice);
			}
			flag = true;
		}
		DebugLog("IsEanbleProdcutEx : " + strProductId);
		DebugLog(" res = " + flag);
		DebugLog(" price : " + dstPrice);
		return flag;
	}

	public static bool GetProdcutPrice(string strProductId, ref string dstOriginalPrice, ref string dstCurrencyCode)
	{
		bool result = false;
		dstOriginalPrice = string.Empty;
		dstCurrencyCode = string.Empty;
		if (mode < Mode.PrepareProducts)
		{
			return false;
		}
		if (productsListTable == null)
		{
			return false;
		}
		if (productsListTable.ContainsKey(strProductId))
		{
			Hashtable hashtable = (Hashtable)productsListTable[strProductId];
			result = true;
			if (hashtable.ContainsKey("OriginalPrice"))
			{
				dstOriginalPrice = (string)hashtable["OriginalPrice"];
			}
			else
			{
				result = false;
			}
			if (hashtable.ContainsKey("CurrencyCode"))
			{
				dstCurrencyCode = (string)hashtable["CurrencyCode"];
			}
			else if (hashtable.ContainsKey("price_currency_code"))
			{
				dstCurrencyCode = (string)hashtable["price_currency_code"];
			}
			else
			{
				result = false;
			}
		}
		return result;
	}

	public static void Purchase(string puroductId, PurchaseHandler callback)
	{
		if (mode == Mode.PrepareProducts)
		{
			mode = Mode.NowPurchase;
			purchaseState = State.None;
			EndPurchaseEvent = callback;
			if (!DROID_StorePurchaseProduct(puroductId))
			{
				mode = Mode.PrepareProducts;
				purchaseState = State.Error;
			}
		}
	}

	public static bool CheckPurchaseFinish()
	{
		if (mode < Mode.NowPurchase)
		{
			return false;
		}
		bool flag = false;
		State state = State.None;
		state = ((!(null != _instance) || !_instance.debugFlag) ? ((State)DROID_StoreGetPurchaseResult(ref purchaseResult)) : _instance.debugPurchaseState);
		switch (state)
		{
		case State.Ok:
			flag = true;
			mode = Mode.PrepareProducts;
			purchaseState = state;
			DebugLog("StoreGetPurchaseResult  ok");
			break;
		case State.Suspend:
			flag = true;
			mode = Mode.PrepareProducts;
			purchaseState = state;
			DebugLog("StoreGetPurchaseResult suspend");
			break;
		default:
			flag = true;
			mode = Mode.PrepareProducts;
			purchaseState = state;
			DebugLog("StoreGetPurchaseResult ng");
			break;
		case State.None:
			break;
		}
		if (flag && EndPurchaseEvent != null)
		{
			DebugLog("EndPurchaseEvent = " + EndPurchaseEvent);
			EndPurchaseEvent(_instance);
			EndPurchaseEvent = null;
		}
		return flag;
	}

	public static bool CheckSuspendFinish()
	{
		if (mode < Mode.Suspend)
		{
			return false;
		}
		bool flag = false;
		State state = State.None;
		state = ((!(null != _instance) || !_instance.debugFlag) ? ((State)DROID_StoreGetPurchaseResult(ref purchaseResult)) : _instance.debugSuspendState);
		switch (state)
		{
		case State.Ok:
			flag = true;
			purchaseState = state;
			DebugLog("StoreGetPurchaseResult  ok");
			break;
		case State.Error:
			flag = true;
			purchaseState = state;
			DebugLog("StoreGetPurchaseResult ng");
			break;
		}
		if (flag)
		{
			mode = Mode.PrepareProducts;
			if (EndSuspendPurchaseEvent != null)
			{
				DebugLog("EndSuspendPurchaseEvent = " + EndSuspendPurchaseEvent);
				EndSuspendPurchaseEvent(_instance);
				EndSuspendPurchaseEvent = null;
			}
			if (endPurchase)
			{
				EndPurchase();
			}
		}
		return flag;
	}

	public static State GetPurchaseResult(string ProductId, ref string transactionId, ref string receipt, ref string signature, ref DateTime purchaseDate)
	{
		if (mode <= Mode.NowPurchase && purchaseState == State.None)
		{
			return State.Error;
		}
		receipt = string.Empty;
		signature = string.Empty;
		transactionId = string.Empty;
		purchaseDate = new DateTime(0L);
		if (purchaseState == State.Ok)
		{
			DebugLog("purchaseResult = " + purchaseResult);
			receipt = purchaseResult.transactionReceipt;
			signature = purchaseResult.signature;
			transactionId = purchaseResult.transactionIdentifier;
			DateTime.TryParse(purchaseResult.transactionDate, out purchaseDate);
		}
		return purchaseState;
	}

	public static void CompletePurchase(string transactionId)
	{
		DROID_StoreCompletePurchase(transactionId);
	}

	public static bool IsCompleteFinish()
	{
		bool flag = false;
		return DROID_StoreIsCompleteFinish();
	}

	public static State GetRepareResult(ref string productId, ref string transactionId, ref string receipt, ref string signature, ref DateTime purchaseDate)
	{
		if (mode != Mode.PrepareProducts)
		{
			return State.None;
		}
		productId = string.Empty;
		receipt = string.Empty;
		signature = string.Empty;
		transactionId = string.Empty;
		purchaseDate = new DateTime(0L);
		State state = State.None;
		if (!DROID_StoreIsRepairePurchase())
		{
			DebugLog("DROID_StoreIsRepairePurchase : no repeare Item");
			return State.None;
		}
		state = (State)DROID_StoreGetRepaireItemResult(ref purchaseResult);
		if (state == State.Ok)
		{
			productId = purchaseResult.productIdentifier;
			receipt = purchaseResult.transactionReceipt;
			signature = purchaseResult.signature;
			transactionId = purchaseResult.transactionIdentifier;
			DateTime.TryParse(purchaseResult.transactionDate, out purchaseDate);
			purchaseState = state;
		}
		return purchaseState;
	}

	public static void UpdatePurchase()
	{
		if (!init)
		{
			CheckPreparePurchase();
			return;
		}
		switch (mode)
		{
		case Mode.GetProducts:
			CheckProductsList();
			break;
		case Mode.NowPurchase:
			CheckPurchaseFinish();
			break;
		case Mode.Suspend:
			CheckSuspendFinish();
			break;
		case Mode.PrepareProducts:
		case Mode.NowRepare:
			break;
		}
	}

	private void Start()
	{
		debugFlag = false;
	}

	private void Update()
	{
		if (startPurchase)
		{
			UpdatePurchase();
		}
	}

	private void OnApplicationQuit()
	{
		EndPurchase();
	}
}
